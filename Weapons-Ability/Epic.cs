using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.SimulationBehaviors;

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
                var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-004").GetBehavior<BonusCashPerRoundModel>().Duplicate();
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                towerModel.AddBehavior(wpn);
                tower.UpdateRootModel(towerModel);
            }
        }
        public static List<string> EpicWpn = new List<string>();
        public static List<string> EpicImg = new List<string>();
    }
}
