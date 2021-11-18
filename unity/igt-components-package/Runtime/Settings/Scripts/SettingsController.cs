using UnityEngine;
using UnityEngine.UI;

namespace InfinityGameTable.Settings
{
    public class SettingsController : MonoBehaviour
    {
        [Header("In Game Components")]
        [Tooltip("The button used to activate the Settings Panel")]
        public Button settingsButton;

        [Header("Settings Panels")]
        [Tooltip("The panel activated when the Settings Button is clicked")]
        public GameObject settingsPanel;
        [Tooltip("The text component used for displaying the application version number")]
        public Text versionLabel;
        [Tooltip("The panel activated when the How to Play button is clicked")]
        public GameObject howToPlayPanel;

        [Header("Settings Menu Toggle Buttons")]
        [Tooltip("The Vibration button, so that it's state can be toggled on/off")]
        public ToggleButtonExtension vibrationButton;
        [Tooltip("The SFX button, so that it's state can be toggled on/off")]
        public ToggleButtonExtension sfxButton;
        [Tooltip("The Music button, so that it's state can be toggled on/off")]
        public ToggleButtonExtension musicButton;

        [HideInInspector]
        public Settings settingsConfig;

        private string isVibrationEnabledKey = "isVibrationEnabled";
        private bool isVibrationEnabled
        {
            get
            {
                return PlayerPrefs.GetInt(isVibrationEnabledKey, 1) == 1;
            }

            set
            {
                PlayerPrefs.SetInt(isVibrationEnabledKey, value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        private string isSFXEnabledKey = "isSFXEnabled";
        private bool isSFXEnabled
        {
            get
            {
                return PlayerPrefs.GetInt(isSFXEnabledKey, 1) == 1;
            }

            set
            {
                PlayerPrefs.SetInt(isSFXEnabledKey, value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        private string isMusicEnabledKey = "isMusicEnabled";
        private bool isMusicEnabled
        {
            get
            {
                return PlayerPrefs.GetInt(isMusicEnabledKey, 1) == 1;
            }

            set
            {
                PlayerPrefs.SetInt(isMusicEnabledKey, value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        void Start()
        {
            settingsConfig = GetComponentInParent<Settings>();
            if (!settingsConfig) throw new System.Exception($"Missing Settings component on parent of {gameObject.name}");

            if (!settingsButton) throw new System.Exception($"Missing Settings Button for {gameObject.name}");
            if (!settingsPanel) throw new System.Exception($"Missing Settings Panel game object for {gameObject.name}");
            if (!howToPlayPanel) throw new System.Exception($"Missing How To Play Panel game object for {gameObject.name}");
            if (!vibrationButton) throw new System.Exception($"Missing Vibration Button for {gameObject.name}");
            if (!sfxButton) throw new System.Exception($"Missing SFX Button for {gameObject.name}");
            if (!musicButton) throw new System.Exception($"Missing Music Button for {gameObject.name}");

            settingsPanel.SetActive(false);
            howToPlayPanel.SetActive(false);

            versionLabel.text = $"v{Application.version}";

            // Load values from PlayerPrefs
            SetVibration(isVibrationEnabled);
            SetSFX(isSFXEnabled);
            SetMusic(isMusicEnabled);
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

            if (settingsPanel.activeInHierarchy)
            {
                settingsConfig.onShowSettingsMenu.Invoke();
            }
            else
            {
                settingsConfig.onHideSettingsMenu.Invoke();
            }
        }

        public void GoHome()
        {
            settingsConfig.onGoHome.Invoke();
            SetSettingsPanelActive(false);
        }

        public void ToggleHowToPlayPanelActive()
        {
            howToPlayPanel.SetActive(!howToPlayPanel.activeInHierarchy);
        }

        public void GoDashboard()
        {
            InfinityGameTableHelper.QuitToDashboard();
        }

        public void ToggleVibration()
        {
            settingsConfig.onToggleVibration.Invoke();
            SetVibration(!isVibrationEnabled);

            if (isVibrationEnabled)
            {
                InfinityGameTableHelper.Rumble(100);
            }
        }

        public void ToggleSFX()
        {
            settingsConfig.onToggleSFX.Invoke();
            SetSFX(!isSFXEnabled);
        }

        public void ToggleMusic()
        {
            settingsConfig.onToggleMusic.Invoke();
            SetMusic(!isMusicEnabled);
        }

        private void SetVibration(bool isEnabled)
        {
            isVibrationEnabled = isEnabled;
            if (isEnabled)
            {
                settingsConfig.onEnableVibration.Invoke();
            }
            else
            {
                settingsConfig.onDisableVibration.Invoke();
            }
            vibrationButton.SetOn(isEnabled);
        }

        private void SetSFX(bool isEnabled)
        {
            isSFXEnabled = isEnabled;
            if (isEnabled)
            {
                settingsConfig.onEnableSFX.Invoke();
            }
            else
            {
                settingsConfig.onDisableSFX.Invoke();
            }
            sfxButton.SetOn(isEnabled);
        }

        private void SetMusic(bool isEnabled)
        {
            isMusicEnabled = isEnabled;
            if (isEnabled)
            {
                settingsConfig.onEnableMusic.Invoke();
            }
            else
            {
                settingsConfig.onDisableMusic.Invoke();
            }
            musicButton.SetOn(isEnabled);
        }
    }
}
