using AncientMonkey.Projectiles;
using blankdisplay;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.SimulationBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.IO;
using PlasmaEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey.Weapons
{
	public class Epic
	{
		public class PlasmaBlasts : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.PlasmaBlastUpgradeIcon;
			public override string WeaponName => "Plasma Blasts";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-200").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class DragonsBreath : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.DragonsBreathUpgradeIcon;
			public override string WeaponName => "Dragon's Breath";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-030").GetAttackModel(3).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class RecursiveCluster : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.RecursiveClusterUpgradeIcon;
			public override string WeaponName => "Recursive Cluster";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BombShooter-024").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BouncingBullet : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BouncingBulletUpgradeIcon;
			public override string WeaponName => "Bouncing Bullet";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-230").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class StickyBomb : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.StickyBombUpgradeIcon;
			public override string WeaponName => "Sticky Bomb";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey-004").GetAttackModel(2).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SpikedBalls : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.SpikedBallsUpgradeIcon;
			public override string WeaponName => "Spiked Balls";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-320").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BananaPlantation : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BananaPlantationUpgradeIcon;
			public override string WeaponName => "Banana Plantation";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BananaFarm-320").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BloonTrap : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BloonTrapUpgradeIcon;
			public override string WeaponName => "Bloon Trap";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-004").GetAttackModel(1).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class HydraRocketPods : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.HydraRocketsUpgradeIcon;
			public override string WeaponName => "Hydra Rocket Pods";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-030").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Destroyer : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.DestroyerUpgradeIcon;
			public override string WeaponName => "Destroyer";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-320").GetAttackModel().Duplicate();
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
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class MoabGlue : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.MoabGlueUpgradeIcon;
			public override string WeaponName => "Moab Glue";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("GlueGunner-023").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.range = towerModel.range;
				wpn.name = "AttackModel_MoabGlue_";
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Icicles : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.IciclesUpgradeIcon;
			public override string WeaponName => "Icicles";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("IceMonkey-204").GetAttackModel().Duplicate();

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.range = towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Overdrive : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.OverdriveUpgradeIcon;
			public override string WeaponName => "Overdrive";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("TackShooter-204").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class DruidOfTheJungle : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.DruidoftheJungleUpgradeIcon;
			public override string WeaponName => "Druid of the jungle";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("Druid-130").GetAttackModel(1).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BallisticMissile : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BallisticMissileUpgradeIcon;
			public override string WeaponName => "Ballistic Missile";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("MonkeySub-032").GetAttackModel(1).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SentryExpert : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.SentryExpertUpgradeIcon;
			public override string WeaponName => "Sentry Expert";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-400").GetAttackModel(1).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BloonLiquefier : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BloonLiquefierUpgradeIcon;
			public override string WeaponName => "Bloon Liquefier";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("GlueGunner-420").GetAttackModel(0).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class RingOfFire : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.RingOfFireUpgradeIcon;
			public override string WeaponName => "Ring Of Fire";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("TackShooter-420").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class MoabAssassin : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.MoabAssassinUpgradeIcon;
			public override string WeaponName => "Moab Assassin";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-204").GetAttackModel(0).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SharpShooter : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.SharpShooterUpgradeIcon;
			public override string WeaponName => "Sharp Shooter";
			public override bool IsCamo => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-204").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class TheBigOne : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.TheBIgOneUpgradeIcon;
			public override string WeaponName => "The Big One";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-402").GetAttackModel().Duplicate();
				wpn.RemoveBehaviors<TargetSelectedPointModel>();
				wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
				wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
				wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
				wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class OperationDartStorm : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.OperationDartStormUpgradeIcon;
			public override string WeaponName => "Operation: Dart Storm";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
				var ace = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehavior<AirUnitModel>().Duplicate();
				var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehavior<AttackAirUnitModel>().Duplicate();
				var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
				var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
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

				towerModel.AddBehavior(phoenix);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class ArtilleryBattery : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.ArtilleryBatteryUpgradeIcon;
			public override string WeaponName => "Artillery Battery";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-240").GetAttackModel().Duplicate();
				wpn.RemoveBehaviors<TargetSelectedPointModel>();
				wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
				wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
				wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
				wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class FullAutoRifle : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.FullAutoRifleUpgradeIcon;
			public override string WeaponName => "Full Auto Rifle";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-204").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class ArmorPiercingDarts : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.ArmorPiercingDartsUpgradeIcon;
			public override string WeaponName => "Armor Piercing Darts";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("MonkeySub-024").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.range = towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class DarkKnight : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.DarkKnightUpgradeIcon;
			public override string WeaponName => "Dark Knight";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-203").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.range = towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class MarketPlace : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.MarketplaceUpgradeIcon;
			public override string WeaponName => "Market Place";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BananaFarm-023").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class FavoredTrades : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.FavoredTradesUpgradeIcon;
			public override string WeaponName => "Favored Trades";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-004").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Rifleman : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.DeadlyPrecisionUpgradeIcon;
			public override string WeaponName => "Rifleman";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override Sprite CustomIcon => GetSprite("RiflemanIcon");
			public override string Description => "Dart Monkey 4th path by LynxC";
			public override void EditTower(Tower tower)
			{
				var seeking = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();
				seeking.distance = 999;
				seeking.constantlyAquireNewTarget = true;

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				wpn.weapons[0].projectile.AddBehavior(seeking);
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 4;
				wpn.weapons[0].projectile.pierce += 2;
				wpn.weapons[0].rate /= 5.6f;
				wpn.weapons[0].projectile.GetDamageModel().damage += 1;
				wpn.weapons[0].projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 3, false, false) { name = "CeramicModifier_" });
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PlasmaBomb : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BallLightningUpgradeIcon;
			public override string WeaponName => "Plasma Bombs";
			public override Sprite CustomIcon => GetSprite("PlasmaBombIcon");
			public override string Description => "Bomb Shooter 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var super = Game.instance.model.GetTowerFromId(TowerType.SuperMonkey + "-050");
				var techTerror = super.GetDescendants<AttackModel>().ToArray().First(a => a.name == "AttackModel_TechTerror_").Duplicate();
				var fire = Game.instance.model.GetTowerFromId("MortarMonkey-002").Duplicate<TowerModel>().GetBehavior<AttackModel>().weapons[0].projectile.
					GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();

				var wpn = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

				var charge = techTerror.weapons[0].projectile;
				charge.GetBehavior<AgeModel>().Lifespan = 0.1f;
				charge.radius = 30;
				charge.scale = 30;
				charge.pierce = 35;
				charge.GetDamageModel().damage = 10;
				charge.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				charge.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				charge.hasDamageModifiers = true;
				charge.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 20, false, false) { name = "MoabModifier_" });
				charge.AddBehavior(fire);
				var chargeBehavior = new CreateProjectileOnContactModel("", charge, new ArcEmissionModel("ArcEmissionModel_", 1, 0, 0, null, false, false), true, false, false) { name = "PlasmaBlast_" };

				var lightningVisual = charge.Duplicate();
				lightningVisual.RemoveBehavior<DamageModel>();
				lightningVisual.RemoveBehavior<ProjectileFilterModel>();
				lightningVisual.RemoveBehavior<DistributeToChildrenBloonModifierModel>();
				lightningVisual.GetBehavior<AgeModel>().Lifespan = 0.75f;
				lightningVisual.ApplyDisplay<WpnPlasmaDisplay>();
				var lightningVisualBehavior = new CreateProjectileOnContactModel("", lightningVisual, new ArcEmissionModel("ArcEmissionModel_", 1, 0, 0, null, false, false), true, false, false) { name = "PlasmaVisual_" };

				var druid = Game.instance.model.GetTower(TowerType.Druid, 2);
				var lightningBolt = druid.GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning").Duplicate();

				var lightning = lightningBolt.projectile;
				lightning.pierce = 25;
				lightning.GetBehavior<LightningModel>().splitRange = towerModel.range * 5f;
				lightning.GetBehavior<LightningModel>().splits = 1;
				lightning.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				lightning.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				lightning.AddBehavior(fire);
				var lightningBehavior = new CreateProjectileOnContactModel("", lightning, new ArcEmissionModel("ArcEmissionModel_", 1, 0, 0, null, false, false), true, false, false) { name = "Lightning_" };

				wpn.weapons[0].projectile.AddBehavior(lightningBehavior);
				wpn.weapons[0].projectile.AddBehavior(lightningVisualBehavior);
				wpn.weapons[0].projectile.AddBehavior(chargeBehavior);
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(fire);
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.collisionPasses = new int[] { 0, -1 };
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 3, false, false) { name = "CeramicModifier_" });
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Fortified", 1, 3, false, false) { name = "FortifiedModifier_" });
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 20, false, false) { name = "MoabModifier_" });
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 9;
				wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnContactModel>();
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class FireCracker : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.ShrapnelShotUpgradeIcon;
			public override string WeaponName => "Fire Cracker";
			public override Sprite CustomIcon => GetSprite("FirecrackerIcon");
			public override string Description => "Tack Shooter 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var effect = Game.instance.model.GetTower(TowerType.MortarMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.CreateEffectOnExpireModel>().Duplicate();
				var sound = Game.instance.model.GetTower(TowerType.MortarMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileExhaustModel>().Duplicate();
				var explosion = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.Duplicate();
				var bombEffect = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.Duplicate();
				var fragment = Game.instance.model.GetTower(TowerType.TackShooter).GetAttackModel().weapons[0].projectile.Duplicate();
				effect.effectModel = bombEffect;
				fragment.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

				explosion.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				explosion.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				explosion.GetDamageModel().damage = 2;

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("TackShooter-200").GetAttackModel().Duplicate();
				wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.2f;
				wpn.weapons[0].projectile.pierce = 999;
				wpn.weapons[0].projectile.GetDamageModel().damage -= 1;
				wpn.weapons[0].projectile.RemoveBehavior<CreateProjectileOnContactModel>();
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("Fragment", fragment, new ArcEmissionModel("FragmentEmmision_", 6, 0, 360, null, true, false), false));
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("Explosion", explosion, new ArcEmissionModel("FragmentEmmision_", 1, 0, 0, null, true, false), false));
				wpn.weapons[0].projectile.AddBehavior(effect);
				wpn.weapons[0].projectile.AddBehavior(sound);
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class IceMagic : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.IntenseMagicUpgradeIcon;
			public override string WeaponName => "Ice Magic";
			public override Sprite CustomIcon => GetSprite("IceMagicIcon");
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
				shard.pierce += 2;
				shard.AddBehavior(seeking);
				shard.GetBehavior<TravelStraitModel>().Lifespan *= 6;
				shard.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.White;
				shard.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				shard.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());

				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 0, 5).GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.White;
				wpn.weapons[0].rate /= 1.44f;
				wpn.weapons[0].projectile.GetDamageModel().damage += 3;
				wpn.weapons[0].projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 1f, "ShardFreeze", 1, "Ice", true, new GrowBlockModel("GrowBlockModel_"), null, 0, false, false));
				wpn.weapons[0].projectile.collisionPasses = new int[] { 0, -1 };
				wpn.weapons[0].projectile.pierce = 1;
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("CreateProjectileOnContactModel_", shard, new ArcEmissionModel("ArcEmissionModel_", 3, 0, 30, null, true, false), true, false, false));
				wpn.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class AciGunner : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.CorrosiveGlueUpgradeIcon;
			public override string WeaponName => "Acid Gunner";
			public override Sprite CustomIcon => GetSprite("AcidGunnerIcon");
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
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				wpn.weapons[0].rate = Game.instance.model.GetTower(TowerType.GlueGunner).GetAttackModel().weapons[0].rate / 2.8f;
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.GlueGunner, 3).GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetDamageModel().damage = 4;
				wpn.weapons[0].projectile.pierce = 3;
				wpn.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());
				wpn.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
				wpn.weapons[0].emission = new RandomArcEmissionModel("VenomGunner_", 3, 0, 0, 35, 0, null);
				wpn.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
				wpn.weapons[0].projectile.AddBehavior(slowModel);
				wpn.GetBehavior<AttackFilterModel>().filters = Game.instance.model.GetTowerFromId("DartMonkey-003").GetAttackModel().GetBehavior<AttackFilterModel>().filters;
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class FlakGun : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.FragBombsUpgradeIcon;
			public override string WeaponName => "Flak Gun";
			public override Sprite CustomIcon => GetSprite("FlakGunIcon");
			public override string Description => "Sniper 4th path by LynxC";
			public override void EditTower(Tower tower)
			{
				var bomb = Game.instance.model.GetTower(TowerType.BombShooter, 0).GetAttackModel().weapons[0].projectile.Duplicate();
				var blast = bomb.GetBehavior<CreateProjectileOnContactModel>().projectile.Duplicate();
				var explosion = bomb.GetBehavior<CreateEffectOnContactModel>().Duplicate();
				var shrapnel = Game.instance.model.GetTower(TowerType.TackShooter).GetAttackModel().weapons[0].projectile.Duplicate();
				shrapnel.pierce = 3;
				shrapnel.GetBehavior<TravelStraitModel>().Lifespan *= 1.5f;
				shrapnel.GetDamageModel().damage = 2;

				blast.GetDamageModel().damage = 3;
				blast.radius = 20;
				blast.pierce = 16;
				blast.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

				explosion.effectModel.scale *= 2;

				var contactModel = new CreateProjectileOnContactModel("aaa", blast, new ArcEmissionModel("ArcEmissionModel_", 1, 0, 0, null, false, false), true, false, false) { name = "RifleBlast_" };
				var fragmentModel = new CreateProjectileOnContactModel("aaa", shrapnel, new ArcEmissionModel("ArcEmissionModel_", 6, 0, 360, null, true, false), true, false, false) { name = "RifleShrapnel_" };


				var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-002").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.weapons[0].projectile.GetDamageModel().damage += 1;
				wpn.weapons[0].projectile.AddBehavior(contactModel);
				wpn.weapons[0].projectile.AddBehavior(explosion);
				wpn.weapons[0].projectile.AddBehavior(fragmentModel);
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class AssaultSub : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.LotsMoreDartsUpgradeIcon;
			public override string WeaponName => "Assault Sub";
			public override Sprite CustomIcon => GetSprite("AssaultSubIcon");
			public override string Description => "Monkey Sub 4th path by LynxC";
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("MonkeySub").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.GetBehavior<TrackTargetModel>().TurnRate *= 3;
				wpn.weapons[0].name = "Dart1";
				wpn.weapons[0].rate /= 1.2f;

				var dart2 = wpn.weapons[0].Duplicate();
				var dart3 = wpn.weapons[0].Duplicate();
				var dart4 = wpn.weapons[0].Duplicate();

				dart2.name = "Dart2";
				dart3.name = "Dart3";
				dart4.name = "Dart4";

				wpn.AddWeapon(dart2);
				wpn.AddWeapon(dart3);
				wpn.AddWeapon(dart4);

				foreach (var weapon in wpn.weapons)
				{
					if (weapon.name == "Dart1")
					{
						weapon.ejectX = 9;
					}
					if (weapon.name == "Dart2")
					{
						weapon.ejectX = 3;
					}
					if (weapon.name == "Dart3")
					{
						weapon.ejectX = -3;
					}
					if (weapon.name == "Dart4")
					{
						weapon.ejectX = -9;
					}
				}

				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Dreadnought : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.SpikedBallsUpgradeIcon;
			public override string WeaponName => "Dreadnought";
			public override Sprite CustomIcon => GetSprite("DreadnoughtIcon");
			public override string Description => "Buccaneer 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var bleed = Game.instance.model.GetTowerFromId("Sauda 9").GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
				bleed.GetBehavior<DamageOverTimeModel>().damage += 1;
				bleed.GetBehavior<DamageOverTimeModel>().interval -= 1f;

				var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-200").GetAttackModel().Duplicate();
				wpn.GetBehavior<RotateToTargetModel>().additionalRotation = 0;
				wpn.weapons[0].emission.RemoveBehavior<EmissionRotationOffTowerDirectionModel>();
				wpn.weapons[0].ejectX = 0;
				wpn.weapons[0].ejectY = 0;
				wpn.weapons[0].ejectX = 0;

				wpn.weapons[0].projectile.AddBehavior(bleed);
				wpn.weapons[0].projectile.collisionPasses = new[] { -1, 0, 1 };
				wpn.weapons[0].projectile.GetDamageModel().damage += 3;
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
				wpn.weapons[0].projectile.ApplyDisplay<LeadBall>();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Dogfighter : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.FasterBarrelSpinUpgradeIcon;
			public override string WeaponName => "Dogfighter";
			public override Sprite CustomIcon => GetSprite("DogfighterIcon");
			public override string Description => "Monkey Ace 4th path by LynxC";
			public override void EditTower(Tower tower)
			{
				var dart = Game.instance.model.GetTower(TowerType.DartMonkey).GetWeapon().projectile.Duplicate();
				var bomb = Game.instance.model.GetTower(TowerType.BombShooter).GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
				var effect = Game.instance.model.GetTower(TowerType.BombShooter).GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
				bomb.name = "SplodeyDart";
				bomb.projectile.GetDamageModel().damage += 2;

				var gatling = Game.instance.model.GetTower(TowerType.HeliPilot, 4).GetAttackModel().weapons[2].Duplicate();
				gatling.emission = new RandomArcEmissionModel("emission", 4, 0, 0, 45, 0, null);
				gatling.projectile.GetDamageModel().damage += 3;
				gatling.name = "GatlingGun";

				var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
				var ace = Game.instance.model.GetTowerFromId("MonkeyAce").GetBehavior<AirUnitModel>().Duplicate();
				var wpn = Game.instance.model.GetTowerFromId("MonkeyAce").GetBehavior<AttackAirUnitModel>().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				ace.GetBehavior<PathMovementModel>().speed *= 2.5f;
				wpn.weapons[0].projectile.AddBehavior(bomb);
				wpn.weapons[0].projectile.AddBehavior(effect);
				wpn.weapons[0].projectile.pierce = 1;
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("Crackshot", dart, new ArcEmissionModel("ArcEmissionModel_", 4, 0, 35, null, true, false), true, false, false));
				wpn.weapons[0].projectile.GetDamageModel().damage += 1;
				wpn.AddWeapon(gatling);
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
		public class Railgun : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.LaserCannonUpgradeIcon;
			public override string WeaponName => "Railgun";
			public override Sprite CustomIcon => GetSprite("RailgunIcon");
			public override string Description => "Heli Pilot 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var railgun = Game.instance.model.GetTower(TowerType.HeliPilot, 4).GetAttackModel().weapons[2].Duplicate();

				railgun.projectile.pierce = 20;
				railgun.projectile.GetDamageModel().damage = 5;
				railgun.projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				railgun.rate = Game.instance.model.GetTower(TowerType.HeliPilot, 2).GetAttackModel().weapons[0].rate * 3f;
				railgun.projectile.ApplyDisplay<RailgunProj>();
				railgun.name = "_Railgun_Main";

				var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
				var heli = Game.instance.model.GetTowerFromId("HeliPilot").GetBehavior<AirUnitModel>().Duplicate();
				var wpn = Game.instance.model.GetTowerFromId("HeliPilot").GetBehavior<AttackModel>().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.weapons[0].projectile.GetDamageModel().damage += 1;
				wpn.weapons[0].projectile.pierce += 4;
				wpn.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-300").GetAttackModel().weapons[0].projectile.display;
				wpn.AddWeapon(railgun);
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
		public class CarpetBomb : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BomberAceUpgradeIcon;
			public override string WeaponName => "Carpet Bombing";
			public override Sprite CustomIcon => GetSprite("CarpetBombIcon");
			public override string Description => "Mortar 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var bomb = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
				var mortar = Game.instance.model.GetTower(TowerType.MortarMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
				var effect = Game.instance.model.GetTower(TowerType.MortarMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.CreateEffectOnExpireModel>().Duplicate();
				var sound = Game.instance.model.GetTower(TowerType.MortarMonkey).GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileExhaustModel>().Duplicate();
				var explosion = Game.instance.model.GetTower(TowerType.BombShooter, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.Duplicate();
				var bombEffect = Game.instance.model.GetTower(TowerType.BombShooter, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.Duplicate();
				bombEffect.scale /= 2;
				effect.effectModel = bombEffect;

				explosion.radius /= 2;
				explosion.pierce = 16;
				explosion.GetDamageModel().damage = 2;

				bomb.pierce = 9999;
				bomb.GetDamageModel().damage = 0;
				bomb.GetBehavior<TravelStraitModel>().Speed /= 1.75f;
				bomb.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				bomb.display = Game.instance.model.GetTower(TowerType.DartlingGunner, 5).GetAttackModel().weapons[0].projectile.display;

				bomb.AddBehavior(new CreateProjectileOnExpireModel("ExpireExplosion", explosion, new ArcEmissionModel("", 1, 0, 0, null, true, false), false));

				bomb.AddBehavior(effect);
				bomb.AddBehavior(sound);

				var bomb2 = bomb.Duplicate();
				var bomb3 = bomb.Duplicate();

				bomb2.GetBehavior<TravelStraitModel>().Lifespan *= 1.5f;
				bomb3.GetBehavior<TravelStraitModel>().Lifespan *= 2;

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-020").GetAttackModel().Duplicate();
				wpn.RemoveBehaviors<TargetSelectedPointModel>();
				wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
				wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
				wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
				wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExhaustFractionModel("CarpetBomb-1", bomb, new ArcEmissionModel("", 4, 0, 360, null, true, false), mortar.fraction, mortar.durationfraction, true, false, true));
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExhaustFractionModel("CarpetBomb-2", bomb2, new ArcEmissionModel("", 4, 0, 360, null, true, false), mortar.fraction, mortar.durationfraction, true, false, true));
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExhaustFractionModel("CarpetBomb-3", bomb3, new ArcEmissionModel("", 4, 0, 360, null, true, false), mortar.fraction, mortar.durationfraction, true, false, true));
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Volley : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.QuadDartsUpgradeIcon;
			public override string WeaponName => "Volley";
			public override Sprite CustomIcon => GetSprite("VolleyIcon");
			public override string Description => "Dartling 4th path by LynxC";
			public override bool IsCamo => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-020").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 6, 12, 100, false, null, 0, null, 1));
				wpn.weapons[0].projectile.GetDamageModel().damage += 1;
				wpn.weapons[0].emission = new RandomArcEmissionModel("VollyGunner_", 3, 0, 0, 15, 0, null);
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SpectralClaws : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.ArcaneSpikeUpgradeIcon;
			public override string WeaponName => "Spectral Claws";
			public override Sprite CustomIcon => GetSprite("SpectralClawsIcon");
			public override string Description => "Super Monkey 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var seeking = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();
				var wpn = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().Duplicate();
				var shard = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.Duplicate();

				wpn.weapons[0].rate /= 1.5f;
				wpn.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 180, null, false, false);
				wpn.weapons[0].projectile.pierce = 999;
				wpn.weapons[0].projectile.GetDamageModel().damage = 0;
				wpn.weapons[0].projectile.ApplyDisplay<SpectralOrb>();
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed /= 2;

				shard.pierce = 3;
				shard.GetDamageModel().damage = 4;
				shard.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
				shard.AddBehavior(new TrackTargetModel("", 999, seeking.trackNewTargets, true, seeking.maxSeekAngle, seeking.ignoreSeekAngle, seeking.turnRate * 6, seeking.overrideRotation, seeking.useLifetimeAsDistance));
				shard.GetBehavior<TravelStraitModel>().Speed *= 2;
				shard.GetBehavior<TravelStraitModel>().Lifespan *= 3;
				shard.ApplyDisplay<SpectralShard>();

				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("SpectralShards", shard, new ArcEmissionModel("", 3, 0, 30, null, false, false), false));
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PotionLauncher : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.BuckshotUpgradeIcon;
			public override string WeaponName => "Potion Launcher";
			public override Sprite CustomIcon => GetSprite("PotionLauncherIcon");
			public override string Description => "Alchemist 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("Alchemist").GetAttackModel().Duplicate();
				wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 1f, "AcidFreeze", 1, "Ice", true, new GrowBlockModel("GrowBlockModel_"), null, 0, false, false));
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.collisionPasses = new int[] { 0, -1 };
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().damage += 1;
				wpn.weapons[0].rate /= 3;
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class DeepDruid : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.GreatWhiteUpgradeIcon;
			public override string WeaponName => "Druid of the Deep";
			public override Sprite CustomIcon => GetSprite("DruidofDeepIcon");
			public override string Description => "Druid 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTower(TowerType.BeastHandler, 3).GetBehavior<BeastHandlerLeashModel>().towerModel.GetAttackModel().Duplicate();
				wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
				wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
				wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
				wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class HealthierBananas : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.GreaterProductionUpgradeIcon;
			public override string WeaponName => "Healthier Bananas";
			public override Sprite CustomIcon => GetSprite("HealthierBananasIcon");
			public override string Description => "Farm 4th path by LynxC";
			public override void EditTower(Tower tower)
			{
				var lives = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 0, 5).GetBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.BonusLivesPerRoundModel>().Duplicate();
				lives.name = "RoundLives";
				lives.amount = 3;

				var wpn = Game.instance.model.GetTowerFromId("BananaFarm-020").GetAttackModel().Duplicate();
				wpn.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count += 3;
				wpn.weapons[0].projectile.GetBehavior<CashModel>().maximum += 30f;
				wpn.weapons[0].projectile.GetBehavior<CashModel>().minimum += 30f;
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(lives);
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class ShieldGenerator : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.PlasmaAcceleratorUpgradeIcon;
			public override string WeaponName => "Shield Generator";
			public override Sprite CustomIcon => GetSprite("ShieldGeneratorIcon");
			public override string Description => "Spike Factory 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-020").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.RemoveBehavior<SetSpriteFromPierceModel>();
				wpn.weapons[0].projectile.pierce += 11;
				wpn.weapons[0].projectile.GetBehavior<AgeModel>().Lifespan *= 1.25f;
				wpn.weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 0, 10, 50, false, null, 0, null, 1));
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
				wpn.weapons[0].projectile.ApplyDisplay<ForceFields>();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PrototypeSentries : WeaponTemplate
		{
			public override int SandboxIndex => 3;
			public override Rarity WeaponRarity => Rarity.Epic;
			public override string Icon => VanillaSprites.SentryGunUpgradeIcon;
			public override string WeaponName => "Prototype Sentries";
			public override Sprite CustomIcon => GetSprite("PrototypeSentriesIcon");
			public override string Description => "Engineer 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var druid = Game.instance.model.GetTower(TowerType.Druid, 2);
				var lightning = druid.GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning").Duplicate();
				lightning.animation = 1;
				lightning.projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.Purple;

				lightning.rate = .75f;

				var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel(1).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var sentry = wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower;
				var lightningProj = lightning.projectile;
				lightningProj.pierce = 9;
				lightningProj.GetBehavior<LightningModel>().splitRange = sentry.range / 2f;
				lightningProj.GetBehavior<LightningModel>().splits = 1;
				sentry.GetAttackModel().weapons[0] = lightning;
				wpn.range = towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}

		public class TruckNotRotorDisplay : ModDisplay
		{
			public override PrefabReference BaseDisplayReference => Game.instance.model.GetTower(TowerType.HeliPilot, 0, 4, 0).GetBehavior<AirUnitModel>().display;
			public override void ModifyDisplayNode(UnityDisplayNode node)
			{
				node.RemoveBone("MonkeyHeliRig:Top_Rotor");
				node.RemoveBone("MonkeyHeliRig:Top_RotorExtra");
			}
		}
		public static List<string> EpicWpn = new List<string>();
		public static List<string> EpicImg = new List<string>();
		public static List<Sprite> EpicCustomImg = new List<Sprite>();
	}
}
namespace Monkeys
{
	public class Officer : ModTower
	{
		public override string Portrait => "Officer";
		public override string Name => "Officer";
		public override TowerSet TowerSet => TowerSet.Military;
		public override string BaseTower => TowerType.SniperMonkey;

		public override bool DontAddToShop => true;
		public override int Cost => 0;

		public override int TopPathUpgrades => 0;
		public override int MiddlePathUpgrades => 0;
		public override int BottomPathUpgrades => 0;


		public override string DisplayName => "Officer";
		public override string Description => "";

		public override void ModifyBaseTowerModel(TowerModel towerModel)
		{
			var attackModel = towerModel.GetBehavior<AttackModel>();
			var weapons = attackModel.weapons[0];
			var projectile = weapons.projectile;
			towerModel.isSubTower = true;
			towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 30f, 3, false, false));
			weapons.rate = 0.4f;
			projectile.GetDamageModel().damage = 5;
			towerModel.range = 42;
			attackModel.range = 42;
			towerModel.radius = 0;
			towerModel.isGlobalRange = false;
			var Pops = Game.instance.model.GetTowerFromId("Sentry").GetBehavior<CreditPopsToParentTowerModel>().Duplicate();
			towerModel.AddBehavior(Pops);



		}
		public class OfficerDisplay : ModTowerDisplay<Officer>
		{
			public override float Scale => .7f;
			public override string BaseDisplay => GetDisplay(TowerType.EngineerMonkey, 0, 0, 2);

			public override bool UseForTower(int[] tiers)
			{
				return true;
			}
			public override void ModifyDisplayNode(UnityDisplayNode node)
			{
				foreach (var renderer in node.genericRenderers)
				{
					renderer.material.mainTexture = GetTexture("OfficerDisplay");
				}
			}
		}

	}
}
