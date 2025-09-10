using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using Il2CppTMPro;
using MelonLoader;
using UnityEngine;

namespace AncientMonkey.UI {
    [RegisterTypeInIl2Cpp]
    public class TextSmoothing : MonoBehaviour {
        private ModHelperText text;
        private float currentValue;
        private float targetValue;
        private float smoothSpeed = 5f;
        private string beforeText;
        private string afterText;
        private bool useNumAb;

        public TextSmoothing() : base() { }

        public void Init(ModHelperText text, int currentValue, float smoothSpeed = 5f, string beforeText = "", string afterText = "", bool useNumAb = false) {
         
            this.text = text;
            this.currentValue = currentValue;
            this.targetValue = currentValue;
            this.smoothSpeed = smoothSpeed;
            this.beforeText = beforeText;
            this.afterText = afterText;
            this.useNumAb = useNumAb;
        }

        public void SetTarget(float value) {
            this.targetValue = value;
        }

        private void Update() {
            if (text == null) return;


            currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * smoothSpeed);

            if (Mathf.Abs(currentValue - targetValue) < 0.01f) {
                currentValue = targetValue;
            }
            if (useNumAb) {
                text.Text.text = beforeText + TextManager.ConvertNumberToText(Mathf.RoundToInt(currentValue)) + afterText;
            } else {
                text.Text.text = beforeText + Mathf.RoundToInt(currentValue).ToString() + afterText;
            }
          
        }
    }
}
