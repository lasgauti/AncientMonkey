using MelonLoader;
using BTD_Mod_Helper;
using AncientMonkey;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using UnityEngine;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Api;
using System.Linq;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppTMPro;
using Il2CppNinjaKiwi.Common;
using AncientMonkey.Weapons;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using System.IO;
using Il2CppSystem.Linq;
using AncientMonkey.Quest;
using System.Collections.Generic;
using AncientMonkey.Challenge;

[assembly: MelonInfo(typeof(AncientMonkey.AncientMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace AncientMonkey;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
    public Il2CppSystem.DateTime LastDateLogin = new Il2CppSystem.DateTime();
    public List<object> daily1;
    public List<object> daily2;
    public List<object> daily3;
    public int CostReductionUpgradeBought = 0;
    public int LuckIncreaseUpgradeBought = 0;
    public int LeftUpgradesBought = 0;
    public int EpicWeaponsBoxCount = 0;
    public string Path = "Mods/AncientMonkey/";
    public bool DailyReset = false;
    public ChallengeTemplate selectedChallenge;

    public override void OnApplicationQuit()
    {
        if (!Directory.Exists(Path)) { return; }
        string file = Path + "Data.txt";
        string[] lines = File.ReadAllLines(file);
        double bloonsPopped = BloonsPopped;
        lines[0] = "bloonsPopped:" + bloonsPopped;
        double cashSpent = CashSpent;
        lines[1] = "cashSpent:" + cashSpent;
        int weaponsBought = (int)Mathf.Round(WeaponsBought);
        lines[2] = "weaponsBought:" + weaponsBought;
        int strongerWeaponsBought = (int)Mathf.Round(StrongerWeaponsBought);
        lines[3] = "strongerWeaponBought:" + strongerWeaponsBought;
        int abilityBought = (int)Mathf.Round(AbilityBought);
        lines[4] = "abilityBought:" + abilityBought;
        int roundsCleared = (int)Mathf.Round(RoundsCleared);
        lines[5] = "roundsCleared:" + roundsCleared;
        int ancientPiece = (int)Mathf.Round(AncientPiece);
        lines[6] = "ancientPiece:" + ancientPiece;
        double bloonsPoppedDaily = DailyBloonsPopped;
        lines[7] = "bloonsDailyPopped:" + bloonsPoppedDaily;
        double cashSpentDaily = DailyCashSpent;
        lines[8] = "cashDailySpent:" + cashSpentDaily;
        double weaponsBoughtDaily = DailyWeaponsBought;
        lines[9] = "weaponsDailyBought:" + weaponsBoughtDaily;
        Il2CppSystem.DateTime lastLoginDay = Il2CppSystem.DateTime.Now;
        lines[10] = "lastLoginDate!" + lastLoginDay;
        lines[11] = "daily1:" + daily1[0] + "/" + daily1[1] + "/" + daily1[2] + "/" + daily1[3];
        lines[12] = "daily2:" + daily2[0] + "/" + daily2[1] + "/" + daily2[2] + "/" + daily2[3];
        lines[13] = "daily3:" + daily3[0] + "/" + daily3[1] + "/" + daily3[2] + "/" + daily3[3];
        ModHelper.Log<AncientMonkey>(CostReductionUpgradeBought);
        lines[14] = "costRedutionBought:" + CostReductionUpgradeBought;
        lines[15] = "luckIncreaseBought:" + LuckIncreaseUpgradeBought;
        lines[16] = "leftUpgradesBought:" + LeftUpgradesBought;
        var i = 17;
        foreach (QuestTemplate quest in ModContent.GetContent<QuestTemplate>())
        {
            lines[i] = quest.QuestID + ":" + quest.Cleared;
            i++;
        }
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
    public override void OnApplicationStart()
    {
        mod = this;
        foreach (QuestTemplate quest in ModContent.GetContent<QuestTemplate>())
        {
            quest.Cleared = false;
        }
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
            if (Directory.GetFiles(Path).Length == 0)
            {
                List<string> lines = new List<string>();
                lines.Add("bloonsPopped:" + 0);
                lines.Add("cashSpent:" + 0);
                lines.Add("weaponsBought:" + 0);
                lines.Add("strongerWeaponBought:" + 0);
                lines.Add("abilityBought:" + 0);
                lines.Add("roundsCleared:" + 0);
                lines.Add("ancientPiece:" + 0);
                lines.Add("bloonsDailyPopped:" + 0);
                lines.Add("cashDailySpent:" + 0);
                lines.Add("weaponsDailyBought:" + 0);
                lines.Add("lastLoginDate!" + new Il2CppSystem.DateTime());
                lines.Add("daily1:BloonsPopped/0/0/False");
                lines.Add("daily2:BloonsPopped/0/0/False");
                lines.Add("daily3:BloonsPopped/0/0/False");
                lines.Add("costRedutionBought:0");
                lines.Add("luckIncreaseBought:0");
                lines.Add("leftUpgradesBought:0");
                foreach (QuestTemplate quest in ModContent.GetContent<QuestTemplate>())
                {
                    lines.Add(quest.QuestID + ":" + false);
                }
                File.WriteAllLines(Path + "Data.txt", lines.ToArray());
            }
        }
        else
        {
            string file = Path + "Data.txt";
            string[] lines = File.ReadAllLines(file);
            List<object> bloonPoppedLine = DoesLinesContains("bloonsPopped");
            if((bool)bloonPoppedLine[0])
            {
                var line = lines[(int)bloonPoppedLine[1]];
                BloonsPopped = double.Parse(line.Split(':')[1]);
            }
            List<object> cashSpentLine = DoesLinesContains("cashSpent");
            if ((bool)cashSpentLine[0])
            {
                var line = lines[(int)cashSpentLine[1]];
                CashSpent = double.Parse(line.Split(':')[1]);
            }
            List<object> weaponsBoughtLine = DoesLinesContains("weaponsBought");
            if ((bool)weaponsBoughtLine[0])
            {
                var line = lines[(int)weaponsBoughtLine[1]];
                WeaponsBought = int.Parse(line.Split(':')[1]);
            }
            List<object> strongerWeaponsBoughtLine = DoesLinesContains("strongerWeaponBought");
            if ((bool)weaponsBoughtLine[0])
            {
                var line = lines[(int)weaponsBoughtLine[1]];
                WeaponsBought = int.Parse(line.Split(':')[1]);
            }
            List<object> abilityBoughtLine = DoesLinesContains("abilityBought");
            if ((bool)abilityBoughtLine[0])
            {
                var line = lines[(int)abilityBoughtLine[1]];
                AbilityBought = int.Parse(line.Split(':')[1]);
            }
            List<object> roundsClearedLine = DoesLinesContains("roundsCleared");
            if ((bool)roundsClearedLine[0])
            {
                var line = lines[(int)roundsClearedLine[1]];
                RoundsCleared = int.Parse(line.Split(':')[1]);
            }
            List<object> ancientPieceLine = DoesLinesContains("ancientPiece");
            if ((bool)ancientPieceLine[0])
            {
                var line = lines[(int)ancientPieceLine[1]];
                AncientPiece = int.Parse(line.Split(':')[1]);
            }
            List<object> bloonDailyPoppedLine = DoesLinesContains("bloonsDailyPopped");
            if ((bool)bloonDailyPoppedLine[0])
            {
                var line = lines[(int)bloonDailyPoppedLine[1]];
                DailyBloonsPopped = double.Parse(line.Split(':')[1]);
            }
            List<object> cashDailySpentLine = DoesLinesContains("cashDailySpent");
            if ((bool)cashDailySpentLine[0])
            {
                var line = lines[(int)cashDailySpentLine[1]];
                DailyCashSpent = double.Parse(line.Split(':')[1]);
            }
            List<object> weaponsDailyBoughtLine = DoesLinesContains("weaponsDailyBought");
            if ((bool)weaponsDailyBoughtLine[0])
            {
                var line = lines[(int)weaponsDailyBoughtLine[1]];
                DailyWeaponsBought = int.Parse(line.Split(':')[1]);
            }
            List<object> lastLoginDayLine = DoesLinesContains("lastLoginDate");
            if ((bool)lastLoginDayLine[0])
            {
                var line = lines[(int)lastLoginDayLine[1]];
                LastDateLogin = Il2CppSystem.DateTime.Parse(line.Split('!')[1]);
            }
            List<object> daily1Line = DoesLinesContains("daily1");
            if ((bool)daily1Line[0])
            {
                var line = lines[(int)daily1Line[1]];
                var dailyQuest = line.Split(':')[1];
                var dailyQuestInfos = dailyQuest.Split("/");
                daily1 = new List<object> { dailyQuestInfos[0], int.Parse(dailyQuestInfos[1]), int.Parse(dailyQuestInfos[2]), bool.Parse(dailyQuestInfos[3])};
            }
            List<object> daily2Line = DoesLinesContains("daily2");
            if ((bool)daily2Line[0])
            {
                var line = lines[(int)daily2Line[1]];
                var dailyQuest = line.Split(':')[1];
                var dailyQuestInfos = dailyQuest.Split("/");
                daily2 = new List<object> { dailyQuestInfos[0], int.Parse(dailyQuestInfos[1]), int.Parse(dailyQuestInfos[2]), bool.Parse(dailyQuestInfos[3]) };
            }
            List<object> daily3Line = DoesLinesContains("daily3");
            if ((bool)daily3Line[0])
            {
                var line = lines[(int)daily3Line[1]];
                var dailyQuest = line.Split(':')[1];
                var dailyQuestInfos = dailyQuest.Split("/");
                
                daily3 = new List<object> { dailyQuestInfos[0], int.Parse(dailyQuestInfos[1]), int.Parse(dailyQuestInfos[2]), bool.Parse(dailyQuestInfos[3]) };
            }
            List<object> costRedutionBoughtLine = DoesLinesContains("costRedutionBought");
            if ((bool)costRedutionBoughtLine[0])
            {
                var line = lines[(int)costRedutionBoughtLine[1]];
                CostReductionUpgradeBought = int.Parse(line.Split(':')[1]);
            }
            List<object> luckIncreaseBoughtLine = DoesLinesContains("luckIncreaseBought");
            if ((bool)luckIncreaseBoughtLine[0])
            {
                var line = lines[(int)luckIncreaseBoughtLine[1]];
                LuckIncreaseUpgradeBought = int.Parse(line.Split(':')[1]);
            }
            List<object> leftUpgradesBoughtLine = DoesLinesContains("leftUpgradesBought");
            if ((bool)leftUpgradesBoughtLine[0])
            {
                var line = lines[(int)leftUpgradesBoughtLine[1]];
                LeftUpgradesBought = int.Parse(line.Split(':')[1]);
            }
            foreach (QuestTemplate quest in ModContent.GetContent<QuestTemplate>())
            {
                List<object> questLine = DoesLinesContains(quest.QuestID);
                if ((bool)questLine[0])
                {
                    var line = lines[(int)questLine[1]];
                    quest.Cleared = bool.Parse(line.Split(':')[1]);
                }
            }
            List<string> newLines = new List<string>();
            newLines.Add("bloonsPopped:" + 0);
            newLines.Add("cashSpent:" + 0);
            newLines.Add("weaponsBought:" + 0);
            newLines.Add("strongerWeaponBought:" + 0);
            newLines.Add("abilityBought:" + 0);
            newLines.Add("roundsCleared:" + 0);
            newLines.Add("ancientPiece:" + 0);
            newLines.Add("bloonsDailyPopped:" + 0);
            newLines.Add("cashDailySpent:" + 0);
            newLines.Add("weaponsDailyBought:" + 0);
            newLines.Add("lastLoginDate!" + new Il2CppSystem.DateTime());
            newLines.Add("daily1:BloonsPopped/0/0/False");
            newLines.Add("daily2:BloonsPopped/0/0/False");
            newLines.Add("daily3:BloonsPopped/0/0/False");
            newLines.Add("costRedutionBought:0");
            newLines.Add("luckIncreaseBought:0");
            newLines.Add("leftUpgradesBought:0");
            foreach (QuestTemplate quest in ModContent.GetContent<QuestTemplate>())
            {
                newLines.Add(quest.QuestID + ":" + false);
            }
           
            File.WriteAllLines(Path + "Data.txt", newLines.ToArray());
        }
       
        var daysDif = CalculateDaysDifference(LastDateLogin, Il2CppSystem.DateTime.Now);
        if (daysDif > 0)
        {
            RerollDailyQuests();
        }
        foreach (var weapon in ModContent.GetContent<WeaponTemplate>().OrderByDescending(c => c.mod == mod))
        {
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Common)
            {
                Common.CommonWpn.Add(weapon.WeaponName); 
                if (weapon.CustomIcon)
                {
                    Common.CommonCustomImg.Add(weapon.CustomIcon);
                }
                else
                {
                    Common.CommonCustomImg.Add(new Sprite());
                }
                Common.CommonImg.Add(weapon.Icon);
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Rare)
            {
                Rare.RareWpn.Add(weapon.WeaponName);
                Rare.RareImg.Add(weapon.Icon);
                if (weapon.CustomIcon)
                {
                    Rare.RareCustomImg.Add(weapon.CustomIcon);
                }
                else
                {
                    Rare.RareCustomImg.Add(new Sprite());
                }
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Epic)
            {

                Epic.EpicWpn.Add(weapon.WeaponName);
                Epic.EpicImg.Add(weapon.Icon);
                if (weapon.CustomIcon)
                {
                    Epic.EpicCustomImg.Add(weapon.CustomIcon);
                }
                else
                {
                    Epic.EpicCustomImg.Add(new Sprite());
                }

            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Legendary)
            {
                Legendary.LegendaryWpn.Add(weapon.WeaponName);
                Legendary.LegendaryImg.Add(weapon.Icon);
                if (weapon.CustomIcon)
                {
                    Legendary.LegendaryCustomImg.Add(weapon.CustomIcon);
                }
                else
                {
                    Legendary.LegendaryCustomImg.Add(new Sprite());
                }
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Exotic)
            {
                Exotic.ExoticWpn.Add(weapon.WeaponName);
                Exotic.ExoticImg.Add(weapon.Icon);
                if (weapon.CustomIcon)
                {
                    Exotic.ExoticCustomImg.Add(weapon.CustomIcon);
                }
                else
                {
                    Exotic.ExoticCustomImg.Add(new Sprite());
                }
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Godly)
            {
                Godly.GodlyWpn.Add(weapon.WeaponName);
                Godly.GodlyImg.Add(weapon.Icon);
                if (weapon.CustomIcon)
                {
                    Godly.GodlyCustomImg.Add(weapon.CustomIcon);
                }
                else
                {
                    Godly.GodlyCustomImg.Add(new Sprite());
                }
            }
            if (weapon.WeaponRarity == WeaponTemplate.Rarity.Omega)
            {
                Omega.OmegaWpn.Add(weapon.WeaponName);
                Omega.OmegaImg.Add(weapon.Icon);
                if (weapon.CustomIcon)
                {
                    Omega.OmegaCustomImg.Add(weapon.CustomIcon);
                }
                else
                {
                    Omega.OmegaCustomImg.Add(new Sprite());
                }
            }
        }
        foreach (var ability in ModContent.GetContent<AbilityTemplate>().OrderByDescending(c => c.mod == mod))
        {
            AbilityClass.AbilityName.Add(ability.AbilityName);
            AbilityClass.AbilityImg.Add(ability.Icon);
            if (ability.CustomIcon)
            {
                AbilityClass.AbilityCustomImg.Add(ability.CustomIcon);
            }
            else
            {
                AbilityClass.AbilityCustomImg.Add(new Sprite());
            }
        }
    }
    public void RerollDailyQuests()
    {
        daily1 = CreateDailyQuest("BloonsPopped");
        daily2 = CreateDailyQuest("CashSpent");
        daily3 = CreateDailyQuest("WeaponsBought");
        DailyBloonsPopped = 0;
        DailyCashSpent = 0;
        DailyWeaponsBought = 0;
    }
    public List<object> CreateDailyQuest(string goalName)
    {
        int goal= 0;
        int pieces= 0;
        Il2CppSystem.Random rnd = new Il2CppSystem.Random();
        if (goalName == "BloonsPopped")
        {
            goal = rnd.Next(1000000, 75000000);
            pieces = 4;
            if (goal >= 7500000)
            {
                pieces = 8;
            }
            if (goal >= 35000000)
            {
                pieces = 12;
            }
        }
        if (goalName == "CashSpent")
        {
            goal = rnd.Next(500000, 10000000);
            pieces = 4;
            if (goal >= 1250000)
            {
                pieces = 8;
            }
            if (goal >= 5000000)
            {
                pieces = 12;
            }
        }
        if (goalName == "WeaponsBought")
        {
            goal = rnd.Next(100, 1500);
            pieces = 4;
            if (goal >= 300)
            {
                pieces = 8;
            }
            if (goal >= 800)
            {
                pieces = 12;
            }
        }
        List<object> quest = new List<object>() {goalName, goal, pieces, false};
        return quest;
    }
    public int CalculateDaysDifference(Il2CppSystem.DateTime dateTime1, Il2CppSystem.DateTime dateTime2)
    {
        var dateTime1TotalDays = CalculateTotalDaysInYears(dateTime1);

        var dateTime2TotalDays = CalculateTotalDaysInYears(dateTime2);

        var daysDif = dateTime2TotalDays - dateTime1TotalDays;
        return daysDif;
    }
    public int CalculateTotalDaysInYears(Il2CppSystem.DateTime dateTime)
    {
        var days = 365;
        for (int i = 0; i < dateTime.Year - 1; i++)
        {
            if(Il2CppSystem.DateTime.IsLeapYear(i + 1))
            {
                days += 366;
             
            }
            else
            {
                days += 365;
            }
        }
       
        days += CalculateTotalDaysInMonths(dateTime);
        return days;
    }
    public int CalculateTotalDaysInMonths(Il2CppSystem.DateTime dateTime)
    {
        var days = 0;
        for (int i = 0; i < dateTime.Month - 1; i++)
        {
            days += Il2CppSystem.DateTime.DaysInMonth(dateTime.Year, i + 1);
        }
        days += dateTime.Day;
        return days;
    }
    public override void OnUpdate()
    {
        if (Il2CppSystem.DateTime.Now.Hour == 0 && Il2CppSystem.DateTime.Now.Minute == 0 && DailyReset == false)
        {
            DailyReset = true;
            RerollDailyQuests();
        }
        else
        {
            DailyReset = false;
        }
    }
    public void Reset()
    {
        newWeaponCost = (float)Settings.settingsValue["NewWeaponStartingCost"] /  (1 + (CostReductionUpgradeBought * 0.05f));
        baseNewWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalNewWeaponCostMultiplier"];
        rareChance = 100 - (int)Settings.settingsValue["BaseRareChance"];
        epicChance = 100- (int)Settings.settingsValue["BaseEpicChance"];
        rareStrongChance = 90;
        epicStrongChance = 100;
        legendaryStrongChance = 100;
        legendaryChance = 100 - (int)Settings.settingsValue["BaseLegendaryChance"];
        exoticChance =  100 - (int)Settings.settingsValue["BaseExoticChance"];
        exoticStrongChance = 100;
        omegaChance = 100;
        omegaStrongerChance = 100;
        baseNewWeaponCost = (float)Settings.settingsValue["IncrementalNewWeaponStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        strongerWeaponCost = (float)Settings.settingsValue["StrongerWeaponStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        baseStrongerWeaponCost = (float)Settings.settingsValue["IncrementalStrongerWeaponStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        baseStrongerWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalStrongerWeaponCostMultiplier"];
        newAbilityCost = (float)Settings.settingsValue["NewAbilityStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        baseNewAbilityCost = (float)Settings.settingsValue["IncrementalNewAbilityStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
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
        extraWeaponSlotCost = (float)Settings.settingsValue["ExtraWeaponSlotStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        strongExtraWeaponSlotLevel = 0;
        strongExtraWeaponSlotCost = (float)Settings.settingsValue["ExtraStrongerSlotStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        strongExtraWeaponSlotLevelMax = (int)Settings.settingsValue["ExtraStrongerSlotUpgradeCount"];
        ExtraAbilitySlotLevelMax = (int)Settings.settingsValue["ExtraAbilitySlotUpgradeCount"];
        ExtraAbilitySlotLevel = 0; 
        ExtraAbilitySlotCost = (float)Settings.settingsValue["ExtraAbilitySlotStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        ExtraLuckCost = (float)Settings.settingsValue["ExtraLuckStartingCost"] / (1 + (CostReductionUpgradeBought * 0.05f));
        ExtraLuckLevel = 0;
        ExtraLuckMax = (int)Settings.settingsValue["ExtraLuckUpgradeCount"];
        minNewWeaponRarity = WeaponTemplate.Rarity.Common;
        maxNewWeaponRarity = WeaponTemplate.Rarity.Exotic;
        minStrongWeaponRarity = WeaponTemplate.Rarity.Common;
        maxStrongWeaponRarity = WeaponTemplate.Rarity.Exotic;
        UpgradeCost = (float)Settings.settingsValue["Upgrade1Cost"] / (1 + (mod.CostReductionUpgradeBought * 0.05f));
        Upgrade2Cost = 1000000 / (1 + (mod.CostReductionUpgradeBought * 0.05f));
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
        public void WeaponSelected(string Weapon, Tower tower,bool levelup)
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
                if(weapon.WeaponName == Weapon)
                {
                    weapon.stackIndex += 1;
                    weapon.EditTower(tower);
                }
            }
            mod.XP += 1;
            if (levelup)
            {
                mod.XP = 0;
            }
            if (mod.XP >= mod.XPMax && mod.level >= 2)
            {
                mod.XPMax += 2;
                NewWeaponPanel(rect, tower, true);

                return;
            }
            if(mod.level == 0)
            {
                mod.rareChance -= (float)Settings.settingsValue["BaseRareChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                if (mod.rareChance <= 100 - (int)Settings.settingsValue["BaseRareChanceUntilEpicChance"])
                {
                    mod.epicChance -= (float)Settings.settingsValue["BaseEpicChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                }
                if (mod.epicChance <= 100 - (int)Settings.settingsValue["BaseEpicChanceUntilLegendaryChance"])
                {
                    mod.legendaryChance -= (float)Settings.settingsValue["BaseLegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                }
                if (mod.legendaryChance <= 100 - (int)Settings.settingsValue["BaseLegendaryChanceUntilExoticChance"])
                {
                    mod.exoticChance -= (float)Settings.settingsValue["BaseExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                }
            }
           
            if (mod.level == 1)
            {
                mod.epicChance -= (float)Settings.settingsValue["Upgrade1EpicChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                if (mod.epicChance <= 100 - (int)Settings.settingsValue["Upgrade1EpicChanceUntilLegendaryChance"])
                {
                    mod.legendaryChance -= (float)Settings.settingsValue["Upgrade1LegendaryChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                }
                if (mod.legendaryChance <= 100 - (int)Settings.settingsValue["Upgrade1LegendaryChanceUntilExoticChance"])
                {
                    mod.exoticChance -= (float)Settings.settingsValue["Upgrade1ExoticChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                }
                if (mod.exoticChance <= 100 - (int)Settings.settingsValue["Upgrade1ExoticChanceUntilGodlyChance"])
                {
                    mod.godlyChance -= (float)Settings.settingsValue["Upgrade1GodlyChanceDecrease"] * (1 + (mod.ExtraLuckLevel * 0.1f));
                }
            }
            if (mod.level == 2)
            {
                mod.legendaryChance -= 0.85f + mod.ExtraLuckLevel * 0.06f;
                if (mod.legendaryChance <= 91)
                {
                    mod.exoticChance -= 0.50f + mod.ExtraLuckLevel * 0.04f;
                }
                if (mod.exoticChance <= 94)
                {
                    mod.godlyChance -= 0.3f + mod.ExtraLuckLevel * 0.025f;
                }
                if (mod.godlyChance <= 95)
                {
                    mod.omegaChance -= 0.15f + mod.ExtraLuckLevel * 0.01f;
                }
            }
          
            if (mod.upgradeOpen == true && !(bool)Settings.settingsValue["SandboxMode"])
            {
                CreateUpgradeMenu(rect, tower);
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
            ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { upgradeUi.WeaponSelected(weapon.WeaponName, tower, false);}) ) ;
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
         
                ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", wpnContentX, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.WeaponSelected(weapon, tower,Levelup)));
                ModHelperText selectWpnTxt = selectWpnBtn.AddText(new Info("selectWpnTxt", 0, 0, 700, 160), "Select", 70);
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
                var damageBoost = rnd.Next(0, 2);
                var pierceBoost = rnd.Next(0, 2);
                float rangeBoost = rnd.Next(0, 7);
                float attackSpeedBoost = rnd.Next(95, 101);
                float moneyBoost = rnd.Next(0, 7);
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
                if (StrongWpnRarity == "Rare")
                {
                    damageBoost = rnd.Next(0, 3);
                    pierceBoost = rnd.Next(0, 3);
                    rangeBoost = rnd.Next(0, 10);
                    attackSpeedBoost = rnd.Next(91, 101);
                    moneyBoost = rnd.Next(0, 10);
                    sprite = VanillaSprites.BlueInsertPanel;
                }
                if (StrongWpnRarity == "Epic")
                {
                    damageBoost = rnd.Next(1, 5);
                    pierceBoost = rnd.Next(1, 5);
                    rangeBoost = rnd.Next(0, 13);
                    attackSpeedBoost = rnd.Next(88, 101);
                    moneyBoost = rnd.Next(0, 13);
                    sprite = VanillaSprites.MainBgPanelParagon;
                }
                if (StrongWpnRarity == "Legendary")
                {
                    damageBoost = rnd.Next(2, 7);
                    pierceBoost = rnd.Next(2, 7);
                    rangeBoost = rnd.Next(0, 15);
                    attackSpeedBoost = rnd.Next(85, 101);
                    moneyBoost = rnd.Next(0, 15);
                    sprite = VanillaSprites.MainBGPanelYellow;
                }
                if (StrongWpnRarity == "Exotic")
                {
                    damageBoost = rnd.Next(3, 9);
                    pierceBoost = rnd.Next(3, 9);
                    rangeBoost = rnd.Next(0, 18);
                    attackSpeedBoost = rnd.Next(83, 101);
                    moneyBoost = rnd.Next(0, 18);
                    sprite = VanillaSprites.MainBgPanelWhiteSmall;
                }
                if (StrongWpnRarity == "Godly")
                {
                    damageBoost = rnd.Next(5, 15);
                    pierceBoost = rnd.Next(5, 15);
                    rangeBoost = rnd.Next(0, 23);
                    attackSpeedBoost = rnd.Next(75, 101);
                    moneyBoost = rnd.Next(0, 23);
                    sprite = VanillaSprites.MainBGPanelSilver;
                }
                if (StrongWpnRarity == "Omega")
                {
                    damageBoost = rnd.Next(8, 22);
                    pierceBoost = rnd.Next(8, 22);
                    rangeBoost = rnd.Next(0, 28);
                    attackSpeedBoost = rnd.Next(71, 101);
                    moneyBoost = rnd.Next(0, 28);
                    sprite = VanillaSprites.MainBgPanelHematite;
                }
                attackSpeedBoost = attackSpeedBoost / 100;
                rangeBoost = 1 + rangeBoost / 100;
                moneyBoost = 1 + moneyBoost / 100;
                ModHelperPanel strongWpnPanel = panel.AddPanel(new Info("strongWpnPanel", strongWeaponPanelX, strongWeaponPanelY, 650, 1450, new UnityEngine.Vector2()), sprite);
                
                ModHelperText rarityText = panel.AddText(new Info("rarityText", strongWpnContentX, 600, 800, 180), StrongWpnRarity, 100);
                ModHelperText cardText = panel.AddText(new Info("cardText", strongWpnContentX, 500, 800, 180), "Stronger Weapon Card", 50);
                ModHelperText dmgBoostText = panel.AddText(new Info("dmgBoostText", strongWpnContentX, 200, 800, 180), "Damage Boost :" + damageBoost, 50);
                ModHelperText prcBoostText = panel.AddText(new Info("prcBoostText", strongWpnContentX, 100, 800, 180), "Pierce Boost :" + pierceBoost, 50);
                ModHelperText rngBoostText = panel.AddText(new Info("rngBoostText", strongWpnContentX, 0, 800, 180), "Range Boost : X" + rangeBoost, 50);
                ModHelperText atkspdBoostText = panel.AddText(new Info("atkspdBoostText", strongWpnContentX, -100, 800, 180), "Attack Speed Boost : X" + attackSpeedBoost, 50);
                ModHelperText mnyBoostText = panel.AddText(new Info("mnyBoostText", strongWpnContentX, -200, 800, 180), "Money Boost : X" + moneyBoost, 50);
                ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", strongWpnContentX, -600, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.StrongWpnSelected(damageBoost, pierceBoost, attackSpeedBoost, rangeBoost, moneyBoost, tower)));
                ModHelperText selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 700, 160), "Select", 70);
                strongWeaponPanelX += strongWeaponPanelWidth;
                strongWpnContentX += strongWeaponPanelWidth;
            }
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
        public void StrongWpnSelected(int Dmg, int Pierce, float AtkSpd, float Range, float Money, Tower tower)
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
                                    if (attackModel.weapons[0].rate < 0.1f)
                                    {
                                        attackModel.weapons[0].rate = 0.1f;
                                    }
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
                                if (attackModel.weapons[0].rate < 0.1f)
                                {
                                    attackModel.weapons[0].rate = 0.1f;
                                }
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
                    if (attackModel.weapons[0].rate < 0.07f)
                    {
                        attackModel.weapons[0].rate = 0.07f;
                    }
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
                        if (attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.HasBehavior<DamageModel>())
                        {
                            attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().damage += Dmg;
                        }
                    }
                } 
            }
            foreach (var attackModel in towerModel.GetDescendants<AttackModel>().ToArray())
            {
                attackModel.range *= Range;
            }
            mod.rareStrongChance -= 6.7f + mod.ExtraLuckLevel * 0.55f;
            mod.epicStrongChance -= 2f + mod.ExtraLuckLevel * 0.15f;
            if (mod.epicStrongChance <= 88)
            {
                mod.legendaryStrongChance -= 1.15f + mod.ExtraLuckLevel * 0.09f;
            }
            if (mod.legendaryStrongChance <= 91)
            {
                mod.exoticStrongChance -= 0.75f + mod.ExtraLuckLevel * 0.05f;
            }
            if (mod.exoticStrongChance <= 93)
            {
                mod.godlyStrongerChance -= 0.55f + mod.ExtraLuckLevel * 0.03f;
            }
            if (mod.godlyChance <= 94)
            {
                mod.omegaStrongerChance -= 0.30f + mod.ExtraLuckLevel * 0.015f;
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
                    ability.stackIndex += 1;
                }
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
            ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade1Buy", 0, 0, 700, 160), "Upgrade ($" + TextManager.ConvertIntToText((int)Mathf.Round(mod.UpgradeCost)) + ")", 70);
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
            ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade1Buy", 0, 0, 700, 160), "Upgrade ($" + TextManager.ConvertIntToText((int)Mathf.Round(mod.Upgrade2Cost)) + ")", 70);
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

            var pipY = 400;
            var pipX = -650;
            for (int i = 0; i < mod.extraWeaponSlotLevel; i++)
            {
                ModHelperImage pipUpgraded = panel.AddImage(new Info("pipUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOnGreen);
                pipX += 87;
            }
            for (int i = 0; i < mod.extraWeaponSlotLevelMax - mod.extraWeaponSlotLevel; i++)
            {
                ModHelperImage pipNotUpgraded = panel.AddImage(new Info("pipNotUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOffRed);
                pipX += 87;
            }
            if(mod.extraWeaponSlotLevel == mod.extraWeaponSlotLevelMax)
            {
                ModHelperButton upgradeExtraSlotLevel = panel.AddButton(new Info("upgradeExtraSlotLevel", -980, 400, 525, 145), VanillaSprites.GreenBtnLong, null);
                ModHelperText upgradeExtraSlotLevelText = upgradeExtraSlotLevel.AddText(new Info("upgradeExtraSlotLevelText", 0, 0, 550, 150), "Max", 50);
            } 
            else
            {
                ModHelperButton upgradeExtraSlotLevel = panel.AddButton(new Info("upgradeExtraSlotLevel", -980, 400, 525, 145), VanillaSprites.GreenBtnLong, new System.Action(() => { if (game.GetCash() >= mod.extraWeaponSlotCost) { mod.CashSpent += mod.extraWeaponSlotCost; mod.DailyCashSpent += mod.extraWeaponSlotCost; game.AddCash(mod.extraWeaponSlotCost * -1); mod.extraWeaponSlotCost *= (float)Settings.settingsValue["ExtraWeaponSlotIncreaseMultiplier"]; mod.extraWeaponSlotLevel += 1; panel.DeleteObject(); ExtraPanel(tower); mod.newWeaponSlot++; } }));
                ModHelperText upgradeExtraSlotLevelText = upgradeExtraSlotLevel.AddText(new Info("upgradeExtraSlotLevelText", 0, 0, 550, 150), "Extra New Weapon Slot : $" + TextManager.ConvertIntToText((int)Mathf.Round(mod.extraWeaponSlotCost)), 45);
            }
            ModHelper.Log<AncientMonkey>((float)Settings.settingsValue["ExtraWeaponSlotIncreaseMultiplier"]);
            pipY = 250;
            pipX = -650;
            for (int i = 0; i < mod.strongExtraWeaponSlotLevel; i++)
            {
                ModHelperImage pipUpgraded = panel.AddImage(new Info("pipUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOnGreen);
                pipX += 87;
            }
            for (int i = 0; i < mod.strongExtraWeaponSlotLevelMax - mod.strongExtraWeaponSlotLevel; i++)
            {
                ModHelperImage pipNotUpgraded = panel.AddImage(new Info("pipNotUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOffRed);
                pipX += 87;
            }
            if (mod.strongExtraWeaponSlotLevel == mod.strongExtraWeaponSlotLevelMax)
            {
                ModHelperButton upgradeExtraSlotLevel = panel.AddButton(new Info("upgradeExtraSlotLevel", -980, 250, 525, 145), VanillaSprites.GreenBtnLong, null);
                ModHelperText upgradeExtraSlotLevelText = upgradeExtraSlotLevel.AddText(new Info("upgradeExtraSlotLevelText", 0, 0, 550, 150), "Max", 60);
            }
            else
            {
                ModHelperButton upgradeExtraSlotLevel = panel.AddButton(new Info("upgradeExtraSlotLevel", -980, 250, 525, 145), VanillaSprites.GreenBtnLong, new System.Action(() => { if (game.GetCash() >= mod.strongExtraWeaponSlotCost) { mod.CashSpent += mod.strongExtraWeaponSlotCost; mod.DailyCashSpent += mod.strongExtraWeaponSlotCost; game.AddCash(mod.strongExtraWeaponSlotCost * -1); mod.strongExtraWeaponSlotCost *= (float)Settings.settingsValue["ExtraStrongerSlotIncreaseMultiplier"]; mod.strongExtraWeaponSlotLevel += 1; panel.DeleteObject(); ExtraPanel(tower); mod.strongWeaponSlot++; } }));
                ModHelperText upgradeExtraSlotLevelText = upgradeExtraSlotLevel.AddText(new Info("upgradeExtraSlotLevelText", 0, 0, 550, 150), "Extra Stronger Weapon Slot : $" + TextManager.ConvertIntToText((int)Mathf.Round(mod.strongExtraWeaponSlotCost)), 45);
            }

            pipY = 100;
            pipX = -650;
            for (int i = 0; i < mod.ExtraAbilitySlotLevel; i++)
            {
                ModHelperImage pipUpgraded = panel.AddImage(new Info("pipUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOnGreen);
                pipX += 87;
            }
            for (int i = 0; i < mod.ExtraAbilitySlotLevelMax - mod.ExtraAbilitySlotLevel; i++)
            {
                ModHelperImage pipNotUpgraded = panel.AddImage(new Info("pipNotUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOffRed);
                pipX += 87;
            }
            if (mod.ExtraAbilitySlotLevel == mod.ExtraAbilitySlotLevelMax)
            {
                ModHelperButton upgradeExtraSlotLevel = panel.AddButton(new Info("upgradeExtraSlotLevel", -980, 100, 525, 145), VanillaSprites.GreenBtnLong, null);
                ModHelperText upgradeExtraSlotLevelText = upgradeExtraSlotLevel.AddText(new Info("upgradeExtraSlotLevelText", 0, 0, 550, 150), "Max", 60);
            }
            else
            {
                ModHelperButton upgradeExtraSlotLevel = panel.AddButton(new Info("upgradeExtraSlotLevel", -980, 100, 525, 145), VanillaSprites.GreenBtnLong, new System.Action(() => { if (game.GetCash() >= mod.ExtraAbilitySlotCost) { mod.CashSpent += mod.ExtraAbilitySlotCost; mod.DailyCashSpent += mod.ExtraAbilitySlotCost; game.AddCash(mod.ExtraAbilitySlotCost * -1); mod.ExtraAbilitySlotCost *= (float)Settings.settingsValue["ExtraAbilitySlotIncreaseMultiplier"]; mod.ExtraAbilitySlotLevel += 1; panel.DeleteObject(); ExtraPanel(tower); mod.abilitySlot++; } }));
                ModHelperText upgradeExtraSlotLevelText = upgradeExtraSlotLevel.AddText(new Info("upgradeExtraSlotLevelText", 0, 0, 550, 150), "Extra New Ability Slot : $" + TextManager.ConvertIntToText((int)Mathf.Round(mod.ExtraAbilitySlotCost)), 50);
            }

            pipY = -50;
            pipX = -650;
            for (int i = 0; i < mod.ExtraLuckLevel; i++)
            {
                ModHelperImage pipUpgraded = panel.AddImage(new Info("pipUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOnGreen);
                pipX += 87;
            }
            for (int i = 0; i < mod.ExtraLuckMax - mod.ExtraLuckLevel; i++)
            {
                ModHelperImage pipNotUpgraded = panel.AddImage(new Info("pipNotUpgraded", pipX, pipY, 80, 160), VanillaSprites.MkOffRed);
                pipX += 87;
            }
            if (mod.ExtraLuckLevel == mod.ExtraLuckMax)
            {
                ModHelperButton upgradeExtraLevel = panel.AddButton(new Info("upgradeExtraLevel", -980, -50, 525, 145), VanillaSprites.GreenBtnLong, null);
                ModHelperText upgradeExtraLevelText = upgradeExtraLevel.AddText(new Info("upgradeExtraLevelText", 0, 0, 550, 150), "Max", 60);
            }
            else
            {
                ModHelperButton upgradeExtraLevel = panel.AddButton(new Info("upgradeExtraLevel", -980, -50, 525, 145), VanillaSprites.GreenBtnLong, new System.Action(() => { if (game.GetCash() >= mod.ExtraLuckCost) { mod.CashSpent += mod.ExtraLuckCost; mod.DailyCashSpent += mod.ExtraLuckCost; game.AddCash(mod.ExtraLuckCost * -1); mod.ExtraLuckLevel += 1; mod.ExtraLuckCost *= (float)Settings.settingsValue["ExtraLuckCostIncreaseMultiplier"]; ; panel.DeleteObject(); ExtraPanel(tower); } }));
                ModHelperText upgradeExtraLevelText = upgradeExtraLevel.AddText(new Info("upgradeExtraLevelText", 0, 0, 550, 150), "Extra Luck : $" + TextManager.ConvertIntToText((int)Mathf.Round(mod.ExtraLuckCost)), 50);
            }

         
            ModHelperButton monkeySkinChange = panel.AddButton(new Info("monkeySkinChange", -980, -200, 525, 145), VanillaSprites.GreenBtnLong, new System.Action(() => { ChangeSkin(tower); panel.DeleteObject(); ExtraPanel(tower); } ));
            ModHelperText monkeySkinChangeText = monkeySkinChange.AddText(new Info("monkeySkinChangeText", 0, 0, 550, 150), "Change Skin", 60);
            if (upgradePath == 1)
            {
                ModHelperText monkeySkinChangeMonkeyText = panel.AddText(new Info("monkeySkinChangeMonkeyText", 50, -200, 1000, 150), Monkey + " " + upgradeTier + "00", 60);
            }
            if (upgradePath == 2)
            {
                ModHelperText monkeySkinChangeMonkeyText = panel.AddText(new Info("monkeySkinChangeMonkeyText", 50, -200, 1000, 150), Monkey + " 0" + upgradeTier + "0", 60);
            }
            if (upgradePath == 3)
            {
                ModHelperText monkeySkinChangeMonkeyText = panel.AddText(new Info("monkeySkinChangeMonkeyText", 50, -200, 1000, 150), Monkey + " 00" + upgradeTier, 60);
            }
          

            ModHelperButton cancel = panel.AddButton(new Info("cancel", 0, -800, 500, 160), VanillaSprites.RedBtnLong, new System.Action(() => upgradeUi.Cancel(tower)));
            ModHelperText cancelText = cancel.AddText(new Info("cancelText", 0, 0, 700, 160), "Cancel", 70);


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
                mod.newWeaponCost = (float)Settings.settingsValue["NewWeaponStartingCost1"] / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.baseNewWeaponCost = (float)Settings.settingsValue["IncrementalNewWeaponStartingCost1"] / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.baseNewWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalNewWeaponCostMultiplier1"];
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
                mod.strongerWeaponCost = (float)Settings.settingsValue["StrongerWeaponStartingCost1"] / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.baseStrongerWeaponCost = (float)Settings.settingsValue["IncrementalStrongerWeaponStartingCost1"] / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.baseStrongerWeaponCostMultiplier = (float)Settings.settingsValue["IncrementalStrongerWeaponCostMultiplier1"];
                mod.newAbilityCost = (float)Settings.settingsValue["NewAbilityStartingCost1"] / (1 + (mod.CostReductionUpgradeBought * 0.05f));

                mod.baseNewAbilityCost = (float)Settings.settingsValue["IncrementalNewAbilityStartingCost1"] / (1 + (mod.CostReductionUpgradeBought * 0.05f));
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
                mod.newWeaponCost = 2350 / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.baseNewWeaponCost = 1750 / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.rareChance = 0;
                mod.epicChance = 0;
                mod.legendaryChance = 80;
                mod.exoticChance = 99;
                mod.godlyChance = 100;
                mod.rareStrongChance = 0;
                mod.epicStrongChance = 0;
                mod.legendaryStrongChance = 75;
                mod.exoticStrongChance = 98;
                mod.godlyStrongerChance = 100;
                mod.strongerWeaponCost = 3500 / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.baseStrongerWeaponCost = 2250 / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.newAbilityCost = 5500 / (1 + (mod.CostReductionUpgradeBought * 0.05f));

                mod.baseNewAbilityCost = 500 / (1 + (mod.CostReductionUpgradeBought * 0.05f));
                mod.level += 1;
                mod.minNewWeaponRarity = WeaponTemplate.Rarity.Epic;
                mod.maxNewWeaponRarity = WeaponTemplate.Rarity.Omega;
                mod.minStrongWeaponRarity = WeaponTemplate.Rarity.Epic;
                mod.maxStrongWeaponRarity = WeaponTemplate.Rarity.Omega;
                mod.XP = 0;
                mod.XPMax = 2;

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
            ModHelperText newWpnCostTxt = newWpnCostTextBox.AddText(new Info("newWpnCostTxt", 0, 0, 1000, 180), TextManager.ConvertIntToText((int)Mathf.Round(mod.newWeaponCost)), 65);
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
            ModHelperText strongWpnCostTxt = strongWpnCostTextBox.AddText(new Info("strongWpnCostTxt", 0, 0, 1000, 180), TextManager.ConvertIntToText((int)Mathf.Round(mod.strongerWeaponCost)), 65);
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
            ModHelperText abilityCostTxt = abilityCostTextBox.AddText(new Info("abilityCostTxt", 0, 0, 1000, 180), TextManager.ConvertIntToText((int)Mathf.Round(mod.newAbilityCost)), 65);
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
            ModHelperButton abilityBtn = abilityBtnBox.AddButton(new Info("abilityBtn", 0, 0, 500, 110), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.NewAbility(tower)));
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
            if (mod.level == 1)
            {
                ModHelperButton upgrade1 = panel.AddButton(new Info("upgrade2", 0, 415, 500, 160), VanillaSprites.GreenBtnLong, new System.Action(() => upgradeUi.Upgrade2Panel(tower)));
                ModHelperText upgrade1Buy = upgrade1.AddText(new Info("upgrade2Buy", 0, 0, 700, 160), "Upgrade", 70);
            }
            if (mod.level >= 2)
            {
                var percent = mod.XP * 100 / mod.XPMax;
                var size = 2970 * percent / 100;
                ModHelperPanel xppanel = panel.AddPanel(new Info("Panel", 0, 440, 3000, 180), VanillaSprites.BrownInsertPanel);
                ModHelperPanel xpbar = panel.AddPanel(new Info("Panel", (size - size / 2) - 2970 / 2 , 440, size, 150), VanillaSprites.MainBgPanelParagon);
                ModHelperText upgrade1Buy = panel.AddText(new Info("text", 0, 440, 3000, 180), mod.XPMax - mod.XP + " Until Free Weapon", 70);
            }
            
        }
    }
    /*[HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
    internal static class Bloon_Damage
    {
        [HarmonyPrefix]
        private static void Prefix(Bloon __instance, float totalAmount, Projectile projectile, bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect, Tower tower, BloonProperties immuneBloonProperties = BloonProperties.None, bool canDestroyProjectile = true, bool ignoreNonTargetable = false, bool blockSpawnChildren = false, bool ignoreInvunerable = false)
        {
            if (__instance != null && tower != null)
            {
                InGame game = InGame.instance;
                if (!game.GetGameModel().gameMode.Contains("Sandbox") && tower.towerModel.name.Contains("AncientMonkey"))
                {
                    mod.BloonsPopped += (int)Mathf.Round(totalAmount);
                    mod.DailyBloonsPopped += (int)Mathf.Round(totalAmount);
                }
            }
        }
    }*/
}