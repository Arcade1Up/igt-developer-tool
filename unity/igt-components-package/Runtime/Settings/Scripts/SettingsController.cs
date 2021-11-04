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
        public Settings config;

        private bool isVibrationEnabled = true;
        private bool isSFXEnabled = true;
        private bool isMusicEnabled = true;

        void Awake()
        {
            config = GetComponentInParent<Settings>();
            if (!config) throw new System.Exception($"Missing Settings component on parent of {gameObject.name}");

            if (!settingsButton) throw new System.Exception($"Missing Settings Button for {gameObject.name}");
            if (!settingsPanel) throw new System.Exception($"Missing Settings Panel game object for {gameObject.name}");
            if (!howToPlayPanel) throw new System.Exception($"Missing How To Play Panel game object for {gameObject.name}");
            if (!vibrationButton) throw new System.Exception($"Missing Vibration Button for {gameObject.name}");
            if (!sfxButton) throw new System.Exception($"Missing SFX Button for {gameObject.name}");
            if (!musicButton) throw new System.Exception($"Missing Music Button for {gameObject.name}");

            settingsPanel.SetActive(false);
            howToPlayPanel.SetActive(false);

            versionLabel.text = $"V{Application.version}";
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
                config.onShowSettingsMenu.Invoke();
            }
            else
            {
                config.onHideSettingsMenu.Invoke();
            }
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
            InfinityGameTableHelper.QuitToDashboard();
        }

        public void ToggleVibration()
        {
            config.onToggleVibration.Invoke();
            isVibrationEnabled = !isVibrationEnabled;
            if (isVibrationEnabled)
            {
                config.onEnableVibration.Invoke();
            }
            else
            {
                config.onDisableVibration.Invoke();
            }
            vibrationButton.SetOn(isVibrationEnabled);

            if (isVibrationEnabled)
            {
                InfinityGameTableHelper.Rumble(100);
            }
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
