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
using Il2CppSystem;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Mutators;
using Il2CppAssets.Scripts.Models.GenericBehaviors;

namespace AncientMonkey.Weapons
{
    public class MIB : AbilityTemplate
    {
        public override string AbilityName => "MIB";
        public override string Icon => VanillaSprites.MonkeyIntelligenceBureauUpgradeIcon;
        public override void EditTower(Tower tower)
        {
        }
    }
    public class SummoningPhoenix : AbilityTemplate
    {
        public override string AbilityName => "Summoning Phoenix";
        public override string Icon => VanillaSprites.SummonPhoenixUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("WizardMonkey-042").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class Teleportation : AbilityTemplate
    {
        public override string AbilityName => "Teleportation";
        public override string Icon => VanillaSprites.DarkKnightUpgradeIconAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("SuperMonkey-004").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class BladeMaelstrom : AbilityTemplate
    {
        public override string AbilityName => "Blade Maelstrom";
        public override string Icon => VanillaSprites.BladeMaelstromUpgradeIconAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("TackShooter-040").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class TechTerror : AbilityTemplate
    {
        public override string AbilityName => "Tech Terror";
        public override string Icon => VanillaSprites.TechTerrorUpgradeIconAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("SuperMonkey-040").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class SpikeStorm : AbilityTemplate
    {
        public override string AbilityName => "Spike Storm";
        public override string Icon => VanillaSprites.SpikeStormUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("SpikeFactory-040").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class Overclock : AbilityTemplate
    {
        public override string AbilityName => "Overclock";
        public override string Icon => VanillaSprites.OverclockUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-040").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class FirstStrikeCapability : AbilityTemplate
    {
        public override string AbilityName => "First Strike Capability";
        public override string Icon => VanillaSprites.FirstStrikeCapabilityUpgradeIconAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("MonkeySub-040").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class EliteSniper : AbilityTemplate
    {
        public override string AbilityName => "Elite Sniper";
        public override string Icon => VanillaSprites.EliteSniperUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("SniperMonkey-050").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class SnowStorm : AbilityTemplate
    {
        public override string AbilityName => "Snow Storm";
        public override string Icon => VanillaSprites.SnowstormUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("IceMonkey-040").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class CarpetOfSpike : AbilityTemplate
    {
        public override string AbilityName => "Carpet Of Spike";
        public override string Icon => VanillaSprites.CarpetOfSpikesUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("SpikeFactory-250").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class MoabEliminator : AbilityTemplate
    {
        public override string AbilityName => "Moab Eliminator";
        public override string Icon => VanillaSprites.MoabEliminatorUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("BombShooter-050").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class MonkeyNomics : AbilityTemplate
    {
        public override string AbilityName => "Monkey Nomics";
        public override string Icon => VanillaSprites.MonkeyNomicsUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("BananaFarm-050").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class PermaPhoenix : AbilityTemplate
    {
        public override string AbilityName => "Perma Phoenix";
        public override string Icon => VanillaSprites.WizardLordPhoenixUpgradeIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
            towerModel.AddBehavior(phoenix);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class FireStorm : AbilityTemplate
    {
        public override string AbilityName => "Fire Storm";
        public override string Icon => VanillaSprites.FirestormAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAbility(1).Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class MOABHex : AbilityTemplate
    {
        public override string AbilityName => "MOAB Hex";
        public override string Icon => VanillaSprites.MoabHexAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Ezili 20").GetAbility(2).Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class BallOfLight : AbilityTemplate
    {
        public override string AbilityName => "Ball Of Light";
        public override string Icon => VanillaSprites.BallofLightAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Adora 20").GetAbility(2).Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class PermaUCAV : AbilityTemplate
    {
        public override string AbilityName => "Perma UCAV";
        public override string Icon => VanillaSprites.UcavAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
            phoenix.towerModel = Game.instance.model.GetTowerFromId("UCAVPerma").Duplicate();
            towerModel.AddBehavior(phoenix);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class PsionicScream : AbilityTemplate
    {
        public override string AbilityName => "Psionic Scream";
        public override string Icon => VanillaSprites.PsionicScreamAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Psi 20").GetAbility(1).Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class MOABBarrage : AbilityTemplate
    {
        public override string AbilityName => "MOAB Barrage";
        public override string Icon => VanillaSprites.MOABBarrageAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("CaptainChurchill 20").GetAbility(1).Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class BenjaminEndOfRoundCash : AbilityTemplate
    {
        public override string AbilityName => "Ben End Round Cash";
        public override string Icon => VanillaSprites.BenjaminIcon;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Benjamin 20").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class AbilityClass
    {
        public static List<string> AbilityName = new List<string>();
        public static List<string> AbilityImg = new List<string>();
    }
}
