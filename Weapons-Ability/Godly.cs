using AncientMonkey.Projectiles;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey.Weapons
{
	public class ApexPlasmaMaster : WeaponTemplate
	{
		public override int SandboxIndex => 6;
		public override Rarity WeaponRarity => Rarity.Godly;
		public override string Icon => VanillaSprites.ApexPlasmaMasterUpgradeIcon;
		public override string WeaponName => "Apex Plasma Master";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("DartMonkey-Paragon").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = tower.towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class GlaiveDominus : WeaponTemplate
	{
		public override int SandboxIndex => 6;
		public override Rarity WeaponRarity => Rarity.Godly;
		public override string Icon => VanillaSprites.GlaiveDominusUpgradeIcon;
		public override string WeaponName => "Glaive Dominus";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetAttackModel().Duplicate();
			var wpn2 = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetAttackModel(1).Duplicate();
			var wpn3 = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetAttackModel(2).Duplicate();
			var orbit = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetBehavior<OrbitModel>().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = tower.towerModel.range;
			towerModel.AddBehavior(wpn);
			towerModel.AddBehavior(wpn2);
			towerModel.AddBehavior(wpn3);
			towerModel.AddBehavior(orbit);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class AscendedShadow : WeaponTemplate
	{
		public override int SandboxIndex => 6;
		public override Rarity WeaponRarity => Rarity.Godly;
		public override string Icon => VanillaSprites.AscendedShadowUpgradeIcon;
		public override string WeaponName => "Ascended Shadow";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel().Duplicate();
			var wpn2 = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel(1).Duplicate();
			var wpn3 = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel(2).Duplicate();
			var wpn4 = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel(3).Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = tower.towerModel.range;
			towerModel.AddBehavior(wpn);
			towerModel.AddBehavior(wpn2);
			towerModel.AddBehavior(wpn3);
			towerModel.AddBehavior(wpn4);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class GoliathDoomship : WeaponTemplate
	{
		public override int SandboxIndex => 6;
		public override Rarity WeaponRarity => Rarity.Godly;
		public override string Icon => VanillaSprites.GoliathDoomshipUpgradeIcon;
		public override string WeaponName => "Goliath Doomship";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
			var ace = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehavior<AirUnitModel>().Duplicate();
			var ab = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehavior<AbilityModel>().Duplicate();
			var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehavior<AttackAirUnitModel>().Duplicate();
			var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
			var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			ace.AddBehavior(wpn);
			ace.AddBehavior(wpn2);
			ace.AddBehavior(wpn3);
			phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
			phoenix.towerModel.RemoveBehavior<AttackModel>();
			phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
			phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
			phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
			phoenix.towerModel.AddBehavior(ace);
			phoenix.towerModel.AddBehavior(ab);
			towerModel.AddBehavior(phoenix);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class MasterBuilder : WeaponTemplate
	{
		public override int SandboxIndex => 6;
		public override Rarity WeaponRarity => Rarity.Godly;
		public override string Icon => VanillaSprites.MasterBuilderUpgradeIcon;
		public override string WeaponName => "Master Builder";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAttackModel().Duplicate();
			var wpn2 = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAttackModel(1).Duplicate();
			var wpn3 = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAttackModel(2).Duplicate();
			var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAbility();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			towerModel.AddBehavior(wpn2);
			towerModel.AddBehavior(wpn3);
			towerModel.AddBehavior(ab);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class ArcaneGuardian : WeaponTemplate
	{
		public override int SandboxIndex => 6;
		public override Rarity WeaponRarity => Rarity.Godly;
		public override string Icon => VanillaSprites.TrueSonGodUpgradeIcon;
		public override string WeaponName => "Arcane Guardian";
		public override Sprite CustomIcon => GetSprite("ArcaneGuardianIcon");
		public override string Description => "Super Monkey 4th path by LynxC";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var fire = Game.instance.model.GetTowerFromId("MortarMonkey-002").Duplicate<TowerModel>().GetBehavior<AttackModel>().weapons[0].projectile.
				GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();

			fire.GetBehavior<DamageOverTimeModel>().damage += 28;
			fire.GetBehavior<DamageOverTimeModel>().Interval -= 1f;

			var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-200").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.weapons[0].projectile.AddBehavior(fire);
			wpn.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
			wpn.weapons[0].projectile.hasDamageModifiers = true;
			wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 6, 0, false, false) { name = "MoabModifier_" });
			wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Fortified", 2, 0, false, false) { name = "FortifiedModifier_" });
			wpn.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 4, 0, 45, null, false, false);
			wpn.weapons[0].projectile.pierce += 8;
			wpn.weapons[0].projectile.GetDamageModel().damage = 22;
			wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
			wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			wpn.weapons[0].projectile.ApplyDisplay<EnergyBeam>();

			wpn.range = tower.towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Godly
	{
		public static List<string> GodlyWpn = new List<string>();
		public static List<string> GodlyImg = new List<string>();
		public static List<Sprite> GodlyCustomImg = new List<Sprite>();
	}
}
