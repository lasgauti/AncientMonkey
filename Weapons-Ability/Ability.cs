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
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppSystem.IO;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using HarmonyLib;

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

    //public class AncientMonkey_GLAoL : 
    /*public class GLAoL : AbilityTemplate
    {
        public override string AbilityName => "Group Long Arm of Light";
        public override string Icon => VanillaSprites.TheLongArmofLightAA;
        public override string Description => "Custom Ability by Derpy-Jacob-903, Affects Heros";
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Adora 20").GetAbility(0).Duplicate();
            var ab2 = Game.instance.model.GetTowerFromId("AdmiralBrickell 20").GetAbility(0).Duplicate();
            //var ActivateRangeSupportZoneModel = new ActivatePierceSupportZoneModel("", "AncientMonkey_GLAoL", true, 3, 0, 9999, 999, false, 12,  ab.GetDescendant<LongArmOfLightModel>()., "AncientMonkey_GLAoL", new Il2CppReferenceArray<TowerFilterModel>([]));
            ab2.RemoveBehavior<ActivateRateSupportZoneModel>();
            ab2.GetBehavior<ActivatePierceSupportZoneModel>().pierceIncrease = 25;
            ab2.GetBehavior<ActivatePierceSupportZoneModel>().
            var ActivateRangeSupportZoneModel = new ActivateRangeSupportZoneModel("", "AncientMonkey_GLAoL", true, 3, 0, 9999, 999, false, 12, new Il2CppReferenceArray<TowerFilterModel>([]));
            var fillterModels = ActivateRangeSupportZoneModel.filters.ToList();
            fillterModels.Clear();
            fillterModels.Add(new FilterInBaseTowerIdModel("Sally_FilterInBaseTowerIdModel", new Il2CppStringArray(["TackShooter"])));
            //fillterModels.Add(new FilterInBaseTowerIdModel("Sally_FilterInBaseTowerIdModel", new Il2CppStringArray(["TackShooter"])));
            //abilityBrickell.filters = fillterModels.ToIl2CppReferenceArray();
            //ab.AddBehavior(abilityBrickell);


            //
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }*/
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
    public class Benzili : AbilityTemplate
    {
        public override string AbilityName => "Sacrificial Totem + Cyber Security";
        public override string Icon => VanillaSprites.SacrificialTotemAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Ezili 16").GetAbility(1).Duplicate();
            var ab2 = Game.instance.model.GetTowerFromId("Benjamin 4").GetBehavior<BonusLivesPerRoundModel>().Duplicate();
            towerModel.AddBehavior(ab);
            towerModel.AddBehavior(ab2);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class ArtilleryCommand : AbilityTemplate
    {
        public override string AbilityName => "Artillery Command + Black Bloon debuff";
        public override string Icon => VanillaSprites.ArtilleryCommandAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            if (towerModel.GetBehavior<AddBehaviorToBloonInZoneModel>() == null)
            {
                var ab2 = Game.instance.model.GetTowerFromId("StrikerJones 20").GetBehavior<AddBehaviorToBloonInZoneModel>().Duplicate();
                towerModel.AddBehavior(ab2);
            }
            var ab = Game.instance.model.GetTowerFromId("StrikerJones 20").GetAbility(2).Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class StormOfArrows : AbilityTemplate
    {
        public override string AbilityName => "Double Storm";
        public override string Icon => "DualStormIcon";
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Quincy 20").GetAbility(1).Duplicate();
            var wpn = ab.GetDescendant<ActivateAttackModel>().Duplicate();
            var projectile = ab.GetDescendant<CreateProjectileOnExhaustFractionModel>().projectile;
            projectile.GetBehavior<DamageModel>().damage *= 2;
            projectile.GetBehavior<DamageModel>().immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
            projectile.GetBehavior<AgeModel>().lifespan = projectile.GetBehavior<AgeModel>().Lifespan /= 2;
            projectile.GetBehavior<ClearHitBloonsModel>().interval /= 2;
            ab.AddBehavior(wpn);
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    public class Popseidon : AbilityTemplate
    {
        public override string AbilityName => "Popseidon";
        public override string Icon => VanillaSprites.Mermonkey050;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Mermonkey-050").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }
    /*public class RapidShot : AbilityTemplate
    {
        public override string AbilityName => "Group Rapid Shot";
        public override string Icon => VanillaSprites.RapidShotAA;
        public override void EditTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            var ab = Game.instance.model.GetTowerFromId("Mermonkey-050").GetAbility().Duplicate();
            towerModel.AddBehavior(ab);
            tower.UpdateRootModel(towerModel);
        }
    }*/
    public class BananaStockExchange : AbilityTemplate
    {
        public override string AbilityName => "Banana Stock Exchange";
        public override string Icon => VanillaSprites.ThriveIcon;
        public override Sprite CustomIcon => GetSprite("BananaStockExchangeIcon");
        public override string Description => "Custom Ability by LynxC";
        public override void EditTower(Tower tower)
        {
            foreach (var ability in ModContent.GetContent<AbilityTemplate>().OrderByDescending(c => c.mod == mod))
            {
                if (ability.Name == "BananaStockExchange")
                {
                    if (ability.stackIndex > 1)
                    {
                        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

                        if (towerModel.HasBehavior<TowerCreateTowerModel>())
                        {
                            foreach (var towercreate in towerModel.GetBehaviors<TowerCreateTowerModel>().ToArray())
                            {
                                if (towercreate.towerModel.HasBehavior<AirUnitModel>())
                                {
                                    foreach (var attackModel in towercreate.towerModel.GetBehavior<AirUnitModel>().GetBehaviors<AttackAirUnitModel>().ToArray())
                                    {
                                        if (towerModel.GetBehavior<TowerCreateTowerModel>().towerModel.HasBehavior<AirUnitModel>())
                                        {
                                            if (attackModel.weapons[0].projectile.HasBehavior<CashModel>())
                                            {
                                                towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<CashModel>().minimum *= 1.5f;
                                                towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<CashModel>().maximum *= 1.5f;
                                            }
                                        }
                                    }
                                    foreach (var attackModel in towercreate.towerModel.GetBehavior<AirUnitModel>().GetBehaviors<AttackModel>().ToArray())
                                    {
                                        if (attackModel.weapons[0].projectile.HasBehavior<CashModel>())
                                        {
                                            towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<CashModel>().minimum *= 1.5f;
                                            towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<CashModel>().maximum *= 1.5f;
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var attackModel in towerModel.GetDescendants<AttackModel>().ToArray())
                        {
                            if (!attackModel.weapons[0].projectile.HasBehavior<SlowModel>())
                            {
                                if (attackModel.weapons[0].projectile.HasBehavior<CashModel>())
                                {
                                    towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<CashModel>().minimum *= 1.5f;
                                    towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<CashModel>().maximum *= 1.5f;
                                }
                            }
                        }
                        foreach (var cashModel in towerModel.GetDescendants<PerRoundCashBonusTowerModel>().ToArray())
                        {
                            cashModel.cashPerRound *= 1.5f;
                        }

                        tower.UpdateRootModel(towerModel);
                    }
                    else
                    {
                        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                        var cash = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 0, 5).GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
                        cash.cashPerRound = 1000;

                        towerModel.AddBehavior(cash);
                        tower.UpdateRootModel(towerModel);
                    }
                }
            }
        }
    }
    public class AbilityClass
    {
        public static List<string> AbilityName = new List<string>();
        public static List<string> AbilityImg = new List<string>();
        public static List<Sprite> AbilityCustomImg = new List<Sprite>();
    }
}
