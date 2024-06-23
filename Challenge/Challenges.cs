using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using static AncientMonkey.WeaponTemplate;

namespace AncientMonkey.Challenge
{
	public class None : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Easy;
		public override string ChallengeName => "None";
		public override string Background => VanillaSprites.MainBGPanelGrey;
		public override string Icon => VanillaSprites.WoodenRoundButton;
		public override string Description => "-Basic Mode";
		public override int DescriptionPanelHeight => 80;
	}
	public class OnlyGodly : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Easy;
		public override string ChallengeName => "Only Godly";
		public override string Background => VanillaSprites.MainBgPanelWhiteSmall;
		public override string Icon => VanillaSprites.VengefulAdoraIcon;
		public override string Description => "-Every New Weapon Is Godly\n-Every Stronger Weapon Is Godly";
		public override Rarity MaxNURarity => Rarity.Godly;
		public override Rarity MinNURarity => Rarity.Godly;
		public override Rarity MaxURarity => Rarity.Godly;
		public override Rarity MinURarity => Rarity.Godly;
		public override Rarity MaxUURarity => Rarity.Godly;
		public override Rarity MinUURarity => Rarity.Godly;
		public override int DescriptionPanelHeight => 180;
	}
	public class LegendaryMadness : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Easy;
		public override string ChallengeName => "Legendary Madness";
		public override string Background => VanillaSprites.MainBGPanelYellow;
		public override string Icon => VanillaSprites.SunTempleUpgradeIcon;
		public override string Description => "-Every New Weapon Is Min Legendary\n-Every Stronger Weapon Is Min Legendary";
		public override Rarity MaxNURarity => Rarity.Exotic;
		public override Rarity MinNURarity => Rarity.Legendary;
		public override Rarity MaxURarity => Rarity.Godly;
		public override Rarity MinURarity => Rarity.Legendary;
		public override Rarity MaxUURarity => Rarity.Omega;
		public override Rarity MinUURarity => Rarity.Legendary;
		public override int DescriptionPanelHeight => 180;
	}
	public class ExpensiveWeapons : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Medium;
		public override string ChallengeName => "Expensive Weapons";
		public override string Background => VanillaSprites.MainBGPanelBronze;
		public override string Icon => VanillaSprites.IntermediateMapIcon;
		public override string Description => "-New Weapons Cost Are 1.5X More Expensive";
		public override float NewWeaponCostMult => 1.5f;
		public override int DescriptionPanelHeight => 80;
	}
	public class AbilitySpam : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Medium;
		public override string ChallengeName => "Ability Spam";
		public override string Background => VanillaSprites.MainBgPanelParagon;
		public override string Icon => VanillaSprites.CashDropUpgradeIcon;
		public override string Description => "-New Weapons Cost Are 25X More Expensive\n-Stronger Weapons Cost Are 25X More Expensive\n-Abilities Cost Are 4X Less Expensive";
		public override int DescriptionPanelHeight => 280;
		public override float NewWeaponCostMult => 25;
		public override float StrongerWeaponCostMult => 25;
		public override float AbilityWeaponCostMult => 0.25f;
	}
	public class NoUpgrade : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Medium;
		public override string ChallengeName => "No Upgrade";
		public override string Background => VanillaSprites.MainBGPanelBlue;
		public override string Icon => VanillaSprites.UpgradeIcon;
		public override string Description => "-Upgrade Cost Is 100X More Expensive";
		public override int DescriptionPanelHeight => 80;
		public override float UpgradeCostMult => 100;
	}
	public class MoneyTrouble : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Hard;
		public override string ChallengeName => "Money Trouble";
		public override string Background => VanillaSprites.MainBGPanelYellow;
		public override string Icon => VanillaSprites.HalfCashIcon;
		public override string Description => "-New Weapons Cost Are 3X More Expensive\n-Stronger Weapons Cost Are 3X More Expensive\n-Abilities Cost Are 3X More Expensive\nUpgrade Cost Is 3X More Expensive\n-Extra Luck Cost Is 3X More Expensive";
		public override int DescriptionPanelHeight => 480;
		public override float UpgradeCostMult => 3;
		public override float NewWeaponCostMult => 3;
		public override float StrongerWeaponCostMult => 3;
		public override float AbilityWeaponCostMult => 3;
		public override float LuckCostMult => 3;
	}
	public class OnlyCommon : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Impossible;
		public override string ChallengeName => "Only Common";
		public override string Background => VanillaSprites.MainBgPanel;
		public override string Icon => VanillaSprites.DartMonkeyIcon;
		public override string Description => "-Every New Weapon Is Common\n-Every Stronger Weapon Is Common";
		public override Rarity MaxNURarity => Rarity.Common;
		public override Rarity MinNURarity => Rarity.Common;
		public override Rarity MaxURarity => Rarity.Common;
		public override Rarity MinURarity => Rarity.Common;
		public override Rarity MaxUURarity => Rarity.Common;
		public override Rarity MinUURarity => Rarity.Common;
		public override int DescriptionPanelHeight => 180;
	}
	public class EliteChallenge : ChallengeTemplate
	{
		public override Difficulty ChallengeDifficulty => Difficulty.Ancient;
		public override string ChallengeName => "Elite Challenge";
		public override string Background => VanillaSprites.MainBgPanelWhiteSmall;
		public override string Icon => VanillaSprites.CHIMPSIcon;
		public override string Description => "-Every New Weapon Is Common\n-Every Stronger Weapon Is Common\n-New Weapons Cost Are 15X More Expensive\n-Stronger Weapons Cost Are 15X More Expensive\n-Abilities Cost Are 15X More Expensive\nUpgrade Cost Is 15X More Expensive\n-Extra Luck Cost Is 15X More Expensive";
		public override Rarity MaxNURarity => Rarity.Common;
		public override Rarity MinNURarity => Rarity.Common;
		public override Rarity MaxURarity => Rarity.Common;
		public override Rarity MinURarity => Rarity.Common;
		public override Rarity MaxUURarity => Rarity.Common;
		public override Rarity MinUURarity => Rarity.Common;
		public override int DescriptionPanelHeight => 680;
		public override float UpgradeCostMult => 15;
		public override float NewWeaponCostMult => 15;
		public override float StrongerWeaponCostMult => 15;
		public override float AbilityWeaponCostMult => 15;
		public override float LuckCostMult => 15;
	}
}
