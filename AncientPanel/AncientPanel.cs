using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppTMPro;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common;
using static AncientMonkey.AncientMonkey;
using Il2CppSystem;
using BTD_Mod_Helper;
using UnityEngine.UI;
using AncientMonkey.Quest;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
            TopPanelText.Text.outlineColor = color;
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
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
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
                    #pragma warning disable CS8602 // Dereference of a possibly null reference.
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
                CenterPanel.AddScrollContent(CreateSetting("NewWeaponStartingCost", "New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponStartingCost", "Increase New Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewWeaponCostMultiplier", "Increase Cost New Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("StrongerWeaponStartingCost", "Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponStartingCost", "Increase Stronger Weapon Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalStrongerWeaponCostMultiplier", "Increase Cost Stronger Weapon Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("NewAbilityStartingCost", "New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityStartingCost", "Increase New Ability Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("IncrementalNewAbilityCostMultiplier", "Increase Cost New Ability Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraLuckStartingCost", "Extra Luck Starting Cost:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraLuckCostIncreaseMultiplier", "Extra Luck Cost Increase Multiplier:", "float", reset));
                CenterPanel.AddScrollContent(CreateSetting("ExtraLuckUpgradeCount", "Extra Luck Upgrade Count: ", "intSlider", reset, 1f, 20f, 1f));
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
        public void LoadQuestPanel()
        {

            CenterPanel.ScrollContent.transform.DestroyAllChildren();
            var dailyQuestPanel = ModHelperPanel.Create(new Info("dailyQuestPanel", 0, 0, 2800, 150), VanillaSprites.GreyInsertPanel);
            ModHelperText dailyQuestTxt = dailyQuestPanel.AddText(new Info("dailyQuestTxt", 0, 0, 2800, 150), "Daily Quests", 110, TextAlignmentOptions.Center);
            CenterPanel.AddScrollContent(dailyQuestPanel);

            if ((string)AncientMonkey.mod.daily1[0] != "")
            {
                var daily1Panel = ModHelperPanel.Create(new Info("daily1Panel", 0, 0, 2800, 600), VanillaSprites.BlueInsertPanel);

                double dpercent = 0f;
                float dsize = 0f;
                string dcompletionNum = "";

                dpercent = AncientMonkey.mod.DailyBloonsPopped * 100 / (int)AncientMonkey.mod.daily1[1];
                if (dpercent >= 100)
                {
                    dpercent = 100;
                }
                dsize = 2580 * Mathf.ClampToFloat(dpercent) / 100;
                dcompletionNum = "Bloons Popped: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.DailyBloonsPopped))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat((int)AncientMonkey.mod.daily1[1])));
               
                ModHelperText QuestName = daily1Panel.AddText(new Info("QuestName", 0, 225, 2800, 150), "Daily Quest 1", 110, TextAlignmentOptions.Center);
                ModHelperPanel barBG = daily1Panel.AddPanel(new Info("Panel", 0, 60, 2600, 160), VanillaSprites.GreyInsertPanel);
                ModHelperPanel bar = daily1Panel.AddPanel(new Info("Panel", (dsize - dsize / 2) - 2580 / 2, 60, dsize, 140), VanillaSprites.BlueInsertPanel);
                ModHelperText questPercent = daily1Panel.AddText(new Info("questPercent", 0, 60, 2800, 150), Mathf.Round(Mathf.ClampToFloat(dpercent)) + "%", 80, TextAlignmentOptions.Center);
                ModHelperText completionNumber = daily1Panel.AddText(new Info("completionNumber", -695, -90, 1400, 150), dcompletionNum, 80, TextAlignmentOptions.MidlineLeft);
                ModHelperText rewardText = daily1Panel.AddText(new Info("rewardText", 695, -90, 1400, 150), "+" + AncientMonkey.mod.daily1[2] + " Ancient Pieces", 80, TextAlignmentOptions.MidlineRight);
                ModHelperButton claimRewardButton = null;
                ModHelperText claimRewardButtonText = null;
                claimRewardButton = daily1Panel.AddButton(new Info("claimRewardButton", 0, -200, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                    if (dpercent >= 100 && !(bool)AncientMonkey.mod.daily1[3])
                    {
                        AncientMonkey.mod.daily1[3] = true;
                        AncientMonkey.mod.AncientPiece += (int)AncientMonkey.mod.daily1[2];
                        LoadQuestPanel();
                    
                    }
                }));
                claimRewardButtonText = claimRewardButton.AddText(new Info("claimRewardButtonText", 0, 0, 700, 160), "Claim", 60);
                if (dpercent >= 100)
                {
                    claimRewardButton.Image.SetSprite(VanillaSprites.GreenBtnLong);
                }
                if ((bool)AncientMonkey.mod.daily1[3])
                {
                    claimRewardButtonText.SetText("Claimed");
                    claimRewardButton.Image.SetSprite(VanillaSprites.YellowBtnLong);
                }
                CenterPanel.AddScrollContent(daily1Panel);
            }
            if ((string)AncientMonkey.mod.daily2[0] != "")
            {
                var daily1Panel = ModHelperPanel.Create(new Info("daily1Panel", 0, 0, 2800, 600), VanillaSprites.BlueInsertPanel);

                double dpercent = 0f;
                float dsize = 0f;
                string dcompletionNum = "";

                dpercent = AncientMonkey.mod.DailyCashSpent * 100 / (int)AncientMonkey.mod.daily2[1];
                if (dpercent >= 100)
                {
                    dpercent = 100;
                }
                dsize = 2580 * Mathf.ClampToFloat(dpercent) / 100;
                dcompletionNum = "Cash Spent: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.DailyCashSpent))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat((int)AncientMonkey.mod.daily2[1])));

                ModHelperText QuestName = daily1Panel.AddText(new Info("QuestName", 0, 225, 2800, 150), "Daily Quest 2", 110, TextAlignmentOptions.Center);
                ModHelperPanel barBG = daily1Panel.AddPanel(new Info("Panel", 0, 60, 2600, 160), VanillaSprites.GreyInsertPanel);
                ModHelperPanel bar = daily1Panel.AddPanel(new Info("Panel", (dsize - dsize / 2) - 2580 / 2, 60, dsize, 140), VanillaSprites.BlueInsertPanel);
                ModHelperText questPercent = daily1Panel.AddText(new Info("questPercent", 0, 60, 2800, 150), Mathf.Round(Mathf.ClampToFloat(dpercent)) + "%", 80, TextAlignmentOptions.Center);
                ModHelperText completionNumber = daily1Panel.AddText(new Info("completionNumber", -695, -90, 1400, 150), dcompletionNum, 80, TextAlignmentOptions.MidlineLeft);
                ModHelperText rewardText = daily1Panel.AddText(new Info("rewardText", 695, -90, 1400, 150), "+" + AncientMonkey.mod.daily2[2] + " Ancient Pieces", 80, TextAlignmentOptions.MidlineRight);
                ModHelperButton claimRewardButton = null;
                ModHelperText claimRewardButtonText = null;
                claimRewardButton = daily1Panel.AddButton(new Info("claimRewardButton", 0, -200, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                    if (dpercent >= 100 && !(bool)AncientMonkey.mod.daily2[3])
                    {
                        AncientMonkey.mod.daily2[3] = true;
                        AncientMonkey.mod.AncientPiece += (int)AncientMonkey.mod.daily2[2];
                        LoadQuestPanel();

                    }
                }));
                claimRewardButtonText = claimRewardButton.AddText(new Info("claimRewardButtonText", 0, 0, 700, 160), "Claim", 60);
                if (dpercent >= 100)
                {
                    claimRewardButton.Image.SetSprite(VanillaSprites.GreenBtnLong);
                }
                if ((bool)AncientMonkey.mod.daily2[3])
                {
                    claimRewardButtonText.SetText("Claimed");
                    claimRewardButton.Image.SetSprite(VanillaSprites.YellowBtnLong);
                }
                CenterPanel.AddScrollContent(daily1Panel);
            }
            if ((string)AncientMonkey.mod.daily3[0] != "")
            {
                var daily1Panel = ModHelperPanel.Create(new Info("daily1Panel", 0, 0, 2800, 600), VanillaSprites.BlueInsertPanel);

                double dpercent = 0f;
                float dsize = 0f;
                string dcompletionNum = "";

                dpercent = AncientMonkey.mod.DailyWeaponsBought * 100 / (int)AncientMonkey.mod.daily3[1];
                if (dpercent >= 100)
                {
                    dpercent = 100;
                }
                dsize = 2580 * Mathf.ClampToFloat(dpercent) / 100;
                dcompletionNum = "Weapons Bought: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.DailyWeaponsBought))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat((int)AncientMonkey.mod.daily3[1])));

                ModHelperText QuestName = daily1Panel.AddText(new Info("QuestName", 0, 225, 2800, 150), "Daily Quest 3", 110, TextAlignmentOptions.Center);
                ModHelperPanel barBG = daily1Panel.AddPanel(new Info("Panel", 0, 60, 2600, 160), VanillaSprites.GreyInsertPanel);
                ModHelperPanel bar = daily1Panel.AddPanel(new Info("Panel", (dsize - dsize / 2) - 2580 / 2, 60, dsize, 140), VanillaSprites.BlueInsertPanel);
                ModHelperText questPercent = daily1Panel.AddText(new Info("questPercent", 0, 60, 2800, 150), Mathf.Round(Mathf.ClampToFloat(dpercent)) + "%", 80, TextAlignmentOptions.Center);
                ModHelperText completionNumber = daily1Panel.AddText(new Info("completionNumber", -695, -90, 1400, 150), dcompletionNum, 80, TextAlignmentOptions.MidlineLeft);
                ModHelperText rewardText = daily1Panel.AddText(new Info("rewardText", 695, -90, 1400, 150), "+" + AncientMonkey.mod.daily3[2] + " Ancient Pieces", 80, TextAlignmentOptions.MidlineRight);
                ModHelperButton claimRewardButton = null;
                ModHelperText claimRewardButtonText = null;
                claimRewardButton = daily1Panel.AddButton(new Info("claimRewardButton", 0, -200, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                    if (dpercent >= 100 && !(bool)AncientMonkey.mod.daily3[3])
                    {
                        AncientMonkey.mod.daily3[3] = true;
                        AncientMonkey.mod.AncientPiece += (int)AncientMonkey.mod.daily3[2];
                        LoadQuestPanel();

                    }
                }));
                claimRewardButtonText = claimRewardButton.AddText(new Info("claimRewardButtonText", 0, 0, 700, 160), "Claim", 60);
                if (dpercent >= 100)
                {
                    claimRewardButton.Image.SetSprite(VanillaSprites.GreenBtnLong);
                }
                if ((bool)AncientMonkey.mod.daily3[3])
                {
                    claimRewardButtonText.SetText("Claimed");
                    claimRewardButton.Image.SetSprite(VanillaSprites.YellowBtnLong);
                }
                CenterPanel.AddScrollContent(daily1Panel);
            }

            var questsPanel = ModHelperPanel.Create(new Info("questsPanel", 0, 0, 2800, 150), VanillaSprites.GreyInsertPanel);
            ModHelperText questsPanelText = questsPanel.AddText(new Info("questsPanelText", 0, 0, 2800, 150), "Quests", 110, TextAlignmentOptions.Center);
            CenterPanel.AddScrollContent(questsPanel);

            foreach (QuestTemplate quest in GetContent<QuestTemplate>())
            {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 600), VanillaSprites.BlueInsertPanel);
               
                double percent = 0f;
                float size = 0f;
                string completionNum = "";
                if (quest.QuestGoal == QuestTemplate.Goal.BloonsPopped)
                {
                     percent = AncientMonkey.mod.BloonsPopped * 100 / quest.GoalCountRequired;
                     if (percent >= 100)
                     {
                        percent = 100;
                     }
                     size = 2580 * Mathf.ClampToFloat(percent) / 100;
                     completionNum = "Bloons Popped: " + TextManager.ConvertIntToText((long) Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.BloonsPopped))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(quest.GoalCountRequired)));
                }
                if (quest.QuestGoal == QuestTemplate.Goal.CashSpent)
                {
                    percent = AncientMonkey.mod.CashSpent * 100 / quest.GoalCountRequired;
                    if (percent >= 100)
                    {
                        percent = 100;
                    }
                    size = 2580 * Mathf.ClampToFloat(percent) / 100;
                    completionNum = "Cash Spent: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.CashSpent))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(quest.GoalCountRequired)));
                }
                if (quest.QuestGoal == QuestTemplate.Goal.WeaponsBought)
                {
                    percent = AncientMonkey.mod.WeaponsBought * 100 / quest.GoalCountRequired;
                    if (percent >= 100)
                    {
                        percent = 100;
                    }
                    size = 2580 * Mathf.ClampToFloat(percent) / 100;
                    completionNum = "Weapons Bought: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.WeaponsBought))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(quest.GoalCountRequired)));
                }
                if (quest.QuestGoal == QuestTemplate.Goal.AbilityBought)
                {
                    percent = AncientMonkey.mod.AbilityBought * 100 / quest.GoalCountRequired;
                    if (percent >= 100)
                    {
                        percent = 100;
                    }
                    size = 2580 * Mathf.ClampToFloat(percent) / 100;
                    completionNum = "Ability Bought: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.AbilityBought))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(quest.GoalCountRequired)));
                }
                if (quest.QuestGoal == QuestTemplate.Goal.StrongerBought)
                {
                    percent = AncientMonkey.mod.StrongerWeaponsBought * 100 / quest.GoalCountRequired;
                    if (percent >= 100)
                    {
                        percent = 100;
                    }
                    size = 2580 * Mathf.ClampToFloat(percent) / 100;
                    completionNum = "Stronger Weapons Bought: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.StrongerWeaponsBought))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(quest.GoalCountRequired)));
                }
                if (quest.QuestGoal == QuestTemplate.Goal.UpgradesBought)
                {
                    percent = AncientMonkey.mod.UpgradesBought * 100 / quest.GoalCountRequired;
                    if (percent >= 100)
                    {
                        percent = 100;
                    }
                    size = 2580 * Mathf.ClampToFloat(percent) / 100;
                    completionNum = "Upgrades Bought: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.UpgradesBought))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(quest.GoalCountRequired)));
                }
                if (quest.QuestGoal == QuestTemplate.Goal.RoundCleared)
                {
                    percent = AncientMonkey.mod.RoundsCleared * 100 / quest.GoalCountRequired;
                    if (percent >= 100)
                    {
                        percent = 100;
                    }
                    size = 2580 * Mathf.ClampToFloat(percent) / 100;
                    completionNum = "Rounds Cleared: " + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(AncientMonkey.mod.RoundsCleared))) + "/" + TextManager.ConvertIntToText((long)Mathf.Round(Mathf.ClampToFloat(quest.GoalCountRequired)));
                }
                ModHelperText QuestName = panel.AddText(new Info("QuestName", 0, 225, 2800, 150), quest.QuestName, 110, TextAlignmentOptions.Center);
                ModHelperPanel barBG = panel.AddPanel(new Info("Panel", 0, 60, 2600, 160), VanillaSprites.GreyInsertPanel);
                ModHelperPanel bar = panel.AddPanel(new Info("Panel", (size - size / 2) - 2580 / 2, 60, size, 140), VanillaSprites.BlueInsertPanel);
                ModHelperText questPercent = panel.AddText(new Info("questPercent", 0, 60, 2800, 150), Mathf.Round(Mathf.ClampToFloat(percent)) + "%", 80, TextAlignmentOptions.Center);
                ModHelperText completionNumber = panel.AddText(new Info("completionNumber", -695, -90, 1400, 150), completionNum, 80, TextAlignmentOptions.MidlineLeft);
                ModHelperText rewardText = panel.AddText(new Info("rewardText", 695, -90, 1400, 150), "+" + quest.Reward + " Ancient Pieces", 80, TextAlignmentOptions.MidlineRight);
                ModHelperButton claimRewardButton = null;
                ModHelperText claimRewardButtonText = null;
                claimRewardButton = panel.AddButton(new Info("claimRewardButton", 0, -200, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                    if (percent >= 100 && !quest.Cleared)
                    {
                        quest.Cleared = true;
                        AncientMonkey.mod.AncientPiece += quest.Reward;
                        LoadQuestPanel();
                    }
                }));
                claimRewardButtonText = claimRewardButton.AddText(new Info("claimRewardButtonText", 0, 0, 700, 160), "Claim", 60);
                if (percent >= 100)
                {
                    claimRewardButton.Image.SetSprite(VanillaSprites.GreenBtnLong);
                }
                if (quest.Cleared)
                {
                    claimRewardButtonText.SetText("Claimed");
                    claimRewardButton.Image.SetSprite(VanillaSprites.YellowBtnLong);
                }
                CenterPanel.AddScrollContent(panel);
            }
        }
        public void LoadUpgradePanel()
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            var topScrollPanel = ModHelperScrollPanel.Create(new Info("topScrollPanel", 0, 0, 3000, 1000), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 0, 0);
            var bottomScrollPanel = ModHelperScrollPanel.Create(new Info("bottomScrollPanel", 0, 0, 3000, 1000), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 0, 0);
            CenterPanel.AddScrollContent(topScrollPanel);

            var upgradeCount = 0;
            var cost = 0;
            for (int i = 0; i < 25; i++)
            {
                cost++;
                upgradeCount++;
                var panelCost = ModHelperPanel.Create(new Info("panelCost", 0, 0, 3000, 150), VanillaSprites.BlueInsertPanel);
                panelCost.AddText(new Info("cost", 0, 0, 1000, 150), "Ancient Pieces: " + cost, 80, TextAlignmentOptions.Center);
                panelCost.AddText(new Info("info", 0, 0, 2800, 150), "+5% Cost Reduction(All)", 80, TextAlignmentOptions.Left);
                if (upgradeCount <= AncientMonkey.mod.LeftUpgradesBought)
                {
                    var BoughtButton = panelCost.AddButton(new Info("BoughtButton", 755, 0, 400, 120), VanillaSprites.YellowBtnLong, new System.Action(() => {
                    }));
                    var BoughtButtonText = BoughtButton.AddText(new Info("BoughtButtonText", 0, 0, 700, 160), "Bought", 60);
                }
                else if (upgradeCount == AncientMonkey.mod.LeftUpgradesBought + 1)
                {
                    var cost2 = cost;
                    if (AncientMonkey.mod.AncientPiece >= cost) 
                    {
                        var BuyButton = panelCost.AddButton(new Info("BuyButton", 755, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                            AncientMonkey.mod.LeftUpgradesBought++;
                            AncientMonkey.mod.AncientPiece -= cost2;
                            AncientMonkey.mod.CostReductionUpgradeBought++;
                            ModHelper.Log<AncientMonkey>(AncientMonkey.mod.AncientPiece);
                            LoadUpgradePanel();
                        }));
                        var BuyButtonText = BuyButton.AddText(new Info("BuyButtonText", 0, 0, 700, 160), "Buy", 60);
                    }
                    else
                    {
                        var BuyButton = panelCost.AddButton(new Info("BuyButton", 755, 0, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                        }));
                        var BuyButtonText = BuyButton.AddText(new Info("BuyButtonText", 0, 0, 700, 160), "Buy", 60);
                    }
                }
                else
                {
                    var LockedBtn = panelCost.AddButton(new Info("LockedBtn", 755, 0, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                    }));
                    var LockedBtnText = LockedBtn.AddText(new Info("LockedBtnText", 0, 0, 700, 160), "Locked", 60);
                }
                topScrollPanel.AddScrollContent(panelCost);

                cost++;
                upgradeCount++;
                var panelLuck = ModHelperPanel.Create(new Info("panelLuck", 0, 0, 3000, 150), VanillaSprites.BlueInsertPanel);
                panelLuck.AddText(new Info("cost", 0, 0, 1000, 150), "Ancient Pieces: " + cost, 80, TextAlignmentOptions.Center);
                panelLuck.AddText(new Info("info", 0, 0, 2800, 150), "+5% Luck Increase(All)", 80, TextAlignmentOptions.Left);
                if (upgradeCount <= AncientMonkey.mod.LeftUpgradesBought)
                {
                    var BoughtButton = panelLuck.AddButton(new Info("BoughtButton", 755, 0, 400, 120), VanillaSprites.YellowBtnLong, new System.Action(() => {
                    }));
                    var BoughtButtonText = BoughtButton.AddText(new Info("BoughtButtonText", 0, 0, 700, 160), "Bought", 60);
                }
                else if (upgradeCount == AncientMonkey.mod.LeftUpgradesBought + 1)
                {
                    var cost2 = cost;
                    if (AncientMonkey.mod.AncientPiece >= cost)
                    {
                        var BuyButton = panelLuck.AddButton(new Info("BuyButton", 755, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                            AncientMonkey.mod.LeftUpgradesBought++;
                            AncientMonkey.mod.AncientPiece -= cost2;
                            AncientMonkey.mod.LuckIncreaseUpgradeBought++;
                            LoadUpgradePanel();
                        }));
                        var BuyButtonText = BuyButton.AddText(new Info("BuyButtonText", 0, 0, 700, 160), "Buy", 60);
                    }
                    else
                    {
                        var BuyButton = panelLuck.AddButton(new Info("BuyButton", 755, 0, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                        }));
                        var BuyButtonText = BuyButton.AddText(new Info("BuyButtonText", 0, 0, 700, 160), "Buy", 60);
                    }
                }
                else
                {
                    var LockedBtn = panelLuck.AddButton(new Info("LockedBtn", 755, 0, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                    }));
                    var LockedBtnText = LockedBtn.AddText(new Info("LockedBtnText", 0, 0, 700, 160), "Locked", 60);
                }
                topScrollPanel.AddScrollContent(panelLuck);
            }
            /*  var epicWeaponsPanel = ModHelperPanel.Create(new Info("epicWeaponsPanel", 0, 0, 3000, 150), VanillaSprites.BlueInsertPanel);
              epicWeaponsPanel.AddText(new Info("cost", 0, 0, 1000, 150), "Ancient Pieces: 1", 80, TextAlignmentOptions.Center);
              epicWeaponsPanel.AddText(new Info("info", 0, 0, 2800, 150), "Epic Weapon Box", 80, TextAlignmentOptions.Left);
              if (AncientMonkey.mod.AncientPiece >= 1)
              {
                  var BuyButton = epicWeaponsPanel.AddButton(new Info("BuyButton", 755, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                      AncientMonkey.mod.EpicWeaponsBoxCount++;
                      AncientMonkey.mod.AncientPiece -= 1;
                      LoadUpgradePanel();
                  }));
                  var BuyButtonText = BuyButton.AddText(new Info("BuyButtonText", 0, 0, 700, 160), "Buy", 60);
              }
              else
              {
                  var BuyButton = epicWeaponsPanel.AddButton(new Info("BuyButton", 755, 0, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => {
                  }));
                  var BuyButtonText = BuyButton.AddText(new Info("BuyButtonText", 0, 0, 700, 160), "Buy", 60);
              }*/
            var epicWeaponsPanel = ModHelperPanel.Create(new Info("epicWeaponsPanel", 0, 0, 3000, 150), VanillaSprites.BlueInsertPanel);
            epicWeaponsPanel.AddText(new Info("info", 0, 0, 2800, 150), "Coming Soon: Weapons Box Shop", 80, TextAlignmentOptions.Left);
            bottomScrollPanel.AddScrollContent(epicWeaponsPanel);
              CenterPanel.AddScrollContent(bottomScrollPanel); 
           
        }
        public void LoadInventoryPanel()
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            if (AncientMonkey.mod.AncientPiece > 0)
            {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.GreyInsertPanel);
                ModHelperText itemName = panel.AddText(new Info("itemName", 0, 0, 2800, 150), "Ancient Pieces:", 80, TextAlignmentOptions.MidlineLeft);
                ModHelperPanel itemCountBG = panel.AddPanel(new Info("itemCountBG", 0,0,350,140), VanillaSprites.BlueInsertPanel);
                ModHelperText itemCount = panel.AddText(new Info("itemCount", 0, 0, 350, 150), TextManager.ConvertIntToText(AncientMonkey.mod.AncientPiece), 80, TextAlignmentOptions.Center);
                CenterPanel.AddScrollContent(panel);
            }
          /*  if (AncientMonkey.mod.EpicWeaponsBoxCount > 0)
            {
                var panel = ModHelperPanel.Create(new Info("panel", 0, 0, 2800, 150), VanillaSprites.GreyInsertPanel);
                ModHelperText itemName = panel.AddText(new Info("itemName", 0, 0, 2800, 150), "Ancient Pieces:", 80, TextAlignmentOptions.MidlineLeft);
                ModHelperPanel itemCountBG = panel.AddPanel(new Info("itemCountBG", 0, 0, 350, 140), VanillaSprites.BlueInsertPanel);
                ModHelperText itemCount = panel.AddText(new Info("itemCount", 0, 0, 350, 150), TextManager.ConvertIntToText(AncientMonkey.mod.EpicWeaponsBoxCount), 80, TextAlignmentOptions.Center);
                CenterPanel.AddScrollContent(panel);
                var BuyButton = panel.AddButton(new Info("panel", 755, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                    AncientMonkey.mod.EpicWeaponsBoxCount--;
                    LoadInventoryPanel();
                }));
                var BuyButtonText = BuyButton.AddText(new Info("BuyButtonText", 0, 0, 700, 160), "Buy", 60);
            } */
        }
        public void LoadWeaponsLuckSettings(bool reset = false)
        {
            CenterPanel.ScrollContent.transform.DestroyAllChildren();

            CenterPanel.AddScrollContent(CreateResetAllButton());

            if ((bool)Settings.settingsValue["Cheats"])
            {
                CenterPanel.AddScrollContent(CreateSetting("BaseRareChance", "Base Rare Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseEpicChance", "Base Epic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseLegendaryChance", "Base Legendary Chance: ", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseExoticChance", "Base Exotic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseRareChanceUntilEpicChance", "Base Rare Chance Until Epic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseEpicChanceUntilLegendaryChance", "Base Epic Chance Until Legendary Chance: ", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseLegendaryChanceUntilExoticChance", "Base Legendary Chance Until Exotic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("BaseRareChanceDecrease", "Base Rare Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("BaseEpicChanceDecrease", "Base Epic Chance Decrease: ", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("BaseLegendaryChanceDecrease", "Base Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("BaseExoticChanceDecrease", "Base Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));

                CenterPanel.AddScrollContent(CreateSetting("Upgrade1EpicChance", "Upgrade 1 Epic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1LegendaryChance", "Upgrade 1 Legendary Chance: ", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1ExoticChance", "Upgrade 1 Exotic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1GodlyChance", "Upgrade 1 Godly Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1EpicChanceUntilLegendaryChance", "Upgrade 1 Epic Chance Until Legendary Chance: ", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1LegendaryChanceUntilExoticChance", "Upgrade 1 Legendary Chance Until Exotic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1ExoticChanceUntilGodlyChance", "Upgrade 1 Legendary Chance Until Exotic Chance:", "intSlider", reset, 0f, 100f, 1f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1EpicChanceDecrease", "Upgrade 1 Epic Chance Decrease: ", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1LegendaryChanceDecrease", "Upgrade 1 Legendary Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1ExoticChanceDecrease", "Upgrade 1 Exotic Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
                CenterPanel.AddScrollContent(CreateSetting("Upgrade1GodlyChanceDecrease", "Upgrade 1 Godly Chance Decrease:", "floatSlider", reset, 0f, 100f, 0.01f));
            }
            else
            {
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
                if (loadedPanel == "WeaponsLuckSettings")
                {
                    LoadWeaponsLuckSettings(true);
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
                boolValueText = boolValue.AddText(new Info("boolValueText", 0, 0, 700, 160), "True", 60);
                if (!(bool)dictValue)
                {
                    boolValue.Image.SetSprite(VanillaSprites.RedBtnLong);
                    boolValueText.Text.SetText("False");
                }
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
                if(loadedPanel == "GeneralSettings")
                {
                    LoadGeneralSettings();
                }
                if (loadedPanel == "Upgrade1Settings")
                {
                    LoadUpgrade1Settings();
                }
                if (loadedPanel == "WeaponsLuckSettings")
                {
                    LoadWeaponsLuckSettings();
                }
            }));
           
            return panel;
        }
        public void LoadLeftPanelContent()
        {
            LeftPanel.ScrollContent.transform.DestroyAllChildren();
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


            ModHelperButton questPanel = ModHelperButton.Create(new Info("questPanel", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "QuestPanel")
                {
                    loadedPanel = "QuestPanel";
                    LoadLeftPanelContent();
                    SetTopPanelText("Quests", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadQuestPanel();
                }
            }));
            if (loadedPanel == "QuestPanel")
            {
                questPanel.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText questPanelText = questPanel.AddText(new Info("questPanelText", 0, 0, 950, 170), "Quests", 94);
            LeftPanel.AddScrollContent(questPanel);

            ModHelperButton upgradePanel = ModHelperButton.Create(new Info("upgradePanel", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "UpgradePanel")
                {
                    loadedPanel = "UpgradePanel";
                    LoadLeftPanelContent();
                    SetTopPanelText("Upgrades", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadUpgradePanel();
                }
            }));
            if (loadedPanel == "UpgradePanel")
            {
                upgradePanel.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText upgradePanelText = upgradePanel.AddText(new Info("upgradePanelText", 0, 0, 950, 170), "Upgrades", 94);
            LeftPanel.AddScrollContent(upgradePanel);

            ModHelperButton inventoryPanel = ModHelperButton.Create(new Info("inventoryPanel", 0, 0, 950, 220), VanillaSprites.GreenBtnLong, new System.Action(() => {
                if (loadedPanel != "InventoryPanel")
                {
                    loadedPanel = "InventoryPanel";
                    LoadLeftPanelContent();
                    SetTopPanelText("Inventory", new Color(1, 1, 1), new Color(0, 0, 0));
                    LoadInventoryPanel();
                }
            }));
            if (loadedPanel == "InventoryPanel")
            {
                inventoryPanel.Image.SetSprite(VanillaSprites.BlueBtnLong);
            }
            ModHelperText InventoryPanelText = inventoryPanel.AddText(new Info("InventoryPanelText", 0, 0, 950, 170), "Inventory", 94);
            LeftPanel.AddScrollContent(inventoryPanel);
            /*
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
            */
        }
    }
  
}
