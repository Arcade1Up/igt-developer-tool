using UnityEngine;
using UnityEngine.UI;

namespace IGT.Settings
{
    public class SettingsController : MonoBehaviour
    {
        [Header("In Game Components")]
        [Tooltip("The button used to activate the Settings Panel")]
        public Button settingsButton;

        [Header("Settings Panels")]
        [Tooltip("The panel activated when the Settings Button is clicked")]
        public GameObject settingsPanel;
        [Tooltip("The panel activated when the How to Play button is clicked")]
        public GameObject howToPlayPanel;

        [Header("Settings Menu Toggle Buttons")]
        [Tooltip("The SFX button, so that it's state can be toggled on/off")]
        public ToggleButtonExtension sfxButton;
        [Tooltip("The Music button, so that it's state can be toggled on/off")]
        public ToggleButtonExtension musicButton;

        [HideInInspector]
        public Settings config;

        private bool isSFXEnabled = true;
        private bool isMusicEnabled = true;

        void Awake()
        {
            config = GetComponentInParent<Settings>();
            if (!config) throw new System.Exception($"Missing Settings component on parent of {gameObject.name}");

            if (!settingsButton) throw new System.Exception($"Missing Settings Button for {gameObject.name}");
            if (!settingsPanel) throw new System.Exception($"Missing Settings Panel game object for {gameObject.name}");
            if (!howToPlayPanel) throw new System.Exception($"Missing How To Play Panel game object for {gameObject.name}");
            if (!sfxButton) throw new System.Exception($"Missing SFX Button for {gameObject.name}");
            if (!musicButton) throw new System.Exception($"Missing Music Button for {gameObject.name}");
        }

        public void ToggleSettingsPanelActive()
        {
            settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
            UpdateSettingsButtonActive();
        }

        public void SetSettingsPanelActive(bool value)
        {
            settingsPanel.SetActive(value);
            UpdateSettingsButtonActive();
        }

        private void UpdateSettingsButtonActive()
        {
            settingsButton.gameObject.SetActive(!settingsPanel.activeInHierarchy);
        }

        public void GoHome()
        {
            config.onGoHome.Invoke();
            SetSettingsPanelActive(false);
        }

        public void ToggleHowToPlayPanelActive()
        {
            howToPlayPanel.SetActive(!howToPlayPanel.activeInHierarchy);
        }

        public void GoDashboard()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call("finish");
                Application.Quit();
            #endif
        }

        public void ToggleSFX()
        {
            config.onToggleSFX.Invoke();
            isSFXEnabled = !isSFXEnabled;
            if (isSFXEnabled)
            {
                config.onEnableSFX.Invoke();
            }
            else
            {
                config.onDisableSFX.Invoke();
            }
            sfxButton.SetOn(isSFXEnabled);
        }

        public void ToggleMusic()
        {
            config.onToggleMusic.Invoke();
            isMusicEnabled = !isMusicEnabled;
            if (isMusicEnabled)
            {
                config.onEnableMusic.Invoke();
            }
            else
            {
                config.onDisableMusic.Invoke();
            }
            musicButton.SetOn(isMusicEnabled);
        }
    }
}
