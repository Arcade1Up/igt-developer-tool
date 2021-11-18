using UnityEngine;
using UnityEngine.UI;

namespace InfinityGameTable.Settings
{
    public class ToggleButtonExtension : MonoBehaviour
    {
        public Image image;
        public Text label;
        public Color onColor;
        public Color offColor;
        
        private bool isOn = true;

        private void Awake()
        {
            if (!image) throw new System.Exception($"Missing Image for {gameObject.name}");
            if (!label) throw new System.Exception($"Missing Label for {gameObject.name}");

            UpdateDisplay();
        }

        public void Toggle()
        {
            this.isOn = !this.isOn;
            UpdateDisplay();
        }

        public void SetOn(bool value)
        {
            this.isOn = value;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            image.color = this.isOn ? onColor : offColor;
            label.color = this.isOn ? onColor : offColor;
        }
    }
}
