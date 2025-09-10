using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AncientMonkey.UI;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New;
using Octokit;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Il2CppSystem.Linq.Expressions.Interpreter.CastInstruction.CastInstructionNoT;

namespace AncientMonkey.Helper {
    public static class UIHelper {
        public static ModHelperButton CreateButton(ModHelperPanel panel, TransformConfig transformConfig, SpriteConfig spriteConfig, ActionConfig actionConfig) {
            ModHelperButton upgradeExtraLevel = panel.AddButton(new Info("upgradeExtraLevel", -980, -50, 525, 145), VanillaSprites.GreenBtnLong, null);
            return upgradeExtraLevel;
        }
        public static ModHelperButton CreateButtonOption(bool value, ModHelperPanel panel, TransformConfig transformConfig, SpriteConfig spriteConfig, ActionConfig actionConfig, ButtonOptionConfig falseButton) {
            ModHelperButton upgradeExtraLevel = panel.AddButton(new Info("upgradeExtraLevel", -980, -50, 525, 145), VanillaSprites.GreenBtnLong, null);
            return upgradeExtraLevel;
        }
        public static TextButton CreateTextButton(ModHelperPanel panel, TransformConfig transformConfig, SpriteConfig spriteConfig, ActionConfig actionConfig , TextConfig textConfig) {
            ModHelperButton button;
            ModHelperText text;

            button = panel.AddButton(new Info("Button", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize, transformConfig.ySize), spriteConfig.sprite, null);
            text = button.AddText(new Info("Text", 0, 0, transformConfig.xSize, transformConfig.ySize), textConfig.text, textConfig.fontSize);

            TextButton textButton = new TextButton(
               button,
               text,
               panel,
               transformConfig,
               spriteConfig,
               textConfig,
               actionConfig
           );

            button.Button.SetOnClick(() =>
            {
                textButton.actionConfig?.action?.DynamicInvoke(textButton.actionConfig.parameters);
            });

            return textButton;
        }
        public static TextSlider CreateTextSlider(ModHelperPanel panel, SliderConfig sliderConfig, SliderOffsetConfig sliderOffsetConfig, TransformConfig transformConfig, SpriteConfig backgroundSprite, SpriteConfig barSprite, TextConfig textConfig) {
         
            ModHelperPanel sliderPanel = panel.AddPanel(new Info("slider", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize - sliderOffsetConfig.xScaleOffset, transformConfig.ySize - sliderOffsetConfig.yScaleOffset), backgroundSprite.sprite);
            ModHelperPanel background = sliderPanel.AddPanel(new Info("background", 0, 0, transformConfig.xSize, transformConfig.ySize), backgroundSprite.sprite);
            ModHelperPanel fillRect = background.AddPanel(new Info("fillRect", 0, 0, -sliderOffsetConfig.xScaleOffset, -sliderOffsetConfig.yScaleOffset), barSprite.sprite);
            ModHelperText text;
            if (textConfig.useNumberSmoothing) {
                text = background.AddText(new Info("text", 0, 0, transformConfig.xSize, transformConfig.ySize), textConfig.beforeText + textConfig.textNumber + textConfig.afterText, textConfig.fontSize);
            } else {
                text = background.AddText(new Info("text", 0, 0, transformConfig.xSize, transformConfig.ySize), textConfig.text, textConfig.fontSize);
            }
            UnityEngine.UI.Slider slider = background.AddComponent<UnityEngine.UI.Slider>();
            slider.transition = Selectable.Transition.None;
            slider.fillRect = fillRect.RectTransform;
            slider.interactable = false;
            slider.value = sliderConfig.minValue;
            slider.maxValue = sliderConfig.maxValue;
            BarSmoothing barSmoothing = background.AddComponent<BarSmoothing>();
            TextSmoothing textSmoothing = text.AddComponent<TextSmoothing>();
            if (sliderConfig.useSmoothing) {
                barSmoothing.Init(slider);
                barSmoothing.SetTarget(sliderConfig.minValue);
            }
            if (textConfig.useNumberSmoothing) {
                textSmoothing.Init(text, textConfig.textNumber, 5, textConfig.beforeText, textConfig.afterText);
            }
            return new TextSlider(panel, sliderPanel, background, fillRect, text, slider, barSmoothing, sliderConfig, sliderOffsetConfig, transformConfig, backgroundSprite, barSprite, textConfig, textSmoothing);
        }
        public static TextButtonOption CreateTextButtonOption(bool value,ModHelperPanel panel,TransformConfig transformConfig,SpriteConfig spriteConfig,TextConfig textConfig,ActionConfig actionConfig,TextButtonOptionConfig falseButton) {
            ModHelperButton button;
            ModHelperText text;

            if (value) {
                button = panel.AddButton(new Info("Button", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize, transformConfig.ySize), spriteConfig.sprite, null);
                text = button.AddText(new Info("Text", 0, 0, transformConfig.xSize, transformConfig.ySize), textConfig.text, textConfig.fontSize);
               
            }
            else {
                button = panel.AddButton(new Info("Button", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize, transformConfig.ySize), falseButton.spriteConfig.sprite, null);
                text = button.AddText(new Info("Text", 0, 0, transformConfig.xSize, transformConfig.ySize), falseButton.textConfig.text, falseButton.textConfig.fontSize);
                
            }
            TextButtonOption textButton = new TextButtonOption(
                button,
                text,
                panel,
                transformConfig,
                spriteConfig,
                textConfig,
                actionConfig,
                falseButton,
                value
            );
            if (value) {
                button.Button.SetOnClick(() =>
                {
                    textButton.actionConfig?.action?.DynamicInvoke(textButton.actionConfig.parameters);
                });
            } else {
                button.Button.SetOnClick(() =>
                {
                    textButton.falseButtonConfig.actionConfig?.action?.DynamicInvoke(textButton.falseButtonConfig.actionConfig.parameters);
                });
            }

            return textButton;
        }
    }
    public class Slider {
        public ModHelperPanel panel;
        public ModHelperPanel sliderPanel;
        public ModHelperPanel background;
        public ModHelperPanel fillRect;
        public UnityEngine.UI.Slider slider;
        public BarSmoothing barSmoothing;
        public SliderConfig sliderConfig;
        public SliderOffsetConfig sliderOffsetConfig;
        public TransformConfig transformConfig;
        public SpriteConfig backgroundSpriteConfig;
        public SpriteConfig barSpriteConfig;

        public Slider(ModHelperPanel panel, ModHelperPanel sliderPanel, ModHelperPanel background, ModHelperPanel fillRect, UnityEngine.UI.Slider slider, BarSmoothing barSmoothing,
            SliderConfig sliderConfig, SliderOffsetConfig sliderOffsetConfig, TransformConfig transformConfig, SpriteConfig backgroundSpriteConfig, SpriteConfig barSpriteConfig) {
            this.panel = panel;
            this.sliderPanel = sliderPanel;
            this.background = background;
            this.fillRect = fillRect;
            this.slider = slider;
            this.barSmoothing = barSmoothing;
            this.sliderConfig = sliderConfig;
            this.sliderOffsetConfig = sliderOffsetConfig;
            this.transformConfig = transformConfig;
            this.backgroundSpriteConfig = backgroundSpriteConfig;
            this.barSpriteConfig = barSpriteConfig;

        }
    }
    public class TextSlider: Slider {
        public TextConfig textConfig;
        public ModHelperText text;
        public TextSmoothing textSmoothing;
        public TextSlider(ModHelperPanel panel, ModHelperPanel sliderPanel, ModHelperPanel background, ModHelperPanel fillRect, ModHelperText text, UnityEngine.UI.Slider slider, BarSmoothing barSmoothing,
            SliderConfig sliderConfig, SliderOffsetConfig sliderOffsetConfig, TransformConfig transformConfig, SpriteConfig backgroundSpriteConfig, SpriteConfig barSpriteConfig, TextConfig textConfig, TextSmoothing textSmoothing) : 
            base(panel,sliderPanel,background,fillRect,slider,barSmoothing,sliderConfig,sliderOffsetConfig,transformConfig,backgroundSpriteConfig,barSpriteConfig){
            this.panel = panel;
            this.sliderPanel = sliderPanel;
            this.background = background;
            this.fillRect = fillRect;
            this.text = text;
            this.slider = slider;
            this.barSmoothing = barSmoothing;
            this.sliderConfig = sliderConfig;
            this.sliderOffsetConfig = sliderOffsetConfig;
            this.transformConfig = transformConfig;
            this.backgroundSpriteConfig = backgroundSpriteConfig;
            this.barSpriteConfig = barSpriteConfig;
            this.textConfig = textConfig;   
            this.textSmoothing = textSmoothing;
        }
    }
    public class SliderConfig {
        public int minValue;
        public int maxValue;
        public bool useSmoothing;
        public SliderConfig(int minValue, int maxValue, bool useSmoothing) {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.useSmoothing = useSmoothing;
        }
    }
    public class SliderOffsetConfig {
        public int xScaleOffset;
        public int yScaleOffset;
        public SliderOffsetConfig(Vector2 scaleOffset) {
            this.xScaleOffset = Mathf.RoundToInt(scaleOffset.x);
            this.yScaleOffset = Mathf.RoundToInt(scaleOffset.y);
        }
    }
    public class Button {
        public ModHelperButton? button;
        public ModHelperPanel panel;

        public TransformConfig transformConfig;
        public SpriteConfig spriteConfig;
        public ActionConfig actionConfig;

        public void SetAction(ActionConfig actionConfig) {
            this.actionConfig = actionConfig;
        }
        public Button(ModHelperButton button, ModHelperPanel panel, TransformConfig transformConfig, SpriteConfig spriteConfig, ActionConfig actionConfig) {
            this.button = button;
            this.panel = panel;

            this.transformConfig = transformConfig;
            this.spriteConfig = spriteConfig;
            this.actionConfig = actionConfig;
        }
    }

    public class ButtonOption : Button {
        public ButtonOptionConfig falseButtonConfig;
        public bool lastValue;
        public void SetFalseAction(ActionConfig actionConfig) {
            falseButtonConfig.actionConfig = actionConfig;
        }

        public ButtonOption(ModHelperButton button, ModHelperPanel panel,TransformConfig transformConfig, SpriteConfig trueSpriteConfig,ActionConfig trueActionConfig,ButtonOptionConfig falseButtonConfig,bool value)
            : base(button, panel, transformConfig, trueSpriteConfig, trueActionConfig){
            this.falseButtonConfig = falseButtonConfig;
            this.lastValue = value;
        }

        public virtual void Rebuild(bool? newValue = null) {
            bool value = newValue ?? lastValue;
            lastValue = value;

            button.DeleteObject();

            if (value) {
                button = panel.AddButton(
                    new Info("Button", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize, transformConfig.ySize),
                    spriteConfig.sprite,
                    null
                );
                button.Button.SetOnClick(() => actionConfig.action?.DynamicInvoke(actionConfig.parameters));
            }
            else {
                button = panel.AddButton(
                    new Info("Button", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize, transformConfig.ySize),
                    falseButtonConfig.spriteConfig.sprite,
                    null
                );
                if (falseButtonConfig.actionConfig?.action != null) {
                    button.Button.SetOnClick(() => falseButtonConfig.actionConfig.action?.DynamicInvoke(falseButtonConfig.actionConfig.parameters));
                }
            }
        }
    }
    public class TextButton : Button {
        public ModHelperText text;
        public TextConfig textConfig;
        public TextButton(ModHelperButton button, ModHelperText text, ModHelperPanel panel, TransformConfig transformConfig, SpriteConfig spriteConfig, TextConfig textConfig, ActionConfig actionConfig) 
            : base(button, panel, transformConfig, spriteConfig, actionConfig) {
            this.text = text;
            this.textConfig = textConfig;
        }
    }
    public class TextButtonOption : TextButton {
        public TextButtonOptionConfig falseButtonConfig;
        public bool lastValue;

        public TextButtonOption(ModHelperButton button, ModHelperText text, ModHelperPanel panel, TransformConfig transformConfig,SpriteConfig trueSpriteConfig,TextConfig trueTextConfig,ActionConfig trueActionConfig, TextButtonOptionConfig falseButtonConfig, bool value)
            : base(button, text, panel, transformConfig, trueSpriteConfig, trueTextConfig, trueActionConfig) {
            this.falseButtonConfig = falseButtonConfig;
            this.lastValue = value;
        }

        public void Rebuild(bool? newValue = null, string? newText = "") {
            bool value = newValue ?? lastValue;
            this.textConfig.text = newText;
            lastValue = value;
            
            button.DeleteObject();
            button = null;

            if (value) {
                button = panel.AddButton(
                    new Info("Button", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize, transformConfig.ySize),
                    spriteConfig.sprite,
                    null
                );
                text = button.AddText(
                    new Info("Text", 0, 0, transformConfig.xSize, transformConfig.ySize),
                    textConfig.text,
                    textConfig.fontSize
                );
                button.Button.SetOnClick(() => actionConfig.action?.DynamicInvoke(actionConfig.parameters));
            }
            else {
                button = panel.AddButton(
                    new Info("Button", transformConfig.xPos, transformConfig.yPos, transformConfig.xSize, transformConfig.ySize),
                    falseButtonConfig.spriteConfig.sprite,
                    null
                );
                text = button.AddText(
                    new Info("Text", 0, 0, transformConfig.xSize, transformConfig.ySize),
                    falseButtonConfig.textConfig.text,
                    falseButtonConfig.textConfig.fontSize
                );
                if (falseButtonConfig.actionConfig?.action != null) {
                    button.Button.SetOnClick(() => falseButtonConfig.actionConfig.action?.DynamicInvoke(falseButtonConfig.actionConfig.parameters));
                }
            }
        }
    }
    public class ButtonOptionConfig {
        public SpriteConfig spriteConfig;
        public ActionConfig actionConfig;
        public ButtonOptionConfig(SpriteConfig spriteConfig, ActionConfig actionConfig) {
            this.spriteConfig = spriteConfig;
            this.actionConfig = actionConfig;
        }
    }
    public class TextButtonOptionConfig {
        public SpriteConfig spriteConfig;
        public ActionConfig actionConfig;
        public TextConfig textConfig;
        public TextButtonOptionConfig(SpriteConfig spriteConfig, ActionConfig actionConfig, TextConfig textConfig) {
            this.spriteConfig = spriteConfig;
            this.actionConfig = actionConfig;
            this.textConfig = textConfig;
        }
    }
    public class TransformConfig {
        public int xSize;
        public int ySize;
        public int xPos;
        public int yPos;
        public TransformConfig(Vector2 position, Vector2 size) {
            this.xSize = Mathf.RoundToInt(size.x);
            this.ySize = Mathf.RoundToInt(size.y);
            this.xPos = Mathf.RoundToInt(position.x);
            this.yPos = Mathf.RoundToInt(position.y);
        }
    }
    public class SpriteConfig {
        public string sprite;
        public SpriteConfig(string sprite) {
            this.sprite = sprite;
        }
    }
    public class ActionConfig {
        public Delegate action;
        public object[] parameters;
    }
    public class TextConfig {
        public string text;
        public int fontSize;
        public bool useNumberSmoothing;
        public int textNumber;
        public string beforeText;
        public string afterText;
        public bool useNumAbreviation;
        public TextConfig(string text, int fontSize) {
            this.text = text;
            this.fontSize = fontSize;
        }
        public TextConfig(int fontSize, int number, string beforeText, string afterText, bool useNumAbreviation) {
            this.useNumberSmoothing = true;
            this.fontSize = fontSize;
            this.textNumber = number;
            this.beforeText = beforeText;
            this.afterText = afterText;
            this.useNumAbreviation = useNumAbreviation;
        }
    }
}
