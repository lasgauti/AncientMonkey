using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Monkeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey.Weapons
{
	public class Bloonarius : WeaponTemplate
	{
		public override int SandboxIndex => 7;
		public override Rarity WeaponRarity => Rarity.Omega;
		public override string Icon => VanillaSprites.BloonariusPortrait;
		public override string WeaponName => "Bloonarius";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var agemodel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
			var summon = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
			summon.weapons[0].projectile.name = "AttackModel_Summon_";
			summon.weapons[0].emission = new NecromancerEmissionModel("Bloonarius.", 99999999, 999999, 1, 1, 1, 50, 0, null, null, null, 1, 100, 1, 1, 2);
			summon.weapons[0].rate = 60;
			summon.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
			summon.name = "AttackModel_Summon_";
			summon.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("Clearhit", 1f));
			summon.weapons[0].projectile.GetDamageModel().damage = 67500;
			summon.weapons[0].projectile.display = Game.instance.model.GetBloon(BloonType.Bloonarius5).display;
			summon.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			summon.weapons[0].projectile.pierce = 100;
			summon.range = 100000;
			summon.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespanFrames = 99999;
			summon.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speedFrames *= 0.4f;
			summon.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
			agemodel.lifespanFrames = 99999;
			agemodel.lifespan = 99999;
			agemodel.rounds = 9999;
			summon.weapons[0].projectile.AddBehavior(agemodel);
			var summon2 = summon.Duplicate();
			summon2.weapons[0].emission = new NecromancerEmissionModel("Bloonarius.", 99999999, 999999, 5, 10, 1, 75, 0, null, null, null, 1, 100, 1, 1, 2);
			summon2.weapons[0].rate = 45;
			summon2.weapons[0].projectile.GetDamageModel().damage = 250;
			summon2.weapons[0].projectile.pierce = 10;
			summon2.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speedFrames *= 2f;
			summon2.weapons[0].projectile.display = Game.instance.model.GetBloon(BloonType.Bfb).display;
			var summon3 = summon.Duplicate();
			summon3.weapons[0].emission = new NecromancerEmissionModel("Bloonarius.", 99999999, 999999, 25, 50, 1, 75, 0, null, null, null, 1, 100, 1, 1, 2);
			summon3.weapons[0].rate = 25;
			summon3.weapons[0].projectile.GetDamageModel().damage = 40;
			summon3.weapons[0].projectile.pierce = 3;
			summon3.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speedFrames *= 5f;
			summon3.weapons[0].projectile.display = Game.instance.model.GetBloon(BloonType.Red).display;
			summon3.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = true;
			towerModel.AddBehavior(summon);
			towerModel.AddBehavior(summon2);
			towerModel.AddBehavior(summon3);
			tower.UpdateRootModel(towerModel);

		}
	}
	public class Lych : WeaponTemplate
	{
		public override int SandboxIndex => 7;
		public override Rarity WeaponRarity => Rarity.Omega;
		public override string Icon => VanillaSprites.LychPortrait;
		public override string WeaponName => "Lych";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var agemodel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
			var lych = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel(1).Duplicate();
			lych.range = towerModel.range;
			lych.name = "Sniper_Weapon";
			lych.weapons[0].Rate = 50;
			lych.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
			lych.weapons[0].projectile.ApplyDisplay<blankdisplay.BlankDisplay>();
			lych.GetDescendant<RotateToTargetModel>().rotateTower = false;
			lych.weapons[0].projectile.AddBehavior(new CreateTowerModel("LychTower", GetTowerModel<LychMinion>().Duplicate(), 0f, true, false, false, true, true));
			towerModel.AddBehavior(lych);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Vortex : WeaponTemplate
	{
		public override int SandboxIndex => 7;
		public override Rarity WeaponRarity => Rarity.Omega;
		public override string Icon => VanillaSprites.VortexPortrait;
		public override string WeaponName => "Vortex";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var agemodel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
			var vort = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
			vort.weapons[0].rate = 12.5f;
			vort.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan /= 10f;
			vort.weapons[0].projectile.radius = 1000000000;
			vort.weapons[0].projectile.scale = 0.01f;
			vort.weapons[0].projectile.GetDamageModel().damage = 55000;
			vort.weapons[0].projectile.GetDamageModel().distributeToChildren = true;
			vort.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			vort.weapons[0].projectile.pierce = 999999999;
			var stun = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModel>().Duplicate();
			var stuntag = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModifierForTagModel>().Duplicate();
			vort.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
			var moabstun = Game.instance.model.GetTowerFromId("BombShooter-500").GetDescendant<SlowModel>().Duplicate();
			moabstun.lifespan = 10f;
			stun.lifespan = 15;
			vort.weapons[0].projectile.AddBehavior(stun);
			vort.weapons[0].projectile.AddBehavior(stuntag);
			vort.weapons[0].projectile.AddBehavior(moabstun);
			var explosion = Game.instance.model.GetTower(TowerType.MortarMonkey, 5, 0, 0).GetDescendant<Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.CreateEffectOnExpireModel>().Duplicate();
			vort.weapons[0].projectile.AddBehavior(explosion);

			var superbrittle = Game.instance.model.GetTowerFromId("IceMonkey-500").GetDescendant<AddBonusDamagePerHitToBloonModel>();
			superbrittle.perHitDamageAddition = 10;
			vort.weapons[0].projectile.AddBehavior(superbrittle);
			vort.fireWithoutTarget = true;
			towerModel.AddBehavior(vort);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Dreadbloon : WeaponTemplate
	{
		public override int SandboxIndex => 7;
		public override Rarity WeaponRarity => Rarity.Omega;
		public override string Icon => VanillaSprites.DreadbloonPortrait;
		public override string WeaponName => "Dreadbloon";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
			var ace = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehavior<AirUnitModel>().Duplicate();
			var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-020").GetBehavior<AttackAirUnitModel>().Duplicate();
			ace.display = Game.instance.model.GetBloon("Dreadbloon5").display;
			wpn.weapons[0].projectile.display = Game.instance.model.GetBloon("DreadRockBloonStandard5").display;
			wpn.weapons[0].rate = 0.33f;
			wpn.weapons[0].projectile.GetDamageModel().damage = 4500;
			wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			wpn.weapons[0].projectile.pierce = 10;
			wpn.weapons[0].emission = new ArcEmissionModel("Arc", 5, 0, 90, null, false, true);
			phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
			phoenix.towerModel.RemoveBehavior<AttackModel>();
			phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
			phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
			phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
			phoenix.towerModel.AddBehavior(ace);
			ace.AddBehavior(wpn);

			towerModel.AddBehavior(phoenix);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Phayze : WeaponTemplate
	{
		public override int SandboxIndex => 7;
		public override Rarity WeaponRarity => Rarity.Omega;
		public override string Icon => VanillaSprites.PhayzePortrait;
		public override string WeaponName => "Phayze";
		public override bool IsCamo => true;
		public override bool IsLead => true;
		public override void EditTower(Tower tower)
		{
			var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
			var orbit = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 5).GetBehavior<OrbitModel>().Duplicate();
			orbit.count = 2;
			orbit.projectile.display = Game.instance.model.GetBloon("Phayze5").display;
			orbit.projectile.scale *= 0.5f;
			orbit.range = 50;
			var orbitDamage = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 5).GetAttackModel("AttackModel_OrbitAttack_").Duplicate();
			orbitDamage.weapons[0].rate = 0.01f;
			orbitDamage.weapons[0].projectile.pierce = 9999999;
			orbitDamage.weapons[0].projectile.RemoveBehaviors<DamageModifierForTagModel>();
			orbitDamage.weapons[0].projectile.GetDamageModel().damage = 250;
			orbitDamage.weapons[0].projectile.GetDamageModel().maxDamage = 999999;
			orbitDamage.weapons[0].projectile.radius = 50;
			orbitDamage.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			towerModel.AddBehavior(orbitDamage);
			towerModel.AddBehavior(orbit);
			tower.UpdateRootModel(towerModel);
		}
	}
	public class Omega
	{
		public static List<string> OmegaWpn = new List<string>();
		public static List<string> OmegaImg = new List<string>();
		public static List<Sprite> OmegaCustomImg = new List<Sprite>();
	}
}
namespace Monkeys
{
	public class LychMinion : ModTower
	{
		public override string Portrait => "Officer";
		public override string Name => "Lych";
		public override TowerSet TowerSet => TowerSet.Military;
		public override string BaseTower => TowerType.DartMonkey + "-002";

		public override bool DontAddToShop => true;
		public override int Cost => 0;

		public override int TopPathUpgrades => 0;
		public override int MiddlePathUpgrades => 0;
		public override int BottomPathUpgrades => 0;

		public override string DisplayName => "Lych";
		public override string Description => "";

		public override void ModifyBaseTowerModel(TowerModel towerModel)
		{
			var attackModel = towerModel.GetBehavior<AttackModel>();
			var weapons = attackModel.weapons[0];
			var projectile = weapons.projectile;
			towerModel.isSubTower = true;
			towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 40f, 3, false, false));
			weapons.rate = 0.06f;
			projectile.display = Game.instance.model.GetBloon(BloonType.Lych5).display;
			projectile.scale *= 0.3f;
			projectile.GetDamageModel().damage = 750;
			projectile.pierce = 75;
			projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
			projectile.GetBehavior<TravelStraitModel>().lifespan *= 3;
			towerModel.range = 50;
			attackModel.range = 50;
			towerModel.radius = 0;
			towerModel.displayScale *= 0.6f;
			towerModel.isGlobalRange = false;
			var Pops = Game.instance.model.GetTowerFromId("Sentry").GetBehavior<CreditPopsToParentTowerModel>().Duplicate();
			towerModel.AddBehavior(Pops);
			towerModel.display = Game.instance.model.GetBloon(BloonType.Lych5).display;
			towerModel.ignoreTowerForSelection = true;
		}

	}
}