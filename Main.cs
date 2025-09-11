using System;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using AncientMonkey;
using AncientMonkey.Artifacts;
using AncientMonkey.Challenge;
using AncientMonkey.Helper;
using AncientMonkey.Mutators;
using AncientMonkey.StrongerWeapons;
using AncientMonkey.UI;
using AncientMonkey.Weapons;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2Cpp;
using Il2Cpp;
using Il2CppAssets.Scripts.Data.Behaviors.Weapons;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Powers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Gamepad;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Unity.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity.Towers.Weapons;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Unity.UI_New.Quests;
using Il2CppAssets.Scripts.Utils;
using Il2CppNewtonsoft.Json.Utilities;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Il2CppSystem.Linq;
using Il2CppSystem.Runtime.InteropServices;
using Il2CppTMPro;
using MelonLoader;
using MelonLoader;
using MelonLoader;
using MelonLoader;
using MelonLoader;
using MelonLoader;
using MelonLoader;
using MelonLoader;
using Octokit;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine;
using UnityEngine;
using UnityEngine;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Il2CppSystem.Globalization.TimeSpanParse;
using Random = System.Random;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;

[assembly: MelonInfo(typeof(AncientMonkey.AncientMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace AncientMonkey;

public class AncientMonkey : BloonsTD6Mod
{

    
    public static AncientMonkey mod;
    public float newWeaponCost = 250;
    public float baseNewWeaponCost = 250;
    public float baseNewWeaponCostMultiplier = 1.06f;
    public float rareChance = 90;
    public float epicChance = 100;
    public float legendaryChance = 100;
    public float exoticChance = 100;
    public float godlyChance = 100;
    public float omegaChance = 100;
    public float rareStrongChance = 85;
    public float epicStrongChance = 100;
    public float legendaryStrongChance = 100;
    public float exoticStrongChance = 100;
    public float godlyStrongerChance = 100;
    public float omegaStrongerChance = 100;
    public float strongerWeaponCost = 1100;
    public float baseStrongerWeaponCost = 1100;
    public float baseStrongerWeaponCostMultiplier = 1.06f;
    public float newAbilityCost = 6500;
    public float baseNewAbilityCost = 1750;
    public float baseNewAbilityCostMultiplier = 1.06f;
    public bool upgradeOpen = false;
    public bool selectingWeaponOpen = false;
    public bool mib = false;
    public bool panelOpen = false;
    public float level = 0;
    public float rangeBoostSandbox = 1;
    public float attackSpeedBoostSandbox = 1;
    public float moneyBoostSandbox = 1;
    public int damageBoostSandbox = 0;
    public int pierceBoostSandbox = 0;
    public int newWeaponSlot = 3;
    public int strongWeaponSlot = 3;
    public int abilitySlot = 1;
    public int extraWeaponSlotLevel = 0;
    public int extraWeaponSlotLevelMax = 1;
    public float extraWeaponSlotCost = 80000;
    public int strongExtraWeaponSlotLevel = 0;
    public int strongExtraWeaponSlotLevelMax = 1;
    public float strongExtraWeaponSlotCost = 100000;
    public int ExtraAbilitySlotLevel = 0;
    public int ExtraAbilitySlotLevelMax = 1;
    public float ExtraAbilitySlotCost = 160000;
    public int ExtraLuckLevel = 0;
    public int ExtraLuckMax = 20;
    public int XP = 0;
    public int XPMax = 0;
    public float UpgradeCost = 125000;
    public float Upgrade2Cost = 1000000;
    public float ExtraLuckCost = 250;
    public double BloonsPopped = 0;
    public double CashSpent = 0;
    public int WeaponsBought = 0;
    public int StrongerWeaponsBought = 0;
    public int AbilityBought = 0;
    public int RoundsCleared = 0;
    public int UpgradesBought = 0;
    public int AncientPiece = 0;
    public double DailyBloonsPopped = 0;
    public double DailyCashSpent = 0;
    public double DailyWeaponsBought = 0;
    public WeaponTemplate.Rarity minNewWeaponRarity = WeaponTemplate.Rarity.Common;
    public WeaponTemplate.Rarity maxNewWeaponRarity = WeaponTemplate.Rarity.Exotic;
    public WeaponTemplate.Rarity minStrongWeaponRarity = WeaponTemplate.Rarity.Common;
    public WeaponTemplate.Rarity maxStrongWeaponRarity = WeaponTemplate.Rarity.Exotic;
    public string Path = "Mods/AncientMonkey/";
    public List<Model> newAttackModels = new List<Model>();
    public List<KeyValuePair<AbilityTemplate, List<Model>>> currentAbilities = new List<KeyValuePair<AbilityTemplate, List<Model>>>();

    public override void OnApplicationQuit()
    {
        if (!Directory.Exists(Path)) { return; }
        string file = Path + "Data.txt";
        string[] lines = File.ReadAllLines(file);
        File.WriteAllLines(file, lines);
    }
    public List<object> DoesLinesContains(string stringContain)
    {
        string file = Path + "Data.txt";
        string[] lines = File.ReadAllLines(file);
        var contains = false;
        var i = 0;
        var y = 0;
        foreach (string line in lines)
        {
            if (line.Contains(stringContain))
            {
                contains = true;
                y = i;
            }
            i++;
            
        }
        return new List<object>() {contains, y};
    }
    public override void OnRoundEnd()
    {
        if (InGame.instance == null || InGame.instance.bridge == null) { return; }
        InGame game = InGame.instance;
        var towers = InGame.Bridge.GetAllTowers();
        var hasAncientMonkey = false;
        foreach (var tts in towers.ToArray())
        {
            if (tts.tower.towerModel.name.Contains("AncientMonkey"))
            {
                hasAncientMonkey = true;
                break;
            }
        }
        if (hasAncientMonkey)
        {
            mod.RoundsCleared++;
        }
    }
    public static T StartMonobehavior<T>() where T : MonoBehaviour {
        var obj = InGame.instance.GetInGameUI().AddComponent<T>();

        return obj as T;
    }
    public override void OnApplicationStart()
    {
        mod = this;
        foreach (AbilityTemplate ability in ModContent.GetContent<AbilityTemplate>())
        {
            AbilityClass.AbilityName.Add(ability.AbilityName);
            AbilityClass.AbilityImg.Add(ability.Icon);
            AbilityClass.AbilityCustomImg.Add(ability.CustomIcon);
        }
    }
    public void Reset()
    {
        newWeaponCost = (float)Settings.settingsValue["NewWeaponStartingCost"];
        baseNewWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalNewWeaponCostMultiplier"];
        rareChance = 100 - (float)Settings.settingsValue["BaseRareChance"];
        epicChance = 100 - (float)Settings.settingsValue["BaseEpicChance"];
        rareStrongChance = 100 - (float)Settings.settingsValue["StrongBaseRareChance"];
        epicStrongChance = 100 - (float)Settings.settingsValue["StrongBaseEpicChance"];
        legendaryStrongChance = 100 - (float)Settings.settingsValue["StrongBaseLegendaryChance"];
        legendaryChance = 100 - (float)Settings.settingsValue["BaseLegendaryChance"];
        exoticChance =  100 - (float)Settings.settingsValue["BaseExoticChance"];
        exoticStrongChance = 100 - (float)Settings.settingsValue["StrongBaseExoticChance"];
        baseNewWeaponCost = (float)Settings.settingsValue["IncrementalNewWeaponStartingCost"];
        strongerWeaponCost = (float)Settings.settingsValue["StrongerWeaponStartingCost"];
        baseStrongerWeaponCost = (float)Settings.settingsValue["IncrementalStrongerWeaponStartingCost"];
        baseStrongerWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalStrongerWeaponCostMultiplier"];
        newAbilityCost = (float)Settings.settingsValue["NewAbilityStartingCost"];
        baseNewAbilityCost = (float)Settings.settingsValue["IncrementalNewAbilityStartingCost"];
        baseNewAbilityCostMultiplier = (float)Settings.settingsValue["IncrementalNewAbilityCostMultiplier"];
        upgradeOpen = false;
        selectingWeaponOpen = false;
        mib = false;
        panelOpen = false;
        level = 0;
        newWeaponSlot = (int)Settings.settingsValue["NewWeaponStartingSlot"];
        strongWeaponSlot = (int)Settings.settingsValue["StrongerWeaponStartingSlot"];
        abilitySlot = (int)Settings.settingsValue["NewAbilityStartingSlot"];
        extraWeaponSlotLevel = 0;
        extraWeaponSlotLevelMax = (int)Settings.settingsValue["ExtraWeaponSlotUpgradeCount"];
        extraWeaponSlotCost = (float)Settings.settingsValue["ExtraWeaponSlotStartingCost"];
        strongExtraWeaponSlotLevel = 0;
        strongExtraWeaponSlotCost = (float)Settings.settingsValue["ExtraStrongerSlotStartingCost"];
        strongExtraWeaponSlotLevelMax = (int)Settings.settingsValue["ExtraStrongerSlotUpgradeCount"];
        ExtraAbilitySlotLevelMax = (int)Settings.settingsValue["ExtraAbilitySlotUpgradeCount"];
        ExtraAbilitySlotLevel = 0; 
        ExtraAbilitySlotCost = (float)Settings.settingsValue["ExtraAbilitySlotStartingCost"];
        ExtraLuckCost = (float)Settings.settingsValue["ExtraLuckStartingCost"];
        ExtraLuckLevel = 0;
        ExtraLuckMax = (int)Settings.settingsValue["ExtraLuckUpgradeCount"];
        minNewWeaponRarity = WeaponTemplate.Rarity.Common;
        maxNewWeaponRarity = WeaponTemplate.Rarity.Exotic;
        minStrongWeaponRarity = WeaponTemplate.Rarity.Common;
        maxStrongWeaponRarity = WeaponTemplate.Rarity.Exotic;
        UpgradeCost = (float)Settings.settingsValue["Upgrade1Cost"];
        Upgrade2Cost = (float)Settings.settingsValue["Upgrade2Cost"];
        currentAbilities.Clear();
        XP = 0;
        XPMax = 0;
        foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
        {
            weapon.stackIndex = 0;
        }

    }
    public override void OnGameModelLoaded(GameModel model)
    {
        Reset();
    }
    public override void OnTowerSold(Tower tower, float amount)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            Reset();
        }
    }
    public override void OnRestart()
    {
        MenuUi.instance.CloseMenu();
    }
    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            minNewWeaponRarity = WeaponTemplate.Rarity.Common;
            maxNewWeaponRarity = WeaponTemplate.Rarity.Common;
            newWeaponSlot = 5;
            MenuUi.NewWeaponPanel(rect, tower, false);
            Reset();
        }
    }
    
    public override void OnNewGameModel(GameModel result)
    {
        foreach (var tower in result.towerSet.ToList())
        {
            if (tower.name.Contains("AncientMonkey-AncientMonkey"))
            {
                tower.GetShopTowerDetails().towerCount = 1;
            }
        }
    }
    public override void OnTowerSelected(Tower tower)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            MenuUi.CreateUpgradeMenu(rect, tower);
            upgradeOpen = true;
        }
    }
    public override void OnTowerDeselected(Tower tower)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            upgradeOpen = false;
            if (MenuUi.instance)
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
            if ((bool)Settings.settingsValue["SandboxMode"])
            {
                RectTransform rect = game.uiRect;
                MenuUi.NewWeaponPanel(rect, tower, false);
                MenuUi.instance.CloseMenu();
                return;
            }
            if (game.GetCash() >= mod.newWeaponCost)
            {
                game.AddCash(-mod.newWeaponCost);
                mod.WeaponsBought++;
                mod.DailyWeaponsBought++;
                mod.CashSpent += mod.newWeaponCost;
                mod.DailyCashSpent += mod.newWeaponCost;
                RectTransform rect = game.uiRect;
                mod.newWeaponCost += mod.baseNewWeaponCost;
                tower.worth += mod.newWeaponCost - mod.baseNewWeaponCost;
                mod.baseNewWeaponCost *= mod.baseNewWeaponCostMultiplier;
                MenuUi.NewWeaponPanel(rect, tower,false);
                MenuUi.instance.CloseMenu();
            }
        }
        public void WeaponSelected(string Weapon, Tower tower,bool levelup, int starCount, List<MutatorTemplate> mutators)
        {
            mod.panelOpen = false;
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            if(!(bool)Settings.settingsValue["SandboxMode"])
            {
                Destroy(gameObject);
            }

            foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
            {
                if (weapon.WeaponName == Weapon)
                {
                    mod.newAttackModels.Clear();
                    weapon.stackIndex += 1;
                    var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                    weapon.EditTower(towerModel);
                    AddArtefactEffects(mod.newAttackModels, starCount, mutators); 
                    tower.UpdateRootModel(towerModel);
                }
            }
            if ((bool)Settings.settingsValue["XpEnabled"]) {
                mod.XP += 1;
            }
           
            if (levelup)
            {
                mod.XP = 0;
            }
            if (mod.XP >= mod.XPMax && mod.level >= 2)
            {
                mod.XPMax += (int)Settings.settingsValue["MaxXpIncrease"];
                NewWeaponPanel(rect, tower, true);

                return;
            }
            if(mod.level == 0)
            {
                mod.rareChance -= (float)Settings.settingsValue["BaseRareChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                if (mod.rareChance <= 100 - (float)Settings.settingsValue["BaseRareChanceUntilEpicChance"])
                {
                    mod.epicChance -= (float)Settings.settingsValue["BaseEpicChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.epicChance <= 100 - (float)Settings.settingsValue["BaseEpicChanceUntilLegendaryChance"])
                {
                    mod.legendaryChance -= (float)Settings.settingsValue["BaseLegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.04f));
                }
                if (mod.legendaryChance <= 100 - (float)Settings.settingsValue["BaseLegendaryChanceUntilExoticChance"])
                {
                    mod.exoticChance -= (float)Settings.settingsValue["BaseExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
            }
           
            if (mod.level == 1)
            {
                mod.epicChance -= (float)Settings.settingsValue["Upgrade1EpicChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                if (mod.epicChance <= 100 - (float)Settings.settingsValue["Upgrade1EpicChanceUntilLegendaryChance"])
                {
                    mod.legendaryChance -= (float)Settings.settingsValue["Upgrade1LegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.legendaryChance <= 100 - (float)Settings.settingsValue["Upgrade1LegendaryChanceUntilExoticChance"])
                {
                    mod.exoticChance -= (float)Settings.settingsValue["Upgrade1ExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.exoticChance <= 100 - (float)Settings.settingsValue["Upgrade1ExoticChanceUntilGodlyChance"])
                {
                    mod.godlyChance -= (float)Settings.settingsValue["Upgrade1GodlyChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
            }
            if (mod.level == 2)
            {
                mod.legendaryChance -= (float)Settings.settingsValue["Upgrade2LegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                if (mod.legendaryChance <= 100 - (float)Settings.settingsValue["Upgrade2LegendaryChanceUntilExoticChance"])
                {
                    mod.exoticChance -= (float)Settings.settingsValue["Upgrade2ExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.exoticChance <= 100 - (float)Settings.settingsValue["Upgrade2ExoticChanceUntilGodlyChance"])
                {
                    mod.godlyChance -= (float)Settings.settingsValue["Upgrade2GodlyChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.godlyChance <= 100 - (float)Settings.settingsValue["Upgrade2GodlyChanceUntilOmegaChance"])
                {
                    mod.omegaChance -= (float)Settings.settingsValue["Upgrade2OmegaChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
            }
          
            if (mod.upgradeOpen == true && !(bool)Settings.settingsValue["SandboxMode"])
            {
                CreateUpgradeMenu(rect, tower);
            }
            
        }

        public void AddArtefactEffects(List<Model> models, int starCount, List<MutatorTemplate> mutators)
        {
            foreach (Model model in models) 
            {
                foreach (var artefact in ModContent.GetContent<ArtifactTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if(artefact.enabled)
                    {
                        artefact.EditModel(model);
                    }
                }
                AddBuffToModelBasedOnArtefact(starCount, model);
                foreach (MutatorTemplate mutatorTemplate in mutators)
                {
                    mutatorTemplate.EditModel(model);
                }
            }
        }
        public void AddBuffToModelBasedOnArtefact(int starCount, Model model)
        {
            float damageBuff = 1f;
            float pierceBuff = 1f;
            float rateBuff = 1f;
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            if (starCount == 0)
            {
                damageBuff = rnd.Next(500, 750) / 1000f;
                pierceBuff = rnd.Next(500, 750) / 1000f;
                rateBuff = rnd.Next(1200, 1450) / 1000f;
            }
            if (starCount == 1)
            {
                damageBuff = rnd.Next(750, 900) / 1000f;
                pierceBuff = rnd.Next(750, 900) / 1000f;
                rateBuff = rnd.Next(1100, 1200) / 1000f;
            }
            if (starCount == 2)
            {
                damageBuff = rnd.Next(900, 1100) / 1000f;
                pierceBuff = rnd.Next(900, 1100) / 1000f;
                rateBuff = rnd.Next(950, 1100) / 1000f;
            }
            if (starCount == 3)
            {
                damageBuff = rnd.Next(1100, 1250) / 1000f;
                pierceBuff = rnd.Next(1100, 1250) / 1000f;
                rateBuff = rnd.Next(900, 950) / 1000f;
            }
            if (starCount == 4)
            {
                damageBuff = rnd.Next(1250, 1500) / 1000f;
                pierceBuff = rnd.Next(1250, 1500) / 1000f;
                rateBuff = rnd.Next(850, 900) / 1000f;
            }
            if (starCount == 5)
            {
                damageBuff = rnd.Next(1500, 1800) / 1000f;
                pierceBuff = rnd.Next(1500, 1800) / 1000f;
                rateBuff = rnd.Next(780, 850) / 1000f;
            }
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToArray())
            {
                projectile.pierce *= pierceBuff;
            }
            foreach (DamageModel damageModel in model.GetDescendants<DamageModel>().ToArray())
            {
                damageModel.damage *= damageBuff;
            }
            foreach (WeaponModel weapon in model.GetDescendants<WeaponModel>().ToArray())
            {
                weapon.rate *= rateBuff;
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
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Omega)
            {
                sprite = VanillaSprites.MainBgPanelHematite;
            }
            var panel = ModHelperPanel.Create(new Info("WeaponContent" + weapon.WeaponName, 0, 0, 2250, 150), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText wpnName = panel.AddText(new Info("wpnName", -600, 0, 1000, 150), weapon.WeaponName, 80, TextAlignmentOptions.MidlineLeft);
            ModHelperText rarity = panel.AddText(new Info("rarity", 275, 0, 600, 150), weapon.WeaponRarity.ToString(), 80, TextAlignmentOptions.MidlineLeft);
            ModHelperImage image = panel.AddImage(new Info("image", -100, 0, 140, 140), weapon.Icon);
            ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { upgradeUi.WeaponSelected(weapon.WeaponName, tower, false, 2, null);}) ) ;
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
            ModHelperButton exit = panel.AddButton(new Info("exit", 1200, 900, 135, 135), VanillaSprites.RedBtn, new System.Action(() => {
                tower.SetSelectionBlocked(false); panel.DeleteObject(); if (mod.upgradeOpen == true){CreateUpgradeMenu(rect, tower);  }
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
       
        public static void NewWeaponPanel(RectTransform rect, Tower tower, bool Levelup)
        {
            mod.panelOpen = true;
            if(instance)
            {
                instance.CloseMenu();
            }
          
            if((bool)Settings.settingsValue["SandboxMode"])
            {
                SandBoxWeaponPanel(rect, tower);
                return;
            }
            float weaponPanelWidth = 833.33f;
            float weaponPanelX = 412.5f;
            float weaponPanelY = 900;
            float wpnContentX = 25 - (mod.newWeaponSlot -1) * 425;
            float panelWidth = mod.newWeaponSlot * weaponPanelWidth;
            var imag = VanillaSprites.BrownInsertPanel;
            if (mod.level == 1)
            {
                imag = VanillaSprites.BlueInsertPanel;
            }
            if (mod.level == 2)
            {
                imag = VanillaSprites.MainBgPanelParagon;
            }
            ModHelperPanel panel =  rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, panelWidth, 1850, new UnityEngine.Vector2()), imag);

            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText selectWpn = panel.AddText(new Info("selectWpn", 0, 800, 2500, 180), "Select New Weapon", 100);
            if (!instance)
            {
                selectWpn.Text.text = "Choose A starter Weapon";
                selectWpn.Text.color = new Color(0, 1, 0);
            }
            if (Levelup)
            {
                selectWpn.Text.text = "Choose A level up Weapon";
                selectWpn.Text.color = new Color(0.46f, 0, 0.78f);
            }
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            for (int i = 0; i < mod.newWeaponSlot; i++)
            {
                var WpnRarityNum = rnd.Next(1, 100);
                var WpnRarity = "Common";
                var RarityNumber = 1;
                var MinNum = 1;
                var MaxNum = 1;
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Common)
                {
                    MinNum = 1;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Rare)
                {
                    MinNum = 2;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Epic)
                {
                    MinNum = 3;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Legendary)
                {
                    MinNum = 4;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Exotic)
                {
                    MinNum = 5;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Godly)
                {
                    MinNum = 6;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Omega)
                {
                    MinNum = 7;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Common)
                {
                    MaxNum = 1;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Rare)
                {
                    MaxNum = 2;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Epic)
                {
                    MaxNum = 3;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Legendary)
                {
                    MaxNum = 4;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Exotic)
                {
                    MaxNum = 5;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Godly)
                {
                    MaxNum = 6;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Omega)
                {
                    MaxNum = 7;
                }
                if (WpnRarityNum > mod.rareChance)
                {
                    RarityNumber = 2;
                }
                if (WpnRarityNum > mod.epicChance)
                {
                    RarityNumber = 3;
                }
                if (WpnRarityNum > mod.legendaryChance)
                {
                    RarityNumber = 4;
                }
                if (WpnRarityNum > mod.exoticChance)
                {
                    RarityNumber = 5;
                }
                if (WpnRarityNum > mod.godlyChance)
                {
                    RarityNumber = 6;
                }
                if (WpnRarityNum > mod.omegaChance)
                {
                    RarityNumber = 7;
                }
                if (RarityNumber < MinNum)
                {
                    RarityNumber = MinNum;
                }
                if (RarityNumber > MaxNum)
                {
                    RarityNumber = MaxNum;
                }
                if (RarityNumber == 2)
                {
                     WpnRarity = "Rare";
                }
                if (RarityNumber == 3)
                {
                    WpnRarity = "Epic";
                }
                if (RarityNumber == 4)
                {
                    WpnRarity = "Legendary";
                }
                if (RarityNumber == 5)
                {
                    WpnRarity = "Exotic";
                }
                if (RarityNumber == 6)
                {
                    WpnRarity = "Godly";
                }
                if (RarityNumber == 7)
                {
                    WpnRarity = "Omega";
                }

                List<WeaponTemplate> CEnabled = new List<WeaponTemplate>();
                foreach (var common in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (common.enabled && common.WeaponRarity == WeaponTemplate.Rarity.Common)
                    {
                        CEnabled.Add(common);
                    }
                }
                List<WeaponTemplate> REnabled = new List<WeaponTemplate>();
                foreach (var rare in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (rare.enabled && rare.WeaponRarity == WeaponTemplate.Rarity.Rare)
                    {
                        REnabled.Add(rare);
                    }
                }
                List<WeaponTemplate> EEnabled = new List<WeaponTemplate>();
                foreach (var epic in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (epic.enabled && epic.WeaponRarity == WeaponTemplate.Rarity.Epic)
                    {
                        EEnabled.Add(epic);
                    }
                }
                List<WeaponTemplate> LEnabled = new List<WeaponTemplate>();
                foreach (var legendary in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (legendary.enabled && legendary.WeaponRarity == WeaponTemplate.Rarity.Legendary)
                    {
                        LEnabled.Add(legendary);
                    }
                }
                List<WeaponTemplate> ExEnabled = new List<WeaponTemplate>();
                foreach (var exotic in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (exotic.enabled && exotic.WeaponRarity == WeaponTemplate.Rarity.Exotic)
                    {
                        ExEnabled.Add(exotic);
                    }
                }
                List<WeaponTemplate> GEnabled = new List<WeaponTemplate>();
                foreach (var godly in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (godly.enabled && godly.WeaponRarity == WeaponTemplate.Rarity.Godly)
                    {
                        GEnabled.Add(godly);
                    }
                }
                List<WeaponTemplate> OEnabled = new List<WeaponTemplate>();
                foreach (var omega in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (omega.enabled && omega.WeaponRarity == WeaponTemplate.Rarity.Omega)
                    {
                        OEnabled.Add(omega);
                    }
                }

                var starLuck = rnd.Next(0, 101);
                var starCount = 5;

                if (0 < starLuck)
                {
                    starCount = 0;
                }
                if (5 < starLuck)
                {
                    starCount = 1;
                }
                if (15 < starLuck)
                {
                    starCount = 2;
                }
                if (68 < starLuck)
                {
                    starCount = 3;
                }
                if (90 < starLuck)
                {
                    starCount = 4;
                }
                if (98 < starLuck)
                {
                    starCount = 5;
                }


                var sprite = VanillaSprites.GreyInsertPanel;
                var numWpn = rnd.Next(0, CEnabled.Count);
                var weapon = CEnabled[numWpn].WeaponName;
                var img = CEnabled[numWpn].Icon;
                Sprite csprite = CEnabled[numWpn].CustomIcon;
                if (WpnRarity == "Rare")
                {
                    numWpn = rnd.Next(0, REnabled.Count);
                    sprite = VanillaSprites.BlueInsertPanel;
                    weapon = REnabled[numWpn].WeaponName;
                    img = REnabled[numWpn].Icon;
                    csprite = REnabled[numWpn].CustomIcon;
                }
                if (WpnRarity == "Epic")
                {
                    numWpn = rnd.Next(0, EEnabled.Count);
                    sprite = VanillaSprites.MainBgPanelParagon;
                    weapon = EEnabled[numWpn].WeaponName;
                    img = EEnabled[numWpn].Icon;
                    csprite = EEnabled[numWpn].CustomIcon;
                }
                if (WpnRarity == "Legendary")
                {
                    numWpn = rnd.Next(0, LEnabled.Count);
                    sprite = VanillaSprites.MainBGPanelYellow;
                    weapon = LEnabled[numWpn].WeaponName;
                    img = LEnabled[numWpn].Icon;
                    csprite = LEnabled[numWpn].CustomIcon;
                }
                if (WpnRarity == "Exotic")
                {
                    numWpn = rnd.Next(0, ExEnabled.Count);
                    sprite = VanillaSprites.MainBgPanelWhiteSmall;
                    weapon = ExEnabled[numWpn].WeaponName;
                    img = ExEnabled[numWpn].Icon;
                    csprite = ExEnabled[numWpn].CustomIcon;
                }
                if (WpnRarity == "Godly")
                {
                    numWpn = rnd.Next(0, GEnabled.Count);
                    sprite = VanillaSprites.MainBGPanelSilver;
                    weapon = GEnabled[numWpn].WeaponName;
                    img = GEnabled[numWpn].Icon;
                    csprite = GEnabled[numWpn].CustomIcon;
                }
                if (WpnRarity == "Omega")
                {
                    numWpn = rnd.Next(0, OEnabled.Count);
                    sprite = VanillaSprites.MainBgPanelHematite;
                    weapon = OEnabled[numWpn].WeaponName;
                    img = OEnabled[numWpn].Icon;
                    csprite = OEnabled[numWpn].CustomIcon;
                }   
                ModHelperPanel wpnPanel = panel.AddPanel(new Info("wpnPanel", weaponPanelX, weaponPanelY, 650, 1450, new UnityEngine.Vector2()), sprite);
                ModHelperText rarityText = panel.AddText(new Info("rarityText", wpnContentX, 600, 800, 180), WpnRarity, 100);
                ModHelperText weaponText = panel.AddText(new Info("weaponText", wpnContentX, 500, 800, 180), weapon, 75);

                List<MutatorTemplate> mutators = GetRandomMutators();

                ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", wpnContentX, -550, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(weapon, tower,Levelup, starCount,mutators)));
                ModHelperText selectWpnTxt = selectWpnBtn.AddText(new Info("selectWpnTxt", 0, 0, 700, 160), "Select", 70);
                var starX = -240;
                for (int x = 0; x < starCount; x++)
                {
                    ModHelperImage image = panel.AddImage(new Info("image", starX + wpnContentX, -685, 90, 90), VanillaSprites.MkOnGreen);
                    image.RectTransform.rotation = Quaternion.Euler(0,0,45);
                    starX += 120;
                }
                for (int x = 0; x < 5 - starCount; x++)
                {
                    ModHelperImage image = panel.AddImage(new Info("image", starX + wpnContentX, -685, 90, 90), VanillaSprites.MkOffRed);
                    image.RectTransform.rotation = Quaternion.Euler(0, 0, 45);
                    starX += 120;
                }
                ModHelperScrollPanel mutatorsPanel = wpnPanel.AddScrollPanel(new Info("mutatorsPanel", -43, 325, 80, 650, new UnityEngine.Vector2()), RectTransform.Axis.Vertical, sprite);
         
              
                foreach (var mutator in mutators)
                {
                    ModHelperButton button= null;
                    button = ModHelperButton.Create(new Info("Image", -40, 325, 75, 75), mutator.Icon, new System.Action(() => { PopupScreen.instance.ShowOkPopup(mutator.MutatorName + " Mutator: " + mutator.MutatorDescription, null); }));
                 
                    mutatorsPanel.AddScrollContent(button);
                }
                foreach (var weaponContent in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (weaponContent.WeaponName == weapon)
                    {
                        if (weaponContent.Description != null)
                        {
                            ModHelperText descText = panel.AddText(new Info("descText", wpnContentX, 400, 800, 180), weaponContent.Description, 55);
                        }
                        ModHelperText StackIndex = panel.AddText(new Info("StackIndex", wpnContentX - 275, 650, 100, 100), $"{weaponContent.stackIndex}", 80);
                        if (weaponContent.CustomIcon)
                        {
                            ModHelperImage image = panel.AddImage(new Info("image", wpnContentX, 0, 400, 400), csprite);
                        }
                        else
                        {
                            ModHelperImage image = panel.AddImage(new Info("image", wpnContentX, 0, 400, 400), img);
                        }
                        if (weaponContent.IsCamo && !weaponContent.IsLead)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", wpnContentX + 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                        }
                        if (weaponContent.IsLead && !weaponContent.IsCamo)
                        {
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", wpnContentX + 275, 650, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                        if (weaponContent.IsLead && weaponContent.IsCamo)
                        {
                            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", wpnContentX + 275, 650, 100, 100), VanillaSprites.CamoBloonIcon);
                            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", wpnContentX + 275, 560, 100, 100), VanillaSprites.LeadBloonIcon);
                        }
                    }
                }
                weaponPanelX += weaponPanelWidth;
                wpnContentX += weaponPanelWidth;
            }
           
        }
        public static List<MutatorTemplate> GetRandomMutators()
        {
            List<KeyValuePair<int, float>> mutatorsCountLuck = new List<KeyValuePair<int, float>>() { new KeyValuePair<int, float>(0, 350f), new KeyValuePair<int, float>(1, 200f), new KeyValuePair<int, float>(2, 80f), new KeyValuePair<int, float>(3, 20f), new KeyValuePair<int, float>(4, 6), new KeyValuePair<int, float>(5, 2)
            , new KeyValuePair<int, float>(6, 0.9f), new KeyValuePair<int, float>(7, 0.4f), new KeyValuePair<int, float>(8, 0.18f), new KeyValuePair<int, float>(9, 0.09f), new KeyValuePair<int, float>(10, 0.03f)};

            float totalLuck = 0;
            foreach (var item in mutatorsCountLuck)
            {
                totalLuck += item.Value;
            }
         
            float randomLuck = RandomExtensions.Range(new Il2CppSystem.Random(), 0.0000f, totalLuck);
            int mutatorCount = 0;
           
            foreach (var item in mutatorsCountLuck)
            {
                randomLuck -= item.Value;
                if (randomLuck < 0)
                {
                    mutatorCount = item.Key;
                    break;
                }
            }

            List<MutatorTemplate> allMutators = ModContent.GetContent<MutatorTemplate>().ToList();
            List<MutatorTemplate> mutators = new List<MutatorTemplate>();
            for (int i = 0; i < mutatorCount; i++)
            {
                var randomNum = new Random().Next(0, allMutators.Count);
                mutators.Add(allMutators[randomNum]);
            }

            return mutators;
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

            ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 0, -600, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { upgradeUi.StrongWpnSelected(new List<KeyValuePair<float, BuffKey>>(), tower); panel.DeleteObject(); }));
            ModHelperText selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Edit", 70);
        }
        public static void StrongWeaponPanel(RectTransform rect, Tower tower)
        {
            mod.panelOpen = true;
            if ((bool)Settings.settingsValue["SandboxMode"])
            {
                SandBoxStrongWeaponPanel(rect, tower);
                return;
            }
            float strongWeaponPanelWidth = 833.33f;
            float strongWeaponPanelX = 412.5f;
            float strongWeaponPanelY = 900;
            float strongWpnContentX = 25 - (mod.strongWeaponSlot - 1) * 425;
            float panelWidth = mod.strongWeaponSlot * strongWeaponPanelWidth;
            var img = VanillaSprites.BrownInsertPanel;
            if (mod.level == 1)
            {
                img = VanillaSprites.BlueInsertPanel;
            }
            if (mod.level == 2)
            {
                img = VanillaSprites.MainBgPanelParagon;
            }
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, panelWidth, 1850, new UnityEngine.Vector2()), img);
            ModHelperText selectStrongWpn = panel.AddText(new Info("selectStrongWpn", 0, 800, 2500, 180), "Select Stronger Weapon Card", 100);
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();

            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            for (int i = 0; i < mod.strongWeaponSlot; i++)
            {
                var StrongWpnRarityNum = rnd.Next(1, 100);
                var StrongWpnRarity = "Common";
                var RarityNumber = 1;
                var MinNum = 1;
                var MaxNum = 1;
                var sprite = VanillaSprites.GreyInsertPanel;


                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Common)
                {
                    MinNum = 1;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Rare)
                {
                    MinNum = 2;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Epic)
                {
                    MinNum = 3;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Legendary)
                {
                    MinNum = 4;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Exotic)
                {
                    MinNum = 5;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Godly)
                {
                    MinNum = 6;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Omega)
                {
                    MinNum = 7;
                }
                if (mod.minNewWeaponRarity == WeaponTemplate.Rarity.Common)
                {
                    MaxNum = 1;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Rare)
                {
                    MaxNum = 2;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Epic)
                {
                    MaxNum = 3;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Legendary)
                {
                    MaxNum = 4;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Exotic)
                {
                    MaxNum = 5;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Godly)
                {
                    MaxNum = 6;
                }
                if (mod.maxNewWeaponRarity == WeaponTemplate.Rarity.Omega)
                {
                    MaxNum = 7;
                }
                if (StrongWpnRarityNum > mod.rareStrongChance)
                {
                    RarityNumber = 2;
                }
                if (StrongWpnRarityNum > mod.epicStrongChance)
                {
                    RarityNumber = 3;
                }
                if (StrongWpnRarityNum > mod.legendaryStrongChance)
                {
                    RarityNumber = 4;
                }
                if (StrongWpnRarityNum > mod.exoticStrongChance)
                {
                    RarityNumber = 5;
                }
                if (StrongWpnRarityNum > mod.godlyStrongerChance)
                {
                    RarityNumber = 6;
                }
                if (StrongWpnRarityNum > mod.omegaStrongerChance)
                {
                    RarityNumber = 7;
                }
                if (RarityNumber < MinNum)
                {
                    RarityNumber = MinNum;
                }
                if (RarityNumber > MaxNum)
                {
                    RarityNumber = MaxNum;
                }
                if (RarityNumber == 2)
                {
                    StrongWpnRarity = "Rare";
                }
                if (RarityNumber == 3)
                {
                    StrongWpnRarity = "Epic";
                }
                if (RarityNumber == 4)
                {
                    StrongWpnRarity = "Legendary";
                }
                if (RarityNumber == 5)
                {
                    StrongWpnRarity = "Exotic";
                }
                if (RarityNumber == 6)
                {
                    StrongWpnRarity = "Godly";
                }
                if (RarityNumber == 7)
                {
                    StrongWpnRarity = "Omega";
                }
                StrongerWeaponTemplate template = new Common();
                if (StrongWpnRarity == "Common")
                {
                    foreach (StrongerWeaponTemplate strongerWeapon in ModContent.GetContent<StrongerWeaponTemplate>())
                    {
                        if (strongerWeapon.Rarity == WeaponTemplate.Rarity.Common)
                        {
                            template = strongerWeapon;
                        }
                    }
                    sprite = VanillaSprites.GreyInsertPanel;
                }
                if (StrongWpnRarity == "Rare")
                {
                    foreach (StrongerWeaponTemplate strongerWeapon in ModContent.GetContent<StrongerWeaponTemplate>())
                    {
                        if (strongerWeapon.Rarity == WeaponTemplate.Rarity.Rare)
                        {
                            template = strongerWeapon;
                        }
                    }
                    sprite = VanillaSprites.BlueInsertPanel;
                }
                if (StrongWpnRarity == "Epic")
                {
                    foreach (StrongerWeaponTemplate strongerWeapon in ModContent.GetContent<StrongerWeaponTemplate>())
                    {
                        if (strongerWeapon.Rarity == WeaponTemplate.Rarity.Epic)
                        {
                            template = strongerWeapon;
                        }
                    }
                    sprite = VanillaSprites.MainBgPanelParagon;
                }
                if (StrongWpnRarity == "Legendary")
                {
                    foreach (StrongerWeaponTemplate strongerWeapon in ModContent.GetContent<StrongerWeaponTemplate>())
                    {
                        if (strongerWeapon.Rarity == WeaponTemplate.Rarity.Legendary)
                        {
                            template = strongerWeapon;
                        }
                    }
                    sprite = VanillaSprites.MainBGPanelYellow;
                }
                if (StrongWpnRarity == "Exotic")
                {
                    foreach (StrongerWeaponTemplate strongerWeapon in ModContent.GetContent<StrongerWeaponTemplate>())
                    {
                        if (strongerWeapon.Rarity == WeaponTemplate.Rarity.Exotic)
                        {
                            template = strongerWeapon;
                        }
                    }
                    sprite = VanillaSprites.MainBgPanelWhiteSmall;
                }
                if (StrongWpnRarity == "Godly")
                {
                    foreach (StrongerWeaponTemplate strongerWeapon in ModContent.GetContent<StrongerWeaponTemplate>())
                    {
                        if (strongerWeapon.Rarity == WeaponTemplate.Rarity.Godly)
                        {
                            template = strongerWeapon;
                        }
                    }
                    sprite = VanillaSprites.MainBGPanelSilver;
                }
                if (StrongWpnRarity == "Omega")
                {
                    foreach (StrongerWeaponTemplate strongerWeapon in ModContent.GetContent<StrongerWeaponTemplate>())
                    {
                        if (strongerWeapon.Rarity == WeaponTemplate.Rarity.Omega)
                        {
                            template = strongerWeapon;
                        }
                    }
                    sprite = VanillaSprites.MainBgPanelParagon;
                    sprite = VanillaSprites.MainBgPanelHematite;
                }
                List<BuffKey> buffKeys = new List<BuffKey>();
                for (int x = 0; x < rnd.Next(template.BuffMinCount, template.BuffMaxCount + 1); x++)    
                {
                    buffKeys.Add(template.GetRandomBuffKey());
                }
                List<KeyValuePair<float, BuffKey>> keyValues = new List<KeyValuePair<float, BuffKey>>();
                foreach (BuffKey key in buffKeys)
                {
                    keyValues.Add(new KeyValuePair<float, BuffKey> (rnd.Next(Mathf.RoundToInt(key.minValue * 1000), Mathf.RoundToInt(key.maxValue * 1000)) / 1000f, key));
                }
                ModHelperPanel strongWpnPanel = panel.AddPanel(new Info("strongWpnPanel", strongWeaponPanelX, strongWeaponPanelY, 650, 1450, new UnityEngine.Vector2()), sprite);
                
                ModHelperText rarityText = panel.AddText(new Info("rarityText", strongWpnContentX, 600, 800, 180), StrongWpnRarity, 100);
                ModHelperText cardText = panel.AddText(new Info("cardText", strongWpnContentX, 500, 800, 180), "Stronger Weapon Card", 50);
                ModHelperScrollPanel scrollPanel = strongWpnPanel.AddScrollPanel(new Info("strongWpnPanel", 0, 0, 610, 850), RectTransform.Axis.Vertical, sprite, 1, 0);
                foreach (KeyValuePair<float, BuffKey> key in keyValues) 
                {
                    scrollPanel.AddScrollContent(instance.AddBuffStat(key, sprite));
                }

                ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", strongWpnContentX, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(keyValues, tower)));
                ModHelperText selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Select", 70);
                strongWeaponPanelX += strongWeaponPanelWidth;
                strongWpnContentX += strongWeaponPanelWidth;
            }
        }
        public ModHelperPanel AddBuffStat(KeyValuePair<float, BuffKey> key, string sprite)
        {
            ModHelperPanel panel = ModHelperPanel.Create(new Info("panel", 0, 0, 600, 120), sprite);
            panel.AddImage(new Info("Image", 235, 0, 110, 110), key.Value.statBuff.icon);
            string buffName = GetBuffName(key.Value.statBuff.buffType);
            if (key.Value.statBuff.buffType == StatsBuff.BuffTypes.MIB)
            {
                panel.AddText(new Info("Name", -65, 0, 450, 110), "+MIB", 40);
            }
            else
            {
                if (key.Value.operation == Operations.Add)
                {
                    panel.AddText(new Info("Name", -65, 0, 450, 110), "+ " + key.Key + "% " + buffName, 40);
                }
                if (key.Value.operation == Operations.Subtract)
                {
                    panel.AddText(new Info("Name", -65, 0, 450, 110), "- " + key.Key + "% " + buffName, 40);
                }
                if (key.Value.operation == Operations.Multiply)
                {
                    panel.AddText(new Info("Name", -65, 0, 450, 110), "+ " + Mathf.Round((key.Key - 1) * 1000) / 10 + "% " + buffName, 40);
                }
                if (key.Value.operation == Operations.Divide)
                {
                    panel.AddText(new Info("Name", -65, 0, 450, 110), "- " + Mathf.Round((key.Key - 1) * 1000) /10 + "% " + buffName, 40);
                }
            }
                
           
            return panel;
        }
        public string GetBuffName(StatsBuff.BuffTypes buffTypes)
        {
            string buffName = "";

            switch (buffTypes)
            {
                case StatsBuff.BuffTypes.Damage:
                    buffName = "Damage";
                    break;
                case StatsBuff.BuffTypes.AttackSpeed:
                    buffName = "Attack Interval";
                    break;
                case StatsBuff.BuffTypes.Range:
                    buffName = "Range";
                    break;
                case StatsBuff.BuffTypes.Pierce:
                    buffName = "Pierce";
                    break;
                case StatsBuff.BuffTypes.Money:
                    buffName = "Money";
                    break;
                case StatsBuff.BuffTypes.AbilityCooldown:
                    buffName = "Ability Cooldown";
                    break;
                case StatsBuff.BuffTypes.ProjectileLifespan:
                    buffName = "Projectile Lifespan";
                    break;
                case StatsBuff.BuffTypes.ProjectileSpeed:
                    buffName = "Projectile Speed";
                    break;
                case StatsBuff.BuffTypes.DebuffDuration:
                    buffName = "Debuff Duration";
                    break;
                case StatsBuff.BuffTypes.DebuffDamage:
                    buffName = "Debuff Damage";
                    break;
                case StatsBuff.BuffTypes.MIB:
                    buffName = "MIB";
                    break;
                default:
                    break;
            }

            return buffName;
        }
        public void StrongWeapon(Tower tower)
        {
            InGame game = InGame.instance;
            if ((bool)Settings.settingsValue["SandboxMode"])
            {
                RectTransform rect = game.uiRect;
                MenuUi.StrongWeaponPanel(rect, tower);
                MenuUi.instance.CloseMenu();

                return;
            }

            if (game.GetCash() >= mod.strongerWeaponCost)
            {
                mod.StrongerWeaponsBought++;
                mod.CashSpent += mod.strongerWeaponCost;
                mod.DailyCashSpent += mod.strongerWeaponCost;
                game.AddCash(-mod.strongerWeaponCost);
                RectTransform rect = game.uiRect;
                MenuUi.StrongWeaponPanel(rect, tower);
                mod.strongerWeaponCost += mod.baseStrongerWeaponCost;
                tower.worth += mod.strongerWeaponCost - mod.baseStrongerWeaponCost;
                mod.baseStrongerWeaponCost *= mod.baseStrongerWeaponCostMultiplier;
                
         
                MenuUi.instance.CloseMenu();

            }
        }
        public void StrongWpnSelected(List<KeyValuePair<float, BuffKey>> keys, Tower tower)
        {
            mod.panelOpen = false;
            InGame game = InGame.instance;
            Destroy(gameObject);
            RectTransform rect = game.uiRect;
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            if (mod.upgradeOpen == true)
            {
                CreateUpgradeMenu(rect, tower);
            }
            foreach (var key in keys)
            {
                key.Value.statBuff.ApplyBuff(towerModel, key.Key, key.Value.operation);
            }
           
            if (mod.level == 0) {
                mod.rareStrongChance -= (float)Settings.settingsValue["StrongBaseRareChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                if (mod.rareStrongChance <= 100 - (float)Settings.settingsValue["StrongBaseRareChanceUntilEpicChance"]) {
                    mod.epicStrongChance -= (float)Settings.settingsValue["StrongBaseEpicChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.epicStrongChance <= 100 - (float)Settings.settingsValue["StrongBaseEpicChanceUntilLegendaryChance"]) {
                    mod.legendaryStrongChance -= (float)Settings.settingsValue["StrongBaseLegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.04f));
                }
                if (mod.legendaryStrongChance <= 100 - (float)Settings.settingsValue["StrongBaseLegendaryChanceUntilExoticChance"]) {
                    mod.exoticStrongChance -= (float)Settings.settingsValue["StrongBaseExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
            }

            if (mod.level == 1) {
                mod.epicStrongChance -= (float)Settings.settingsValue["StrongUpgrade1EpicChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                if (mod.epicStrongChance <= 100 - (float)Settings.settingsValue["StrongUpgrade1EpicChanceUntilLegendaryChance"]) {
                    mod.legendaryStrongChance -= (float)Settings.settingsValue["StrongUpgrade1LegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.legendaryStrongChance <= 100 - (float)Settings.settingsValue["StrongUpgrade1LegendaryChanceUntilExoticChance"]) {
                    mod.exoticStrongChance -= (float)Settings.settingsValue["StrongUpgrade1ExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.exoticStrongChance <= 100 - (float)Settings.settingsValue["StrongUpgrade1ExoticChanceUntilGodlyChance"]) {
                    mod.godlyStrongerChance -= (float)Settings.settingsValue["StrongUpgrade1GodlyChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
            }
            if (mod.level == 2) {
                mod.legendaryChance -= (float)Settings.settingsValue["StrongUpgrade2LegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                if (mod.legendaryStrongChance <= 100 - (float)Settings.settingsValue["StrongUpgrade2LegendaryChanceUntilExoticChance"]) {
                    mod.exoticStrongChance -= (float)Settings.settingsValue["StrongUpgrade2ExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.exoticStrongChance <= 100 - (float)Settings.settingsValue["StrongUpgrade2ExoticChanceUntilGodlyChance"]) {
                    mod.godlyStrongerChance -= (float)Settings.settingsValue["StrongUpgrade2GodlyChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
                if (mod.godlyStrongerChance <= 100 - (float)Settings.settingsValue["StrongUpgrade2GodlyChanceUntilOmegaChance"]) {
                    mod.omegaStrongerChance -= (float)Settings.settingsValue["StrongUpgrade2OmegaChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.05f));
                }
            }
            tower.UpdateRootModel(towerModel);
        }
        public void NewAbility(Tower tower)
        {
            InGame game = InGame.instance;
            if((bool)Settings.settingsValue["SandboxMode"])
            {
                RectTransform rect = game.uiRect;
                MenuUi.NewAbilityPanel(rect, tower);
                MenuUi.instance.CloseMenu();
                return;
            }
            if (game.GetCash() >= mod.newAbilityCost)
            {
                mod.CashSpent += mod.newAbilityCost;
                mod.DailyCashSpent += mod.newAbilityCost;
                mod.AbilityBought++;
                game.AddCash(-mod.newAbilityCost);
                RectTransform rect = game.uiRect;
                mod.newAbilityCost += mod.baseNewAbilityCost;
                tower.worth += mod.newAbilityCost - mod.baseNewAbilityCost;
                mod.baseNewAbilityCost *= mod.baseNewAbilityCostMultiplier;
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
                tower.SetSelectionBlocked(false); panel.DeleteObject(); 
            }));
            ModHelperText x = exit.AddText(new Info("x", 0, 0, 700, 160), "X", 80);
            foreach (var ability in ModContent.GetContent<AbilityTemplate>())
            { 
                scrollPanel.AddScrollContent(CreateAbility(ability, tower));
            }
        }
        public static void AbilityUpgradePanel(RectTransform rect, Tower tower)
        {

            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), VanillaSprites.BrownInsertPanel);
            panel.transform.DestroyAllChildren();

            ModHelperText title = panel.AddText(new Info("abilityName", 0, 850, 2500, 150), "Abilities Upgrades", 110, TextAlignmentOptions.Center);
            ModHelperScrollPanel scrollPanel = panel.AddScrollPanel(new Info("scrollPanel", 0, -75, 2500, 1700), RectTransform.Axis.Vertical, VanillaSprites.BrownInsertPanel, 15, 50);
            ModHelperButton exit = panel.AddButton(new Info("exit", 1200, 900, 135, 135), VanillaSprites.RedBtn, new System.Action(() => {
                tower.SetSelectionBlocked(false); panel.DeleteObject(); if (mod.upgradeOpen == true)
                {
                    CreateUpgradeMenu(rect, tower);
                }
            }));
            ModHelperText x = exit.AddText(new Info("x", 0, 0, 700, 160), "X", 80);
            foreach (var ability in mod.currentAbilities)
            {
                scrollPanel.AddScrollContent(CreateAbilityUpgrade(ability, tower, rect));
            }
        }
        public static ModHelperPanel CreateAbilityUpgrade(KeyValuePair<AbilityTemplate, List<Model>> abilityPair, Tower tower, RectTransform rect)
        {

            var sprite = VanillaSprites.GreyInsertPanel;
            var panel = ModHelperPanel.Create(new Info("WeaponContent" + abilityPair.Key.AbilityName, 0, 0, 2250, 150), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText abilityName = panel.AddText(new Info("abilityName", -600, 0, 1000, 150), abilityPair.Key.AbilityName, 80, TextAlignmentOptions.MidlineLeft);
            ModHelperImage image = panel.AddImage(new Info("image", -100, 0, 140, 140), abilityPair.Key.Icon);
            ModHelperText abilityLevel = panel.AddText(new Info("abilityLevel", 200, 0, 300, 150), "Lvl: " + abilityPair.Key.upgradesCount, 75, TextAlignmentOptions.MidlineLeft);
            ModHelperText selectWpn = null;
          ModHelperButton selectWpnBtn = null;
            if (abilityPair.Key.upgradesCount < abilityPair.Key.MaxLevel)
            {
                ModHelperText abilityUpgradeCost = panel.AddText(new Info("abilityCost", 525, 0, 300, 150), "$" + TextManager.ConvertNumberToText(Mathf.RoundToInt(abilityPair.Key.upgradeCost)), 75, TextAlignmentOptions.Center);
                selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { abilityPair.Key.Upgrade(abilityPair.Value, tower);
                    abilityLevel.Text.text = "Lvl: " + abilityPair.Key.upgradesCount;
                    abilityUpgradeCost.Text.text = "$" + TextManager.ConvertNumberToText(Mathf.RoundToInt(abilityPair.Key.upgradeCost));
                    if (abilityPair.Key.upgradesCount >= abilityPair.Key.MaxLevel)
                    {
                        abilityLevel.Text.text = "MAX";
                        selectWpnBtn.Image.SetSprite(VanillaSprites.RedBtnLong);
                        selectWpn.Text.text = "Max";
                        abilityUpgradeCost.Text.text = "";
                    }
                }));
                selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Upgrade", 60);
            }
            else
            {
                abilityLevel.SetText("MAX");
                selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.RedBtnLong, new System.Action(() => { }));
                selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "MAX", 60);
            }
           
            return panel;
        }
        public static void NewAbilityPanel(RectTransform rect, Tower tower)
        {
            mod.panelOpen = true;
            if ((bool)Settings.settingsValue["SandboxMode"])
            {
                SandBoxAbilityPanel(rect, tower);
                return;
            }

            float abilityPanelWidth = 833.33f;
            float abilityPanelX = 412.5f;
            float abilityPanelY = 900;
            float abilityContentX = 25 + (mod.abilitySlot - 1) * -425;
            float panelWidth = mod.abilitySlot * abilityPanelWidth;
            var sprite = VanillaSprites.BrownInsertPanel;
            if (mod.level == 1)
            {
                sprite = VanillaSprites.BlueInsertPanel;
            }
            if (mod.level == 2)
            {
                sprite = VanillaSprites.MainBgPanelParagon;
            }
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, panelWidth, 1850, new UnityEngine.Vector2()), sprite);
            ModHelperText selectAb = panel.AddText(new Info("selectAb", 0, 800, 2500, 180), "Select New Ability", 100);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();

            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            for (int i = 0; i < mod.abilitySlot; i++)
            {
                var num = rnd.Next(0, AbilityClass.AbilityName.Count);
                var abSelected = AbilityClass.AbilityName[num];
                var imgSelected = AbilityClass.AbilityImg[num];
                Sprite csprite = AbilityClass.AbilityCustomImg[num];
                ModHelperPanel abilityPanel = panel.AddPanel(new Info("abilityPanel", abilityPanelX, abilityPanelY, 650, 1450, new UnityEngine.Vector2()), VanillaSprites.GreyInsertPanel);
                ModHelperText abilityText = panel.AddText(new Info("abilityText", abilityContentX, 600, 800, 180), "Ability", 100);
                ModHelperText abilityText2 = panel.AddText(new Info("abilityText2", abilityContentX, 500, 800, 180), abSelected, 75);
                ModHelperButton selectAbilityBtn = panel.AddButton(new Info("selectAbilityBtn", abilityContentX, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.AbilitySelected(abSelected, tower, "Common")));
                ModHelperText selectAbility1 = selectAbilityBtn.AddText(new Info("selectAbility1", 0, 0, 700, 160), "Select", 70);
          
            
                foreach (var ability in ModContent.GetContent<AbilityTemplate>().OrderByDescending(c => c.mod == mod))
                {
                    if (ability.AbilityName == abSelected)
                    {
                        if (ability.Description != null)
                        {
                            ModHelperText descText = panel.AddText(new Info("descText", abilityContentX, 400, 800, 180), ability.Description, 55);
                        }
                     
                        ModHelperText StackIndex = panel.AddText(new Info("StackIndex", abilityContentX - 275, 650, 100, 100), $"{ability.stackIndex}", 80);
                        if (ability.CustomIcon)
                        {
                            ModHelperImage image = panel.AddImage(new Info("image", abilityContentX, 0, 400, 400), csprite);
                        }
                        else
                        {
                            ModHelperImage image = panel.AddImage(new Info("image", abilityContentX, 0, 400, 400), imgSelected);
                        }
                    }
                }
                abilityPanelX += abilityPanelWidth;
                abilityContentX += abilityPanelWidth;
            }
        
        }
        public void AbilitySelected(string Ability, Tower tower, string rarity)
        {
            mod.panelOpen = false;
            InGame game = InGame.instance;
            if(!(bool)Settings.settingsValue["SandboxMode"])
            {
                Destroy(gameObject);
            }
            RectTransform rect = game.uiRect;
            if (mod.upgradeOpen == true && !(bool)Settings.settingsValue["SandboxMode"])
            {
                CreateUpgradeMenu(rect, tower);
            }
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            if (Ability == "MIB")
            {
                mod.mib = true;
               
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
            }
            foreach (var ability in ModContent.GetContent<AbilityTemplate>().OrderByDescending(c => c.mod == mod))
            {
                if (ability.AbilityName == Ability)
                {
                   
                    ability.EditTower(towerModel);
                    ability.stackIndex += 1;
                  
                }
            }
            tower.UpdateRootModel(towerModel);
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
            ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade1Buy", 0, 0, 700, 160), "Upgrade ($" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.UpgradeCost)) + ")", 70);
            ModHelperButton cancel = panel.AddButton(new Info("cancel", -350, -800, 500, 160), VanillaSprites.RedBtnLong, new System.Action(() => upgradeUi.Cancel(tower)));
            ModHelperText cancelText = cancel.AddText(new Info("cancelText", 0, 0, 700, 160), "Cancel", 70);
        }
        public void Upgrade2Panel(Tower tower)
        {
            MenuUi.instance.CloseMenu();
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), VanillaSprites.BrownInsertPanel);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText upgradeText = panel.AddText(new Info("upgradeText", 0, 800, 2500, 180), "Upgrade To Super Ancient Monkey", 100);
            ModHelperText text1 = panel.AddText(new Info("text1", 0, 500, 2500, 180), "-Unlock a new rarity", 75);
            ModHelperText text2 = panel.AddText(new Info("text2", 0, 400, 2500, 180), "-Greatly Increased Luck", 75);
            ModHelperText text3 = panel.AddText(new Info("text3", 0, 300, 2500, 180), "-Removed Rare Rarity", 75);
            ModHelperText text4 = panel.AddText(new Info("text4", 0, 200, 2500, 180), "-Stronger Weapon and New Weapon Cost Increased", 75);
            ModHelperText text5 = panel.AddText(new Info("text5", 0, 100, 2500, 180), "-New Ability Cost Decreased", 75);
            ModHelperText text6 = panel.AddText(new Info("text5", 0, 0, 2500, 180), "-New XP System", 75);
            ModHelperText text7 = panel.AddText(new Info("text7", 0, -100, 2500, 180), "-Keep Everything", 75);
            ModHelperButton upgrade1 = panel.AddButton(new Info("upgrade1", 350, -800, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.Upgrade2(tower)));
            ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade1Buy", 0, 0, 700, 160), "Upgrade ($" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.Upgrade2Cost)) + ")", 70);
            ModHelperButton cancel = panel.AddButton(new Info("cancel", -350, -800, 500, 160), VanillaSprites.RedBtnLong, new System.Action(() => upgradeUi.Cancel(tower)));
            ModHelperText cancelText = cancel.AddText(new Info("cancelText", 0, 0, 700, 160), "Cancel", 70);
        }
        public string[] Monkeys = {
        "DartMonkey",
        "BoomerangMonkey",
        "BombShooter",
        "TackShooter",
        "IceMonkey",
        "GlueGunner",
        "SniperMonkey",
        "MonkeySub",
        "MonkeyBuccaneer",
        "MonkeyAce",
        "HeliPilot",
        "MortarMonkey",
        "DartlingGunner",
        "WizardMonkey",
        "SuperMonkey",
        "Mermonkey",
        "NinjaMonkey",
        "Alchemist",
        "Druid",
        "BananaFarm",
        "MonkeyVillage",
        "SpikeFactory",
        "EngineerMonkey",
        };
        public string Monkey = "DartMonkey";
        public int upgradeTier = 0;
        public int upgradePath = 0;
        public void ChangeSkin(Tower tower)
        {
            Il2CppNinjaKiwi.Common.Random rnd = new Il2CppNinjaKiwi.Common.Random();
            var monkey = Monkeys[rnd.Next(1, Monkeys.Length)];
            var upgradeTier = rnd.Next(1, 6);
            var upgradePath = rnd.Next(1, 4);
            instance.Monkey = monkey;
            instance.upgradePath = upgradePath;
            instance.upgradeTier = upgradeTier;
            
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            if (upgradePath == 1)
            {
                towerModel.display = Game.instance.model.GetTowerFromId(monkey + "-" + upgradeTier + "00").display;
            }
            if (upgradePath == 2)
            {
                towerModel.display = Game.instance.model.GetTowerFromId(monkey + "-0" + upgradeTier + "0").display;
            }
            if (upgradePath == 3)
            {
                towerModel.display = Game.instance.model.GetTowerFromId(monkey + "-00" + upgradeTier).display;
            }
            tower.UpdateRootModel(towerModel);
        }
        public void ExtraPanel(Tower tower)
        {
            mod.panelOpen = true;
          
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            var sprite = VanillaSprites.BrownInsertPanel;
            
            if (mod.level == 1)
            {
                sprite = VanillaSprites.BlueInsertPanel;
            }
            if (mod.level == 2)
            {
                sprite = VanillaSprites.MainBgPanelParagon;
            }
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 1500, 2500, 1850, new UnityEngine.Vector2()), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            ModHelperText upgradeText = panel.AddText(new Info("upgradeText", 0, 800, 2500, 180), "Extra Upgrades Panel", 100);


            TextSlider extraLuckSlider =  UIHelper.CreateTextSlider(panel, new Helper.SliderConfig(mod.ExtraLuckLevel, mod.ExtraLuckMax, true), new SliderOffsetConfig(new Vector2(25, 25)), new TransformConfig(new Vector2(280, 555), new Vector2(1525, 145)),
                new SpriteConfig(VanillaSprites.BrownInsertPanel), new SpriteConfig(VanillaSprites.MainBGPanelBlue), new TextConfig(60, mod.ExtraLuckLevel * 5, "+", "%", false));
            TextButtonOption extraLuckButton = UIHelper.CreateTextButtonOption(mod.ExtraLuckLevel != mod.ExtraLuckMax, panel, new TransformConfig(new Vector2(-795, 555), new Vector3(600, 145)), new SpriteConfig(VanillaSprites.GreenBtnLong), new TextConfig("Extra Luck : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.ExtraLuckCost)), 50), new ActionConfig()
                , new TextButtonOptionConfig(new SpriteConfig(VanillaSprites.GreenBtnLong), new ActionConfig(), new TextConfig("Max", 60)));
            extraLuckButton.SetAction(new ActionConfig { action = (System.Action<AncientMonkey, InGame, ModHelperPanel, Tower, BarSmoothing, TextButtonOption, TextSmoothing>)Actions.ExtraLuckAction,parameters = new object[] { mod, game, panel, tower, extraLuckSlider.barSmoothing, extraLuckButton, extraLuckSlider.textSmoothing }});

            TextSlider extraWeaponSlotSlider = UIHelper.CreateTextSlider(panel, new Helper.SliderConfig(mod.extraWeaponSlotLevel, mod.extraWeaponSlotLevelMax, true), new SliderOffsetConfig(new Vector2(25, 25)), new TransformConfig(new Vector2(280, 355), new Vector2(1525, 145)),
               new SpriteConfig(VanillaSprites.BrownInsertPanel), new SpriteConfig(VanillaSprites.MainBGPanelBlue), new TextConfig(60, mod.extraWeaponSlotLevel, "+", "", false));
            TextButtonOption extraWeaponSlotButton = UIHelper.CreateTextButtonOption(mod.extraWeaponSlotLevel != mod.extraWeaponSlotLevelMax, panel, new TransformConfig(new Vector2(-795, 355), new Vector3(600, 145)), new SpriteConfig(VanillaSprites.GreenBtnLong), new TextConfig("Extra Weapon Slot : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.extraWeaponSlotCost)), 45), new ActionConfig()
                , new TextButtonOptionConfig(new SpriteConfig(VanillaSprites.GreenBtnLong), new ActionConfig(), new TextConfig("Max", 60)));
            extraWeaponSlotButton.SetAction(new ActionConfig { action = (System.Action<AncientMonkey, InGame, ModHelperPanel, Tower, BarSmoothing, TextButtonOption, TextSmoothing>)Actions.ExtraWeaponSlotAction, parameters = new object[] { mod, game, panel, tower, extraWeaponSlotSlider.barSmoothing, extraWeaponSlotButton, extraWeaponSlotSlider.textSmoothing } });

            TextSlider extraAbilitySlotSlider = UIHelper.CreateTextSlider(panel, new Helper.SliderConfig(mod.ExtraAbilitySlotLevel, mod.ExtraAbilitySlotLevelMax, true), new SliderOffsetConfig(new Vector2(25, 25)), new TransformConfig(new Vector2(280, 155), new Vector2(1525, 145)),
               new SpriteConfig(VanillaSprites.BrownInsertPanel), new SpriteConfig(VanillaSprites.MainBGPanelBlue), new TextConfig(60, mod.ExtraAbilitySlotLevel, "+", "", false));
            TextButtonOption extraAbilitySlotButton = UIHelper.CreateTextButtonOption(mod.ExtraAbilitySlotLevel != mod.ExtraAbilitySlotLevelMax, panel, new TransformConfig(new Vector2(-795, 155), new Vector3(600, 145)), new SpriteConfig(VanillaSprites.GreenBtnLong), new TextConfig("Extra Ability Slot : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.ExtraAbilitySlotCost)), 45), new ActionConfig()
                , new TextButtonOptionConfig(new SpriteConfig(VanillaSprites.GreenBtnLong), new ActionConfig(), new TextConfig("Max", 60)));
            extraAbilitySlotButton.SetAction(new ActionConfig { action = (System.Action<AncientMonkey, InGame, ModHelperPanel, Tower, BarSmoothing, TextButtonOption, TextSmoothing>)Actions.ExtraAbilitySlotAction, parameters = new object[] { mod, game, panel, tower, extraAbilitySlotSlider.barSmoothing, extraAbilitySlotButton, extraAbilitySlotSlider.textSmoothing } });

            TextSlider extraStrongerWeaponSlotSlider = UIHelper.CreateTextSlider(panel, new Helper.SliderConfig(mod.strongExtraWeaponSlotLevel, mod.strongExtraWeaponSlotLevelMax, true), new SliderOffsetConfig(new Vector2(25, 25)), new TransformConfig(new Vector2(280, -45), new Vector2(1525, 145)),
              new SpriteConfig(VanillaSprites.BrownInsertPanel), new SpriteConfig(VanillaSprites.MainBGPanelBlue), new TextConfig(60, mod.strongExtraWeaponSlotLevel, "+", "", false));
            TextButtonOption extraStrongerWeaponSlotButton = UIHelper.CreateTextButtonOption(mod.strongExtraWeaponSlotLevel != mod.strongExtraWeaponSlotLevelMax, panel, new TransformConfig(new Vector2(-795, -45), new Vector3(600, 145)), new SpriteConfig(VanillaSprites.GreenBtnLong), new TextConfig("Extra Stronger Weapon Slot : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.strongExtraWeaponSlotCost)), 45), new ActionConfig()
                , new TextButtonOptionConfig(new SpriteConfig(VanillaSprites.GreenBtnLong), new ActionConfig(), new TextConfig("Max", 60)));
            extraStrongerWeaponSlotButton.SetAction(new ActionConfig { action = (System.Action<AncientMonkey, InGame, ModHelperPanel, Tower, BarSmoothing, TextButtonOption, TextSmoothing>)Actions.ExtraStrongerWeaponSlotAction, parameters = new object[] { mod, game, panel, tower, extraStrongerWeaponSlotSlider.barSmoothing, extraStrongerWeaponSlotButton, extraStrongerWeaponSlotSlider.textSmoothing } });

            TextButton cancelButton = UIHelper.CreateTextButton(panel, new TransformConfig(new Vector2(0, -800), new Vector2(500, 160)), new SpriteConfig(VanillaSprites.RedBtnLong), new ActionConfig(), new TextConfig("Cancer", 70));
            cancelButton.SetAction(new ActionConfig { action = (System.Action<Tower>)upgradeUi.Cancel, parameters = new object[] { tower } });


        }
        public void Upgrade1(Tower tower)
        {
            InGame game = InGame.instance;
            if (game.GetCash() >= mod.UpgradeCost)
            {
                mod.CashSpent += mod.UpgradeCost;
                mod.DailyCashSpent += mod.UpgradeCost;
                game.AddCash(-mod.UpgradeCost);
                
                RectTransform rect = game.uiRect;
                mod.UpgradesBought++;
                mod.newWeaponCost = (float)Settings.settingsValue["NewWeaponStartingCost1"];
                mod.baseNewWeaponCost = (float)Settings.settingsValue["IncrementalNewWeaponStartingCost1"];
                mod.baseNewWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalNewWeaponCostMultiplier1"];
                mod.rareChance = 0;
                mod.epicChance = 100 - (float)Settings.settingsValue["Upgrade1EpicChance"];
                mod.legendaryChance = 100 - (float)Settings.settingsValue["Upgrade1LegendaryChance"]; ;
                mod.exoticChance = 100 - (float)Settings.settingsValue["Upgrade1ExoticChance"];
                mod.godlyChance = 100 - (float)Settings.settingsValue["Upgrade1GodlyChance"];
                mod.rareStrongChance = 0;
                mod.epicStrongChance = 100 - (float)Settings.settingsValue["StrongUpgrade1EpicChance"];
                mod.legendaryStrongChance = 100 - (float)Settings.settingsValue["StrongUpgrade1LegendaryChance"];
                mod.exoticStrongChance = 100 - (float)Settings.settingsValue["StrongUpgrade1ExoticChance"];
                mod.godlyStrongerChance = 100 - (float)Settings.settingsValue["StrongUpgrade1GodlyChance"];
                mod.strongerWeaponCost = (float)Settings.settingsValue["StrongerWeaponStartingCost1"];
                mod.baseStrongerWeaponCost = (float)Settings.settingsValue["IncrementalStrongerWeaponStartingCost1"];
                mod.baseStrongerWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalStrongerWeaponCostMultiplier1"];
                mod.newAbilityCost = (float)Settings.settingsValue["NewAbilityStartingCost1"];

                mod.baseNewAbilityCost = (float)Settings.settingsValue["IncrementalNewAbilityStartingCost1"];
                mod.baseNewWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalNewAbilityCostMultiplier1"];
                mod.level += 1;
                mod.newWeaponSlot += (int)Settings.settingsValue["NewWeaponSlotBonus1"];
                mod.strongWeaponSlot += (int)Settings.settingsValue["StrongerWeaponSlotBonus1"];
                mod.abilitySlot += (int)Settings.settingsValue["NewAbilitySlotBonus1"];
                mod.minNewWeaponRarity = WeaponTemplate.Rarity.Rare;
                mod.maxNewWeaponRarity = WeaponTemplate.Rarity.Godly;
                mod.minStrongWeaponRarity = WeaponTemplate.Rarity.Rare;
                mod.maxStrongWeaponRarity = WeaponTemplate.Rarity.Godly;
                mod.panelOpen = false;
                if (mod.upgradeOpen == true)
                {
                    CreateUpgradeMenu(rect, tower);
                }
                  
                Destroy(gameObject);
            }
        }
        public void Upgrade2(Tower tower)
        {
            InGame game = InGame.instance;
            if (game.GetCash() >= mod.Upgrade2Cost)
            {
                mod.CashSpent += mod.Upgrade2Cost;
                mod.DailyCashSpent += mod.Upgrade2Cost;
                game.AddCash(-mod.Upgrade2Cost);

                RectTransform rect = game.uiRect;
                mod.UpgradesBought++;
                mod.newWeaponCost = 2350;
                mod.baseNewWeaponCost = 1750;
                mod.baseNewWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalNewWeaponCostMultiplier2"];
                mod.rareChance = 0;
                mod.epicChance = 0;
                mod.legendaryChance = 100 - (float)Settings.settingsValue["Upgrade2LegendaryChance"];
                mod.exoticChance = 100 - (float)Settings.settingsValue["Upgrade2ExoticChance"];
                mod.godlyChance = 100 - (float)Settings.settingsValue["Upgrade2GodlyChance"];
                mod.omegaChance = 100 - (float)Settings.settingsValue["Upgrade2OmegaChance"];
                mod.rareStrongChance = 0;
                mod.epicStrongChance = 0;
                mod.legendaryStrongChance = 100 - (float)Settings.settingsValue["StrongUpgrade2LegendaryChance"];
                mod.exoticStrongChance = 100 - (float)Settings.settingsValue["StrongUpgrade2ExoticChance"];
                mod.godlyStrongerChance = 100 - (float)Settings.settingsValue["StrongUpgrade2GodlyChance"];
                mod.omegaStrongerChance = 100 - (float)Settings.settingsValue["StrongUpgrade2OmegaChance"];
                mod.strongerWeaponCost = (float)Settings.settingsValue["StrongerWeaponStartingCost2"];
                mod.baseStrongerWeaponCost = (float)Settings.settingsValue["IncrementalStrongerWeaponStartingCost2"];
                mod.baseStrongerWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalStrongerWeaponCostMultiplier2"];
                mod.baseNewWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalNewAbilityCostMultiplier2"];

                mod.newAbilityCost = (float)Settings.settingsValue["NewAbilityStartingCost2"];

                mod.baseNewAbilityCost = (float)Settings.settingsValue["IncrementalNewAbilityStartingCost2"];
                mod.level += 1;
                mod.minNewWeaponRarity = WeaponTemplate.Rarity.Epic;
                mod.maxNewWeaponRarity = WeaponTemplate.Rarity.Omega;
                mod.minStrongWeaponRarity = WeaponTemplate.Rarity.Epic;
                mod.maxStrongWeaponRarity = WeaponTemplate.Rarity.Omega;
                mod.XP = 0;
                mod.XPMax = (int)Settings.settingsValue["StartingMaxXp"];

                mod.panelOpen = false;
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
            mod.panelOpen = false;
            if (mod.upgradeOpen == true)
            {
                CreateUpgradeMenu(rect, tower);
            }
        }
        public static void CreateUpgradeMenu(RectTransform rect, Tower tower)
        {
            if(mod.panelOpen == true)
            {
                return;
            }

          
            var sprite = VanillaSprites.BrownInsertPanel;
            if (mod.level == 1)
            {
                sprite = VanillaSprites.BlueInsertPanel;
            }
            if (mod.level == 2)
            {
                sprite = VanillaSprites.MainBgPanelParagon;
            }
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 250, 3333, 550, new UnityEngine.Vector2()), sprite);
            MenuUi upgradeUi = panel.AddComponent<MenuUi>();
            instance = upgradeUi;

            ModHelperPanel newWpnTextBox = panel.AddPanel(new Info("newWpnTextBox", 1250, 475, 750, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText newWpnTxt = newWpnTextBox.AddText(new Info("newWpnTxt", 0, 0, 1000, 180), "New Weapon", 75);
            newWpnTxt.Text.color = new Color(0,1,0);
            newWpnTxt.Text.outlineColor = new Color(0.2f, 0.64f, 0.1f);
            ModHelperPanel newWpnCostTextBox = panel.AddPanel(new Info("newWpnCostTextBox", 1188, 345, 625, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText newWpnCostTxt = newWpnCostTextBox.AddText(new Info("newWpnCostTxt", 0, 0, 1000, 180), TextManager.ConvertNumberToText((int)Mathf.Round(mod.newWeaponCost)), 65);
            newWpnCostTxt.Text.color = new Color(1, 0.85f, 0);
            newWpnCostTxt.Text.outlineColor = new Color(0.86f, 0.5f, 0f);
            newWpnCostTxt.Text.outlineWidth *= 1.5f;
            ModHelperPanel newWpnImageTextBox = panel.AddPanel(new Info("newWpnImageTextBox", 1570, 345, 110, 110, new UnityEngine.Vector2()), sprite);
            ModHelperImage newWpnImage = newWpnImageTextBox.AddImage(new Info("newWpnImage", 55, 55, 93, 93, new UnityEngine.Vector2()), VanillaSprites.Gold);
            if ((bool)Settings.settingsValue["SandboxMode"])
            {
                newWpnCostTxt.Text.text = "FREE";
            }
            ModHelperPanel newWpnBtnBox = panel.AddPanel(new Info("newWpnBtnBox", 1250, 210, 750, 120, new UnityEngine.Vector2()), sprite);
            ModHelperButton newWpnBtn = newWpnBtnBox.AddButton(new Info("newWpnBtn", 0, 0, 500, 110), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.NewWeapon(tower)));
            ModHelperText newWpnBuy = newWpnBtn.AddText(new Info("newWpnBuy", 0, 0, 700, 160), "Buy", 70);

            ModHelperPanel newWpnDescTextBox = panel.AddPanel(new Info("newWpnDescTextBox", 1250, 80, 750, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText newWpnDesc = newWpnDescTextBox.AddText(new Info("newWpnDesc", 0, 0, 750, 110), "Give an extra weapon", 50);



            ModHelperPanel strongWpnTextBox = panel.AddPanel(new Info("strongWpnTextBox", 417, 475, 750, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText strongWpnTxt = strongWpnTextBox.AddText(new Info("strongWpnTxt", 0, 0, 1000, 180), "Stronger Weapon", 75);
            strongWpnTxt.Text.color = new Color(1,0, .5f);
            strongWpnTxt.Text.outlineColor = new Color(0.55f, 0, 0.26f);
            ModHelperPanel strongWpnCostTextBox = panel.AddPanel(new Info("strongWpnCostTextBox", 355, 345, 625, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText strongWpnCostTxt = strongWpnCostTextBox.AddText(new Info("strongWpnCostTxt", 0, 0, 1000, 180), TextManager.ConvertNumberToText((int)Mathf.Round(mod.strongerWeaponCost)), 65);
            strongWpnCostTxt.Text.color = new Color(1, 0.85f, 0);
            strongWpnCostTxt.Text.outlineColor = new Color(0.86f, 0.5f, 0f);
            strongWpnCostTxt.Text.outlineWidth *= 1.5f;
            ModHelperPanel strongWpnImageTextBox = panel.AddPanel(new Info("strongWpnImageTextBox", 737, 345, 110, 110, new UnityEngine.Vector2()), sprite);
            ModHelperImage strongWpnImage = strongWpnImageTextBox.AddImage(new Info("strongWpnImage", 55, 55, 93, 93, new UnityEngine.Vector2()), VanillaSprites.Gold);
            if ((bool)Settings.settingsValue["SandboxMode"])
            {
                strongWpnCostTxt.Text.text = "FREE";
            }
            ModHelperPanel strongWpnBtnBox = panel.AddPanel(new Info("abilityBtnBox", 417, 210, 750, 120, new UnityEngine.Vector2()), sprite);
            ModHelperButton strongWpnBtn = strongWpnBtnBox.AddButton(new Info("strongWpnBtn", 0, 0, 500, 110), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWeapon(tower)));
            ModHelperText strongWpnBuy = strongWpnBtn.AddText(new Info("strongWpnBuy", 0, 0, 700, 160), "Buy", 70);

            ModHelperPanel strongWpnDescTextBox = panel.AddPanel(new Info("strongWpnDescTextBox", 417, 80, 750, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText strongWpnDesc = strongWpnDescTextBox.AddText(new Info("strongWpnDesc", 0, 0, 750, 110), "Make your current weapons stronger", 50);

            ModHelperPanel abilityTextBox = panel.AddPanel(new Info("abilityTextBox", 2083, 475, 750, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText abilityWpnTxt = abilityTextBox.AddText(new Info("abilityWpnTxt", 0, 0, 1000, 180), "New Ability", 75);
            abilityWpnTxt.Text.color = new Color(0, 0.45f,.9f);
            abilityWpnTxt.Text.outlineColor = new Color(0, 0.35f, 0.7f);
            ModHelperPanel abilityCostTextBox = panel.AddPanel(new Info("abilityCostTextBox", 2021, 345, 625, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText abilityCostTxt = abilityCostTextBox.AddText(new Info("abilityCostTxt", 0, 0, 1000, 180), TextManager.ConvertNumberToText((int)Mathf.Round(mod.newAbilityCost)), 65);
            abilityCostTxt.Text.color = new Color(1, 0.85f, 0);
            abilityCostTxt.Text.outlineColor = new Color(0.86f, 0.5f, 0f);
            abilityCostTxt.Text.outlineWidth *= 1.5f;
            ModHelperPanel abilityImageTextBox = panel.AddPanel(new Info("abilityImageTextBox", 2403, 345, 110, 110, new UnityEngine.Vector2()), sprite);
            ModHelperImage abilityImage = abilityImageTextBox.AddImage(new Info("abilityImage", 55, 55, 93, 93, new UnityEngine.Vector2()), VanillaSprites.Gold);
            if ((bool)Settings.settingsValue["SandboxMode"])
            {
                abilityCostTxt.Text.text = "FREE";
            }
            ModHelperPanel abilityBtnBox = panel.AddPanel(new Info("abilityBtnBox", 2083, 210, 750, 120, new UnityEngine.Vector2()), sprite);
            ModHelperButton abilityBtn = abilityBtnBox.AddButton(new Info("abilityBtn", -75, 0, 370, 110), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.NewAbility(tower)));
            ModHelperButton abilityUpgradeBtn = abilityBtnBox.AddButton(new Info("abilityBtn", 170, 0, 110, 110), VanillaSprites.UpgradeBtn, new System.Action(() => { AbilityUpgradePanel(rect, tower); tower.SetSelectionBlocked(false); panel.DeleteObject(); }));
            ModHelperText abilityBuy = abilityBtn.AddText(new Info("abilityBuy", 0, 0, 700, 160), "Buy", 70);

            ModHelperPanel abilityDescTextBox = panel.AddPanel(new Info("abilityDescTextBox", 2083, 80, 750, 110, new UnityEngine.Vector2()), sprite);
            ModHelperText abilityDesc = abilityDescTextBox.AddText(new Info("abilityDesc", 0, 0, 750, 110), "Give an extra ability", 50);

           

            ModHelperText extraText = panel.AddText(new Info("extraText", 1217, 240, 1000, 180), "Extra Panel", 70);
            ModHelperButton extraBtn = panel.AddButton(new Info("extraBtn", 1217, 120, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => { upgradeUi.ExtraPanel(tower); MenuUi.instance.CloseMenu(); }));
            ModHelperText extraOpen = extraBtn.AddText(new Info("extraOpen", 0, 0, 700, 160), "Open", 70);


            if (mod.level == 0 && (bool)Settings.settingsValue["Upgrade1Enabled"])
            {
                ModHelperButton upgrade1 = panel.AddButton(new Info("upgrade1", 0, 415, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.Upgrade1Panel(tower)));
                ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade1Buy", 0, 0, 700, 160), "Upgrade", 70);
            }
            if (mod.level == 1 && (bool)Settings.settingsValue["Upgrade2Enabled"])
            {
                ModHelperButton upgrade1 = panel.AddButton(new Info("upgrade2", 0, 415, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.Upgrade2Panel(tower)));
                ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade2Buy", 0, 0, 700, 160), "Upgrade", 70);
            }
            if (mod.level >= 2 && (bool)Settings.settingsValue["XpEnabled"])
            {
                var percent = mod.XP * 100 / mod.XPMax;
                var size = 2970 * percent / 100;
                ModHelperPanel xppanel = panel.AddPanel(new Info("Panel", 0, 440, 3000, 180), VanillaSprites.BrownInsertPanel);
                ModHelperPanel xpbar = panel.AddPanel(new Info("Panel", (size - size / 2) - 2970 / 2 , 440, size, 150), VanillaSprites.MainBgPanelParagon);
                ModHelperText upgrade1Buy = panel.AddText(new Info("text", 0, 440, 3000, 180), mod.XPMax - mod.XP + " Until Free Weapon", 70);
            }
            
        }
    }
   
}