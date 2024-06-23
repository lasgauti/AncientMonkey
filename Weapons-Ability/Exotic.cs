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
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey.Weapons
{
	public class Exotic
	{
		public class LegendOfTheNight : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.LegendOfTheNightUpgradeIcon;
			public override string WeaponName => "Legend Of The Night";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-205").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SuperMines : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.SuperMinesUpgradeIcon;
			public override string WeaponName => "Super Mines";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-520").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BananaCentral : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.BananaCentralUpgradeIcon;
			public override string WeaponName => "Banana Central";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BananaFarm-520").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class XXXLTrap : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.XXXLUpgradeIcon;
			public override string WeaponName => "XXXL Trap";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-015").GetAttackModel(1).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Archmage : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.ArchmageUpgradeIcon;
			public override string WeaponName => "Archmage";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var wpn2 = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetAttackModel(1).Duplicate();
				wpn2.range = tower.towerModel.range;
				var wpn3 = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetAttackModel(2).Duplicate();
				wpn3.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				towerModel.AddBehavior(wpn2);
				towerModel.AddBehavior(wpn3);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class MAD : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.MadUpgradeIcon;
			public override string WeaponName => "M.A.D";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-250").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class RayOfDoom : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.RayOfDoomUpgradeIcon;
			public override string WeaponName => "Ray Of Doom";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-520").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class AvatarOfWrath : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.AvatarofWrathUpgradeIcon;
			public override string WeaponName => "Avatar Of Wrath";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("Druid-025").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class InfernoRing : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.InfernoRingUpgradeIcon;
			public override string WeaponName => "Inferno Ring";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("TackShooter-520").GetAttackModel().Duplicate();
				var wpn2 = Game.instance.model.GetTowerFromId("TackShooter-520").GetAttackModel(1).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				towerModel.AddBehavior(wpn2);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BloonCrush : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.BloonCrushUpgradeIcon;
			public override string WeaponName => "Bloon Crush";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BombShooter-520").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class MoabDomination : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.MoabDominationUpgradeIcon;
			public override string WeaponName => "Moab Domination";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-025").GetAttackModel(1).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PermaBrew : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.PermanentBrewUpgradeIcon;
			public override string WeaponName => "Perma Brew";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("Alchemist-520").GetAttackModel(2).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SuperStorm : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.SuperStormUpgradeIcon;
			public override string WeaponName => "Super Storm";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var tornado = Game.instance.model.GetTowerFromId("Druid-520").GetAttackModel().weapons.First(w => w.name.Contains("Superstorm")).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.GetAttackModel().AddWeapon(tornado);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class FlyingFortress : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.FlyingFortressUpgradeIcon;
			public override string WeaponName => "Flying Fortress";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
				var ace = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehavior<AirUnitModel>().Duplicate();
				var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehavior<AttackAirUnitModel>().Duplicate();
				var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
				var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
				var wpn4 = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehaviors<AttackAirUnitModel>()[3].Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				ace.AddBehavior(wpn);
				ace.AddBehavior(wpn2);
				ace.AddBehavior(wpn3);
				ace.AddBehavior(wpn4);
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
		public class ExplosionKing : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.RecursiveClusterUpgradeIcon;
			public override string WeaponName => "Explosion King";
			public override Sprite CustomIcon => GetSprite("ExplosionKingIcon");
			public override string Description => "Tack Shooter 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var effect = Game.instance.model.GetTower(TowerType.MortarMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.CreateEffectOnExpireModel>().Duplicate();
				var sound = Game.instance.model.GetTower(TowerType.MortarMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileExhaustModel>().Duplicate();
				var explosion = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.Duplicate();
				var bombEffect = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.Duplicate();
				effect.effectModel = bombEffect;

				explosion.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				explosion.GetDamageModel().immuneBloonProperties = BloonProperties.None;

				var clusterExplosion = explosion.Duplicate();
				var recursiveExplosion = explosion.Duplicate();

				explosion.GetDamageModel().damage = 6;
				clusterExplosion.GetDamageModel().damage = 4;
				recursiveExplosion.GetDamageModel().damage = 2;

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("TackShooter-200").GetAttackModel().Duplicate();
				wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.2f;
				wpn.weapons[0].projectile.pierce = 999;
				wpn.weapons[0].projectile.GetDamageModel().damage -= 1;
				wpn.weapons[0].projectile.RemoveBehavior<CreateProjectileOnContactModel>();
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.AddBehavior(effect);
				wpn.weapons[0].projectile.AddBehavior(sound);

				var firework = wpn.weapons[0].projectile.Duplicate();
				var recursiveFirework = firework.Duplicate();

				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("Explosion", explosion, new ArcEmissionModel("FragmentEmmision_", 1, 0, 0, null, true, false), false));
				firework.AddBehavior(new CreateProjectileOnExpireModel("Explosion", clusterExplosion, new ArcEmissionModel("FragmentEmmision_", 1, 0, 0, null, true, false), false));
				recursiveFirework.AddBehavior(new CreateProjectileOnExpireModel("Explosion", recursiveExplosion, new ArcEmissionModel("FragmentEmmision_", 1, 0, 0, null, true, false), false));

				firework.AddBehavior(new CreateProjectileOnExpireModel("Firework", recursiveFirework, new ArcEmissionModel("FragmentEmmision_", 8, 0, 360, null, true, false), false));
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("Firework", firework, new ArcEmissionModel("FragmentEmmision_", 8, 0, 360, null, true, false), false));

				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PolarVortex : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.TheBIggestOneUpgradeIcon;
			public override string WeaponName => "Polar Vortex";
			public override Sprite CustomIcon => GetSprite("PolarVortexIcon");
			public override string Description => "Ice Monkey 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var seeking = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();
				seeking.distance = 999;
				seeking.constantlyAquireNewTarget = true;
				seeking.turnRate *= 2;

				var shard = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
				shard.display = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 0, 5).GetAttackModel().weapons[0].projectile.display;
				shard.scale /= 1.25f;
				shard.pierce += 7;
				shard.AddBehavior(seeking);
				shard.GetBehavior<TravelStraitModel>().Lifespan *= 6;
				shard.GetDamageModel().damage += 1;
				shard.GetDamageModel().immuneBloonProperties = BloonProperties.White;
				shard.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				shard.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());

				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 0, 5).GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.White;
				wpn.weapons[0].rate /= 1.44f;
				wpn.weapons[0].projectile.GetDamageModel().damage += 7;
				wpn.weapons[0].projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 1f, "ShardFreeze", 1, "Ice", true, new GrowBlockModel("GrowBlockModel_"), null, 0, false, false));
				wpn.weapons[0].projectile.collisionPasses = new int[] { 0, -1 };
				wpn.weapons[0].projectile.pierce = 1;
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("CreateProjectileOnContactModel_", shard, new ArcEmissionModel("ArcEmissionModel_", 5, 0, 50, null, true, false), true, false, false));
				wpn.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());
				wpn.range = tower.towerModel.range;

				var breath = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().Duplicate();
				breath.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 0, 3).GetAttackModel().weapons[0].projectile.display;
				breath.range = tower.towerModel.range;
				breath.weapons[0].rate /= 12;
				breath.weapons[0].projectile.GetDamageModel().damage = 4;
				breath.weapons[0].projectile.pierce = 3;
				breath.weapons[0].projectile.hasDamageModifiers = true;
				breath.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 3, 5, false, false) { name = "MoabModifier_" });

				breath.weapons[0].projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 1f, "BreathFreeze", 999999, "Ice", true, new GrowBlockModel("GrowBlockModel_"), null, 0, false, false));
				breath.weapons[0].projectile.collisionPasses = new int[] { 0, -1 };
				breath.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				breath.weapons[0].GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

				var icicleOrbit = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 5).GetBehavior<OrbitModel>().Duplicate();
				icicleOrbit.projectile.display = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 0, 5).GetAttackModel().weapons[0].projectile.display;
				icicleOrbit.range = 20;

				var icicleOrbit2 = icicleOrbit.Duplicate();
				icicleOrbit2.range = 45;
				icicleOrbit2.count = 5;

				var icicleDamage = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 5).GetAttackModel(1).Duplicate();
				icicleDamage.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				icicleDamage.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				icicleDamage.weapons[0].projectile.GetDamageModel().damage *= 4;
				icicleDamage.weapons[0].projectile.pierce *= 3;
				icicleDamage.range = tower.towerModel.range;
				icicleDamage.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 2, 0, false, false) { name = "MoabModifier_" });
				icicleDamage.weapons[0].projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 1f, "ShardFreeze", 1, "Ice", true, new GrowBlockModel("GrowBlockModel_"), null, 0, false, false));
				icicleDamage.weapons[0].projectile.collisionPasses = new int[] { 0, -1 };

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				towerModel.AddBehavior(breath);
				towerModel.AddBehavior(icicleOrbit);
				towerModel.AddBehavior(icicleOrbit2);
				towerModel.AddBehavior(icicleDamage);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class KingCobra : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.InfernoRingUpgradeIcon;
			public override string WeaponName => "King Cobra";
			public override Sprite CustomIcon => GetSprite("KingCobraIcon");
			public override string Description => "Glue Gunner 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var overlay = Game.instance.model.GetTowerFromId("GlueGunner-300").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().overlayType;
				var slow = Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate();
				var slowModel = new SlowModel("SlowModel_", slow.multiplier, slow.lifespan, "AcidSlow", 3, overlay, slow.isUnique, slow.dontRefreshDuration, slow.effectModel, true, false, false);

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].rate = Game.instance.model.GetTower(TowerType.GlueGunner).GetAttackModel().weapons[0].rate / 7f;
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.GlueGunner, 3).GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetDamageModel().damage = 20;
				wpn.weapons[0].projectile.pierce = 3;
				wpn.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());
				wpn.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
				wpn.weapons[0].emission = new RandomArcEmissionModel("VenomGunner_", 8, 0, 0, 80, 0, null);
				wpn.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
				wpn.weapons[0].projectile.AddBehavior(slowModel);
				wpn.weapons[0].projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 3, 0, false, false) { name = "MoabModifier_" });
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Fortified", 2, 0, false, false) { name = "FortifiedModifier_" });
				wpn.GetBehavior<AttackFilterModel>().filters = Game.instance.model.GetTowerFromId("DartMonkey-003").GetAttackModel().GetBehavior<AttackFilterModel>().filters;
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class FlyingDutchman : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.DarkRitualAA;
			public override string WeaponName => "Flying Dutchman";
			public override Sprite CustomIcon => GetSprite("FlyingDutchmanIcon");
			public override string Description => "Buccaneer 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var bleed = Game.instance.model.GetTowerFromId("Sauda 9").GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
				bleed.GetBehavior<DamageOverTimeModel>().damage += 5;
				bleed.GetBehavior<DamageOverTimeModel>().interval = 0.5f;

				var aura = Game.instance.model.GetTower(TowerType.TackShooter, 5, 2).GetAttackModel().Duplicate();
				aura.weapons[0].projectile.GetDamageModel().damage = 9;
				aura.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				aura.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

				var orbit = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 5).GetBehavior<OrbitModel>().Duplicate();
				orbit.projectile.ApplyDisplay<T4SouldOrb>();
				orbit.range = aura.range;
				orbit.count = 10;

				var necro = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 5).GetBehavior<NecromancerZoneModel>().Duplicate();
				var necroWeapon = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 5).GetAttackModel(2).Duplicate();

				var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-200").GetAttackModel().Duplicate();
				wpn.GetBehavior<RotateToTargetModel>().additionalRotation = 0;
				wpn.weapons[0].emission.RemoveBehavior<EmissionRotationOffTowerDirectionModel>();
				wpn.weapons[0].ejectX = 0;
				wpn.weapons[0].ejectY = 0;
				wpn.weapons[0].ejectX = 0;

				wpn.weapons[0].projectile.AddBehavior(bleed);
				wpn.weapons[0].projectile.collisionPasses = new[] { -1, 0, 1 };
				wpn.weapons[0].projectile.GetDamageModel().damage += 6;
				wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
				wpn.weapons[0].projectile.ApplyDisplay<GhostBall>();
				wpn.range = tower.towerModel.range;

				var ball2 = wpn.weapons[0].Duplicate();
				var ball3 = wpn.weapons[0].Duplicate();

				ball2.ejectX = 15;
				ball3.ejectX = -15;

				wpn.AddWeapon(ball2);
				wpn.AddWeapon(ball3);

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(aura);
				towerModel.AddBehavior(orbit);
				towerModel.AddBehavior(necroWeapon);
				towerModel.AddBehavior(necro);
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Incinerator : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.InfernoRingUpgradeIcon;
			public override string WeaponName => "Incinerator";
			public override Sprite CustomIcon => GetSprite("IncineratorIcon");
			public override string Description => "Dartling 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var fire = Game.instance.model.GetTowerFromId("MortarMonkey-002").Duplicate<TowerModel>().GetBehavior<AttackModel>().weapons[0].projectile.
					GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();

				var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-020").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 18, 36, 100, false, null, 0, null, 1));
				wpn.weapons[0].projectile.GetDamageModel().damage += 31;
				wpn.weapons[0].emission = new RandomArcEmissionModel("VollyGunner_", 12, 0, 0, 60, 0, null);
				wpn.weapons[0].projectile.pierce += 6;
				wpn.weapons[0].rate /= 3f;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan * 1.2f;
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 1).GetAttackModel(1).weapons[0].projectile.display;
				wpn.weapons[0].projectile.AddBehavior(fire);
				wpn.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
				wpn.weapons[0].projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 2, 0, false, false) { name = "MoabModifier_" });
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "BAD", 3, 0, false, false) { name = "BADModifier_" });
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class MasterWaves : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.SpiritoftheForestUpgradeIcon;
			public override string WeaponName => "Master of the Waves";
			public override Sprite CustomIcon => GetSprite("MasterofWavesIcon");
			public override string Description => "Druid 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.BeastHandler, 2).GetBehavior<BeastHandlerLeashModel>().towerModel.GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 3;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed /= 1.667f;
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.GetDamageModel().damage = 8;
				wpn.weapons[0].projectile.pierce = 99;
				wpn.weapons[0].rate = 1.4f;
				wpn.weapons[0].emission = new ArcEmissionModel("Tsunami_", 10, 0, 90, null, false, false);
				wpn.range = tower.towerModel.range;

				var orca = Game.instance.model.GetTower(TowerType.BeastHandler, 4).GetBehavior<BeastHandlerLeashModel>().towerModel.GetAttackModel().Duplicate();
				orca.AddBehavior(new TargetStrongModel("targetstrong", false, false));
				orca.AddBehavior(new TargetCloseModel("targetclose", false, false));
				orca.AddBehavior(new TargetFirstModel("targetfirst", false, false));
				orca.AddBehavior(new TargetLastModel("targetlast", false, false));
				orca.range = tower.towerModel.range;

				towerModel.AddBehavior(wpn);
				towerModel.AddBehavior(orca);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Lockdown : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.EnergizerUpgradeIcon;
			public override string WeaponName => "Lockdown";
			public override Sprite CustomIcon => GetSprite("LockdownIcon");
			public override string Description => "Spike Factory 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-020").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.RemoveBehavior<SetSpriteFromPierceModel>();
				wpn.weapons[0].projectile.pierce += 43;
				wpn.weapons[0].projectile.GetBehavior<AgeModel>().Lifespan *= 1.875f;
				wpn.weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 0, 45, 75, true, null, 0, null, 1));
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.GetDamageModel().damage += 4;
				wpn.weapons[0].projectile.ApplyDisplay<ForceFieldsLockdown>();
				//wpn.weapons[0].rate /= 2;
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PrimalLegend : WeaponTemplate
		{
			public override int SandboxIndex => 5;
			public override Rarity WeaponRarity => Rarity.Exotic;
			public override string Icon => VanillaSprites.TrueSonGodUpgradeIcon;
			public override string WeaponName => "Primal Legend";
			public override Sprite CustomIcon => GetSprite("PrimalLegendIcon");
			public override string Description => "Beast Handler 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("ObynGreenfoot").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.weapons[0].rate /= 5f;
				wpn.weapons[0].projectile.GetDamageModel().damage += 7;
				wpn.weapons[0].projectile.pierce += 5;
				wpn.weapons[0].projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 56, false, false) { name = "MoabModifier_" });
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 16, false, false) { name = "CeramicModifier_" });

				wpn.weapons[0].projectile.collisionPasses = new int[] { 0, -1 };
				wpn.weapons[0].projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 2.5f, "Stun", 999, "Stun", true, new GrowBlockModel("GrowBlockModel_"), null, 0, false, true));

				var shard = Game.instance.model.GetTower(TowerType.TackShooter).GetAttackModel().weapons[0].projectile.Duplicate();
				shard.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				shard.ApplyDisplay<T5SouldOrb>();
				shard.GetDamageModel().damage = 5;
				shard.pierce = 6;

				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("", shard, new ArcEmissionModel("aaa", 16, 0, 360, null, true, false), true, false, false));
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public static List<string> ExoticWpn = new List<string>();
		public static List<string> ExoticImg = new List<string>();
		public static List<Sprite> ExoticCustomImg = new List<Sprite>();
	}
}
