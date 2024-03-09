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
        public class GlaiveLord : WeaponTemplate
        {
            public override int SandboxIndex => 4;
            public override Rarity WeaponRarity => Rarity.Legendary;
            public override string Icon => VanillaSprites.GlaiveLordUpgradeIcon;
            public override string WeaponName => "Glaive lord";
            public override bool IsCamo => true;
            public override bool IsLead => true;
            public override void EditTower(Tower tower)
            {
                var orbit = Game.instance.model.GetTowerFromId("BoomerangMonkey-520").GetBehavior<OrbitModel>().Duplicate();
                var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-520").GetAttackModel().Duplicate();
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                towerModel.AddBehavior(orbit);
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
        public static List<string> LegendaryWpn = new List<string>();
        public static List<string> LegendaryImg = new List<string>();
    }
}
