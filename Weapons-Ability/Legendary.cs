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
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
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
	public class Legendary
	{
		public class UltraJuggernaut : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.UltraJuggernautUpgradeIcon;
			public override string WeaponName => "Ultra Juggernaut";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-520").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BloonSolver : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.TheBloonSolverUpgradeIcon;
			public override string WeaponName => "Bloon Solver";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("GlueGunner-520").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SuperBrittle : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SuperBrittleUpgradeIcon;
			public override string WeaponName => "Super Brittle";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("IceMonkey-520").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class TackZone : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.TheTackZoneUpgradeIcon;
			public override string WeaponName => "Tack Zone";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("TackShooter-025").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BombBlitz : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.BombBlitzUpgradeIcon;
			public override string WeaponName => "Bomb Blitz";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BombShooter-025").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PermaCharge : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.PermaChargeUpgradeIcon;
			public override string WeaponName => "Perma Charge";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-052").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class EliteDefender : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.EliteDefenderUpgradeIcon;
			public override string WeaponName => "Elite Defender";
			public override bool IsCamo => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-025").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SubCommander : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SubCommanderUpgradeIcon;
			public override string WeaponName => "Sub Commander";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("MonkeySub-025").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PlasmaAccelerator : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.PlasmaAcceleratorUpgradeIcon;
			public override string WeaponName => "Plasma Accelerator";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-420").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class ArcaneSpike : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.ArcaneSpikeUpgradeIcon;
			public override string WeaponName => "Arcane Spike";
			public override bool IsCamo => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-402").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SunAvatar : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SunAvatarUpgradeIcon;
			public override string WeaponName => "Sun Avatar";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-320").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SpikedMines : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SpikedMinesUpgradeIcon;
			public override string WeaponName => "Spiked Mines";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-420").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BananaResearchFacility : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.BananaResearchFacilityUpgradeIcon;
			public override string WeaponName => "Banana Research Facility";
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BananaFarm-420").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SentryChampion : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SentryParagonUpgradeIcon;
			public override string WeaponName => "Sentry Champion";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-520").GetAttackModel(1).Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SpiritOfTheForest : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SpiritoftheForestUpgradeIcon;
			public override string WeaponName => "Spirit of the Forest";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("Druid-250").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var vines = Game.instance.model.GetTowerFromId("Druid-250").GetBehavior<SpiritOfTheForestModel>().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				towerModel.AddBehavior(vines);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class CrossBowMaster : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.CrossBowMasterUpgradeIcon;
			public override string WeaponName => "Cross Bow Master";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-025").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class MoabEliminator : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.MoabEliminatorUpgradeIcon;
			public override string WeaponName => "Moab Eliminator";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("BombShooter-051").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class IcicleImpale : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.IcicleImpaleUpgradeIcon;
			public override string WeaponName => "Icicles Impale";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("IceMonkey-205").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class CrippleMOAB : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.CrippleMoabUpgradeIcon;
			public override string WeaponName => "Cripple MOAB";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-520").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SkyShredder : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SkyShredderUpgradeIcon;
			public override string WeaponName => "Sky Shredder";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
				var ace = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehavior<AirUnitModel>().Duplicate();
				var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehavior<AttackAirUnitModel>().Duplicate();
				var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
				var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
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
		public class TheBiggestOne : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.TheBIggestOneUpgradeIcon;
			public override string WeaponName => "The Biggest One";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-502").GetAttackModel().Duplicate();
				wpn.RemoveBehaviors<TargetSelectedPointModel>();
				wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
				wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
				wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
				wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class GrandmasterNinja : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.GrandmasterNinjaUpgradeIcon;
			public override string WeaponName => "Grandmaster Ninja";
			public override bool IsCamo => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey-502").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PermaSpike : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.PermaSpikeUpgradeIcon;
			public override string WeaponName => "Perma Spike";
			public override bool IsLead => true;
			public override bool IsCamo => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-205").GetAttackModel().Duplicate();
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class PlasmaTank : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.ArmorPiercingShellsAA;
			public override string WeaponName => "Plasma Tank";
			public override Sprite CustomIcon => GetSprite("PlasmaTankIcon");
			public override string Description => "Dart Monkey 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var seeking = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();
				seeking.distance = 999;
				seeking.constantlyAquireNewTarget = true;

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.AddBehavior(seeking);
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 4;
				wpn.weapons[0].projectile.pierce += 7;
				wpn.weapons[0].rate /= 5.6f;
				wpn.weapons[0].projectile.GetDamageModel().damage += 4;
				wpn.weapons[0].projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 10, false, false) { name = "CeramicModifier_" });
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.SuperMonkey, 2).GetAttackModel().weapons[0].projectile.display;
				wpn.range = tower.towerModel.range;

				var missileWeapon = Game.instance.model.GetTower(TowerType.BombShooter, 1, 2).GetAttackModel().Duplicate();
				missileWeapon.weapons[0].rate = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].rate;
				missileWeapon.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.DartlingGunner, 0, 3).GetAttackModel().weapons[0].projectile.display;
				missileWeapon.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				missileWeapon.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

				var missile = missileWeapon.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile;
				missile.GetDamageModel().damage = 8;
				missile.hasDamageModifiers = true;
				missile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 56, false, false) { name = "MoabModifier_" });
				missile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

				towerModel.AddBehavior(missileWeapon);
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class BladeGod : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.BladeMaelstromUpgradeIcon;
			public override string WeaponName => "Blade God";
			public override Sprite CustomIcon => GetSprite("BladeGodIcon");
			public override string Description => "Boomerang 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var travel = Game.instance.model.GetTower(TowerType.DartMonkey).GetWeapon().projectile.GetBehavior<TravelStraitModel>().Duplicate();
				var seeking = Game.instance.model.GetTower(TowerType.NinjaMonkey, 0, 0, 1).GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();
				var bleed = Game.instance.model.GetTowerFromId("Sauda 9").GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
				bleed.name = "BleedModel";
				bleed.GetBehavior<DamageOverTimeModel>().interval = 1f;

				seeking.distance = 999;
				seeking.constantlyAquireNewTarget = true;

				var superBleed = bleed.Duplicate();
				superBleed.name = "MoabBleedModel";
				superBleed.GetBehavior<DamageOverTimeModel>().damage = 32;
				superBleed.filter = new FilterMoabModel("MoabsOnly", false);

				var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.collisionPasses = new[] { -1, 0, 1 };
				wpn.weapons[0].projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.AddBehavior(bleed);
				wpn.weapons[0].projectile.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Camo", 1, 1, false, false) { name = "CamoModifier_" });
				wpn.weapons[0].projectile.ApplyDisplay<BladeGodProj>();
				wpn.weapons[0].projectile.RemoveBehavior<FollowPathModel>();
				wpn.weapons[0].projectile.AddBehavior(travel);
				wpn.weapons[0].projectile.AddBehavior(seeking);
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 4;
				wpn.weapons[0].projectile.pierce += 4;
				wpn.weapons[0].projectile.AddBehavior(new UseAttackRotationModel("aaa"));
				wpn.weapons[0].projectile.GetDamageModel().damage += 14;
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval /= 2f;
				wpn.weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damage += 7;
				wpn.weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().lifespan *= 2;
				wpn.weapons[0].rate /= 1.75f;
				wpn.weapons[0].emission = new ArcEmissionModel("aaa", 3, 0, 25, null, false, false);
				wpn.weapons[0].projectile.AddBehavior(superBleed);
				wpn.weapons[0].projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("aaa", "bleed_Bonus_Damage", 8f, 3, 15, true, false, false, "bleed"));
				wpn.range = tower.towerModel.range;
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SuperNova : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.BallofLightAA;
			public override string WeaponName => "Super Nova";
			public override Sprite CustomIcon => GetSprite("SuperNovaIcon");
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
				charge.radius = 75;
				charge.scale = 75;
				charge.pierce = 90;
				charge.GetDamageModel().damage = 35;
				charge.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				charge.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				charge.hasDamageModifiers = true;
				charge.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 60, false, false) { name = "MoabModifier_" });
				charge.AddBehavior(fire);
				var chargeBehavior = new CreateProjectileOnContactModel("", charge, new ArcEmissionModel("ArcEmissionModel_", 1, 0, 0, null, false, false), true, false, false) { name = "PlasmaBlast_" };

				var lightningVisual = charge.Duplicate();
				lightningVisual.RemoveBehavior<DamageModel>();
				lightningVisual.RemoveBehavior<ProjectileFilterModel>();
				lightningVisual.RemoveBehavior<DistributeToChildrenBloonModifierModel>();
				lightningVisual.GetBehavior<AgeModel>().Lifespan = 0.75f;
				lightningVisual.ApplyDisplay<WpnNovaDisplay>();
				var lightningVisualBehavior = new CreateProjectileOnContactModel("", lightningVisual, new ArcEmissionModel("ArcEmissionModel_", 1, 0, 0, null, false, false), true, false, false) { name = "PlasmaVisual_" };

				var druid = Game.instance.model.GetTower(TowerType.Druid, 2);
				var lightningBolt = druid.GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning").Duplicate();

				var lightning = lightningBolt.projectile;
				lightning.GetDamageModel().damage += 2;
				lightning.pierce = 45;
				lightning.GetBehavior<LightningModel>().splitRange = towerModel.range * 10f;
				lightning.GetBehavior<LightningModel>().splits = 1;
				lightning.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				lightning.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				lightning.AddBehavior(fire);
				var lightningBehavior = new CreateProjectileOnContactModel("", lightning, new ArcEmissionModel("ArcEmissionModel_", 3, 0, 0, null, false, false), true, false, false) { name = "Lightning_" };

				wpn.weapons[0].projectile.AddBehavior(lightningBehavior);
				wpn.weapons[0].projectile.AddBehavior(lightningVisualBehavior);
				wpn.weapons[0].projectile.AddBehavior(chargeBehavior);
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(fire);
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.collisionPasses = new int[] { 0, -1 };
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 9, false, false) { name = "CeramicModifier_" });
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Fortified", 1, 9, false, false) { name = "FortifiedModifier_" });
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 60, false, false) { name = "MoabModifier_" });
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 34;
				wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnContactModel>();
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Fireworks : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.ClusterBombsUpgradeIcon;
			public override string WeaponName => "Fireworks";
			public override Sprite CustomIcon => GetSprite("FireworksIcon");
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
				explosion.GetDamageModel().damage = 2;

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("TackShooter-200").GetAttackModel().Duplicate();
				wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.display;
				wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.2f;
				wpn.weapons[0].projectile.pierce = 999;
				wpn.weapons[0].projectile.GetDamageModel().damage -= 1;
				wpn.weapons[0].projectile.RemoveBehavior<CreateProjectileOnContactModel>();
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("Explosion", explosion, new ArcEmissionModel("FragmentEmmision_", 1, 0, 0, null, true, false), false));
				wpn.weapons[0].projectile.AddBehavior(effect);
				wpn.weapons[0].projectile.AddBehavior(sound);

				var firework = wpn.weapons[0].projectile.Duplicate();
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("Firework", firework, new ArcEmissionModel("FragmentEmmision_", 8, 0, 360, null, true, false), false));

				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Bloonzooka : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.MissileLauncherUpgradeIcon;
			public override string WeaponName => "Bloonzooka";
			public override Sprite CustomIcon => GetSprite("BloonzookaIcon");
			public override string Description => "Sniper 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var rocket = Game.instance.model.GetTower(TowerType.BombShooter, 0, 2).GetAttackModel().weapons[0].Duplicate();
				var homing = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();

				homing.distance = 999;
				homing.constantlyAquireNewTarget = false;

				rocket.projectile.AddBehavior(homing);
				rocket.rate = Game.instance.model.GetTower(TowerType.SniperMonkey, 0, 0, 2).GetAttackModel().weapons[0].rate;
				rocket.projectile.GetBehavior<TravelStraitModel>().Lifespan *= 3;
				rocket.projectile.GetBehavior<TravelStraitModel>().Speed /= 1.45f;

				var shrapnel = Game.instance.model.GetTower(TowerType.TackShooter).GetAttackModel().weapons[0].projectile.Duplicate();
				shrapnel.GetBehavior<TravelStraitModel>().Speed *= 1.5f;
				shrapnel.GetBehavior<TravelStraitModel>().Lifespan *= 1.75f;

				var blast = rocket.projectile.GetBehavior<CreateProjectileOnContactModel>().projectile;
				blast.GetDamageModel().damage = 7;
				blast.radius = 30;
				blast.pierce = 65;
				blast.GetDamageModel().immuneBloonProperties = BloonProperties.None;

				var explosion = rocket.projectile.GetBehavior<CreateEffectOnContactModel>().effectModel;
				explosion.scale *= 3f;

				var fragmentModel = new CreateProjectileOnContactModel("aaa", shrapnel, new ArcEmissionModel("ArcEmissionModel_", 16, 0, 360, null, true, false), true, false, false) { name = "RifleShrapnel_" };
				rocket.projectile.AddBehavior(fragmentModel);

				var wpn = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0] = rocket;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class NauticDestroyer : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.RocketStormUpgradeIconAA;
			public override string WeaponName => "Nautic Destroyer";
			public override Sprite CustomIcon => GetSprite("NauticDestroyerIcon");
			public override string Description => "Monkey Sub 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("MonkeySub").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.GetBehavior<TrackTargetModel>().TurnRate *= 3;
				wpn.weapons[0].projectile.GetDamageModel().damage = 8;
				wpn.weapons[0].name = "Dart1";
				wpn.weapons[0].rate /= 1.2f;

				var dart2 = wpn.weapons[0].Duplicate();
				var dart3 = wpn.weapons[0].Duplicate();
				var dart4 = wpn.weapons[0].Duplicate();
				var dart5 = wpn.weapons[0].Duplicate();

				dart2.name = "Dart2";
				dart3.name = "Dart3";
				dart4.name = "Dart4";
				dart5.name = "Dart5";

				wpn.AddWeapon(dart2);
				wpn.AddWeapon(dart3);
				wpn.AddWeapon(dart4);
				wpn.AddWeapon(dart5);

				foreach (var weapon in wpn.weapons)
				{
					if (weapon.name == "Dart1")
					{
						weapon.ejectX = 10;
					}
					if (weapon.name == "Dart2")
					{
						weapon.ejectX = 5;
					}
					if (weapon.name == "Dart3")
					{
						weapon.ejectX = 0;
					}
					if (weapon.name == "Dart4")
					{
						weapon.ejectX = -5;
					}
					if (weapon.name == "Dart5")
					{
						weapon.ejectX = -10;
					}
				}

				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);

				var torpedo = Game.instance.model.GetTower(TowerType.BombShooter, 2).GetAttackModel().Duplicate();
				torpedo.weapons[0].projectile.display = Game.instance.model.GetTower(TowerType.BombShooter, 0, 2).GetWeapon().projectile.display;
				torpedo.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2.5f;
				torpedo.weapons[0].rate = towerModel.GetAttackModel().weapons[0].rate * 1.2f;
				torpedo.weapons[0].projectile.scale /= 1.65f;
				torpedo.range = tower.towerModel.range;
				torpedo.weapons[0].emission = new RandomArcEmissionModel("Torpedo Spread", 16, 0, 0, 135, 0, null);
				torpedo.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 14;
				torpedo.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				torpedo.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.hasDamageModifiers = true;
				torpedo.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 24, false, false) { name = "MoabModifier_" });
				towerModel.AddBehavior(torpedo);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SidewinderAce : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.SkyShredderUpgradeIcon;
			public override string WeaponName => "Sidewinder Ace";
			public override Sprite CustomIcon => GetSprite("SidewinderAceIcon");
			public override string Description => "Monkey Ace 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTower(TowerType.MonkeyBuccaneer, 5).GetAttackModel(1).Duplicate();
				var plane = wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower;
				var gatling = Game.instance.model.GetTower(TowerType.HeliPilot, 4).GetAttackModel().weapons[2].Duplicate();

				plane.GetBehavior<TowerExpireOnParentUpgradedModel>().parentTowerUpgradeTier = 0;
				plane.GetAttackModel(1).weapons[0].rate = Game.instance.model.GetTower(TowerType.MonkeyAce, 2).GetAttackModel().weapons[0].rate;
				plane.GetAttackModel(1).weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				plane.GetAttackModel(0).weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

				plane.GetAttackModel(0).weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 3, 2, false, false) { name = "MoabModifier_" });

				plane.GetDescendant<FighterMovementModel>().maxSpeed *= 2f;
				plane.RemoveBehavior(plane.GetAttackModel(2));

				gatling.name = "GatlingGun";
				gatling.projectile.GetBehavior<TravelStraitModel>().Lifespan /= 2;
				gatling.projectile.pierce = 4;
				gatling.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				gatling.projectile.GetDamageModel().damage = 6;
				gatling.projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 4, 0, false, false) { name = "MoabModifier_" });

				plane.GetAttackModel(1).AddWeapon(gatling);
				wpn.weapons[0].GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 2;

				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class RollingThunder : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.BombBlitzUpgradeIcon;
			public override string WeaponName => "Rolling Thunder";
			public override Sprite CustomIcon => GetSprite("RollingThunderIcon");
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
				var thunderExplosion = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.Duplicate();
				var thunderEffect = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.Duplicate();
				var rollingEffect = effect.Duplicate();
				bombEffect.scale /= 2;
				effect.effectModel = bombEffect;
				rollingEffect.effectModel = thunderEffect;

				explosion.radius /= 2;
				explosion.pierce = 32;
				explosion.GetDamageModel().damage = 8;
				explosion.GetDamageModel().immuneBloonProperties = BloonProperties.None;

				thunderExplosion.radius += 4;
				thunderExplosion.pierce = 16;
				thunderExplosion.GetDamageModel().damage = 5;
				thunderExplosion.GetDamageModel().immuneBloonProperties = BloonProperties.None;

				bomb.pierce = 9999;
				bomb.GetDamageModel().damage = 0;
				bomb.GetBehavior<TravelStraitModel>().Speed /= 1.75f;
				bomb.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				bomb.display = Game.instance.model.GetTower(TowerType.DartlingGunner, 5).GetAttackModel().weapons[0].projectile.display;

				var thunderBomb = bomb.Duplicate();

				bomb.AddBehavior(new CreateProjectileOnExpireModel("ThunderExplosion", thunderBomb, new ArcEmissionModel("", 5, 0, 360, null, true, false), false));
				bomb.AddBehavior(new CreateProjectileOnExpireModel("ExpireExplosion", explosion, new ArcEmissionModel("", 1, 0, 0, null, true, false), false));
				thunderBomb.AddBehavior(new CreateProjectileOnExpireModel("ThunderBombs", explosion, new ArcEmissionModel("", 1, 0, 0, null, true, false), false));

				bomb.AddBehavior(effect);
				bomb.AddBehavior(sound);
				thunderBomb.AddBehavior(rollingEffect);
				thunderBomb.AddBehavior(sound);

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
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().damage += 6;
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExhaustFractionModel("CarpetBomb-1", bomb, new ArcEmissionModel("", 8, 0, 360, null, true, false), mortar.fraction, mortar.durationfraction, true, false, true));
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExhaustFractionModel("CarpetBomb-2", bomb2, new ArcEmissionModel("", 8, 0, 360, null, true, false), mortar.fraction, mortar.durationfraction, true, false, true));
				wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnExhaustFractionModel("CarpetBomb-3", bomb3, new ArcEmissionModel("", 8, 0, 360, null, true, false), mortar.fraction, mortar.durationfraction, true, false, true));
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SorcererSupreme : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.ArcaneBlastUpgradeIcon;
			public override string WeaponName => "Sorcerer Supreme";
			public override Sprite CustomIcon => GetSprite("SorcererSupremeIcon");
			public override string Description => "Wizard 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-002").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.weapons[0].rate /= 4.68f;
				wpn.weapons[0].projectile.pierce += 4;
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				wpn.weapons[0].projectile.GetDamageModel().damage += 5;
				wpn.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0, 65, null, false, false);
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class DemonBlade : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.InfernoRingUpgradeIcon;
			public override string WeaponName => "Demon Blade";
			public override Sprite CustomIcon => GetSprite("DemonBladeIcon");
			public override string Description => "Ninja 4th path by LynxC";
			public override bool IsCamo => true;
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
				wpn.weapons[0].projectile.GetDamageModel().damage = 8;
				wpn.weapons[0].projectile.scale *= 2;
				wpn.weapons[0].projectile.pierce = 6;
				wpn.weapons[0].rate = Game.instance.model.GetTowerFromId("NinjaMonkey-200").GetAttackModel().weapons[0].rate * 1.3f;
				wpn.weapons[0].projectile.ApplyDisplay<DemonBladeProj>();
				wpn.weapons[0].projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 125, false, false) { name = "MoabModifier_" });
				wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

				var blades = Game.instance.model.GetTower(TowerType.DartMonkey, 0, 0, 2).GetAttackModel().weapons[0].Duplicate();
				blades.rate = wpn.weapons[0].rate;

				blades.projectile.hasDamageModifiers = true;
				blades.projectile.GetDamageModel().damage = 8;
				blades.projectile.pierce = 6;
				blades.projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 32, false, false) { name = "MoabModifier_" });
				blades.projectile.ApplyDisplay<Katana>();
				blades.projectile.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				blades.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				blades.emission = new ArcEmissionModel("aaa", 2, 0, 60, null, false, false);

				wpn.AddWeapon(blades);
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class SuperAcid : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.BloonLiquefierUpgradeIcon;
			public override string WeaponName => "Super Acid";
			public override Sprite CustomIcon => GetSprite("SuperAcidIcon");
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
				wpn.weapons[0].rate /= 7.5f;
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().damage += 1;
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damage += 9;
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval -= 1f;
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.hasDamageModifiers = true;
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 18, false, false) { name = "MoabModifier_" });
				wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("aaa", "Acid_Bonus_Damage", 4f, 5, 999, true, false, false, "bleed"));
				wpn.range = tower.towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class OmegaBeacon : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.BallLightningUpgradeIcon;
			public override string WeaponName => "Omega Beacon";
			public override Sprite CustomIcon => GetSprite("OmegaBeaconIcon");
			public override string Description => "Village 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var wpn = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				wpn.RemoveBehavior<RotateToTargetModel>();
				wpn.RemoveWeapon(wpn.weapons[0]);
				wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
				wpn.weapons[0].rate /= 3;
				wpn.weapons[0].projectile.GetDamageModel().damage += 10;
				wpn.weapons[0].projectile.pierce += 4;
				wpn.weapons[0].projectile.AddBehavior(new FreezeModel("FreezeModel_", 0, 1f, "BeaconStun", 999, "Stun", true, new GrowBlockModel("GrowBlockModel_"), null, 0.5f, true, true));
				wpn.weapons[0].projectile.collisionPasses = new int[] { 0, -1 };
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);
			}
		}
		public class Overcharge : WeaponTemplate
		{
			public override int SandboxIndex => 4;
			public override Rarity WeaponRarity => Rarity.Legendary;
			public override string Icon => VanillaSprites.HeartofThunderUpgradeIcon;
			public override string WeaponName => "Overcharge";
			public override Sprite CustomIcon => GetSprite("OverchargeIcon");
			public override string Description => "Engineer 4th path by LynxC";
			public override bool IsLead => true;
			public override void EditTower(Tower tower)
			{
				var ballLightning = Game.instance.model.GetTower(TowerType.Druid, 4).GetAttackModel().weapons[1].Duplicate();

				var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel(1).Duplicate();
				var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
				var sentry = wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower;
				ballLightning.rate = 2.5f;

				sentry.GetAttackModel().weapons[0] = ballLightning;
				wpn.range = towerModel.range;
				towerModel.AddBehavior(wpn);
				tower.UpdateRootModel(towerModel);

				var drones = Game.instance.model.GetTower(TowerType.Etienne).GetBehavior<DroneSupportModel>().Duplicate();
				drones.count = 4;

				var droneAttackModel = drones.droneModel.GetAttackModel();
				droneAttackModel.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-300").GetAttackModel().weapons[0].projectile.display;
				droneAttackModel.range = towerModel.range;
				droneAttackModel.weapons[0].projectile.pierce = 12;
				droneAttackModel.weapons[0].projectile.GetDamageModel().damage = 5;
				droneAttackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
				droneAttackModel.weapons[0].rate /= 2.8f;

				towerModel.AddBehavior(wpn);
				towerModel.AddBehavior(drones);
				tower.UpdateRootModel(towerModel);
			}
		}
		public static List<string> LegendaryWpn = new List<string>();
		public static List<string> LegendaryImg = new List<string>();
		public static List<Sprite> LegendaryCustomImg = new List<Sprite>();
	}
}
