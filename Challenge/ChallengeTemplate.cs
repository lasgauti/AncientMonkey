using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Simulation.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey.Challenge
{
	public abstract class ChallengeTemplate : ModContent
	{
		public static bool IsSelected(ChallengeTemplate challenge) => AncientMonkey.mod.selectedChallenge == challenge;
		public override void Register() { }
		public abstract Difficulty ChallengeDifficulty { get; }
		public abstract string ChallengeName { get; }
		public abstract string Background { get; }
		public abstract string Icon { get; }
		public abstract string Description { get; }
		public virtual bool UsingCustomSprite { get; } = false;
		public virtual int DescriptionPanelHeight { get; }
		public virtual Sprite CustomSprite { get; }
		public virtual WeaponTemplate.Rarity MinNURarity { get; } = WeaponTemplate.Rarity.Common;
		public virtual WeaponTemplate.Rarity MaxNURarity { get; } = WeaponTemplate.Rarity.Exotic;
		public virtual WeaponTemplate.Rarity MinURarity { get; } = WeaponTemplate.Rarity.Rare;
		public virtual WeaponTemplate.Rarity MaxURarity { get; } = WeaponTemplate.Rarity.Godly;
		public virtual WeaponTemplate.Rarity MinUURarity { get; } = WeaponTemplate.Rarity.Epic;
		public virtual WeaponTemplate.Rarity MaxUURarity { get; } = WeaponTemplate.Rarity.Omega;
		public virtual float NewWeaponCostMult { get; } = 1;
		public virtual float StrongerWeaponCostMult { get; } = 1;
		public virtual float AbilityWeaponCostMult { get; } = 1;
		public virtual float UpgradeCostMult { get; } = 1;
		public virtual float LuckCostMult { get; } = 1;
		public enum Difficulty
		{
			Easy,
			Medium,
			Hard,
			Impossible,
			Ancient,
		}
	}
}
