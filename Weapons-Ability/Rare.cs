using AncientMonkey.Projectiles;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey.Weapons
{
	public class SuperMonkey : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.EpicRangeUpgradeIcon;
		public override string WeaponName => "Super Monkey";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("SuperMonkey").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class HotRang : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.RedHotRangsUpgradeIcon;
		public override string WeaponName => "Hot Rang";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-002").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Crossbow : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.CrossBowUpgradeIcon;
		public override string WeaponName => "Crossbow";
		public override bool IsCamo => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("DartMonkey-003").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Cluster : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.ClusterBombsUpgradeIcon;
		public override string WeaponName => "Cluster";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("BombShooter-003").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class WhiteHotSpikes : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.WhiteHotSpikesUpgradeIcon;
		public override string WeaponName => "White Hot Spikes";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-220").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class GreaterProduction : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.GreaterProductionUpgradeIcon;
		public override string WeaponName => "Greater Production";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("BananaFarm-200").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class HeartOfThunder : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.HeartofThunderUpgradeIcon;
		public override string WeaponName => "Heart Of Thunder";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning").Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.GetAttackModel().AddWeapon(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class DoubleShot : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.DoubleShotUpgradeIcon2;
		public override string WeaponName => "Double Shot";
		public override bool IsCamo => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey-300").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class WallOfFire : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.WallOfFireUpgradeIcon;
		public override string WeaponName => "Wall Of Fire";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-020").GetAttackModel(2).Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class AirburstDarts : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.AirburstDartsUpgradeIcon;
		public override string WeaponName => "Airburst Darts";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("MonkeySub-022").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class HotShot : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.HotShotUpgradeIcon;
		public override string WeaponName => "Hot Shot";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-020").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			wpn.GetBehavior<RotateToTargetModel>().additionalRotation = 0;
			wpn.weapons[0].emission.RemoveBehavior<EmissionRotationOffTowerDirectionModel>();
			wpn.weapons[0].ejectX = 0;
			wpn.weapons[0].ejectY = 0;
			wpn.weapons[0].ejectX = 0;
			wpn.weapons[1].ejectX = 0;
			wpn.weapons[1].ejectY = 0;
			wpn.weapons[1].ejectX = 0;
			wpn.weapons[2].ejectX = 0;
			wpn.weapons[2].ejectY = 0;
			wpn.weapons[2].ejectX = 0;
			wpn.weapons[2].emission.RemoveBehavior<EmissionArcRotationOffTowerDirectionModel>();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class LargeCalibre : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.LongCalibreUpgradeIcon;
		public override string WeaponName => "Large Calibre";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-202").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Churchill : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.CaptainChurchillIcon;
		public override string WeaponName => "Churchill";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("CaptainChurchill").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Adora : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.AdoraIcon;
		public override string WeaponName => "Adora";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("Adora").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Etienne : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.EtienneIcon;
		public override string WeaponName => "Etienne";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("Etienne").GetBehavior<DroneSupportModel>().Duplicate();
			wpn.count = 2;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Psi : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.PsiIcon;
		public override string WeaponName => "Psi";
		public override bool IsCamo => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("Psi").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class TripleShot : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.TripleShotUpgradeIcon;
		public override string WeaponName => "Triple Shot";
		public override bool IsCamo => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("DartMonkey-032").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class BurnyStuff : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string WeaponName => "Burny Stuff";
		public override string Icon => VanillaSprites.BurnyStuffUpgradeIcon;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-022").GetAttackModel().Duplicate();
			wpn.RemoveBehaviors<TargetSelectedPointModel>();
			wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
			wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
			wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
			wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class LotsMoreDarts : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string WeaponName => "Lots More Darts";
		public override string Icon => VanillaSprites.LotsMoreDartsUpgradeIcon;
		public override bool IsCamo => true;
		public override void EditTower(Tower tower)
		{
			var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
			var ace = Game.instance.model.GetTowerFromId("MonkeyAce-220").GetBehavior<AirUnitModel>().Duplicate();
			var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-220").GetBehavior<AttackAirUnitModel>().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			ace.AddBehavior(wpn);
			phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
			phoenix.towerModel.RemoveBehavior<AttackModel>();
			phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
			phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
			phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
			phoenix.towerModel.AddBehavior(ace);

			towerModel.AddBehavior(phoenix);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class QuadDarts : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string WeaponName => "Quad Darts";
		public override string Icon => VanillaSprites.QuadDartsUpgradeIcon;
		public override void EditTower(Tower tower)
		{
			var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
			var heli = Game.instance.model.GetTowerFromId("HeliPilot-100").GetBehavior<AirUnitModel>().Duplicate();
			var wpn = Game.instance.model.GetTowerFromId("HeliPilot-100").GetBehavior<AttackModel>().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			heli.AddBehavior(wpn);
			phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
			phoenix.towerModel.RemoveBehavior<AttackModel>();
			phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
			phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
			phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
			phoenix.towerModel.AddBehavior(heli);

			towerModel.AddBehavior(phoenix);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class FasterBarrelSpin : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.FasterBarrelSpinUpgradeIcon;
		public override string WeaponName => "Faster Barrel Spin";
		public override bool IsCamo => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-220").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class FasterEngineering : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.FasterEngineeringUpgradeIcon;
		public override string WeaponName => "Faster Engineering";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel(1).Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class MissileLauncher : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.MissileLauncherUpgradeIcon;
		public override string WeaponName => "Missile Launcher";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("BombShooter-220").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class BladeShooter : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.BladeShooterUpgradeIcon;
		public override string WeaponName => "Blade Shooter";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("TackShooter-230").GetAttackModel().Duplicate();
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Obyn : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.ObynGreenFootIcon;
		public override string WeaponName => "Obyn";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("ObynGreenfoot").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Gwendolin : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.GwendolinIcon;
		public override string WeaponName => "Gwendolin";
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("Gwendolin").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Sauda : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.SaudaIcon;
		public override string WeaponName => "Sauda";
		public override bool IsCamo => true;
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("Sauda").GetAttackModel().Duplicate();
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Chakrams : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.BladeShooterUpgradeIcon;
		public override string WeaponName => "Chakrams";
		public override bool IsCamo => true;
		public override Sprite CustomIcon => GetSprite("ChakramIcon");
		public override string Description => "Boomerang 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var bleed = Game.instance.model.GetTowerFromId("Sauda 9").GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
			bleed.name = "BleedModel";
			bleed.GetBehavior<DamageOverTimeModel>().interval = 1f;

			var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey").GetAttackModel().Duplicate();
			wpn.weapons[0].projectile.collisionPasses = new[] { -1, 0, 1 };
			wpn.weapons[0].projectile.hasDamageModifiers = true;
			wpn.weapons[0].projectile.AddBehavior(bleed);
			wpn.weapons[0].projectile.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
			wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Camo", 1, 1, false, false) { name = "CamoModifier_" });
			wpn.weapons[0].projectile.ApplyDisplay<Chakram>();
			wpn.weapons[0].projectile.GetBehavior<FollowPathModel>().Speed *= 2f;
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Frostbite : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.ShrapnelShotUpgradeIcon;
		public override string WeaponName => "Frostbite";
		public override Sprite CustomIcon => GetSprite("FrostbiteIcon");
		public override string Description => "Ice Monkey 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
			wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 0, 5).GetAttackModel().weapons[0].projectile.display;
			wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead | BloonProperties.White;
			wpn.weapons[0].projectile.scale /= 1.25f;
			wpn.weapons[0].rate /= 1.2f;
			wpn.weapons[0].projectile.GetDamageModel().damage += 1;
			wpn.weapons[0].projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 1f, "ShardFreeze", 1, "Ice", true, new GrowBlockModel("GrowBlockModel_"), null, 0, false, false));
			wpn.weapons[0].projectile.collisionPasses = new int[] { 0, -1 };
			wpn.range = tower.towerModel.range;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class CrackShotDarts : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.AirburstDartsUpgradeIcon;
		public override string WeaponName => "Crack Shot Darts";
		public override Sprite CustomIcon => GetSprite("CrackShotIcon");
		public override string Description => "Monkey Ace 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var bomb = Game.instance.model.GetTower(TowerType.BombShooter).GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
			var effect = Game.instance.model.GetTower(TowerType.BombShooter).GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
			var dart = Game.instance.model.GetTower(TowerType.DartMonkey).GetWeapon().projectile.Duplicate();

			var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
			var ace = Game.instance.model.GetTowerFromId("MonkeyAce").GetBehavior<AirUnitModel>().Duplicate();
			var wpn = Game.instance.model.GetTowerFromId("MonkeyAce").GetBehavior<AttackAirUnitModel>().Duplicate();
			wpn.weapons[0].projectile.AddBehavior(bomb);
			wpn.weapons[0].projectile.AddBehavior(effect);
			wpn.weapons[0].projectile.pierce = 1;
			wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("Crackshot", dart, new ArcEmissionModel("ArcEmissionModel_", 3, 0, 25, null, true, false), true, false, false));
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			ace.AddBehavior(wpn);
			phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
			phoenix.towerModel.RemoveBehavior<AttackModel>();
			phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
			phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
			phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
			phoenix.towerModel.AddBehavior(ace);

			towerModel.AddBehavior(phoenix);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class HighGradeDarts : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.ArmorPiercingDartsUpgradeIcon;
		public override string WeaponName => "High-Grade Darts";
		public override Sprite CustomIcon => GetSprite("HighGradeDartsIcon");
		public override string Description => "Dartling 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-100").GetAttackModel().Duplicate();
			wpn.weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 6, 12, 100, false, null, 0, null, 1));
			wpn.weapons[0].projectile.GetDamageModel().damage += 1;
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class SaiToss : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.VeryQuickShotsUpgradeIcon;
		public override string WeaponName => "Sai Toss";
		public override bool IsCamo => true;
		public override Sprite CustomIcon => GetSprite("SaiTossIcon");
		public override string Description => "Ninja 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
			wpn.weapons[0].projectile.GetDamageModel().damage = 3;
			wpn.weapons[0].projectile.pierce = 4;
			wpn.weapons[0].rate = Game.instance.model.GetTowerFromId("NinjaMonkey-200").GetAttackModel().weapons[0].rate * 3f;
			wpn.weapons[0].projectile.ApplyDisplay<Sai>();
			wpn.range = tower.towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class SeaHeart : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.BarracudaUpgradeIcon;
		public override string WeaponName => "Heart of the Sea";
		public override bool IsLead => true;
		public override Sprite CustomIcon => GetSprite("HeartofSeaIcon");
		public override string Description => "Druid 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
			wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.BeastHandler, 2).GetBehavior<BeastHandlerLeashModel>().towerModel.GetAttackModel().weapons[0].projectile.display;
			wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 3;
			wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed /= 2.5f;
			wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			wpn.weapons[0].projectile.GetDamageModel().damage = 3;
			wpn.weapons[0].projectile.pierce = 99;
			wpn.weapons[0].rate = 3;
			wpn.range = tower.towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class BananaStock : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.EzCollectUpgradeIcon;
		public override string WeaponName => "Banana Stock";
		public override Sprite CustomIcon => GetSprite("BananaStockIcon");
		public override string Description => "Farm 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var cash = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 0, 5).GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
			cash.cashPerRound = 50;
			cash.cashRoundBonusMultiplier = 5;

			towerModel.AddBehavior(cash);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class BurstFire : WeaponTemplate
	{
		public override int SandboxIndex => 2;
		public override Rarity WeaponRarity => Rarity.Rare;
		public override string Icon => VanillaSprites.EvenMoreTacksUpgradeIcon;
		public override string WeaponName => "Burst Fire";
		public override bool IsLead => true;
		public override Sprite CustomIcon => GetSprite("BurstFireIcon");
		public override string Description => "Engineer 4th path by LynxC";
		public override void EditTower(Tower tower)
		{
			var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey").GetAttackModel().Duplicate();
			wpn.weapons[0].projectile.hasDamageModifiers = true;
			wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 3, false, false) { name = "CeramicModifier_" });
			wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			wpn.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 25, null, false, false);
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			wpn.range = tower.towerModel.range;
			towerModel.AddBehavior(wpn);
			tower.UpdateRootModel(towerModel);
		}
	}

	public class Rare
	{
		public static List<string> RareWpn = new List<string>();
		public static List<string> RareImg = new List<string>();
		public static List<Sprite> RareCustomImg = new List<Sprite>();
	}
}
