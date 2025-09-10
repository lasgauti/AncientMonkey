using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using MelonLoader;
using UnityEngine;
using UnityEngine.UIElements;

namespace AncientMonkey.UI {
    [RegisterTypeInIl2Cpp]
    public class BarSmoothing : MonoBehaviour {
        public UnityEngine.UI.Slider slider;
        public float targetValue;
        public float smoothSpeed = 5f;

        public BarSmoothing() : base() {

        }
        public void Init(UnityEngine.UI.Slider slider) {
            this.slider = slider;
        }
        public void SetTarget(int value) {
            this.targetValue = value;
        }
        public void Update() {
            if (slider == null) return;

            slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * smoothSpeed);
            if (Mathf.Abs(slider.value - targetValue) < 0.01f)
                slider.value = targetValue;
        }
    }
}
