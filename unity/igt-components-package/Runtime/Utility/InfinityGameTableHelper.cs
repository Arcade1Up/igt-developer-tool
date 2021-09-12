using UnityEngine;

namespace InfinityGameTable
{
    public class InfinityGameTableHelper
    {
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
    }

}
