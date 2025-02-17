using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AncientMonkey.Weapons;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Simulation.Towers;
using UnityEngine;

namespace AncientMonkey.Quest
{
    /*public class BloonsPopper : QuestTemplate
    {
        public override double GoalCountRequired => 2500000;
        public override Goal QuestGoal => Goal.BloonsPopped;
        public override string QuestID => "Pop-1";
        public override string QuestName => "Bloons Popper";
        public override int Reward => 4;
    }
    public class PlasticDestroyer : QuestTemplate
    {
        public override double GoalCountRequired => 10000000;
        public override Goal QuestGoal => Goal.BloonsPopped;
        public override string QuestID => "Pop-2";
        public override string QuestName => "Plastic Destroyer";
        public override int Reward => 8;
    }
    public class BloonsPoppingProduction : QuestTemplate
    {
        public override double GoalCountRequired => 75000000;
        public override Goal QuestGoal => Goal.BloonsPopped;
        public override string QuestID => "Pop-3";
        public override string QuestName => "Bloons Popping Production";
        public override int Reward => 12;
    }
    public class TrueBloonsPopper : QuestTemplate
    {
        public override double GoalCountRequired => 500000000;
        public override Goal QuestGoal => Goal.BloonsPopped;
        public override string QuestID => "Pop-4";
        public override string QuestName => "True Bloons Popper";
        public override int Reward => 20;
    }
    public class AncientPopperMaster : QuestTemplate
    {
        public override double GoalCountRequired => 1500000000;
        public override Goal QuestGoal => Goal.BloonsPopped;
        public override string QuestID => "Pop-5";
        public override string QuestName => "Ancient Popper Master";
        public override int Reward => 40;
    }
    public class RedRegenCamoFortifiedBloonsPower : QuestTemplate
    {
        public override double GoalCountRequired => 99999999999;
        public override Goal QuestGoal => Goal.BloonsPopped;
        public override string QuestID => "Pop-6";
        public override string QuestName => "Red Regen Camo Fortified Bloons Power";
        public override int Reward => 100;
    }*/
    public class BigSpender : QuestTemplate
    {
        public override double GoalCountRequired => 500000;
        public override Goal QuestGoal => Goal.CashSpent;
        public override string QuestID => "Cash-1";
        public override string QuestName => "Big Spender";
        public override int Reward => 4;
    }
    public class BananaCollector : QuestTemplate
    {
        public override double GoalCountRequired => 1250000;
        public override Goal QuestGoal => Goal.CashSpent;
        public override string QuestID => "Cash-2";
        public override string QuestName => "Banana Collector";
        public override int Reward => 8;
    }
    public class BananaCentralProduction : QuestTemplate
    {
        public override double GoalCountRequired => 8000000;
        public override Goal QuestGoal => Goal.CashSpent;
        public override string QuestID => "Cash-3";
        public override string QuestName => "Banana Central Production";
        public override int Reward => 20;
    }
    public class GoldFactory : QuestTemplate
    {
        public override double GoalCountRequired => 100000000;
        public override Goal QuestGoal => Goal.CashSpent;
        public override string QuestID => "Cash-4";
        public override string QuestName => "Gold Factory";
        public override int Reward => 60;
    }
    public class AncientGold : QuestTemplate
    {
        public override double GoalCountRequired => 1000000000;
        public override Goal QuestGoal => Goal.CashSpent;
        public override string QuestID => "Cash-5";
        public override string QuestName => "Ancient Gold";
        public override int Reward => 200;
    }
    public class ElonPopsk : QuestTemplate
    {
        public override double GoalCountRequired => 252700000000;
        public override Goal QuestGoal => Goal.CashSpent;
        public override string QuestID => "Cash-6";
        public override string QuestName => "Elon Popsk";
        public override int Reward => 1000;
    }
    public class WeaponsApprentice : QuestTemplate
    {
        public override double GoalCountRequired => 125;
        public override Goal QuestGoal => Goal.WeaponsBought;
        public override string QuestID => "Weapons-1";
        public override string QuestName => "Weapons Apprentice";
        public override int Reward => 4;
    }
    public class WeaponsMaster : QuestTemplate
    {
        public override double GoalCountRequired => 275;
        public override Goal QuestGoal => Goal.WeaponsBought;
        public override string QuestID => "Weapons-2";
        public override string QuestName => "Weapons Master";
        public override int Reward => 8;
    }
    public class GodlyWeaponsMaster : QuestTemplate
    {
        public override double GoalCountRequired => 550;
        public override Goal QuestGoal => Goal.WeaponsBought;
        public override string QuestID => "Weapons-3";
        public override string QuestName => "Godly Weapons Master";
        public override int Reward => 12;
    }
    public class OneThousandWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 1000;
        public override Goal QuestGoal => Goal.WeaponsBought;
        public override string QuestID => "Weapons-4";
        public override string QuestName => "One Thousand Weapons";
        public override int Reward => 20;
    }
    public class OmegaWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 5000;
        public override Goal QuestGoal => Goal.WeaponsBought;
        public override string QuestID => "Weapons-5";
        public override string QuestName => "Omega Weapons";
        public override int Reward => 40;
    }
    public class LateGameWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 20000;
        public override Goal QuestGoal => Goal.WeaponsBought;
        public override string QuestID => "Weapons-6";
        public override string QuestName => "Late Game Weapons";
        public override int Reward => 100;
    }
    public class AbilityApprentice : QuestTemplate
    {
        public override double GoalCountRequired => 20;
        public override Goal QuestGoal => Goal.AbilityBought;
        public override string QuestID => "Ability-1";
        public override string QuestName => "Ability Apprentice";
        public override int Reward => 4;
    }
    public class AbilityMaster : QuestTemplate
    {
        public override double GoalCountRequired => 45;
        public override Goal QuestGoal => Goal.AbilityBought;
        public override string QuestID => "Ability-2";
        public override string QuestName => "Ability Master";
        public override int Reward => 8;
    }
    public class SuperAbilities : QuestTemplate
    {
        public override double GoalCountRequired => 100;
        public override Goal QuestGoal => Goal.AbilityBought;
        public override string QuestID => "Ability-3";
        public override string QuestName => "Super Abilities";
        public override int Reward => 12;
    }
    public class GodlyAbilities : QuestTemplate
    {
        public override double GoalCountRequired => 250;
        public override Goal QuestGoal => Goal.AbilityBought;
        public override string QuestID => "Ability-4";
        public override string QuestName => "Godly Abilities";
        public override int Reward => 20;
    }
    public class AbilityGod : QuestTemplate
    {
        public override double GoalCountRequired => 1250;
        public override Goal QuestGoal => Goal.AbilityBought;
        public override string QuestID => "Ability-5";
        public override string QuestName => "Ability God";
        public override int Reward => 40;
    }
    public class AbilitySupremacy : QuestTemplate
    {
        public override double GoalCountRequired => 5000;
        public override Goal QuestGoal => Goal.AbilityBought;
        public override string QuestID => "Ability-6";
        public override string QuestName => "Ability Supremacy";
        public override int Reward => 100;
    }
    public class StrongWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 100;
        public override Goal QuestGoal => Goal.StrongerBought;
        public override string QuestID => "Strong-1";
        public override string QuestName => "Strong Weapons";
        public override int Reward => 4;
    }
    public class StrongerWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 240;
        public override Goal QuestGoal => Goal.StrongerBought;
        public override string QuestID => "Strong-2";
        public override string QuestName => "Stronger Weapons";
        public override int Reward => 8;
    }
    public class StrongestWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 500;
        public override Goal QuestGoal => Goal.StrongerBought;
        public override string QuestID => "Strong-3";
        public override string QuestName => "Strongest Weapons";
        public override int Reward => 12;
    }
    public class SuperStrongWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 1250;
        public override Goal QuestGoal => Goal.StrongerBought;
        public override string QuestID => "Strong-4";
        public override string QuestName => "Super Strong Weapons";
        public override int Reward => 20;
    }
    public class UltraStrongWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 6250;
        public override Goal QuestGoal => Goal.StrongerBought;
        public override string QuestID => "Strong-5";
        public override string QuestName => "Ultra Strong Weapons";
        public override int Reward => 40;
    }
    public class SuperDuperStrongestWeapons : QuestTemplate
    {
        public override double GoalCountRequired => 25000;
        public override Goal QuestGoal => Goal.StrongerBought;
        public override string QuestID => "Strong-6";
        public override string QuestName => "Super Duper Strongest Weapons";
        public override int Reward => 100;
    }
    public class UpgradeMaster : QuestTemplate
    {
        public override double GoalCountRequired => 25;
        public override Goal QuestGoal => Goal.UpgradesBought;
        public override string QuestID => "Upgrade-1";
        public override string QuestName => "Upgrade Master";
        public override int Reward => 60;
    }
    public class OmegaUpgrades : QuestTemplate
    {
        public override double GoalCountRequired => 500;
        public override Goal QuestGoal => Goal.UpgradesBought;
        public override string QuestID => "Upgrade-2";
        public override string QuestName => "Omega Upgrades";
        public override int Reward => 700;
    }
    public class TheFinalUpgrade : QuestTemplate
    {
        public override double GoalCountRequired => 10000;
        public override Goal QuestGoal => Goal.UpgradesBought;
        public override string QuestID => "Upgrade-3";
        public override string QuestName => "The Final Upgrade";
        public override int Reward => 12000;
    }
    public class EasyModeMaster : QuestTemplate
    {
        public override double GoalCountRequired => 200;
        public override Goal QuestGoal => Goal.RoundCleared;
        public override string QuestID => "Round-1";
        public override string QuestName => "Easy Mode Master";
        public override int Reward => 12;
    }
    public class MediumModeMaster : QuestTemplate
    {
        public override double GoalCountRequired => 500;
        public override Goal QuestGoal => Goal.RoundCleared;
        public override string QuestID => "Round-2";
        public override string QuestName => "Medium Mode Master";
        public override int Reward => 28;
    }
    public class HardModeMaster : QuestTemplate
    {
        public override double GoalCountRequired => 2000;
        public override Goal QuestGoal => Goal.RoundCleared;
        public override string QuestID => "Round-3";
        public override string QuestName => "Hard Mode Master";
        public override int Reward => 100;
    }
    public class CHIMPSModeMaster : QuestTemplate
    {
        public override double GoalCountRequired => 10000;
        public override Goal QuestGoal => Goal.RoundCleared;
        public override string QuestID => "Round-4";
        public override string QuestName => "CHIMPS Mode Master";
        public override int Reward => 480;
    }
}

