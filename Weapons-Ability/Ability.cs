using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Powers;
using Il2CppAssets.Scripts.Models.SimulationBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Mutators;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem;
using Il2CppSystem.IO;
using Octokit;
using UnityEngine;
using UnityEngine;

namespace AncientMonkey.Weapons
{
    public class SummoningPhoenix : AbilityTemplate
    {
        public override string AbilityName => "Summoning Phoenix";
        public override string Icon => VanillaSprites.SummonPhoenixUpgradeIcon;
        public override float StartingUpgradeCost => 35000;
        public override int MaxLevel => 1;
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("WizardMonkey-042").GetAbility().Duplicate();
            ab.name = "SummonPhoenix1";
            var newTemp = new SummoningPhoenix();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() {ab }));
            towerModel.AddBehavior(ab);
        }
        public override void Upgrade(List<Model> models, Tower tower)
        {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if(game == null) { return; }
            if (game.GetCash() < upgradeCost) {
                return;
            }
            if(upgradesCount == 0)
            {
                foreach (var model in models)
                {
                    if (model.name == "SummonPhoenix1")
                    {
                        if (model is AbilityModel summonPhoenixAbility)
                        {
                            foreach (var ability in towerModel.GetAbilities())
                            {
                                if (ability.name == "AbilityModel_" + summonPhoenixAbility.name)
                                {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("WizardMonkey-052").GetAbility().Duplicate();
                                    ab.name = "SummonPhoenix2";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
           
            tower.UpdateRootModel(towerModel);
        }
    }
    public class BladeMaelstrom : AbilityTemplate
    {
        public override string AbilityName => "Blade Maelstrom";
        public override string Icon => VanillaSprites.BladeMaelstromUpgradeIconAA;
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("TackShooter-040").GetAbility().Duplicate();
            ab.name = "BladeMaelstrom";
            var newTemp = new BladeMaelstrom();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
        public override float StartingUpgradeCost => 12000;
        public override int MaxLevel => 1;
        public override void Upgrade(List<Model> models, Tower tower)
        {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost)
            {
                return;
            }
            if (upgradesCount == 0)
            {
                foreach (var model in models)
                {
                    if (model.name == "BladeMaelstrom")
                    {
                        if (model is AbilityModel bladeMaelstromAbility)
                        {
                            foreach (var ability in towerModel.GetAbilities())
                            {
                                if (ability.name == "AbilityModel_" + bladeMaelstromAbility.name)
                                {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("TackShooter-050").GetAbility().Duplicate();
                                    ab.name = "SuperMaelstrom";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            tower.UpdateRootModel(towerModel);
        }
    }
    public class TechTerror : AbilityTemplate
    {
        public override string AbilityName => "Tech Terror";
        public override string Icon => VanillaSprites.TechTerrorUpgradeIconAA;
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("SuperMonkey-040").GetAbility().Duplicate();
            ab.name = "TechTerror";
            var newTemp = new TechTerror();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
        public override int MaxLevel => 1;
        public override float StartingUpgradeCost => 70000;
        public override void Upgrade(List<Model> models, Tower tower)
        {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost)
            {
                return;
            }
            if (upgradesCount == 0)
            {
                foreach (var model in models)
                {
                    if (model.name == "TechTerror")
                    {
                        if (model is AbilityModel techTerrorAbility)
                        {
                            foreach (var ability in towerModel.GetAbilities())
                            {
                                if (ability.name == "AbilityModel_" + techTerrorAbility.name)
                                {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("SuperMonkey-050").GetAbility().Duplicate();
                                    ab.name = "Anti-Bloon";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            tower.UpdateRootModel(towerModel);
        }
    }
    public class SupplyDrop : AbilityTemplate
    {
        public override string AbilityName => "Supply Drop";
        public override string Icon => VanillaSprites.CashDropUpgradeIcon;
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("SniperMonkey-040").GetAbility().Duplicate();
            ab.name = "SupplyDrop";
            var newTemp = new SupplyDrop();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
        public override int MaxLevel => 1;
        public override float StartingUpgradeCost => 10000;
        public override void Upgrade(List<Model> models, Tower tower)
        {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost)
            {
                return;
            }
            if (upgradesCount == 0)
            {
                foreach (var model in models)
                {
                    if (model.name == "SupplyDrop")
                    {
                        if (model is AbilityModel supplyDropAbility)
                        {
                            foreach (var ability in towerModel.GetAbilities())
                            {
                                if (ability.name == "AbilityModel_" + supplyDropAbility.name)
                                {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("SniperMonkey-050").GetAbility().Duplicate();
                                    ab.name = "EliteSniper";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            tower.UpdateRootModel(towerModel);
        }
    }
    public class SpikeStorm : AbilityTemplate
    {
        public override string AbilityName => "Spike Storm";
        public override string Icon => VanillaSprites.SpikeStormUpgradeIcon;
        public override int MaxLevel => 0;
        public override float StartingUpgradeCost => 100;
        public override void Upgrade(List<Model> models, Tower tower) {
          
        }
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("SpikeFactory-040").GetAbility().Duplicate();
            ab.name = "SpikeStorm";
            var newTemp = new SpikeStorm();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }

    }
    public class Overclock : AbilityTemplate
    {
        public override string AbilityName => "Overclock";
        public override string Icon => VanillaSprites.OverclockUpgradeIcon;
        public override int MaxLevel => 2;
        public override float StartingUpgradeCost => 65000;
        public override void Upgrade(List<Model> models, Tower tower) {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost) {
                return;
            }
            if (upgradesCount == 0) {
                foreach (var model in models) {
                    if (model.name == "Overclock") {
                        if (model is AbilityModel overclockAbility) {
                            foreach (var ability in towerModel.GetAbilities()) {
                                if (ability.name == "AbilityModel_" + overclockAbility.name) {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-050").GetAbility().Duplicate();
                                    ab.name = "Ultraboost";
                                    overclockAbility.name = "Ultraboost";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    upgradeCost = 150000;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            } else if (upgradesCount == 1) {
                foreach (var model in models) {
                    if (model.name == "Ultraboost") {
                        
                        if (model is AbilityModel ultraboostAbility) {
                            foreach (var ability in towerModel.GetAbilities()) {
                                if (ability.name == "AbilityModel_" + ultraboostAbility.name) {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAbility(1).Duplicate();
                                    ab.name = "Powerglove";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            tower.UpdateRootModel(towerModel);
        }
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-040").GetAbility().Duplicate();
            ab.name = "Overclock";
            var newTemp = new Overclock();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
    }
    public class FirstStrikeCapability : AbilityTemplate
    {
        public override string AbilityName => "First Strike Capability";
        public override string Icon => VanillaSprites.FirstStrikeCapabilityUpgradeIconAA;
        public override int MaxLevel => 1;
        public override float StartingUpgradeCost => 10000;
        public override void Upgrade(List<Model> models, Tower tower) {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost) {
                return;
            }
            if (upgradesCount == 0) {
                foreach (var model in models) {
                    if (model.name == "FirstStrikeCapability") {
                        if (model is AbilityModel fscAbility) {
                            foreach (var ability in towerModel.GetAbilities()) {
                                if (ability.name == "AbilityModel_" + fscAbility.name) {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("MonkeySub-050").GetAbility().Duplicate();
                                    ab.name = "PreEmptiveStrike";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            tower.UpdateRootModel(towerModel);
        }
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("MonkeySub-040").GetAbility().Duplicate();
            ab.name = "FirstStrikeCapability";
            var newTemp = new FirstStrikeCapability();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
    }
    public class SnowStorm : AbilityTemplate
    {
        public override string AbilityName => "Snow Storm";
        public override string Icon => VanillaSprites.SnowstormUpgradeIcon;
        public override float StartingUpgradeCost => 10000;
        public override int MaxLevel => 1;
        public override void Upgrade(List<Model> models, Tower tower) {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost) {
                return;
            }
            if (upgradesCount == 0) {
                foreach (var model in models) {
                    if (model.name == "SnowStorm") {
                        if (model is AbilityModel ssAbility) {
                            foreach (var ability in towerModel.GetAbilities()) {
                                if (ability.name == "AbilityModel_" + ssAbility.name) {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("IceMonkey-050").GetAbility().Duplicate();
                                    ab.name = "AbsoluteZero";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            tower.UpdateRootModel(towerModel);
        }
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("IceMonkey-040").GetAbility().Duplicate();
            ab.name = "SnowStorm";
            var newTemp = new SnowStorm();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
    }
    public class MOABAssassin : AbilityTemplate
    {
        public override string AbilityName => "MOAB Assassin";
        public override string Icon => VanillaSprites.MoabAssassinUpgradeIcon;
        public override int MaxLevel => 1;
        public override float StartingUpgradeCost => 20000;
        public override void Upgrade(List<Model> models, Tower tower) {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost) {
                return;
            }
            if (upgradesCount == 0) {
                foreach (var model in models) {
                    if (model.name == "MoabAssassin") {
                        if (model is AbilityModel maAbility) {
                            foreach (var ability in towerModel.GetAbilities()) {
                                if (ability.name == "AbilityModel_" + maAbility.name) {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("BombShooter-050").GetAbility().Duplicate();
                                    ab.name = "MoabEliminator";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            tower.UpdateRootModel(towerModel);
        }
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("BombShooter-040").GetAbility().Duplicate();
            ab.name = "MoabAssassin";
            var newTemp = new MOABAssassin();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
    }
    public class IMFLoan : AbilityTemplate
    {
        public override string AbilityName => "IMF Loan";
        public override string Icon => VanillaSprites.IMFLoanUpgradeIcon;
        public override float StartingUpgradeCost => 80000;
        public override int MaxLevel => 1;
        public override void Upgrade(List<Model> models, Tower tower) {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost) {
                return;
            }
            if (upgradesCount == 0) {
                foreach (var model in models) {
                    if (model.name == "IMFLoan") {
                        if (model is AbilityModel imflAbility) {
                            foreach (var ability in towerModel.GetAbilities()) {
                                if (ability.name == "AbilityModel_" + imflAbility.name) {
                                    towerModel.RemoveBehavior(ability);
                                    var ab = Game.instance.model.GetTowerFromId("BananaFarm-050").GetAbility().Duplicate();
                                    ab.name = "MonkeyNomics";
                                    towerModel.AddBehavior(ab);
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            tower.UpdateRootModel(towerModel);
        }
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("BananaFarm-040").GetAbility().Duplicate();
            ab.name = "IMFLoan";
            var newTemp = new IMFLoan();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
    }
    public class BenjaminEndOfRoundCash : AbilityTemplate
    {
        public override string AbilityName => "Ben End Round Cash";
        public override string Icon => VanillaSprites.BenjaminIcon;
        public override int MaxLevel => 4;
        public override void EditTower(TowerModel towerModel)
        {
            var ab = Game.instance.model.GetTowerFromId("Benjamin").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
            ab.name = "BenEndOfRoundCash";
            var newTemp = new BenjaminEndOfRoundCash();
            newTemp.upgradeCost = StartingUpgradeCost;
            AncientMonkey.mod.currentAbilities.Add(new KeyValuePair<AbilityTemplate, List<Model>>(newTemp, new List<Model>() { ab }));
            towerModel.AddBehavior(ab);
        }
        public override float StartingUpgradeCost => 2500;
        public override void Upgrade(List<Model> models, Tower tower)
        {
            var towerModel = tower.rootModel.Cast<TowerModel>().Duplicate();
            InGame game = InGame.instance;
            if (game == null) { return; }
            if (game.GetCash() < upgradeCost)
            {
                return;
            }
            foreach (var model in models)
            {
                if (model.name == "BenEndOfRoundCash")
                {
                    if (model is PerRoundCashBonusTowerModel roundCash)
                    {
                        foreach (var ability in towerModel.GetBehaviors<PerRoundCashBonusTowerModel>())
                        {
                            if (ability.name ==  roundCash.name)
                            {
                                if (upgradesCount == 0)
                                {
                                    ability.cashPerRound = 250;
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    upgradeCost = 8500;
                                    break;
                                }
                                if (upgradesCount == 1)
                                {
                                    ability.cashPerRound = 1000;
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    upgradeCost = 18000;
                                    break;
                                }
                                if (upgradesCount == 2)
                                {
                                    ability.cashPerRound = 2500;
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    upgradeCost = 30000;
                                    break;
                                }
                                if (upgradesCount == 3)
                                {
                                    ability.cashPerRound = 5000;
                                    upgradesCount++;
                                    game.AddCash(-upgradeCost);
                                    upgradeCost = 1000000;
                                    break;
                                }
                            }
                        }
                    }
                }


            }
            tower.UpdateRootModel(towerModel);
        }
    }
   
    public class AbilityClass
    {
        public static List<string> AbilityName = new List<string>();
        public static List<string> AbilityImg = new List<string>();
        public static List<Sprite> AbilityCustomImg = new List<Sprite>();
    }
}
