
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AncientMonkey.Artifacts;
using AncientMonkey.Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.Powers;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem;
using Il2CppTMPro;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Octokit;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static AncientMonkey.AncientMonkey;

namespace AncientMonkey.Challenge
{
    public class AncientPanel : ModGameMenu<ExtraSettingsScreen>
    {

        ModHelperScrollPanel LeftPanel;
        ModHelperScrollPanel CenterPanel;
        ModHelperPanel TopPanel;
        ModHelperText TopPanelText;
        string loadedPanel = "";
        public override bool OnMenuOpened(Il2CppSystem.Object data)
        {
            CommonForegroundScreen.instance.heading.SetActive(true);
            CommonForegroundHeader.SetText("Ancients Panel");
            var panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            var panel = panelTransform.gameObject;
            loadedPanel = "";
            panel.DestroyAllChildren();
            var MainPanel = panel.AddModHelperPanel(new Info("AncientPanelMenu", 3600, 1900));
            CreateLeftPanel(MainPanel);
            CenterPanel = MainPanel.AddScrollPanel(new Info("CenterPanel", 600, 0, 3000, 2000), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 20, 20);
            TopPanel = MainPanel.AddPanel(new Info("TopPanel", 600, 1100, 3000, 180), VanillaSprites.MainBGPanelBlue);
            TopPanelText = TopPanel.AddText(new Info("weaponsText", 0, 0, 3000, 160), "", 125);

            return false;
        }
        public void SetTopPanelText(string text, Color color, Color outlineColor)
        {
            TopPanelText.Text.text = text;
            TopPanelText.Text.color = color;
            TopPanelText.Text.outlineColor = outlineColor;
        }
        private void CreateLeftPanel(ModHelperPanel MainPanel)
        {
            LeftPanel = MainPanel.AddScrollPanel(new Info("MainScrollMenu", -1500, 0, 1000, 2000), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 50, 50);
            LoadLeftPanelContent();
        }
        public void LoadWeaponsContent()
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();
            for (int i = 1; i < 100; i++)
            {
                foreach (var weapon in GetContent<WeaponTemplate>())
                {
                    if (weapon.SandboxIndex == i)
                    {
                        CenterPanel.AddScrollContent(CreateWeapon(weapon));
                    }
                }
            }
        }
        private int currentMode = 0;
        private string playerName = "Player Name";
        private string title = "Title";
        private string description = "Description (Send log if possible (only bug reports))";
        private DateTime lastFeedbackTime = DateTime.MinValue;
        private TimeSpan feedbackCooldown = TimeSpan.FromSeconds(30);
        public void LoadArtifactsContent()
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();
            foreach (var artefact in GetContent<ArtifactTemplate>())
            {
                CenterPanel.AddScrollContent(CreateArtifact(artefact));
            }
        }
        public void LoadReportContent() {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();
            var modeButton = ModHelperButton.Create(new Info("idea", 1500, 200), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (currentMode == 1) { currentMode = 0; } else { currentMode = 1; }
                LoadReportContent();
            }));
            string modeString = currentMode == 1 ? "Give Idea Mode" : "Report Bug Mode";
            modeButton.AddText(new Info("idea", 1500, 200), modeString, 100);
            var playerNameValue = ModHelperInputField.Create(new Info("playerNameValue", 1000, 165), playerName, VanillaSprites.BlueInsertPanelRound, new System.Action<string>(value => { }), 70, TMP_InputField.CharacterValidation.None);
            playerNameValue.GetComponent<Mask>().enabled = false;
            playerNameValue.GetComponent<Mask>().enabled = true;
            playerNameValue.InputField.lineType = TMP_InputField.LineType.MultiLineNewline;
            playerNameValue.InputField.textComponent.enableWordWrapping = true;
            playerNameValue.InputField.textComponent.overflowMode = TextOverflowModes.Overflow;
            playerNameValue.InputField.onValueChanged.AddListener(new System.Action<string>(value =>
            {
                playerName = value;
                playerNameValue.GetComponent<Mask>().enabled = false;
                playerNameValue.GetComponent<Mask>().enabled = true;
            }));
            playerNameValue.InputField.characterLimit = 25;
            var titleValue = ModHelperInputField.Create(new Info("titleValue", 1000, 165), title, VanillaSprites.BlueInsertPanelRound, new System.Action<string>(value => { }), 70, TMP_InputField.CharacterValidation.None);
            titleValue.GetComponent<Mask>().enabled = false;
            titleValue.GetComponent<Mask>().enabled = true;
            titleValue.InputField.lineType = TMP_InputField.LineType.MultiLineNewline;
            titleValue.InputField.textComponent.enableWordWrapping = true;
            titleValue.InputField.textComponent.overflowMode = TextOverflowModes.Overflow;
            titleValue.InputField.onValueChanged.AddListener(new System.Action<string>(value => {
                title = value;
                titleValue.GetComponent<Mask>().enabled = false;
                titleValue.GetComponent<Mask>().enabled = true;
            }));
            titleValue.InputField.characterLimit = 20;
            var descriptionValue = ModHelperInputField.Create(new Info("descriptionValue", 2000, 330), description, VanillaSprites.BlueInsertPanelRound, new System.Action<string>(value => { }), 70, TMP_InputField.CharacterValidation.None);
            descriptionValue.GetComponent<Mask>().enabled = false;
            descriptionValue.GetComponent<Mask>().enabled = true;
            descriptionValue.InputField.lineType = TMP_InputField.LineType.MultiLineNewline;
            descriptionValue.InputField.textComponent.enableWordWrapping = true;
            descriptionValue.InputField.textComponent.overflowMode = TextOverflowModes.Overflow;
            descriptionValue.InputField.textComponent.alignment = TextAlignmentOptions.TopLeft;
            descriptionValue.InputField.onValueChanged.AddListener(new System.Action<string>(value => {
                description = value;
                descriptionValue.GetComponent<Mask>().enabled = false;
                descriptionValue.GetComponent<Mask>().enabled = true;
            }));
            descriptionValue.InputField.characterLimit = 10000;

            var sendReport = ModHelperButton.Create(new Info("idea", 1500, 200), VanillaSprites.GreenBtnLong, new System.Action(() => {
                SendFeedback(currentMode == 1 ? "idea" : "bug", title, description, playerName);
            }));
            string modeStringSend = currentMode == 1 ? "Send Idea" : "Report Bug";
            sendReport.AddText(new Info("idea", 1500, 200), modeStringSend, 100);


            CenterPanel.AddScrollContent(modeButton);
            CenterPanel.AddScrollContent(playerNameValue);
            CenterPanel.AddScrollContent(titleValue);
            CenterPanel.AddScrollContent(descriptionValue);
            CenterPanel.AddScrollContent(sendReport);
        }
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<HttpResponseMessage> GetDataAsync(string type, string title, string description, string playerName) {
            String url = "https://report-handler.bananapoire12.workers.dev";

            string json = $"{{\"type\":\"{type}\",\"title\":\"{title}\",\"description\":\"{description}\",\"userName\":\"{playerName}\"}}";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(json, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
          

            return await httpClient.SendAsync(request);
        }

        public void SendFeedback(string type, string title, string description, string playerName) {
            DateTime now = DateTime.Now;
            if (now - lastFeedbackTime < feedbackCooldown) {
                double secondsLeft = (feedbackCooldown - (now - lastFeedbackTime)).TotalSeconds;
                PopupScreen.instance.ShowOkPopup($"Please wait {secondsLeft:F1} more seconds before sending another report.", null);
                return;
            }
            lastFeedbackTime = now;
            PopupScreen.instance.ShowOkPopup($"Correctly received report, {playerName}, your feedback will be looked at and thank you :)", null);
            Task.Run(async () =>
            {
                try {

                    HttpResponseMessage response = await GetDataAsync(type, title, description, playerName);
                }
                catch (System.Exception) {
                }
            });

            
        }

        public static ModHelperPanel CreateArtifact(ArtifactTemplate artifact)
        {
            var sprite = VanillaSprites.GreyInsertPanel;
            ModHelperButton selectWpnBtn = null;
            ModHelperText selectWpn = null;
            var panel = ModHelperPanel.Create(new Info("WeaponContent" + artifact.ArtifactName, 0, 0, 2800, 150), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText wpnName = panel.AddText(new Info("wpnName", -745, 0, 1000, 150), artifact.ArtifactName, 70, TextAlignmentOptions.MidlineLeft);
            ModHelperText description = panel.AddText(new Info("rarity", 300, 0, 1350, 150), artifact.ArtifactDescription.ToString(), 50, TextAlignmentOptions.MidlineLeft);
            ModHelperImage image = panel.AddImage(new Info("image", -1330, 0, 140, 140), artifact.Icon);
            selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 1170, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                artifact.enabled = !artifact.enabled;
                if (artifact.enabled)
                {
                    selectWpnBtn.Image.SetSprite(VanillaSprites.GreenBtnLong);
                    selectWpn.Text.text = "Enabled";
                }
                else
                {
                    selectWpnBtn.Image.SetSprite(VanillaSprites.RedBtnLong);
                    selectWpn.Text.text = "Disabled";
                }
            }));
           
            if(artifact.enabled)
            {
                selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Enabled", 60);
            } 
            else
            {
                selectWpnBtn.Image.SetSprite(VanillaSprites.RedBtnLong);
                selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Disabled", 60);
            }
            return panel;
        }
        public static ModHelperPanel CreateWeapon(WeaponTemplate weapon)
        {
            var sprite = VanillaSprites.GreyInsertPanel;
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Rare)
            {
                sprite = VanillaSprites.BlueInsertPanel;
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Epic)
            {
                sprite = VanillaSprites.MainBgPanelParagon;
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Legendary)
            {
                sprite = VanillaSprites.MainBGPanelYellow;
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Exotic)
            {
                sprite = VanillaSprites.MainBgPanelWhiteSmall;
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Godly)
            {
                sprite = VanillaSprites.MainBGPanelSilver;
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Omega)
            {
                sprite = VanillaSprites.MainBgPanelHematite;
            }
            ModHelperButton selectWpnBtn = null;
            ModHelperText selectWpn = null;
            var panel = ModHelperPanel.Create(new Info("WeaponContent" + weapon.WeaponName, 0, 0, 2800, 150), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText wpnName = panel.AddText(new Info("wpnName", -815, 0, 1000, 150), weapon.WeaponName, 80, TextAlignmentOptions.MidlineLeft);
            ModHelperText rarity = panel.AddText(new Info("rarity", 275, 0, 600, 150), weapon.WeaponRarity.ToString(), 80, TextAlignmentOptions.MidlineLeft);
            ModHelperImage image = panel.AddImage(new Info("image", -100, 0, 140, 140), weapon.Icon);
            selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                weapon.enabled = !weapon.enabled;
                if (weapon.enabled)
                {
                    selectWpnBtn.Image.SetSprite(VanillaSprites.GreenBtnLong);
                    selectWpn.Text.text = "Enabled";
                }
                else
                {
                    selectWpnBtn.Image.SetSprite(VanillaSprites.RedBtnLong);
                    selectWpn.Text.text = "Disabled";
                }
            }));

            if (weapon.IsCamo)
            {
                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 460, 0, 120, 120), VanillaSprites.CamoBloonIcon);
            }
            if (weapon.IsLead)
            {
                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 580, 0, 120, 120), VanillaSprites.LeadBloonIcon);
            }
            selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Enabled", 60);
            if (!weapon.enabled)
            {
                selectWpnBtn.Image.SetSprite(VanillaSprites.RedBtnLong);
                selectWpn.Text.text = "Disabled";
            }
            return panel;
        }
       
        public void LoadGeneralSettings(bool reset = false)
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            CenterPanel.AddScrollContent(CreateResetAllButton());

            CenterPanel.AddScrollContent(CreateSetting("Cheats", "Cheats:", "bool", reset));
            if ((bool)Settings.settingsValue["Cheats"])
            {
                CenterPanel.AddScrollContent(CreateSetting("SandboxMode", "Sandbox Mode:", "bool", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraLuckStartingCost", "Extra Luck Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraLuckCostIncreaseMultiplier", "Extra Luck Cost Increase Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraLuckUpgradeCount", "Extra Luck Upgrade Count: ", "intSlider", reset, 1f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("ExtraAbilitySlotStartingCost", "Extra Ability Slot Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraAbilitySlotIncreaseMultiplier", "Extra Ability Slot Increase Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraAbilitySlotUpgradeCount", "Extra Ability Slot Upgrade Count: ", "intSlider", reset, 1f, 20f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("ExtraWeaponSlotStartingCost", "Extra Weapon Slot Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraWeaponSlotIncreaseMultiplier", "Extra Weapon Slot Increase Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraWeaponSlotUpgradeCount", "Extra Weapon Slot Upgrade Count: ", "intSlider", reset, 1f, 20f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("ExtraStrongerSlotStartingCost", "Extra Stronger Slot Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraStrongerSlotIncreaseMultiplier", "Extra Stronger Slot Increase Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraStrongerSlotUpgradeCount", "Extra Stronger Slot Upgrade Count: ", "intSlider", reset, 1f, 20f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("NewWeaponStartingSlot", "New Weapon Starting Slot:", "intSlider", reset, 1f, 5f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("NewAbilityStartingSlot", "New Ability Starting Slot:", "intSlider", reset, 1f, 5f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongerWeaponStartingSlot", "New Weapon Starting Slot: ", "intSlider", reset, 1f, 5f, 1f));
            }
            else
            {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.BlueInsertPanel);
                ModHelperText enableCheats = panel.AddText(new Info("valueName", 0, 0, 2800, 150), "Enable Cheats To Change Settings", 80, TextAlignmentOptions.MidlineLeft);
                CenterPanel.AddScrollContent(panel);
            }
        }
        public void LoadBaseUpgradeSettings(bool reset = false) {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            CenterPanel.AddScrollContent(CreateResetAllButton());
            if ((bool)Settings.settingsValue["Cheats"]) {
                CenterPanel.AddScrollContent(CreateSetting("NewWeaponStartingCost", "New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponStartingCost", "Increase New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponCostMultiplier", "Increase Cost New Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("StrongerWeaponStartingCost", "Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponStartingCost", "Increase Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponCostMultiplier", "Increase Cost Stronger Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewAbilityStartingCost", "New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityStartingCost", "Increase New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityCostMultiplier", "Increase Cost New Ability Multiplier:", "float", reset));
            } else {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.BlueInsertPanel);
                ModHelperText enableCheats = panel.AddText(new Info("valueName", 0, 0, 2800, 150), "Enable Cheats To Change Settings", 80, TextAlignmentOptions.MidlineLeft);
                CenterPanel.AddScrollContent(panel);
            }
        }
        public void LoadUpgrade1Settings(bool reset = false)
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            CenterPanel.AddScrollContent(CreateResetAllButton());
            if ((bool)Settings.settingsValue["Cheats"])
            {
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1Enabled", "Upgrade Enabled:", "bool", reset));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1Cost", "Upgrade Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewWeaponStartingCost1", "New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponStartingCost1", "Increase New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponCostMultiplier1", "Increase Cost New Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("StrongerWeaponStartingCost1", "Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponStartingCost1", "Increase Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponCostMultiplier1", "Increase Cost Stronger Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewAbilityStartingCost1", "New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityStartingCost1", "Increase New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityCostMultiplier1", "Increase Cost New Ability Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewWeaponSlotBonus1", "New Weapon Slot Bonus:", "intSlider", reset, 1f, 3f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongerWeaponSlotBonus1", "Stronger Weapon Slot Bonus:", "intSlider", reset, 1f, 3f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("NewAbilitySlotBonus1", "New Ability Slot Bonus: ", "intSlider", reset, 1f, 3f, 1f));
            }
            else
            {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.BlueInsertPanel);
                ModHelperText enableCheats = panel.AddText(new Info("valueName", 0, 0, 2800, 150), "Enable Cheats To Change Settings", 80, TextAlignmentOptions.MidlineLeft);
                CenterPanel.AddScrollContent(panel);
            }
            

        }
        public void LoadUpgrade2Settings(bool reset = false) {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            CenterPanel.AddScrollContent(CreateResetAllButton());
            if ((bool)Settings.settingsValue["Cheats"]) {
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2Enabled", "Upgrade Enabled:", "bool", reset));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2Cost", "Upgrade Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewWeaponStartingCost2", "New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponStartingCost2", "Increase New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponCostMultiplier2", "Increase Cost New Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("StrongerWeaponStartingCost2", "Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponStartingCost2", "Increase Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponCostMultiplier2", "Increase Cost Stronger Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewAbilityStartingCost2", "New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityStartingCost2", "Increase New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityCostMultiplier2", "Increase Cost New Ability Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewWeaponSlotBonus2", "New Weapon Slot Bonus:", "intSlider", reset, 1f, 3f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongerWeaponSlotBonus2", "Stronger Weapon Slot Bonus:", "intSlider", reset, 1f, 3f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("NewAbilitySlotBonus2", "New Ability Slot Bonus: ", "intSlider", reset, 1f, 3f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("XpEnabled", "Xp Enabled: ", "bool", reset));
                CenterPanel.AddScrollContent(CreateSetting("StartingMaxXp", "Starting Max Xp: ", "int", reset));
                CenterPanel.AddScrollContent(CreateSetting("MaxXpIncrease", "Max Xp Increase: ", "int", reset));
            }
            else {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.BlueInsertPanel);
                ModHelperText enableCheats = panel.AddText(new Info("valueName", 0, 0, 2800, 150), "Enable Cheats To Change Settings", 80, TextAlignmentOptions.MidlineLeft);
                CenterPanel.AddScrollContent(panel);
            }


        }
        public void LoadWeaponsLuckSettings(bool reset = false)
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            CenterPanel.AddScrollContent(CreateResetAllButton());

            if ((bool)Settings.settingsValue["Cheats"])
            {
                CenterPanel.AddScrollContent(CreateSetting("BaseRareChance", "Base Rare Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseEpicChance", "Base Epic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseLegendaryChance", "Base Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseExoticChance", "Base Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseRareChanceUntilEpicChance", "Base Rare Chance Until Epic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseEpicChanceUntilLegendaryChance", "Base Epic Chance Until Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseLegendaryChanceUntilExoticChance", "Base Legendary Chance Until Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseRareChanceDecrease", "Base Rare Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("BaseEpicChanceDecrease", "Base Epic Chance Decrease: ", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("BaseLegendaryChanceDecrease", "Base Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("BaseExoticChanceDecrease", "Base Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));

                CenterPanel.AddScrollContent(CreateSetting("Upgrade1EpicChance", "Upgrade 1 Epic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1LegendaryChance", "Upgrade 1 Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1ExoticChance", "Upgrade 1 Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1GodlyChance", "Upgrade 1 Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1EpicChanceUntilLegendaryChance", "Upgrade 1 Epic Chance Until Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1LegendaryChanceUntilExoticChance", "Upgrade 1 Legendary Chance Until Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1ExoticChanceUntilGodlyChance", "Upgrade 1 Exotic Chance Until Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1EpicChanceDecrease", "Upgrade 1 Epic Chance Decrease: ", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1LegendaryChanceDecrease", "Upgrade 1 Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1ExoticChanceDecrease", "Upgrade 1 Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1GodlyChanceDecrease", "Upgrade 1 Godly Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));

                CenterPanel.AddScrollContent(CreateSetting("Upgrade2LegendaryChance", "Upgrade 2 Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2ExoticChance", "Upgrade 2 Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2GodlyChance", "Upgrade 2 Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2LegendaryChanceUntilExoticChance", "Upgrade 2 Legendary Chance Until Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2ExoticChanceUntilGodlyChance", "Upgrade 2 Exotic Chance Until Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2GodlyChanceUntilOmegaChance", "Upgrade 2 Godly Chance Until Omega Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2LegendaryChanceDecrease", "Upgrade 2 Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2ExoticChanceDecrease", "Upgrade 2 Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2GodlyChanceDecrease", "Upgrade 2 Godly Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade2OmegaChanceDecrease", "Upgrade 2 Omega Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
            }
            else
            {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.BlueInsertPanel);
                ModHelperText enableCheats = panel.AddText(new Info("valueName", 0, 0, 2800, 150), "Enable Cheats To Change Settings", 80, TextAlignmentOptions.MidlineLeft);
                CenterPanel.AddScrollContent(panel);
            }
               
        }
        public void LoadStrongerWeaponsLuckSettings(bool reset = false) {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            CenterPanel.AddScrollContent(CreateResetAllButton());

            if ((bool)Settings.settingsValue["Cheats"]) {
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseRareChance", "Base Rare Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseEpicChance", "Base Epic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseLegendaryChance", "Base Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseExoticChance", "Base Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseRareChanceUntilEpicChance", "Base Rare Chance Until Epic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseEpicChanceUntilLegendaryChance", "Base Epic Chance Until Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseLegendaryChanceUntilExoticChance", "Base Legendary Chance Until Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseRareChanceDecrease", "Base Rare Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseEpicChanceDecrease", "Base Epic Chance Decrease: ", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseLegendaryChanceDecrease", "Base Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongBaseExoticChanceDecrease", "Base Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));

                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1EpicChance", "Upgrade 1 Epic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1LegendaryChance", "Upgrade 1 Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1ExoticChance", "Upgrade 1 Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1GodlyChance", "Upgrade 1 Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1EpicChanceUntilLegendaryChance", "Upgrade 1 Epic Chance Until Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1LegendaryChanceUntilExoticChance", "Upgrade 1 Legendary Chance Until Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1ExoticChanceUntilGodlyChance", "Upgrade 1 Exotic Chance Until Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1EpicChanceDecrease", "Upgrade 1 Epic Chance Decrease: ", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1LegendaryChanceDecrease", "Upgrade 1 Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1ExoticChanceDecrease", "Upgrade 1 Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade1GodlyChanceDecrease", "Upgrade 1 Godly Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));

                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2LegendaryChance", "Upgrade 2 Legendary Chance: ", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2ExoticChance", "Upgrade 2 Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2GodlyChance", "Upgrade 2 Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2LegendaryChanceUntilExoticChance", "Upgrade 2 Legendary Chance Until Exotic Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2ExoticChanceUntilGodlyChance", "Upgrade 2 Exotic Chance Until Godly Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2GodlyChanceUntilOmegaChance", "Upgrade 2 Godly Chance Until Omega Chance:", "floatSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2LegendaryChanceDecrease", "Upgrade 2 Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2ExoticChanceDecrease", "Upgrade 2 Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2GodlyChanceDecrease", "Upgrade 2 Godly Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("StrongUpgrade2OmegaChanceDecrease", "Upgrade 2 Omega Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
            }
            else {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.BlueInsertPanel);
                ModHelperText enableCheats = panel.AddText(new Info("valueName", 0, 0, 2800, 150), "Enable Cheats To Change Settings", 80, TextAlignmentOptions.MidlineLeft);
                CenterPanel.AddScrollContent(panel);
            }

        }
        public ModHelperPanel CreateResetAllButton()
        {
            var panel = ModHelperPanel.Create(new Info("WeaponContent", 0, 0, 2800, 150), VanillaSprites.GreyInsertPanel);

            ModHelperText valueName = panel.AddText(new Info("valueName", -370, 0, 2000, 150), "Reset All", 80, TextAlignmentOptions.MidlineLeft);

            var resetButton = panel.AddButton(new Info("weaponsButton", 1325, 0, 130, 130), VanillaSprites.RestartBtn, new System.Action(() => {
                if (loadedPanel == "GeneralSettings")
                {
                    LoadGeneralSettings(true);
                }
                if (loadedPanel == "Upgrade1Settings")
                {
                    LoadUpgrade1Settings(true);
                }
                if (loadedPanel == "Upgrade2Settings") {
                    LoadUpgrade2Settings(true);
                }
                if (loadedPanel == "WeaponsLuckSettings")
                {
                    LoadWeaponsLuckSettings(true);
                }
                if (loadedPanel == "StrongWeaponsLuckSettings") {
                    LoadWeaponsLuckSettings(true);
                }
                if (loadedPanel == "BaseUpgradeSettings") {
                    LoadBaseUpgradeSettings(true);
                }

            }));
              

            return panel;
        }
        public ModHelperPanel CreateSetting(string dictName, string name, string type, bool resetValue, float minSliderValue = 1f, float maxSliderValue = 20f, float stepSize = 1f)
        {
            if (resetValue)
            {
                Settings.settingsValue[dictName] = Settings.baseValue[dictName];
            }
            var dictValue = Settings.settingsValue[dictName];
            var panel = ModHelperPanel.Create(new Info("WeaponContent", 0, 0, 2800, 150), VanillaSprites.BlueInsertPanel);
            ModHelperText valueName = panel.AddText(new Info("valueName", -370, 0, 2000, 150), name, 80, TextAlignmentOptions.MidlineLeft);
            if (type == "bool")
            {
                ModHelperText boolValueText = null;
                ModHelperButton boolValue = null;
                boolValue = panel.AddButton(new Info("boolValue", 755, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                    Settings.settingsValue[dictName] = !(bool)Settings.settingsValue[dictName];
                    if ((bool)Settings.settingsValue[dictName])
                    {
                        boolValue.Image.SetSprite(VanillaSprites.GreenBtnLong);
                        boolValueText.Text.text = "True";
                    }
                    else
                    {
                        boolValue.Image.SetSprite(VanillaSprites.RedBtnLong);
                        boolValueText.Text.text = "False";
                    }
                    if (name == "Cheats:")
                    {
                        LoadGeneralSettings();
                    }
                }));

                if (!(bool)dictValue)
                {
                    boolValue.Image.SetSprite(VanillaSprites.RedBtnLong);
                    boolValueText = boolValue.AddText(new Info("boolValueText", 0, 0, 700, 160), "False", 60);
                }
                else
                {
                    boolValueText = boolValue.AddText(new Info("boolValueText", 0, 0, 700, 160), "True", 60);
                }
               
              
            }
            if (type == "int") {
                var intValue = panel.AddInputField(
                    new Info("intValue", 755, 0, 700, 130),
                    dictValue.ToString(),
                    VanillaSprites.BlueInsertPanelRound,
                    new System.Action<string>(value => { }),
                    80,
                    TMP_InputField.CharacterValidation.Integer);

                intValue.GetComponent<Mask>().enabled = false;
                intValue.GetComponent<Mask>().enabled = true;

                intValue.InputField.onValueChanged.AddListener(new System.Action<string>(value =>
                {
                    if (int.TryParse(value, out var intV)) {
                        Settings.settingsValue[dictName] = intV;
                    }
                    intValue.GetComponent<Mask>().enabled = false;
                    intValue.GetComponent<Mask>().enabled = true;
                }));

                intValue.InputField.characterLimit = 12;
            }
            if (type == "float")
            {
                var floatValue = panel.AddInputField(new Info("intValue", 755, 0, 700, 130), dictValue.ToString(), VanillaSprites.BlueInsertPanelRound, new System.Action<string>(value => { }), 80, TMP_InputField.CharacterValidation.Decimal);
                floatValue.GetComponent<Mask>().enabled = false;
                floatValue.GetComponent<Mask>().enabled = true;
                floatValue.InputField.onValueChanged.AddListener(new System.Action<string>(value =>
                {
                    float.TryParse(value, out var floatV);
                    Settings.settingsValue[dictName] = floatV;
                    floatValue.GetComponent<Mask>().enabled = false;
                    floatValue.GetComponent<Mask>().enabled = true;
                }));
                floatValue.InputField.characterLimit = 12;
            }
            if (type == "intSlider")
            {
                var sliderValue = panel.AddSlider(new Info("intValue", 755, 0, 700, 130), Convert.ToSingle((int)dictValue), minSliderValue, maxSliderValue, stepSize,new Vector2(130,130));
                sliderValue.Slider.onValueChanged.AddListener(new System.Action<float>(value => {
                    Settings.settingsValue[dictName] = (int)value;
                }));
            }
            if (type == "floatSlider")
            {
                var sliderValue = panel.AddSlider(new Info("floatSlider", 755, 0, 700, 130), (float)dictValue, minSliderValue, maxSliderValue, stepSize, new Vector2(130, 130));
                sliderValue.Slider.onValueChanged.AddListener(new System.Action<float>(value => {
                    Settings.settingsValue[dictName] = value;
                }));
            }
            var resetButton = panel.AddButton(new Info("weaponsButton", 1325, 0, 130, 130), VanillaSprites.RestartBtn, new System.Action(() => {
                Settings.settingsValue[dictName] = Settings.baseValue[dictName];
                if (loadedPanel == "GeneralSettings") {
                    LoadGeneralSettings(true);
                }
                if (loadedPanel == "Upgrade1Settings") {
                    LoadUpgrade1Settings(true);
                }
                if (loadedPanel == "Upgrade2Settings") {
                    LoadUpgrade2Settings(true);
                }
                if (loadedPanel == "WeaponsLuckSettings") {
                    LoadWeaponsLuckSettings(true);
                }
                if (loadedPanel == "StrongWeaponsLuckSettings") {
                    LoadWeaponsLuckSettings(true);
                }
                if (loadedPanel == "BaseUpgradeSettings") {
                    LoadBaseUpgradeSettings(true);
                }
            }));
           
            return panel;
        }
        public void LoadLeftPanelContent()
        {
            LeftPanel.ScrollContent.transform.DestroyAllChildren();
            ModHelperButton ArtifactsButton = ModHelperButton.Create(new Info("ArtifactsButton", 0, 0, 950, 220), VanillaSprites.YellowBtnLong, new System.Action(() => {
                if (loadedPanel != "ArtifactPanel") {
                    loadedPanel = "ArtifactPanel";
                    SetTopPanelText("Artifacts", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadLeftPanelContent();
                    LoadArtifactsContent();
                }
            }));
            if (loadedPanel == "ArtifactPanel") {
                ArtifactsButton.Image.SetSprite(VanillaSprites.RedBtnLong);
            }
            ModHelperText artifactText = ArtifactsButton.AddText(new Info("artifactText", 0, 0, 950, 160), "Artifacts", 94);
            LeftPanel.AddScrollContent(ArtifactsButton);

            ModHelperButton reportButton = ModHelperButton.Create(new Info("reportButton", 0, 0, 950, 220), VanillaSprites.ParagonBtnLong, new System.Action(() => {
                if (loadedPanel != "ReportPanel") {
                    loadedPanel = "ReportPanel";
                    SetTopPanelText("Report", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadLeftPanelContent();
                    LoadReportContent();
                }
            }));
            if (loadedPanel == "ReportPanel") {
                reportButton.Image.SetSprite(VanillaSprites.PurpleBtnLong);
            }
            ModHelperText reportText = reportButton.AddText(new Info("reportText", 0, 0, 950, 160), "Report", 94);
            LeftPanel.AddScrollContent(reportButton);

            ModHelperButton weaponsButton = ModHelperButton.Create(new Info("weaponsButton", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "WeaponsPanel")
                {
                    loadedPanel = "WeaponsPanel";
                    SetTopPanelText("Weapons", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadLeftPanelContent();
                    LoadWeaponsContent();
                }
            }));
            if (loadedPanel == "WeaponsPanel")
            {
                weaponsButton.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText weaponsText = weaponsButton.AddText(new Info("weaponsText", 0, 0, 950, 160), "Weapons", 94);
            LeftPanel.AddScrollContent(weaponsButton);

            ModHelperButton generalSettings = ModHelperButton.Create(new Info("generalSettings", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "GeneralSettings")
                {
                    loadedPanel = "GeneralSettings";
                    LoadLeftPanelContent();
                    SetTopPanelText("General Settings", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadGeneralSettings();
                }
            }));
            if (loadedPanel == "GeneralSettings")
            {
                generalSettings.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText generalSettingsText = generalSettings.AddText(new Info("generalSettingsText", 0, 0, 950, 170), "General Settings", 94);
            LeftPanel.AddScrollContent(generalSettings);

            ModHelperButton baseUpgradeSettings = ModHelperButton.Create(new Info("baseUpgradeSettings", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "BaseUpgradeSettings") {
                    loadedPanel = "BaseUpgradeSettings";
                    LoadLeftPanelContent();
                    SetTopPanelText("Base Upgrade Settings", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadBaseUpgradeSettings();
                }
            }));
            if (loadedPanel == "BaseUpgradeSettings") {
                baseUpgradeSettings.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText baseUpgradeSettingsText = baseUpgradeSettings.AddText(new Info("baseUpgradeSettingsText", 0, 0, 950, 170), "Base Upgrade Settings", 78);
            LeftPanel.AddScrollContent(baseUpgradeSettings);

            ModHelperButton upgrade1Settings = ModHelperButton.Create(new Info("upgrade1Settings", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "Upgrade1Settings")
                {
                    loadedPanel = "Upgrade1Settings";
                    LoadLeftPanelContent();
                    SetTopPanelText("Upgrade 1 Settings", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadUpgrade1Settings();
                }
            }));
            if (loadedPanel == "Upgrade1Settings")
            {
                upgrade1Settings.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText upgrade1SettingsText = upgrade1Settings.AddText(new Info("upgrade1SettingsText", 0, 0, 950, 170), "Upgrade 1 Settings", 94);
            LeftPanel.AddScrollContent(upgrade1Settings);


            ModHelperButton upgrade2Settings = ModHelperButton.Create(new Info("upgrade2Settings", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "Upgrade2Settings") {
                    loadedPanel = "Upgrade2Settings";
                    LoadLeftPanelContent();
                    SetTopPanelText("Upgrade 2 Settings", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadUpgrade2Settings();
                }
            }));
            if (loadedPanel == "Upgrade2Settings") {
                upgrade2Settings.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText upgrade2SettingsText = upgrade2Settings.AddText(new Info("upgrade2SettingsText", 0, 0, 950, 170), "Upgrade 2 Settings", 94);
            LeftPanel.AddScrollContent(upgrade2Settings);

            ModHelperButton luckSettings = ModHelperButton.Create(new Info("luckSettings", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "WeaponsLuckSettings")
                {
                    loadedPanel = "WeaponsLuckSettings";
                    LoadLeftPanelContent();
                    SetTopPanelText("Weapons Luck Settings", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadWeaponsLuckSettings();
                }
            }));
            if (loadedPanel == "WeaponsLuckSettings")
            {
                luckSettings.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText luckSettingsText = luckSettings.AddText(new Info("luckSettingsText", 0, 0, 950, 170), "Weapons Luck Settings", 80);
            LeftPanel.AddScrollContent(luckSettings);

            ModHelperButton sluckSettings = ModHelperButton.Create(new Info("sluckSettings", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "StrongWeaponsLuckSettings") {
                    loadedPanel = "StrongWeaponsLuckSettings";
                    LoadLeftPanelContent();
                    SetTopPanelText("Stronger Weapons Luck Settings", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadStrongerWeaponsLuckSettings();
                }
            }));
            if (loadedPanel == "StrongWeaponsLuckSettings") {
                sluckSettings.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText sluckSettingsText = sluckSettings.AddText(new Info("luckSettingsText", 0, 0, 950, 170), "Weapons Luck Settings", 80);
            LeftPanel.AddScrollContent(sluckSettings);
        }
    }
  
}
