using UnityEngine;
using UnityEngine.Events;

namespace InfinityGameTable.Settings
{
    public class Settings : MonoBehaviour
    {
        [Header("Show/Hide Settings Menu Events")]
        [Tooltip("The events(s) invoked when the settings menu is shown, consider pausing your game")]
        public UnityEvent onShowSettingsMenu;
        [Tooltip("The events(s) invoked when the settings menu is hidden, consider resuming your game")]
        public UnityEvent onHideSettingsMenu;

        [Header("Home Button Event")]
        [Tooltip("The event(s) invoked when the Home button is clicked")]
        public UnityEvent onGoHome;

        [Header("SFX Button Events")]
        [Tooltip("The event(s) invoked when the SFX Button is clicked (optionally, you may add listeners to the enable/disable events instead)")]
        public UnityEvent onToggleSFX;
        [Tooltip("The event(s) invoked when SFX becomes enabled by clicking the SFX Button")]
        public UnityEvent onEnableSFX;
        [Tooltip("The event(s) invoked when SFX becomes disabled by clicking the SFX Button")]
        public UnityEvent onDisableSFX;

        [Header("Music Button Events")]
        [Tooltip("The event(s) invoked when the Music button is clicked (optionally, you may add listeners to the enable/disable events instead)")]
        public UnityEvent onToggleMusic;
        [Tooltip("The event(s) invoked when Music becomes enabled by clicking the Music Button")]
        public UnityEvent onEnableMusic;
        [Tooltip("The event(s) invoked when Music becomes disabled by clicking the Music Button")]
        public UnityEvent onDisableMusic;

        private SettingsController settingsController;

        private void Awake()
        {
            settingsController = GetComponentInChildren<SettingsController>();
            if (!settingsController) throw new System.Exception($"Missing Settings Controller in children for {gameObject.name}");
        }
    }
}
