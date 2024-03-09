using MelonLoader;
using BTD_Mod_Helper;
using AncientMonkey;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using static Il2CppSystem.Globalization.TimeSpanParse;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using BTD_Mod_Helper;
using System;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Simulation.Towers;
using UnityEngine;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppSystem;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Behaviors;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity;

using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppSystem.IO;
using Il2CppAssets.Scripts.Simulation.Objects;
using UnityEngine.InputSystem.Utilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using System.Threading;
using Il2CppSystem.Runtime.InteropServices;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using BTD_Mod_Helper.Api.Enums;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppTMPro;
using Il2CppNinjaKiwi.Common;
using Il2CppAssets.Scripts.Unity.UI_New.Quests;
using Il2Cpp;
using System.Linq;
using MelonLoader;
using AncientMonkey.Weapons;
using Unity.XR.Oculus.Input;
using BTD_Mod_Helper.Api.Helpers;
using HarmonyLib;
using Harmony;
using Il2CppAssets.Scripts.Unity.Towers.Weapons;
using BTD_Mod_Helper.Api.ModOptions;
using UnityEngine.UIElements;
using Il2CppAssets.Scripts.Unity.Towers.Upgrades;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;

[assembly: MelonInfo(typeof(AncientMonkey.AncientMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace AncientMonkey;

public class AncientMonkey : BloonsTD6Mod
{
    internal static readonly ModSettingBool SandboxMode = new(false)
    {
        requiresRestart = true,
        icon = VanillaSprites.SandboxBtn,
        description = "Enable Sandbox Mode"
    };
    public static AncientMonkey mod;
    public float newWeaponCost = 250;
    public float baseNewWeaponCost = 250;
    public float rareChance = 85;
    public float epicChance = 100;
    public float legendaryChance = 100;
    public float exoticChance = 100;
    public float godlyChance = 100;
    public float rareStrongChance = 85;
    public float epicStrongChance = 100;
    public float legendaryStrongChance = 100;
    public float exoticStrongChance = 100;
    public float godlyStrongerChance = 100;
    public float strongerWeaponCost = 1100;
    public float baseStrongerWeaponCost = 1100;
    public float newAbilityCost = 6500;
    public float baseNewAbilityCost = 1750;
    public bool upgradeOpen = false;
    public bool selectingWeaponOpen = false;
    public bool mib = false;
    public float level = 0;
    public float rangeBoostSandbox = 1;
    public float attackSpeedBoostSandbox = 1;
    public float moneyBoostSandbox = 1;
    public int damageBoostSandbox = 0;
    public int pierceBoostSandbox = 0;

    public override void OnApplicationStart()
    {
       
        mod = this;
    
        foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
        {
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Common)
            {
                Common.CommonWpn.Add(weapon.WeaponName);
                Common.CommonImg.Add(weapon.Icon);
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Rare)
            {
                Rare.RareWpn.Add(weapon.WeaponName);
                Rare.RareImg.Add(weapon.Icon);
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Epic)
            {
                Epic.EpicWpn.Add(weapon.WeaponName);
                Epic.EpicImg.Add(weapon.Icon);
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Legendary)
            {
                Legendary.LegendaryWpn.Add(weapon.WeaponName);
                Legendary.LegendaryImg.Add(weapon.Icon);
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Exotic)
            {
                Exotic.ExoticWpn.Add(weapon.WeaponName);
                Exotic.ExoticImg.Add(weapon.Icon);
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Godly)
            {
                Godly.GodlyWpn.Add(weapon.WeaponName);
                Godly.GodlyImg.Add(weapon.Icon);
            }
        }
        foreach (var ability in ModContent.GetContent<AbilityTemplate>().OrderByDescending(c => c.mod == mod))
        {
            AbilityClass.AbilityName.Add(ability.AbilityName);
            AbilityClass.AbilityImg.Add(ability.Icon);
        }
    }
    public override void OnGameModelLoaded(GameModel model)
    {
        newWeaponCost = 250;
        rareChance = 90;
        epicChance = 100;
        rareStrongChance = 90;
        epicStrongChance = 100;
        legendaryStrongChance = 100;
        legendaryChance = 100;
        exoticChance = 100;
        exoticStrongChance = 100;
        baseNewWeaponCost = 250;
        strongerWeaponCost = 500;
        baseStrongerWeaponCost = 500;
        newAbilityCost = 6500;
        baseNewAbilityCost = 1750;
        upgradeOpen = false;
        selectingWeaponOpen = false;
        mib = false;       
        level = 0;
    }
    public override void OnTowerSold(Tower tower, float amount)
    {
        if (tower.towerModel.name.Contains("AncientMonkey"))
        {
            newWeaponCost = 250;
            rareChance = 90;
            epicChance = 100;
            rareStrongChance = 90;
            epicStrongChance = 100;
            legendaryStrongChance = 100;
            legendaryChance = 100;
            exoticChance = 100;
            exoticStrongChance = 100;
            baseNewWeaponCost = 250;
            strongerWeaponCost = 500;
            baseStrongerWeaponCost = 500;
            newAbilityCost = 6500;
            baseNewAbilityCost = 1750;
            upgradeOpen = false;
            selectingWeaponOpen = false;
            mib = false;
            level = 0;
        }
    }
    public override void OnRestart()
    {
        MenuUi.instance.CloseMenu();
    }
    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        if (tower.towerModel.name.Contains("AncientMonkey"))
        {
            newWeaponCost = 250;
            rareChance = 90;
            epicChance = 100;
            rareStrongChance = 90;
            epicStrongChance = 100;
            legendaryStrongChance = 100;
            legendaryChance = 100;
            exoticChance = 100;
            exoticStrongChance = 100;
            baseNewWeaponCost = 250;
            strongerWeaponCost = 500;
            baseStrongerWeaponCost = 500;
            newAbilityCost = 6500;
            baseNewAbilityCost = 1750;
            upgradeOpen = false;
            selectingWeaponOpen = false;
            mib = false;
            level = 0;
        }
    }
    public override void OnNewGameModel(GameModel result)
    {
        foreach (var tower in result.towerSet.ToList())
        {
            if (tower.name.Contains("AncientMonkey"))
            {
                tower.GetShopTowerDetails().towerCount = 1;
            }
        }
    }
    public override void OnTowerSelected(Tower tower)
    {
        if (tower.towerModel.name.Contains("AncientMonkey"))
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            MenuUi.CreateUpgradeMenu(rect, tower);
            upgradeOpen = true;
        }
    }
    public override void OnTowerDeselected(Tower tower)
    {
        if (tower.towerModel.name.Contains("AncientMonkey"))
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            upgradeOpen = false;
            if(MenuUi.instance)
            {
                MenuUi.instance.CloseMenu();
            }

        }
    }
    [RegisterTypeInIl2Cpp(false)]
    public class MenuUi : MonoBehaviour
    {
        public static MenuUi instance;

        public ModHelperInputField input;
        public void CloseMenu()
        {
            if(gameObject)
            {
                Destroy(gameObject);
            }
        }
        public void NewWeapon(Tower tower)
        {
            InGame game = InGame.instance;
            if (SandboxMode)
            {
                RectTransform rect = game.uiRect;
                MenuUi.NewWeaponPanel(rect, tower);
                MenuUi.instance.CloseMenu();
                return;
            }
            if (game.GetCash() >= mod.newWeaponCost)
            {
                game.AddCash(-mod.newWeaponCost);
                RectTransform rect = game.uiRect;
                mod.newWeaponCost += mod.baseNewWeaponCost;
                tower.worth += mod.newWeaponCost - mod.baseNewWeaponCost;
                mod.baseNewWeaponCost *= 1.06f;
                MenuUi.NewWeaponPanel(rect, tower);
                MenuUi.instance.CloseMenu();
            }
        }
        public void WeaponSelected(string Weapon, Tower tower)
        {
          
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            if(!SandboxMode)
            {
                Destroy(gameObject);
            }
            foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
            {
                if(weapon.WeaponName == Weapon)
                {
                    weapon.EditTower(tower);
                }
            }
            mod.rareChance -= 5f;
            mod.epicChance -= 1.45f;
            if (mod.epicChance <= 88)
            {
                mod.legendaryChance -= 0.85f;
            }
            if (mod.legendaryChance <= 91)
            {
                mod.exoticChance -= 0.50f;
            }
            if (mod.level == 1)
            {
                if (mod.exoticChance <= 94)
                {
                    mod.godlyChance -= 0.3f;
                }
            }
            mod.selectingWeaponOpen = false;
            if (mod.mib)
            {
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                foreach (var weaponModel in towerModel.GetDescendants<WeaponModel>().ToArray())
                {
                    if (weaponModel.projectile.HasBehavior<DamageModel>())
                    {
                        weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    }
                    if (weaponModel.projectile.HasBehavior<CreateProjectileOnContactModel>())
                    {
                        weaponModel.projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    }
                    if (weaponModel.projectile.HasBehavior<CreateProjectileOnExhaustFractionModel>())
                    {
                        weaponModel.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    }
                }
                tower.UpdateRootModel(towerModel);
            }
            if (mod.upgradeOpen == true && !SandboxMode)
            {
                CreateUpgradeMenu(rect, tower);
            }
        }
        public static ModHelperPanel CreateWeapon(WeaponTemplate weapon, Tower tower )
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
            var panel = ModHelperPanel.Create(new Info("WeaponContent" + weapon.WeaponName, 0, 0, 2250, 150), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText wpnName = panel.AddText(new Info("wpnName", -600, 0, 1000, 150), weapon.WeaponName, 80, TextAlignmentOptions.MidlineLeft);
            ModHelperText rarity = panel.AddText(new Info("rarity", 275, 0, 600, 150), weapon.WeaponRarity.ToString(), 80, TextAlignmentOptions.MidlineLeft);
            ModHelperImage image = panel.AddImage(new Info("image", -100, 0, 140, 140), weapon.Icon);
            ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { upgradeUi.WeaponSelected(weapon.WeaponName, tower);}) ) ;
            if(weapon.IsCamo)
            {
                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 460, 0, 120, 120), VanillaSprites.CamoBloonIcon);
            }
            if (weapon.IsLead)
            {
                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 580, 0, 120, 120), VanillaSprites.LeadBloonIcon);
            }
            ModHelperText selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Select", 60);
            return panel;
        }
        public static void SandBoxWeaponPanel(RectTransform rect, Tower tower)
        {
          
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelBlue);
            panel.transform.DestroyAllChildren();            
            ModHelperScrollPanel scrollPanel = panel.AddScrollPanel(new Info("scrollPanel", 0, 0, 2500, 1850), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 15, 50);
            ModHelperButton exit = panel.AddButton(new Info("exit", 1200, 900, 135, 135), VanillaSprites.RedBtn, new System.Action(() => { panel.DeleteObject(); tower.SetSelectionBlocked(false); if (mod.upgradeOpen == true){CreateUpgradeMenu(rect, tower);  }
            }));
            ModHelperText x = exit.AddText(new Info("x", 0, 0, 700, 160), "X", 80);

            for (int i = 1; i < 100; i++)
            {
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>())
                {
                    if (weapon.SandboxIndex == i)
                    {
                        scrollPanel.AddScrollContent(CreateWeapon(weapon, tower));
                    }
                }
            }
           
        }
       
        public static void NewWeaponPanel(RectTransform rect, Tower tower)
        {
            instance.CloseMenu();
            if(SandboxMode)
            {
                SandBoxWeaponPanel(rect, tower);
                return;
            }
          
            ModHelperPanel panel =  rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), VanillaSprites.BrownInsertPanel);
            if (mod.level == 1)
            {
                panel.SetInfo(new Info("Panel_", 2200, 1500, 3333, 1850, new UnityEngine.Vector2()));
            }
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText selectWpn = panel.AddText(new Info("selectWpn", 0, 800, 2500, 180), "Select New Weapon", 100);
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();

            if (mod.level == 1)
            {
                ModHelperPanel wpn1Panel = panel.AddPanel(new Info("wpn1Panel", 375, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                var num1 = rnd.Next(0, Rare.RareWpn.Count);
                var wpnSelected = Rare.RareWpn[num1];
                var imgSelected = Rare.RareImg[num1];
                ModHelperText rarityText1 = panel.AddText(new Info("rarityText1", -1300, 600, 800, 180), "Rare", 100);
                ModHelperText weaponText1 = panel.AddText(new Info("weaponText1", -1300, 500, 800, 180), wpnSelected, 75);
                ModHelperImage image1 = panel.AddImage(new Info("image1", -1300, 0, 400, 400), imgSelected);
                ModHelperButton selectWpnBtn1 = panel.AddButton(new Info("selectWpnBtn1", -1300, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected, tower)));
                ModHelperText selectWpn1 = selectWpnBtn1.AddText(new Info("selectWpn1", 0, 0, 700, 160), "Select", 70);
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (weapon.WeaponName == wpnSelected)
                    {
                        if (weapon.IsCamo && !weapon.IsLead)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -1025, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                        }
                        if (weapon.IsLead && !weapon.IsCamo)
                        {
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -1025, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                        if (weapon.IsLead && weapon.IsCamo)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -1025, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -1025, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                    }
                }
            }
            else
            {
                ModHelperPanel wpn1Panel = panel.AddPanel(new Info("wpn1Panel", 375, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                var num1 = rnd.Next(0, Common.CommonWpn.Count);
                var wpnSelected = Common.CommonWpn[num1];
                var imgSelected = Common.CommonImg[num1];
                ModHelperText rarityText1 = panel.AddText(new Info("rarityText1", -875, 600, 800, 180), "Common", 100);
                ModHelperText weaponText1 = panel.AddText(new Info("weaponText1", -875, 500, 800, 180), wpnSelected, 75);
                ModHelperImage image1 = panel.AddImage(new Info("image1", -875, 0, 400, 400), imgSelected);
                ModHelperButton selectWpnBtn1 = panel.AddButton(new Info("selectWpnBtn1", -875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected, tower)));
                ModHelperText selectWpn1 = selectWpnBtn1.AddText(new Info("selectWpn1", 0, 0, 700, 160), "Select", 70);
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if(weapon.WeaponName == wpnSelected)
                    {
                        if(weapon.IsCamo && !weapon.IsLead)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                        }
                        if (weapon.IsLead && !weapon.IsCamo)
                        {
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -600, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                        if (weapon.IsLead && weapon.IsCamo)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -600, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                    }
                }
            }
          
            var rarityNum = rnd.Next(1, 100);
            var rarity = "Common";
            if (mod.level == 1)
            {
                rarity = "Rare";
                if (rarityNum >= mod.epicChance)
                {
                    rarity = "Epic";
                }
                if (rarityNum >= mod.legendaryChance)
                {
                    rarity = "Legendary";
                }
            }
            else
            {
                if (rarityNum >= mod.rareChance)
                {
                    rarity = "Rare";
                }
                if (rarityNum >= mod.epicChance)
                {
                    rarity = "Epic";
                }
            }
            if (rarity == "Common")
            {
                var num2 = rnd.Next(0, Common.CommonWpn.Count);
                var wpnSelected2 = Common.CommonWpn[num2];
                var imgSelected2 = Common.CommonImg[num2];
                ModHelperPanel wpncm2Panel = panel.AddPanel(new Info("wpn2Pane2", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 0, 600, 800, 180), "Common", 100);
                ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 0, 500, 800, 180), wpnSelected2, 75);
                ModHelperImage image2 = panel.AddImage(new Info("image2", 0, 0, 400, 400), imgSelected2);
                ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (weapon.WeaponName == wpnSelected2)
                    {
                        if (weapon.IsCamo && !weapon.IsLead)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                        }
                        if (weapon.IsLead && !weapon.IsCamo)
                        {
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 275, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                        if (weapon.IsLead && weapon.IsCamo)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 275, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                    }
                }
            }
            if (rarity == "Rare")
            {
                var num2 = rnd.Next(0, Rare.RareWpn.Count);
                var wpnSelected2 = Rare.RareWpn[num2];
                var imgSelected2 = Rare.RareImg[num2];
                ModHelperPanel wpnra2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);

                if (mod.level == 1)
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", -425, 600, 800, 180), "Rare", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", -425, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", -425, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", -425, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                else
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 0, 600, 800, 180), "Rare", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 0, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 0, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 275, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 275, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
            }
            if (rarity == "Epic")
            {
              
                var num2 = rnd.Next(0, Epic.EpicWpn.Count);
                var wpnSelected2 = Epic.EpicWpn[num2];
                var imgSelected2 = Epic.EpicImg[num2];
                ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                if (mod.level == 1)
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", -425, 600, 800, 180), "Epic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", -425, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", -425, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", -425, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                else
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 0, 600, 800, 180), "Epic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 0, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 0, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 275, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 275, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
            }
            if (rarity == "Legendary")
            {

                var num2 = rnd.Next(0, Legendary.LegendaryWpn.Count);
                var wpnSelected2 = Legendary.LegendaryWpn[num2];
                var imgSelected2 = Legendary.LegendaryImg[num2];
                ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", -425, 600, 800, 180), "Legendary", 100);
                ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", -425, 500, 800, 180), wpnSelected2, 75);
                ModHelperImage image2 = panel.AddImage(new Info("image2", -425, 0, 400, 400), imgSelected2);
                ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", -425, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (weapon.WeaponName == wpnSelected2)
                    {
                        if (weapon.IsCamo && !weapon.IsLead)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                        }
                        if (weapon.IsLead && !weapon.IsCamo)
                        {
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                        if (weapon.IsLead && weapon.IsCamo)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", -150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", -150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                    }
                }
            }
            var rarityNum2 = rnd.Next(1, 100);
            var rarity2 = "Common";
            if (mod.level == 1)
            {
                rarity2 = "Rare";
                if (rarityNum2 >= mod.epicChance)
                {
                    rarity2 = "Epic";
                }
                if (rarityNum2 >= mod.legendaryChance)
                {
                    rarity2 = "Legendary";
                }
                if (rarityNum2 >= mod.legendaryChance)
                {
                    rarity2 = "Legendary";
                }
                if (rarityNum2 >= mod.exoticChance)
                {
                    rarity2 = "Exotic";
                }
                if(rarityNum2 >= mod.godlyChance)
                {
                    rarity2 = "Godly";
                }
            }
            else
            {
                if (rarityNum2 >= mod.rareChance)
                {
                    rarity2 = "Rare";
                }
                if (rarityNum2 >= mod.epicChance)
                {
                    rarity2 = "Epic";
                }
                if (rarityNum2 >= mod.legendaryChance)
                {
                    rarity2 = "Legendary";
                }
                if (rarityNum2 >= mod.exoticChance)
                {
                    rarity2 = "Exotic";
                }
            }
           

            if (rarity2 == "Common")
            {
                var num2 = rnd.Next(0, Common.CommonWpn.Count);
                var wpnSelected2 = Common.CommonWpn[num2];
                var imgSelected2 = Common.CommonImg[num2];
                ModHelperPanel wpncm2Panel = panel.AddPanel(new Info("wpn2Pane2", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Common", 100);
                ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 875, 500, 800, 180), wpnSelected2, 75);
                ModHelperImage image2 = panel.AddImage(new Info("image2", 875, 0, 400, 400), imgSelected2);
                ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (weapon.WeaponName == wpnSelected2)
                    {
                        if (weapon.IsCamo && !weapon.IsLead)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                        }
                        if (weapon.IsLead && !weapon.IsCamo)
                        {
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                        if (weapon.IsLead && weapon.IsCamo)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                    }
                }
            }
            if (rarity2 == "Rare")
            {
                var num2 = rnd.Next(0, Rare.RareWpn.Count);
                var wpnSelected2 = Rare.RareWpn[num2];
                var imgSelected2 = Rare.RareImg[num2];
                ModHelperPanel wpnra2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);

                if (mod.level == 1)
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Rare", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 450, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 450, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                else
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Rare", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 875, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 875, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
            }
            if (rarity2 == "Epic")
            {

                var num2 = rnd.Next(0, Epic.EpicWpn.Count);
                var wpnSelected2 = Epic.EpicWpn[num2];
                var imgSelected2 = Epic.EpicImg[num2];
                ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                if (mod.level == 1)
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Epic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 450, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 450, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                else
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Epic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 875, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 875, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
               

            }
            if (rarity2 == "Legendary")
            {

                var num2 = rnd.Next(0, Legendary.LegendaryWpn.Count);
                var wpnSelected2 = Legendary.LegendaryWpn[num2];
                var imgSelected2 = Legendary.LegendaryImg[num2];
                ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                if (mod.level == 1)
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Legendary", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 450, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 450, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                else
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Legendary", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 875, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 875, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
               
            }
            if (rarity2 == "Exotic")
            {

                var num2 = rnd.Next(0, Exotic.ExoticWpn.Count);
                var wpnSelected2 = Exotic.ExoticWpn[num2];
                var imgSelected2 = Exotic.ExoticImg[num2];
                ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelWhiteSmall);
                if (mod.level == 1)
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Exotic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 450, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 450, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                else
                {
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Exotic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 875, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 875, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1150, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1150, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
              
            }
            if (rarity2 == "Godly")
            {

                var num2 = rnd.Next(0, Godly.GodlyWpn.Count);
                var wpnSelected2 = Godly.GodlyWpn[num2];
                var imgSelected2 = Godly.GodlyImg[num2];
                ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelSilver);
                ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Godly", 100);
                ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 450, 500, 800, 180), wpnSelected2, 75);
                ModHelperImage image2 = panel.AddImage(new Info("image2", 450, 0, 400, 400), imgSelected2);
                ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (weapon.WeaponName == wpnSelected2)
                    {
                        if (weapon.IsCamo && !weapon.IsLead)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                        }
                        if (weapon.IsLead && !weapon.IsCamo)
                        {
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                        if (weapon.IsLead && weapon.IsCamo)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 725, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 725, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                    }
                }
            }
            if (mod.level == 1)
            {
                var rarityNum3 = rnd.Next(1, 100);
                var rarity3 = "Rare";
                if (rarityNum3 >= mod.epicChance)
                {
                    rarity3 = "Epic";
                }
                if (rarityNum3 >= mod.legendaryChance)
                {
                    rarity3 = "Legendary";
                }
                if (rarityNum3 >= mod.legendaryChance)
                {
                    rarity3 = "Legendary";
                }
                if (rarityNum3 >= mod.exoticChance)
                {
                    rarity3 = "Exotic";
                }
                if (rarityNum3 >= mod.godlyChance)
                {
                    rarity3 = "Godly";
                }
                if (rarity3 == "Rare")
                {
                    var num2 = rnd.Next(0, Rare.RareWpn.Count);
                    var wpnSelected2 = Rare.RareWpn[num2];
                    var imgSelected2 = Rare.RareImg[num2];
                    ModHelperPanel wpnra2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Rare", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 1325, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 1325, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                if (rarity3 == "Epic")
                {

                    var num2 = rnd.Next(0, Epic.EpicWpn.Count);
                    var wpnSelected2 = Epic.EpicWpn[num2];
                    var imgSelected2 = Epic.EpicImg[num2];
                    ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Epic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 1325, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 1325, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                if (rarity3 == "Legendary")
                {
                    var num3 = rnd.Next(0, Legendary.LegendaryWpn.Count);
                    var wpnSelected3 = Legendary.LegendaryWpn[num3];
                    var imgSelected3 = Legendary.LegendaryImg[num3];
                    ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Legendary", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 1325, 500, 800, 180), wpnSelected3, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 1325, 0, 400, 400), imgSelected3);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected3, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected3)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                if (rarity3 == "Exotic")
                {

                    var num2 = rnd.Next(0, Exotic.ExoticWpn.Count);
                    var wpnSelected2 = Exotic.ExoticWpn[num2];
                    var imgSelected2 = Exotic.ExoticImg[num2];
                    ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelWhiteSmall);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Exotic", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 1325, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 1325, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
                if (rarity3 == "Godly")
                {
                    var num2 = rnd.Next(0,Godly.GodlyWpn.Count);
                    var wpnSelected2 = Godly.GodlyWpn[num2];
                    var imgSelected2 = Godly.GodlyImg[num2];
                    ModHelperPanel wpnEp2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelSilver);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Godly", 100);
                    ModHelperText weaponText2 = panel.AddText(new Info("weaponText2", 1325, 500, 800, 180), wpnSelected2, 75);
                    ModHelperImage image2 = panel.AddImage(new Info("image2", 1325, 0, 400, 400), imgSelected2);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(wpnSelected2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                    {
                        if (weapon.WeaponName == wpnSelected2)
                        {
                            if (weapon.IsCamo && !weapon.IsLead)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            }
                            if (weapon.IsLead && !weapon.IsCamo)
                            {
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                            if (weapon.IsLead && weapon.IsCamo)
                            {
                                ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 1600, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                                ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 1600, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                            }
                        }
                    }
                }
            }
        }
        public static void SandBoxStrongWeaponPanel(RectTransform rect, Tower tower)
        {
          
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 1250, 1500, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelBlue);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            panel.transform.DestroyAllChildren();
            if (mod.damageBoostSandbox < 0)
            {
                mod.damageBoostSandbox = 0;
            }
            if (mod.pierceBoostSandbox < 0)
            {
                mod.pierceBoostSandbox = 0;
            }
            if (mod.rangeBoostSandbox <= 0.9)
            {
                mod.rangeBoostSandbox = 1f;
            }
            if (mod.attackSpeedBoostSandbox <= 0)
            {
                mod.attackSpeedBoostSandbox = 0.05f;
            }
            if (mod.attackSpeedBoostSandbox >= 1.05f)
            {
                mod.attackSpeedBoostSandbox = 1f;
            }
            if (mod.moneyBoostSandbox <= 0.9)
            {
                mod.moneyBoostSandbox = 1f;
            }

            mod.rangeBoostSandbox = Mathf.Round(mod.rangeBoostSandbox * 10) / 10;
            mod.attackSpeedBoostSandbox = Mathf.Round(mod.attackSpeedBoostSandbox * 100) / 100;
            mod.moneyBoostSandbox = Mathf.Round(mod.moneyBoostSandbox * 10) / 10;

            panel.AddText(new Info("text", 300, 350, 1200, 150), "Damage Boost: " + mod.damageBoostSandbox, 75, TextAlignmentOptions.TopLeft);
            panel.AddButton(new Info("button1", -400, 430, 100, 100), VanillaSprites.AddMoreBtn, new System.Action(() => { mod.damageBoostSandbox += 1; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));
            panel.AddButton(new Info("button2", -400, 350, 100, 100), VanillaSprites.AddRemoveBtn, new System.Action(() => { mod.damageBoostSandbox -= 1; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));

            panel.AddText(new Info("text2", 300, 150, 1200, 150), "Pierce Boost: " + mod.pierceBoostSandbox, 75, TextAlignmentOptions.TopLeft);
            panel.AddButton(new Info("button3", -400, 230, 100, 100), VanillaSprites.AddMoreBtn, new System.Action(() => { mod.pierceBoostSandbox += 1; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));
            panel.AddButton(new Info("button4", -400, 150, 100, 100), VanillaSprites.AddRemoveBtn, new System.Action(() => { mod.pierceBoostSandbox -= 1; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));

            panel.AddText(new Info("text2", 300, -50, 1200, 150), "Range Boost: " + mod.rangeBoostSandbox, 75, TextAlignmentOptions.TopLeft);
            panel.AddButton(new Info("button3", -400, 30, 100, 100), VanillaSprites.AddMoreBtn, new System.Action(() => { mod.rangeBoostSandbox += 0.1f; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));
            panel.AddButton(new Info("button4", -400, -50, 100, 100), VanillaSprites.AddRemoveBtn, new System.Action(() => { mod.rangeBoostSandbox -= 0.1f; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));

            panel.AddText(new Info("text2", 300, -250, 1200, 150), "Attack Speed Boost: " + mod.attackSpeedBoostSandbox, 75, TextAlignmentOptions.TopLeft);
            panel.AddButton(new Info("button3", -400, -170, 100, 100), VanillaSprites.AddMoreBtn, new System.Action(() => { mod.attackSpeedBoostSandbox -= 0.05f; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));
            panel.AddButton(new Info("button4", -400, -250, 100, 100), VanillaSprites.AddRemoveBtn, new System.Action(() => { mod.attackSpeedBoostSandbox += 0.05f; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));

            panel.AddText(new Info("text2", 300, -450, 1200, 150), "Money Boost: " + mod.moneyBoostSandbox, 75, TextAlignmentOptions.TopLeft);
            panel.AddButton(new Info("button3", -400, -370, 100, 100), VanillaSprites.AddMoreBtn, new System.Action(() => { mod.moneyBoostSandbox += 0.1f; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));
            panel.AddButton(new Info("button4", -400, -450, 100, 100), VanillaSprites.AddRemoveBtn, new System.Action(() => { mod.moneyBoostSandbox -= 0.1f; panel.DeleteObject(); ; SandBoxStrongWeaponPanel(rect, tower); }));

            ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 0, -600, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { upgradeUi.StrongWpnSelected(mod.damageBoostSandbox, mod.pierceBoostSandbox, mod.attackSpeedBoostSandbox, mod.rangeBoostSandbox, mod.moneyBoostSandbox, tower); panel.DeleteObject(); }));
            ModHelperText selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Edit", 70);
        }
        public static void StrongWeaponPanel(RectTransform rect, Tower tower)
        {
          
            if (SandboxMode)
            {
                SandBoxStrongWeaponPanel(rect, tower);
                return;
            }
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), VanillaSprites.BrownInsertPanel);
            if (mod.level == 1)
            {
                panel.SetInfo(new Info("Panel_", 2200, 1500, 3333, 1850, new UnityEngine.Vector2()));
            }
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText selectWpn = panel.AddText(new Info("selectWpn", 0, 800, 2500, 180), "Select New Weapon", 100);
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            if(mod.level == 1)
            {
                var num2 = rnd.Next(0, 10);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 2;
                    RangeBoost2 = 1.2f;
                    AttackSpeedBoost2 = 0.94f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 4;
                    RangeBoost2 = 1.3f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 3;
                    PierceBoost2 = 2;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 5;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.85f;
                    RangeBoost2 = 1.12f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 3;
                    RangeBoost2 = 1.4f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.15f;
                    DmgBoost2 = 2;
                    PierceBoost2 = 3;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.2f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.1f;
                    DmgBoost2 = 2;
                    PierceBoost2 = 2;
                    AttackSpeedBoost2 = 0.95f;
                    RangeBoost2 = 1.1f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 4;
                    PierceBoost2 = 1;
                }
                ModHelperPanel wpn1Panel = panel.AddPanel(new Info("wpn1Panel", 375, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                ModHelperText rarityText1 = panel.AddText(new Info("rarityText1", -1300, 600, 800, 180), "Rare", 100);
                ModHelperText cardText1 = panel.AddText(new Info("cardText1", -1300, 500, 800, 180), "Stronger Weapon Card", 50);
                ModHelperText dmgBoostText1 = panel.AddText(new Info("dmgBoostText1", -1300, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                ModHelperText prcBoostText1 = panel.AddText(new Info("prcBoostText1", -1300, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                ModHelperText rngBoostText1 = panel.AddText(new Info("rngBoostText1", -1300, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                ModHelperText atkspdBoostText1 = panel.AddText(new Info("atkspdBoostText1", -1300, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                ModHelperText mnyBoostText1 = panel.AddText(new Info("mnyBoostText1", -1300, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                ModHelperButton selectWpnBtn1 = panel.AddButton(new Info("selectWpnBtn1", -1300, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                ModHelperText selectWpn1 = selectWpnBtn1.AddText(new Info("selectWpn1", 0, 0, 700, 160), "Select", 70);
            }
            else 
            {
                var num1 = rnd.Next(0, 8);
                int DmgBoost = 0;
                int PierceBoost = 0;
                float RangeBoost = 1f;
                float AttackSpeedBoost = 1f;
                float MoneyBoost = 1f;
                if (num1 == 0)
                {
                    PierceBoost = 1;
                    RangeBoost = 1.1f;
                    AttackSpeedBoost = 0.96f;
                }
                if (num1 == 1)
                {
                    DmgBoost = 2;
                    RangeBoost = 1.2f;
                }
                if (num1 == 2)
                {
                    DmgBoost = 1;
                    PierceBoost = 1;
                }
                if (num1 == 3)
                {
                    PierceBoost = 3;
                }
                if (num1 == 4)
                {
                    AttackSpeedBoost = 0.9f;
                    RangeBoost = 1.05f;
                }
                if (num1 == 5)
                {
                    PierceBoost = 1;
                    RangeBoost = 1.35f;
                }
                if (num1 == 6)
                {
                    MoneyBoost = 1.1f;
                    DmgBoost = 1;
                    PierceBoost = 1;
                }
                if (num1 == 7)
                {
                    MoneyBoost = 1.15f;
                }
                ModHelperPanel wpn1Panel = panel.AddPanel(new Info("wpn1Panel", 375, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText rarityText1 = panel.AddText(new Info("rarityText1", -875, 600, 800, 180), "Common", 100);
                ModHelperText cardText1 = panel.AddText(new Info("cardText1", -875, 500, 800, 180), "Stronger Weapon Card", 50);
                ModHelperText dmgBoostText1 = panel.AddText(new Info("dmgBoostText1", -875, 200, 800, 180), "Damage Boost :" + DmgBoost, 50);
                ModHelperText prcBoostText1 = panel.AddText(new Info("prcBoostText1", -875, 100, 800, 180), "Pierce Boost :" + PierceBoost, 50);
                ModHelperText rngBoostText1 = panel.AddText(new Info("rngBoostText1", -875, 0, 800, 180), "Range Boost : X" + RangeBoost, 50);
                ModHelperText atkspdBoostText1 = panel.AddText(new Info("atkspdBoostText1", -875, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost, 50);
                ModHelperText mnyBoostText1 = panel.AddText(new Info("mnyBoostText1", -875, -200, 800, 180), "Money Boost : X" + MoneyBoost, 50);
                ModHelperButton selectWpnBtn1 = panel.AddButton(new Info("selectWpnBtn1", -875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost, PierceBoost, AttackSpeedBoost, RangeBoost, MoneyBoost, tower)));
                ModHelperText selectWpn1 = selectWpnBtn1.AddText(new Info("selectWpn1", 0, 0, 700, 160), "Select", 70);
            }
            var rarity = "Common";
            if (mod.level == 1)
            {
                var rarityNum = rnd.Next(1, 100);
                rarity = "Rare";
                if (rarityNum >= mod.epicStrongChance)
                {
                    rarity = "Epic";
                }
                if (rarityNum >= mod.legendaryChance)
                {
                    rarity = "Legendary";
                }
            }
            else
            {
                var rarityNum = rnd.Next(1, 100);
                if (rarityNum >= mod.rareStrongChance)
                {
                    rarity = "Rare";
                }
                if (rarityNum >= mod.epicStrongChance)
                {
                    rarity = "Epic";
                }
            }
          

            if (rarity == "Common")
            {
                var num2 = rnd.Next(0, 15);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 1;
                    RangeBoost2 = 1.1f;
                    AttackSpeedBoost2 = 0.96f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 2;
                    RangeBoost2 = 1.2f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 1;
                    PierceBoost2 = 1;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 3;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.9f;
                    RangeBoost2 = 1.05f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 1;
                    RangeBoost2 = 1.35f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.1f;
                    DmgBoost2 = 1;
                    PierceBoost2 = 1;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.15f;
                }
                ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 0, 600, 800, 180), "Common", 100);
                ModHelperText cardText2 = panel.AddText(new Info("cardText2", 0, 500, 800, 180), "Stronger Weapon Card", 50);
                ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 0, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 0, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 05, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 0, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 0, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
            }
            if (rarity == "Rare")
            {
                var num2 = rnd.Next(0, 10);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 2;
                    RangeBoost2 = 1.2f;
                    AttackSpeedBoost2 = 0.94f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 4;
                    RangeBoost2 = 1.3f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 3;
                    PierceBoost2 = 2;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 5;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.85f;
                    RangeBoost2 = 1.12f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 3;
                    RangeBoost2 = 1.4f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.15f;
                    DmgBoost2 = 2;
                    PierceBoost2 = 3;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.2f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.1f;
                    DmgBoost2 = 2;
                    PierceBoost2 = 2;
                    AttackSpeedBoost2 = 0.95f;
                    RangeBoost2 = 1.1f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 4;
                    PierceBoost2 = 1;
                }
                if (mod.level == 1)
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", -425, 600, 800, 180), "Rare", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", -425, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", -425, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", -425, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", -425, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", -425, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", -425, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", -425, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                else
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 0, 600, 800, 180), "Rare", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 0, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 0, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 0, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 05, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 0, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 0, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
            }
            if (rarity == "Epic")
            {
                var num2 = rnd.Next(0, 11);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 4;
                    RangeBoost2 = 1.3f;
                    AttackSpeedBoost2 = 0.90f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 7;
                    RangeBoost2 = 1.45f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 5;
                    PierceBoost2 = 3;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 8;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.82f;
                    RangeBoost2 = 1.18f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 5;
                    RangeBoost2 = 1.52f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.2f;
                    DmgBoost2 = 4;
                    PierceBoost2 = 5;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.3f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.15f;
                    DmgBoost2 = 3;
                    PierceBoost2 = 4;
                    AttackSpeedBoost2 = 0.91f;
                    RangeBoost2 = 1.25f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 7;
                    PierceBoost2 = 3;
                }
                if (num2 == 10)
                {
                    MoneyBoost2 = 1.2f;
                    DmgBoost2 = 5;
                    PierceBoost2 = 4;
                }
                if (mod.level == 1)
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", -425, 600, 800, 180), "Epic", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", -425, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", -425, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", -425, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", -425, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", -425, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", -425, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", -425, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                else
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 0, 600, 800, 180), "Epic", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 0, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 0, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 0, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 05, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 0, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 0, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
               
            }
            if (rarity == "Legendary")
            {
                var num2 = rnd.Next(0, 12);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 7;
                    RangeBoost2 = 1.45f;
                    AttackSpeedBoost2 = 0.85f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 12;
                    RangeBoost2 = 1.55f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 8;
                    PierceBoost2 = 7;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 12;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.77f;
                    RangeBoost2 = 1.25f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 9;
                    RangeBoost2 = 1.60f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.25f;
                    DmgBoost2 = 7;
                    PierceBoost2 = 8;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.4f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.25f;
                    DmgBoost2 = 5;
                    PierceBoost2 = 7;
                    AttackSpeedBoost2 = 0.85f;
                    RangeBoost2 = 1.35f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 11;
                    PierceBoost2 = 6;
                }
                if (num2 == 10)
                {
                    MoneyBoost2 = 1.2f;
                    DmgBoost2 = 8;
                    PierceBoost2 = 6;
                }
                if (num2 == 11)
                {
                    AttackSpeedBoost2 = 0.7f;
                }
                if (mod.level == 1)
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", -425, 600, 800, 180), "Legendary", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", -425, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", -425, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", -425, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", -425, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", -425, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", -425, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", -425, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                else
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 1250, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 0, 600, 800, 180), "Legendary", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 0, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 0, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 0, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 0, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 0, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 0, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
            }
            var rarityNum2 = rnd.Next(1, 100);
            var rarity2 = "Common";
            if (mod.level == 1)
            {
                rarity2 = "Rare";
                if (rarityNum2 >= mod.epicStrongChance)
                {
                    rarity2 = "Epic";
                }
                if (rarityNum2 >= mod.legendaryStrongChance)
                {
                    rarity2 = "Legendary";
                }
                if (rarityNum2 >= mod.exoticStrongChance)
                {
                    rarity2 = "Exotic";
                }
                if (rarityNum2 >= mod.godlyStrongerChance)
                {
                    rarity2 = "Godly";
                }
            }
            else
            {
                if (rarityNum2 >= mod.rareStrongChance)
                {
                    rarity2 = "Rare";
                }
                if (rarityNum2 >= mod.epicStrongChance)
                {
                    rarity2 = "Epic";
                }
                if (rarityNum2 >= mod.legendaryStrongChance)
                {
                    rarity2 = "Legendary";
                }
                if (rarityNum2 >= mod.exoticStrongChance)
                {
                    rarity2 = "Exotic";
                }
            }
            if (rarity2 == "Common")
            {
                var num2 = rnd.Next(0, 15);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 1;
                    RangeBoost2 = 1.1f;
                    AttackSpeedBoost2 = 0.96f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 2;
                    RangeBoost2 = 1.2f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 1;
                    PierceBoost2 = 1;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 3;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.9f;
                    RangeBoost2 = 1.05f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 1;
                    RangeBoost2 = 1.35f;
                }
                if (num2 == 6)
                { 
                    MoneyBoost2 = 1.1f;
                    DmgBoost2 = 1;
                    PierceBoost2 = 1;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.15f;
                }
                ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Common", 100);
                ModHelperText cardText2 = panel.AddText(new Info("cardText2", 875, 500, 800, 180), "Stronger Weapon Card", 50);
                ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 875, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 875, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 875, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 875, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 875, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
            }
            if (rarity2 == "Rare")
            {
                var num2 = rnd.Next(0, 10);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 2;
                    RangeBoost2 = 1.2f;
                    AttackSpeedBoost2 = 0.94f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 4;
                    RangeBoost2 = 1.3f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 3;
                    PierceBoost2 = 2;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 5;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.85f;
                    RangeBoost2 = 1.12f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 3;
                    RangeBoost2 = 1.4f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.15f;
                    DmgBoost2 = 2;
                    PierceBoost2 = 3;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.2f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.1f;
                    DmgBoost2 = 2;
                    PierceBoost2 = 2;
                    AttackSpeedBoost2 = 0.95f;
                    RangeBoost2 = 1.1f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 4;
                    PierceBoost2 = 1;
                }
                if (mod.level == 1)
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Rare", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 450, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 450, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 450, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 450, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 450, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 450, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                else
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Rare", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 875, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 875, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 875, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 875, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 875, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 875, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
            }
            if (rarity2 == "Epic")
            {
                var num2 = rnd.Next(0, 11);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 4;
                    RangeBoost2 = 1.3f;
                    AttackSpeedBoost2 = 0.90f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 7;
                    RangeBoost2 = 1.45f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 5;
                    PierceBoost2 = 3;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 8;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.82f;
                    RangeBoost2 = 1.18f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 5;
                    RangeBoost2 = 1.52f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.2f;
                    DmgBoost2 = 4;
                    PierceBoost2 = 5;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.3f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.15f;
                    DmgBoost2 = 3;
                    PierceBoost2 = 4;
                    AttackSpeedBoost2 = 0.91f;
                    RangeBoost2 = 1.25f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 7;
                    PierceBoost2 = 3;
                }
                if (num2 == 10)
                {
                    MoneyBoost2 = 1.2f;
                    DmgBoost2 = 5;
                    PierceBoost2 = 4;
                }
                if (mod.level == 1)
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Epic", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 450, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 450, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 450, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 450, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 450, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 450, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                else
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Epic", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 875, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 875, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 875, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 875, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 875, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 875, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
             

            }
            if (rarity2 == "Legendary")
            {
                var num2 = rnd.Next(0, 12);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 7;
                    RangeBoost2 = 1.45f;
                    AttackSpeedBoost2 = 0.85f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 12;
                    RangeBoost2 = 1.55f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 8;
                    PierceBoost2 = 7;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 12;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.77f;
                    RangeBoost2 = 1.25f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 9;
                    RangeBoost2 = 1.60f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.25f;
                    DmgBoost2 = 7;
                    PierceBoost2 = 8;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.4f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.25f;
                    DmgBoost2 = 5;
                    PierceBoost2 = 7;
                    AttackSpeedBoost2 = 0.85f;
                    RangeBoost2 = 1.35f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 11;
                    PierceBoost2 = 6;
                }
                if (num2 == 10)
                {
                    MoneyBoost2 = 1.2f;
                    DmgBoost2 = 8;
                    PierceBoost2 = 6;
                }
                if (num2 == 11)
                {
                    AttackSpeedBoost2 = 0.7f;
                }
                if (mod.level == 1)
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Legendary", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 450, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 450, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 450, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 450, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 450, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 450, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                else
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Legendary", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 875, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 875, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 875, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 875, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 875, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 875, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
               
            }
            if (rarity2 == "Exotic")
            {
                var num2 = rnd.Next(0, 12);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 11;
                    RangeBoost2 = 1.6f;
                    AttackSpeedBoost2 = 0.79f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 17;
                    RangeBoost2 = 1.7f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 13;
                    PierceBoost2 = 12;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 20;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.7f;
                    RangeBoost2 = 1.35f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 14;
                    RangeBoost2 = 1.75f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.30f;
                    DmgBoost2 = 12;
                    PierceBoost2 = 14;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.5f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.28f;
                    DmgBoost2 = 9;
                    PierceBoost2 = 11;
                    AttackSpeedBoost2 = 0.78f;
                    RangeBoost2 = 1.48f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 16;
                    PierceBoost2 = 10;
                }
                if (num2 == 10)
                {
                    MoneyBoost2 = 1.35f;
                    DmgBoost2 = 13;
                    PierceBoost2 = 11;
                }
                if (num2 == 11)
                {
                    AttackSpeedBoost2 = 0.6f;
                    PierceBoost2 = 5;
                }
                if (mod.level == 1)
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelWhiteSmall);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Exotic", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 450, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 450, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 450, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 450, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 450, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 450, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                else
                {
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelWhiteSmall);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 875, 600, 800, 180), "Exotic", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 875, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 875, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 875, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 875, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 875, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 875, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 875, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
             
            }
            if (rarity2 == "Godly")
            {
                var num2 = rnd.Next(0, 13);
                int DmgBoost2 = 0;
                int PierceBoost2 = 0;
                float RangeBoost2 = 1f;
                float AttackSpeedBoost2 = 1f;
                float MoneyBoost2 = 1f;
                if (num2 == 0)
                {
                    PierceBoost2 = 19;
                    RangeBoost2 = 1.82f;
                    AttackSpeedBoost2 = 0.69f;
                }
                if (num2 == 1)
                {
                    DmgBoost2 = 35;
                    RangeBoost2 = 2f;
                }
                if (num2 == 2)
                {
                    DmgBoost2 = 20;
                    PierceBoost2 = 25;
                }
                if (num2 == 3)
                {
                    PierceBoost2 = 56;
                }
                if (num2 == 4)
                {
                    AttackSpeedBoost2 = 0.55f;
                    RangeBoost2 = 1.55f;
                }
                if (num2 == 5)
                {
                    PierceBoost2 = 30;
                    RangeBoost2 = 1.92f;
                }
                if (num2 == 6)
                {
                    MoneyBoost2 = 1.37f;
                    DmgBoost2 = 26;
                    PierceBoost2 = 28;
                }
                if (num2 == 7)
                {
                    MoneyBoost2 = 1.65f;
                }
                if (num2 == 8)
                {
                    MoneyBoost2 = 1.35f;
                    DmgBoost2 = 16;
                    PierceBoost2 = 22;
                    AttackSpeedBoost2 = 0.67f;
                    RangeBoost2 = 1.69f;
                }
                if (num2 == 9)
                {
                    DmgBoost2 = 35;
                    PierceBoost2 = 40;
                }
                if (num2 == 10)
                {
                    MoneyBoost2 = 1.48f;
                    DmgBoost2 = 28;
                    PierceBoost2 = 36;
                }
                if (num2 == 11)
                {
                    AttackSpeedBoost2 = 0.55f;
                    PierceBoost2 = 15;
                }
                if (num2 == 12)
                {
                    DmgBoost2 = 100;
                }
                ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 2125, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelSilver);
                ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 450, 600, 800, 180), "Godly", 100);
                ModHelperText cardText2 = panel.AddText(new Info("cardText2", 450, 500, 800, 180), "Stronger Weapon Card", 50);
                ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 450, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 450, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 450, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 450, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 450, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 450, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
            }
            if (mod.level == 1)
            {
                var rarityNum3 = rnd.Next(1, 100);
                var rarity3 = "Rare";

                if (rarityNum3 >= mod.epicStrongChance)
                {
                    rarity3 = "Epic";
                }
                if (rarityNum3 >= mod.legendaryStrongChance)
                {
                    rarity3 = "Legendary";
                }
                if (rarityNum3 >= mod.exoticStrongChance)
                {
                    rarity3 = "Exotic";
                }
                if (rarityNum3 >= mod.godlyStrongerChance)
                {
                    rarity3 = "Godly";
                }
              
                if (rarity3 == "Rare")
                {
                    var num2 = rnd.Next(0, 10);
                    int DmgBoost2 = 0;
                    int PierceBoost2 = 0;
                    float RangeBoost2 = 1f;
                    float AttackSpeedBoost2 = 1f;
                    float MoneyBoost2 = 1f;
                    if (num2 == 0)
                    {
                        PierceBoost2 = 2;
                        RangeBoost2 = 1.2f;
                        AttackSpeedBoost2 = 0.94f;
                    }
                    if (num2 == 1)
                    {
                        DmgBoost2 = 4;
                        RangeBoost2 = 1.3f;
                    }
                    if (num2 == 2)
                    {
                        DmgBoost2 = 3;
                        PierceBoost2 = 2;
                    }
                    if (num2 == 3)
                    {
                        PierceBoost2 = 5;
                    }
                    if (num2 == 4)
                    {
                        AttackSpeedBoost2 = 0.85f;
                        RangeBoost2 = 1.12f;
                    }
                    if (num2 == 5)
                    {
                        PierceBoost2 = 3;
                        RangeBoost2 = 1.4f;
                    }
                    if (num2 == 6)
                    {
                        MoneyBoost2 = 1.15f;
                        DmgBoost2 = 2;
                        PierceBoost2 = 3;
                    }
                    if (num2 == 7)
                    {
                        MoneyBoost2 = 1.2f;
                    }
                    if (num2 == 8)
                    {
                        MoneyBoost2 = 1.1f;
                        DmgBoost2 = 2;
                        PierceBoost2 = 2;
                        AttackSpeedBoost2 = 0.95f;
                        RangeBoost2 = 1.1f;
                    }
                    if (num2 == 9)
                    {
                        DmgBoost2 = 4;
                        PierceBoost2 = 1;
                    }

                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.BlueInsertPanel);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Rare", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 1325, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 1325, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 1325, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 1325, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 1325, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 1325, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                if (rarity3 == "Epic")
                {
                    var num2 = rnd.Next(0, 11);
                    int DmgBoost2 = 0;
                    int PierceBoost2 = 0;
                    float RangeBoost2 = 1f;
                    float AttackSpeedBoost2 = 1f;
                    float MoneyBoost2 = 1f;
                    if (num2 == 0)
                    {
                        PierceBoost2 = 4;
                        RangeBoost2 = 1.3f;
                        AttackSpeedBoost2 = 0.90f;
                    }
                    if (num2 == 1)
                    {
                        DmgBoost2 = 7;
                        RangeBoost2 = 1.45f;
                    }
                    if (num2 == 2)
                    {
                        DmgBoost2 = 5;
                        PierceBoost2 = 3;
                    }
                    if (num2 == 3)
                    {
                        PierceBoost2 = 8;
                    }
                    if (num2 == 4)
                    {
                        AttackSpeedBoost2 = 0.82f;
                        RangeBoost2 = 1.18f;
                    }
                    if (num2 == 5)
                    {
                        PierceBoost2 = 5;
                        RangeBoost2 = 1.52f;
                    }
                    if (num2 == 6)
                    {
                        MoneyBoost2 = 1.2f;
                        DmgBoost2 = 4;
                        PierceBoost2 = 5;
                    }
                    if (num2 == 7)
                    {
                        MoneyBoost2 = 1.3f;
                    }
                    if (num2 == 8)
                    {
                        MoneyBoost2 = 1.15f;
                        DmgBoost2 = 3;
                        PierceBoost2 = 4;
                        AttackSpeedBoost2 = 0.91f;
                        RangeBoost2 = 1.25f;
                    }
                    if (num2 == 9)
                    {
                        DmgBoost2 = 7;
                        PierceBoost2 = 3;
                    }
                    if (num2 == 10)
                    {
                        MoneyBoost2 = 1.2f;
                        DmgBoost2 = 5;
                        PierceBoost2 = 4;
                    }
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelParagon);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Epic", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 1325, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 1325, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 1325, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 1325, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 1325, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 1325, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                if (rarity3 == "Legendary")
                {
                    var num2 = rnd.Next(0, 12);
                    int DmgBoost2 = 0;
                    int PierceBoost2 = 0;
                    float RangeBoost2 = 1f;
                    float AttackSpeedBoost2 = 1f;
                    float MoneyBoost2 = 1f;
                    if (num2 == 0)
                    {
                        PierceBoost2 = 7;
                        RangeBoost2 = 1.45f;
                        AttackSpeedBoost2 = 0.85f;
                    }
                    if (num2 == 1)
                    {
                        DmgBoost2 = 12;
                        RangeBoost2 = 1.55f;
                    }
                    if (num2 == 2)
                    {
                        DmgBoost2 = 8;
                        PierceBoost2 = 7;
                    }
                    if (num2 == 3)
                    {
                        PierceBoost2 = 12;
                    }
                    if (num2 == 4)
                    {
                        AttackSpeedBoost2 = 0.77f;
                        RangeBoost2 = 1.25f;
                    }
                    if (num2 == 5)
                    {
                        PierceBoost2 = 9;
                        RangeBoost2 = 1.60f;
                    }
                    if (num2 == 6)
                    {
                        MoneyBoost2 = 1.25f;
                        DmgBoost2 = 7;
                        PierceBoost2 = 8;
                    }
                    if (num2 == 7)
                    {
                        MoneyBoost2 = 1.4f;
                    }
                    if (num2 == 8)
                    {
                        MoneyBoost2 = 1.25f;
                        DmgBoost2 = 5;
                        PierceBoost2 = 7;
                        AttackSpeedBoost2 = 0.85f;
                        RangeBoost2 = 1.35f;
                    }
                    if (num2 == 9)
                    {
                        DmgBoost2 = 11;
                        PierceBoost2 = 6;
                    }
                    if (num2 == 10)
                    {
                        MoneyBoost2 = 1.2f;
                        DmgBoost2 = 8;
                        PierceBoost2 = 6;
                    }
                    if (num2 == 11)
                    {
                        AttackSpeedBoost2 = 0.7f;
                    }
                   
                        ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelYellow);
                        ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Legendary", 100);
                        ModHelperText cardText2 = panel.AddText(new Info("cardText2", 1325, 500, 800, 180), "Stronger Weapon Card", 50);
                        ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 1325, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                        ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 1325, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                        ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 1325, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                        ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 1325, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                        ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 1325, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                        ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                        ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
                if (rarity3 == "Exotic")
                {
                    var num2 = rnd.Next(0, 12);
                    int DmgBoost2 = 0;
                    int PierceBoost2 = 0;
                    float RangeBoost2 = 1f;
                    float AttackSpeedBoost2 = 1f;
                    float MoneyBoost2 = 1f;
                    if (num2 == 0)
                    {
                        PierceBoost2 = 11;
                        RangeBoost2 = 1.6f;
                        AttackSpeedBoost2 = 0.79f;
                    }
                    if (num2 == 1)
                    {
                        DmgBoost2 = 17;
                        RangeBoost2 = 1.7f;
                    }
                    if (num2 == 2)
                    {
                        DmgBoost2 = 13;
                        PierceBoost2 = 12;
                    }
                    if (num2 == 3)
                    {
                        PierceBoost2 = 20;
                    }
                    if (num2 == 4)
                    {
                        AttackSpeedBoost2 = 0.7f;
                        RangeBoost2 = 1.35f;
                    }
                    if (num2 == 5)
                    {
                        PierceBoost2 = 14;
                        RangeBoost2 = 1.75f;
                    }
                    if (num2 == 6)
                    {
                        MoneyBoost2 = 1.30f;
                        DmgBoost2 = 12;
                        PierceBoost2 = 14;
                    }
                    if (num2 == 7)
                    {
                        MoneyBoost2 = 1.5f;
                    }
                    if (num2 == 8)
                    {
                        MoneyBoost2 = 1.28f;
                        DmgBoost2 = 9;
                        PierceBoost2 = 11;
                        AttackSpeedBoost2 = 0.78f;
                        RangeBoost2 = 1.48f;
                    }
                    if (num2 == 9)
                    {
                        DmgBoost2 = 16;
                        PierceBoost2 = 10;
                    }
                    if (num2 == 10)
                    {
                        MoneyBoost2 = 1.35f;
                        DmgBoost2 = 13;
                        PierceBoost2 = 11;
                    }
                    if (num2 == 11)
                    {
                        AttackSpeedBoost2 = 0.6f;
                        PierceBoost2 = 5;
                    }
                 
                        ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBgPanelWhiteSmall);
                        ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Exotic", 100);
                        ModHelperText cardText2 = panel.AddText(new Info("cardText2", 1325, 500, 800, 180), "Stronger Weapon Card", 50);
                        ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 1325, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                        ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 1325, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                        ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 1325, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                        ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 1325, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                        ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 1325, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                        ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                        ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                   

                }
                if (rarity3 == "Godly")
                {
                    var num2 = rnd.Next(0, 13);
                    int DmgBoost2 = 0;
                    int PierceBoost2 = 0;
                    float RangeBoost2 = 1f;
                    float AttackSpeedBoost2 = 1f;
                    float MoneyBoost2 = 1f;
                    if (num2 == 0)
                    {
                        PierceBoost2 = 19;
                        RangeBoost2 = 1.82f;
                        AttackSpeedBoost2 = 0.69f;
                    }
                    if (num2 == 1)
                    {
                        DmgBoost2 = 35;
                        RangeBoost2 = 2f;
                    }
                    if (num2 == 2)
                    {
                        DmgBoost2 = 20;
                        PierceBoost2 = 25;
                    }
                    if (num2 == 3)
                    {
                        PierceBoost2 = 56;
                    }
                    if (num2 == 4)
                    {
                        AttackSpeedBoost2 = 0.55f;
                        RangeBoost2 = 1.55f;
                    }
                    if (num2 == 5)
                    {
                        PierceBoost2 = 30;
                        RangeBoost2 = 1.92f;
                    }
                    if (num2 == 6)
                    {
                        MoneyBoost2 = 1.37f;
                        DmgBoost2 = 26;
                        PierceBoost2 = 28;
                    }
                    if (num2 == 7)
                    {
                        MoneyBoost2 = 1.65f;
                    }
                    if (num2 == 8)
                    {
                        MoneyBoost2 = 1.35f;
                        DmgBoost2 = 16;
                        PierceBoost2 = 22;
                        AttackSpeedBoost2 = 0.67f;
                        RangeBoost2 = 1.69f;
                    }
                    if (num2 == 9)
                    {
                        DmgBoost2 = 35;
                        PierceBoost2 = 40;
                    }
                    if (num2 == 10)
                    {
                        MoneyBoost2 = 1.48f;
                        DmgBoost2 = 28;
                        PierceBoost2 = 36;
                    }
                    if (num2 == 11)
                    {
                        AttackSpeedBoost2 = 0.55f;
                        PierceBoost2 = 15;
                    }
                    if (num2 == 12)
                    {
                        DmgBoost2 = 100;
                    }
                    ModHelperPanel wpn2Panel = panel.AddPanel(new Info("wpn2Panel", 3000, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelSilver);
                    ModHelperText rarityText2 = panel.AddText(new Info("rarityText2", 1325, 600, 800, 180), "Godly", 100);
                    ModHelperText cardText2 = panel.AddText(new Info("cardText2", 1325, 500, 800, 180), "Stronger Weapon Card", 50);
                    ModHelperText dmgBoostText2 = panel.AddText(new Info("dmgBoostText2", 1325, 200, 800, 180), "Damage Boost :" + DmgBoost2, 50);
                    ModHelperText prcBoostText2 = panel.AddText(new Info("prcBoostText2", 1325, 100, 800, 180), "Pierce Boost :" + PierceBoost2, 50);
                    ModHelperText rngBoostText2 = panel.AddText(new Info("rngBoostText2", 1325, 0, 800, 180), "Range Boost : X" + RangeBoost2, 50);
                    ModHelperText atkspdBoostText2 = panel.AddText(new Info("atkspdBoostText2", 1325, -100, 800, 180), "Attack Speed Boost : X" + AttackSpeedBoost2, 50);
                    ModHelperText mnyBoostText2 = panel.AddText(new Info("mnyBoostText2", 1325, -200, 800, 180), "Money Boost : X" + MoneyBoost2, 50);
                    ModHelperButton selectWpnBtn2 = panel.AddButton(new Info("selectWpnBtn2", 1325, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(DmgBoost2, PierceBoost2, AttackSpeedBoost2, RangeBoost2, MoneyBoost2, tower)));
                    ModHelperText selectWpn2 = selectWpnBtn2.AddText(new Info("selectWpn2", 0, 0, 700, 160), "Select", 70);
                }
            }
        }
        public void StrongWeapon(Tower tower)
        {
            InGame game = InGame.instance;
            if (SandboxMode)
            {
                RectTransform rect = game.uiRect;
                MenuUi.StrongWeaponPanel(rect, tower);
                MenuUi.instance.CloseMenu();

                return;
            }

            if (game.GetCash() >= mod.strongerWeaponCost)
            {
                game.AddCash(-mod.strongerWeaponCost);
                RectTransform rect = game.uiRect;
                MenuUi.StrongWeaponPanel(rect, tower);
                mod.strongerWeaponCost += mod.baseStrongerWeaponCost;
                tower.worth += mod.strongerWeaponCost - mod.baseStrongerWeaponCost;
                mod.baseStrongerWeaponCost *= 1.06f;
                
         
                MenuUi.instance.CloseMenu();

            }
        }
        public void StrongWpnSelected(int Dmg, int Pierce, float AtkSpd, float Range, float Money, Tower tower)
        {
          
            InGame game = InGame.instance;
            Destroy(gameObject);
            RectTransform rect = game.uiRect;
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            towerModel.range *= Range;
            if (towerModel.HasBehavior<TowerCreateTowerModel>())
            {
                foreach (var towercreate in towerModel.GetBehaviors<TowerCreateTowerModel>().ToArray())
                {
                    if (towercreate.towerModel.HasBehavior<AirUnitModel>())
                    {
                        foreach (var attackModel in towercreate.towerModel.GetBehavior<AirUnitModel>().GetBehaviors<AttackAirUnitModel>().ToArray())
                        {
                            if (towerModel.GetBehavior<TowerCreateTowerModel>().towerModel.HasBehavior<AirUnitModel>())
                            {
                                if (attackModel.weapons[0].projectile.HasBehavior<DamageModel>())
                                {
                                    attackModel.weapons[0].rate *= AtkSpd;
                                    attackModel.weapons[0].projectile.pierce += Pierce;
                                    attackModel.weapons[0].projectile.GetDamageModel().damage += Dmg;
                                }
                                if (attackModel.weapons[0].projectile.HasBehavior<TravelStraitModel>())
                                {
                                    attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan += Range / 90;
                                }
                                if (attackModel.weapons[0].projectile.HasBehavior<CashModel>())
                                {
                                    attackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum *= Money;
                                    attackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum *= Money;
                                }

                            }
                          
                        }
                        foreach (var attackModel in towercreate.towerModel.GetBehavior<AirUnitModel>().GetBehaviors<AttackModel>().ToArray())
                        {
                            if (attackModel.weapons[0].projectile.HasBehavior<DamageModel>())
                            {
                                attackModel.weapons[0].rate *= AtkSpd;
                                attackModel.weapons[0].projectile.pierce += Pierce;
                                attackModel.weapons[0].projectile.GetDamageModel().damage += Dmg;
                            }
                            if (attackModel.weapons[0].projectile.HasBehavior<TravelStraitModel>())
                            {
                                attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan += Range / 90;
                            }
                            if (attackModel.weapons[0].projectile.HasBehavior<CashModel>())
                            {
                                attackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum *= Money;
                                attackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum *= Money;
                            }
                        }
                    }
                }
            }
            foreach (var attackModel in towerModel.GetDescendants<AttackModel>().ToArray())
            {
                if (!attackModel.weapons[0].projectile.HasBehavior<SlowModel>())
                {
                    attackModel.weapons[0].rate *= AtkSpd;
                    if (attackModel.weapons[0].projectile.HasBehavior<DamageModel>())
                    {
                        attackModel.weapons[0].projectile.pierce += Pierce;
                        attackModel.weapons[0].projectile.GetDamageModel().damage += Dmg;
                    }
                    if (attackModel.weapons[0].projectile.HasBehavior<TravelStraitModel>())
                    {
                        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan += Range / 60;
                    }
                    if (attackModel.weapons[0].projectile.HasBehavior<CashModel>())
                    {
                        attackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum *= Money;
                        attackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum *= Money;
                    }
                    if (attackModel.weapons[0].projectile.HasBehavior<CreateProjectileOnContactModel>())
                    {
                        attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce += Pierce;
                        attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += Dmg;

                    }
                    if (attackModel.weapons[0].projectile.HasBehavior<CreateProjectileOnExhaustFractionModel>())
                    {
                        attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.pierce += Pierce;
                        attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().damage += Dmg;
                    }
                } 
            }
            foreach (var attackModel in towerModel.GetDescendants<AttackModel>().ToArray())
            {
                attackModel.range *= Range;
            }
            mod.rareStrongChance -= 6.7f;
            mod.epicStrongChance -= 2f;
            if (mod.epicStrongChance <= 88)
            {
                mod.legendaryStrongChance -= 1.15f;
            }
            if (mod.legendaryStrongChance <= 91)
            {
                mod.exoticStrongChance -= 0.75f;
            }
            if (mod.exoticChance <= 93)
            {
                mod.godlyChance -= 0.4f;
            }
            tower.UpdateRootModel(towerModel);
            if (mod.upgradeOpen == true)
            {
                CreateUpgradeMenu(rect, tower);
            }

        }
        public void NewAbility(Tower tower)
        {
            InGame game = InGame.instance;
            if(SandboxMode)
            {
                RectTransform rect = game.uiRect;
                MenuUi.NewAbilityPanel(rect, tower);
                MenuUi.instance.CloseMenu();
                return;
            }
            if (game.GetCash() >= mod.newAbilityCost)
            {
                game.AddCash(-mod.newAbilityCost);
                RectTransform rect = game.uiRect;
                mod.newAbilityCost += mod.baseNewAbilityCost;
                tower.worth += mod.newAbilityCost - mod.baseNewAbilityCost;
                MenuUi.NewAbilityPanel(rect, tower);
                MenuUi.instance.CloseMenu();
            }
        }
        public static ModHelperPanel CreateAbility(AbilityTemplate ability, Tower tower)
        {

            var sprite = VanillaSprites.GreyInsertPanel;
            var panel = ModHelperPanel.Create(new Info("WeaponContent" + ability.AbilityName, 0, 0, 2250, 150), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText abilityName = panel.AddText(new Info("abilityName", -600, 0, 1000, 150), ability.AbilityName, 80, TextAlignmentOptions.MidlineLeft);
            ModHelperImage image = panel.AddImage(new Info("image", -100, 0, 140, 140), ability.Icon);
            ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { upgradeUi.AbilitySelected(ability.AbilityName, tower, "none"); }));
            ModHelperText selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Select", 60);
            return panel;
        }
        public static void SandBoxAbilityPanel(RectTransform rect, Tower tower)
        {
          
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), VanillaSprites.MainBGPanelBlue);
            panel.transform.DestroyAllChildren();

            ModHelperScrollPanel scrollPanel = panel.AddScrollPanel(new Info("scrollPanel", 0, 0, 2500, 1850), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 15, 50);
            ModHelperButton exit = panel.AddButton(new Info("exit", 1200, 900, 135, 135), VanillaSprites.RedBtn, new System.Action(() => {
                panel.DeleteObject(); tower.SetSelectionBlocked(false);
            }));
            ModHelperText x = exit.AddText(new Info("x", 0, 0, 700, 160), "X", 80);
            foreach (var ability in ModContent.GetContent<AbilityTemplate>())
            { 
                scrollPanel.AddScrollContent(CreateAbility(ability, tower));
            }
        }
        public static void NewAbilityPanel(RectTransform rect, Tower tower)
        {
          
            if (SandboxMode)
            {
                SandBoxAbilityPanel(rect, tower);
                return;
            }
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2000, 1500, 1000, 1850, new UnityEngine.Vector2()), VanillaSprites.BrownInsertPanel);
            if (mod.level == 1)
            {
                panel.SetInfo(new Info("Panel_", 2000, 1500, 2000, 1850, new UnityEngine.Vector2()));
            }
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText selectAbility = panel.AddText(new Info("selectAbility", 0, 800, 2500, 180), "Select New Ability", 100);
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            var num1 = rnd.Next(0, AbilityClass.AbilityName.Count);
            var abSelected = AbilityClass.AbilityName[num1];
            var imgSelected = AbilityClass.AbilityImg[num1];

            if (mod.level == 1)
            {
                ModHelperPanel abilityPanel = panel.AddPanel(new Info("abilityPanel", 500, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText abilityText = panel.AddText(new Info("abilityText", -500, 600, 800, 180), "Ability", 100);
                ModHelperText abilityText2 = panel.AddText(new Info("abilityText2", -500, 500, 800, 180), abSelected, 75);
                ModHelperImage image = panel.AddImage(new Info("image", -500, 0, 400, 400), imgSelected);
                ModHelperButton selectAbilityBtn = panel.AddButton(new Info("selectAbilityBtn", -500, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.AbilitySelected(abSelected, tower, "Common")));
                ModHelperText selectAbility1 = selectAbilityBtn.AddText(new Info("selectAbility1", 0, 0, 700, 160), "Select", 70);
            }
            else
            {
                ModHelperPanel abilityPanel = panel.AddPanel(new Info("abilityPanel", 500, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText abilityText = panel.AddText(new Info("abilityText", 0, 600, 800, 180), "Ability", 100);
                ModHelperText abilityText2 = panel.AddText(new Info("abilityText2", 0, 500, 800, 180), abSelected, 75);
                ModHelperImage image = panel.AddImage(new Info("image", 0, 0, 400, 400), imgSelected);
                ModHelperButton selectAbilityBtn = panel.AddButton(new Info("selectAbilityBtn", 0, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.AbilitySelected(abSelected, tower, "Common")));
                ModHelperText selectAbility1 = selectAbilityBtn.AddText(new Info("selectAbility1", 0, 0, 700, 160), "Select", 70);
            }
           
            if (mod.level == 1)
            {
                var num2 = rnd.Next(0, AbilityClass.AbilityName.Count);
                var abSelected2 = AbilityClass.AbilityName[num2];
                var imgSelected2 = AbilityClass.AbilityImg[num2];

                ModHelperPanel abilityPanel2 = panel.AddPanel(new Info("abilityPanel", 1500, 900, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText abilityText3 = panel.AddText(new Info("abilityText3", 500, 600, 800, 180), "Ability", 100);
                ModHelperText abilityText4 = panel.AddText(new Info("abilityText4", 500, 500, 800, 180), abSelected2, 75);
                ModHelperImage image2 = panel.AddImage(new Info("image2", 500, 0, 400, 400), imgSelected2);
                ModHelperButton selectAbilityBtn2 = panel.AddButton(new Info("selectAbilityBtn2", 500, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.AbilitySelected(abSelected2, tower, "Common")));
                ModHelperText selectAbility2 = selectAbilityBtn2.AddText(new Info("selectAbility2", 0, 0, 700, 160), "Select", 70);
            }
          
        }
        public void AbilitySelected(string Ability, Tower tower, string rarity)
        {
          
            InGame game = InGame.instance;
            if(!SandboxMode)
            {
                Destroy(gameObject);
            }
            RectTransform rect = game.uiRect;
            if (Ability == "MIB")
            {
                mod.mib = true;
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                foreach (var weaponModel in towerModel.GetDescendants<WeaponModel>().ToArray())
                {
                    if (weaponModel.projectile.HasBehavior<DamageModel>())
                    {
                        weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    }
                    if (weaponModel.projectile.HasBehavior<CreateProjectileOnContactModel>())
                    {
                        weaponModel.projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    }
                    if (weaponModel.projectile.HasBehavior<CreateProjectileOnExhaustFractionModel>())
                    {
                        weaponModel.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    }
                }
                tower.UpdateRootModel(towerModel);
            }
            foreach (var ability in ModContent.GetContent<AbilityTemplate>().OrderByDescending(c => c.mod == mod))
            {
                if (ability.AbilityName == Ability)
                {
                    ability.EditTower(tower);
                }
            }
            if (mod.upgradeOpen == true && !SandboxMode)
            {
                CreateUpgradeMenu(rect, tower);
            }
        }
        public void Upgrade1Panel(Tower tower)
        {
            MenuUi.instance.CloseMenu();
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), VanillaSprites.BrownInsertPanel);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText upgradeText = panel.AddText(new Info("upgradeText", 0, 800, 2500, 180), "Upgrade To Advanced Ancient Monkey", 100);
            ModHelperText text1 = panel.AddText(new Info("text1", 0, 500, 2500, 180), "-Unlock a new rarity", 75);
            ModHelperText text2 = panel.AddText(new Info("text2", 0, 400, 2500, 180), "-Increase New Weapon Slot by 1", 75);
            ModHelperText text3 = panel.AddText(new Info("text3", 0, 300, 2500, 180), "-Increase Stronger Weapon Slot by 1", 75);
            ModHelperText text4 = panel.AddText(new Info("text4", 0, 200, 2500, 180), "-Increase New Ability Slot by 1", 75);
            ModHelperText text5 = panel.AddText(new Info("text5", 0, 100, 2500, 180), "-Greatly Increased Luck", 75);
            ModHelperText text6 = panel.AddText(new Info("text6", 0, 0, 2500, 180), "-Removed Common Rarity", 75);
            ModHelperText text7 = panel.AddText(new Info("text7", 0, -100, 2500, 180), "-Stronger Weapon and New Weapon Cost Increased", 75);
            ModHelperText text8 = panel.AddText(new Info("text8", 0, -200, 2500, 180), "-New Ability Cost Decreased", 75);
            ModHelperText text9 = panel.AddText(new Info("text9", 0, -300, 2500, 180), "-Keep Everything", 75);
            ModHelperButton upgrade1 = panel.AddButton(new Info("upgrade1", 350, -800, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.Upgrade1(tower)));
            ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade1Buy", 0, 0, 700, 160), "Upgrade ($75K)", 70);
            ModHelperButton cancel = panel.AddButton(new Info("cancel", -350, -800, 500, 160), VanillaSprites.RedBtnLong, new System.Action(() => upgradeUi.Cancel(tower)));
            ModHelperText cancelText = cancel.AddText(new Info("cancelText", 0, 0, 700, 160), "Cancel", 70);
        }
        public void Upgrade1(Tower tower)
        {
            InGame game = InGame.instance;
            if (game.GetCash() >= 75000)
            {
                game.AddCash(-75000);
                
                RectTransform rect = game.uiRect;
            
                mod.newWeaponCost = 300;
                mod.baseNewWeaponCost = 300;
                mod.rareChance = 0;
                mod.epicChance = 75;
                mod.legendaryChance = 98;
                mod.exoticChance = 100;
                mod.godlyChance = 100;
                mod.rareStrongChance = 0;
                mod.epicStrongChance = 70;
                mod.legendaryStrongChance = 95;
                mod.exoticStrongChance = 100;
                mod.godlyStrongerChance = 100;
                mod.strongerWeaponCost = 625;
                mod.baseStrongerWeaponCost = 625;
                mod.newAbilityCost = 5000;
                mod.baseNewAbilityCost = 1000;
                mod.level += 1;
                if (mod.upgradeOpen == true)
                {
                    CreateUpgradeMenu(rect, tower);
                }
                  
                Destroy(gameObject);
            }
        }
        public void Cancel(Tower tower)
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            Destroy(gameObject);
            if (mod.upgradeOpen == true)
            {
                CreateUpgradeMenu(rect, tower);
            }
        }
        public static void CreateUpgradeMenu(RectTransform rect, Tower tower)
        {
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 200, 2500, 450, new UnityEngine.Vector2()), VanillaSprites.BrownInsertPanel);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            instance = upgradeUi;
            if(SandboxMode)
            {
                ModHelperText newWpnCost = panel.AddText(new Info("newWpnCost", 0, 140, 1000, 180), "New Weapon: Free", 70);
            }
            else
            {
                ModHelperText newWpnCost = panel.AddText(new Info("newWpnCost", 0, 140, 1000, 180), "New Weapon: $" + Mathf.Round(mod.newWeaponCost), 70);
            }
            if (mod.selectingWeaponOpen == false)
            {
                ModHelperButton newWpnBtn = panel.AddButton(new Info("newWpnBtn", 0, 20, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.NewWeapon(tower)));
                ModHelperText newWpnBuy = newWpnBtn.AddText(new Info("newWpnBuy", 0, 0, 700, 160), "Buy", 70);
            }
            ModHelperText newWpnDesc = panel.AddText(new Info("newWpnDesc", 0, -100, 860, 180), "Give an extra weapon", 42);

            if (SandboxMode)
            {
                ModHelperText strongWpnCost = panel.AddText(new Info("strongWpnCost", -800, 140, 1000, 180), "Stronger Weapon: Free", 70);
            }
            else
            {
                ModHelperText strongWpnCost = panel.AddText(new Info("strongWpnCost", -800, 140, 1000, 180), "Stronger Weapon: $" + Mathf.Round(mod.strongerWeaponCost), 70);
            }
       
            if (mod.selectingWeaponOpen == false)
            {
                ModHelperButton strongWpnBtn = panel.AddButton(new Info("strongWpnBtn", -800, 20, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWeapon(tower)));
                ModHelperText strongWpnBuy = strongWpnBtn.AddText(new Info("strongWpnBuy", 0, 0, 700, 160), "Buy", 70);
            }

            ModHelperText strongWpnDesc = panel.AddText(new Info("strongWpnDesc", -800, -100, 860, 180), "Make your current weapon stronger", 42);
            if (SandboxMode)
            {
                ModHelperText abilityCost = panel.AddText(new Info("abilityCost", 800, 140, 1000, 180), "New Ability: Free", 70);
            } else
            {
                ModHelperText abilityCost = panel.AddText(new Info("abilityCost", 800, 140, 1000, 180), "New Ability: $" + Mathf.Round(mod.newAbilityCost), 70);
            }
         
            if (mod.selectingWeaponOpen == false)
            {
                ModHelperButton abilityBtn = panel.AddButton(new Info("abilityBtn", 800, 20, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.NewAbility(tower)));
                ModHelperText abilityBuy = abilityBtn.AddText(new Info("abilityBuy", 0, 0, 700, 160), "Buy", 70);
            }
            ModHelperText abilityDesc = panel.AddText(new Info("abilityDesc", 800, -100, 860, 180), "Give an ability", 42);

            if(mod.level == 0)
            {
                ModHelperButton upgrade1 = panel.AddButton(new Info("upgrade1", 0, 300, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.Upgrade1Panel(tower)));
                ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade1Buy", 0, 0, 700, 160), "Upgrade", 70);
            }
        }
    }
}