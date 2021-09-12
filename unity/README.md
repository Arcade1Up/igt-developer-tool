# THE INFINITY GAME TABLE Developer Tools

## Unity Tips & Tricks

This page is intended to help developers to get started on games development on The Infinity Game Table using Unity.
To help with common development needs, there is a community built [igt-components package](./igt-components-package) for Unity in this repository.

## Debugging From Unity / Visual Studio

### Steps to install games directly from within Unity

1. Enable USB Debugging on the table
   - Follow steps provided by <a href="https://arcade1up.com/">Arcade1Up™</a> for accessing the Android launcher on table
   - Go to `Settings` > `About tablet` and tap on `Build number` 7 times
   - Return to `Settings` > "System" > `Developer Options`
     - Enable `Debugging` > `USB debugging`
   - Return to `Settings` > `USB Mode`
     - Change to `OTG` > `Device Mode`
2. Connect USB cable to USB port closest to TF card port
3. Verify you can see the IGT from Windows
   - Launch Windows Explorer and browse to Android SDK platform-tools folder
     - Ex: `C:\Users\<username>\AppData\Local\Android\Sdk\platform-tools`
   - Right-click in Windows Explorer and open in any of Command Prompt | Windows Terminal | Power Shell
   - Run `adb devices` and verify `IGT***********` device is attached
   - May encounter an error that server and client versions do not match
     - Can resolve this by going into `Android Studio` > `Configure` > `SDK Manager` > `SDK Tools` and updating the packages that have available updates
4. After this step, return to Unity and run `File` > `Build and Run` to build the game, deploy it to the table, and automatically launch it on the device

### Steps to debug games running on IGT from within Unity

1. In Unity, go to `File` > `Build Settings…` > `Android` and enable the following:
   - `Development Build`
   - `Script Debugging`
2. Build and deploy a new build of the game (`File` > `Build and Run`)
   - This may prompt to turn on Debug Mode within Unity, this will recompile the game again in debug mode
3. After debug version of game is deployed and running on device, switch to Visual Studio
4. In Visual Studio, launch debugger via `Debug` > `Attach Unity Debugger`
5. Select Unity instance that is running on the table (machine name starts with `rockchip`)
6. After doing this once, you can change the debug drop-down menu in Unity to point directly to this device for quicker access
7. Set a breakpoint in your code and interact with your game until hitting the breakpoint and game should pause on device and you can access debugging within Visual Studio

## Sample Code Snippets

These features are available via the `InfinityGameTableHelper` script within the [igt-components package](./igt-components-package), but the code is provided here for convenience if you wish to perform these actions without installing the components package.

### Exit Game

The following code snippet may be used to cause Unity to exit play mode while in the Unity editor, but to also quit a game and return to the dashboard when running on the IGT:

```
public static void QuitToDashboard()
{
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_ANDROID
        using (var activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("finish");
        }
    #endif
    Application.Quit();
}
```

### Rumble Motor

The following code snippet may be used to cause the IGT Rumble Motor to trigger for a specified duration (in milliseconds):

NOTE: You must first copy the file [igtsdk.aar](./igt-components-package/Runtime/lib/igtsdk.aar) to your Unity project's `Assets` folder.

```
    public static void Rumble(int durationInMs)
    {
        #if UNITY_EDITOR
            Debug.Log($"Infinity Game Table: Rumble ({durationInMs}ms)");
        #elif UNITY_ANDROID
            using (var igtMotor = new AndroidJavaClass("com.arcade1up.igtsdk.IGTMotor"))
            {
                igtMotor.CallStatic("rumble", durationInMs);
            }
        #endif
    }
```
