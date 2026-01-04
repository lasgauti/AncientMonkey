using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AncientMonkey.Artifacts;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;

namespace AncientMonkey.Mutators
{
    public class PiercingStrike : MutatorTemplate
    {
        public override string MutatorName => "Piercing Strike";
        public override string MutatorDescription => "+25% Pierce";
        public override string Icon => VanillaSprites.MapBuffIconPierce;
        public override void EditModel(Model model)
        {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
            {
                projectile.pierce *= 1.25f;
            }
        }
    }
    public class SuperStrength : MutatorTemplate
    {
        public override string MutatorName => "Super Strength";
        public override string MutatorDescription => "+20% Damage";
        public override string Icon => VanillaSprites.MapBuffIconDamage;
        public override void EditModel(Model model)
        {
            foreach (DamageModel damageModel in model.GetDescendants<DamageModel>().ToList())
            {
                damageModel.damage *= 1.2f;
            }
        }
    }
    public class FastHand : MutatorTemplate
    {
        public override string MutatorName => "Fast Hand";
        public override string MutatorDescription => "-18% Attack Interval";
        public override string Icon => VanillaSprites.BuffIconVillage2xx;
        public override void EditModel(Model model)
        {
            foreach (WeaponModel weaponModel in model.GetDescendants<WeaponModel>().ToList())
            {
                weaponModel.rate /= 1.18f;
            }
        }
    }
    public class HotBreathing : MutatorTemplate
    {
        public override string MutatorName => "Hot Breathing";
        public override string MutatorDescription => "Bloons are set on fire";
        public override string Icon => VanillaSprites.DragonsBreathUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
            {
                var fire = Game.instance.model.GetTowerFromId("Alchemist").GetDescendant<AddBehaviorToBloonModel>().Duplicate();
                fire.GetBehavior<DamageOverTimeModel>().interval = 1f;
                fire.lifespan = 5;
                fire.lifespanFrames = 300;
                fire.GetBehavior<DamageOverTimeModel>().damage = 2;
                fire.overlayType = "Fire";

                projectile.AddBehavior(fire);
                projectile.collisionPasses = new int[] { -1, 0 };
            }
        }
    }
    public class Shiny : MutatorTemplate
    {
        public override string MutatorName => "Shiny";
        public override string MutatorDescription => "+25% Cash";
        public override string Icon => VanillaSprites.ValuableBananasUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (CashModel cash in model.GetDescendants<CashModel>().ToList())
            {
                cash.minimum *= 1.25f;
                cash.maximum *= 1.25f;
            }
        }
    }
    public class God : MutatorTemplate
    {
        public override string MutatorName => "God";
        public override string MutatorDescription => "+6% All Stats";
        public override string Icon => VanillaSprites.SunTempleUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (CashModel cash in model.GetDescendants<CashModel>().ToList())
            {
                cash.minimum *= 1.06f;
                cash.maximum *= 1.06f;
            }
            foreach (WeaponModel weaponModel in model.GetDescendants<WeaponModel>().ToList())
            {
                weaponModel.rate /= 1.06f;
            }
            foreach (DamageModel damageModel in model.GetDescendants<DamageModel>().ToList())
            {
                damageModel.damage *= 1.06f;
            }
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
            {
                projectile.pierce *= 1.06f;
            }
            if (model is AttackModel attack)
            {
                attack.range *= 1.06f;
            }
            foreach (TravelStraitModel travel in model.GetDescendants<TravelStraitModel>().ToList())
            {
                travel.lifespan *= 1.06f;
                travel.speed *= 1.06f;
            }
            if(model is AttackModel attackModel)
            {
                attackModel.range *= 1.06f;
            }
        }
    }
    public class WindBreaker : MutatorTemplate
    {
        public override string MutatorName => "Wind Breaker";
        public override string MutatorDescription => "+15% projectile speed and +10% damage";
        public override string Icon => VanillaSprites.DruidoftheStormUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (DamageModel damageModel in model.GetDescendants<DamageModel>().ToList())
            {
                damageModel.damage *= 1.1f;
            }
            foreach (TravelStraitModel damageModel in model.GetDescendants<TravelStraitModel>().ToList())
            {
                damageModel.speed *= 1.15f;
            }

        }
    }
    public class DurableWeapons : MutatorTemplate
    {
        public override string MutatorName => "Durable Weapons";
        public override string MutatorDescription => "+18% projectile lifespan and +15% Pierce";
        public override string Icon => VanillaSprites.IntenseMagicUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
            {
                projectile.pierce *= 1.15f;
            }
            foreach (TravelStraitModel damageModel in model.GetDescendants<TravelStraitModel>().ToList())
            {
                damageModel.lifespan *= 1.18f;
            }

        }
    }
    public class DualWielding : MutatorTemplate
    {
        public override string MutatorName => "Dual Wielding";
        public override string MutatorDescription => "Shoot twice in a consecutive burst but +45% attack speed";
        public override string Icon => VanillaSprites.QuestIconDesperado;
        public override void EditModel(Model model)
        {

            foreach (WeaponModel weaponModel in model.GetDescendants<WeaponModel>().ToList())
            {
                if (!weaponModel.HasBehavior<BurstWeaponBehaviorModel>())
                {
                    weaponModel.AddBehavior(new BurstWeaponBehaviorModel("Burst", 0.08f, 2, false));
                }
                else
                {
                    weaponModel.GetBehavior<BurstWeaponBehaviorModel>().interval /= 1.5f;
                    weaponModel.GetBehavior<BurstWeaponBehaviorModel>().count += 2;
                }
                weaponModel.rate *= 1.45f;
            }
        }
    }
    public class HawkEye : MutatorTemplate
    {
        public override string MutatorName => "Hawk Eye";
        public override string MutatorDescription => "+25% Range";
        public override string Icon => VanillaSprites.EnhancedEyesightUpgradeIcon;
        public override void EditModel(Model model)
        {
            if (model is AttackModel attackModel)
            {
                attackModel.range *= 1.25f;
            }
        }
    }
    public class IntenseTargeting : MutatorTemplate
    {
        public override string MutatorName => "Intense Targeting";
        public override string MutatorDescription => "Weapons seek their targets";
        public override string Icon => VanillaSprites.NevaMissTargetingUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
            {
                if (projectile.GetBehavior<TrackTargetModel>() == null)
                {
                    var track = new TrackTargetModel("target", 6000, true, false, 360, true, 75, false, false, false);
                    projectile.AddBehavior(track);
                }
            }
        }
    }
    public class GlueStick : MutatorTemplate
    {
        public override string MutatorName => "Glue Stick";
        public override string MutatorDescription => "Debuffs last 50% longer";
        public override string Icon => VanillaSprites.StickierGlueUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (AddBehaviorToBloonModel debuff in model.GetDescendants<AddBehaviorToBloonModel>().ToList())
            {
                debuff.lifespan *= 1.5f;
            }
            foreach (SlowModel slow in model.GetDescendants<SlowModel>().ToList())
            {
                slow.lifespan *= 1.5f;
            }
            foreach (FreezeModel freeze in model.GetDescendants<FreezeModel>().ToList())
            {
                freeze.lifespan *= 1.5f;
            }
        }
    }
    public class Gasoline : MutatorTemplate
    {
        public override string MutatorName => "Gasoline";
        public override string MutatorDescription => "+35% debuffs strength";
        public override string Icon => VanillaSprites.FirestormAA;
        public override void EditModel(Model model)
        {
            foreach (AddBehaviorToBloonModel debuff in model.GetDescendants<AddBehaviorToBloonModel>().ToList())
            {
                foreach (DamageOverTimeModel dot in debuff.GetDescendants<DamageOverTimeModel>().ToList())
                {
                    dot.damage *= 1.35f;
                }
            }
            foreach (SlowModel slow in model.GetDescendants<SlowModel>().ToList())
            {
                slow.multiplier /= 1.35f;
            }
          
        }
    }
    public class WeakeningSubstance : MutatorTemplate
    {
        public override string MutatorName => "Weakening Substance";
        public override string MutatorDescription => "Bloons take +1 damage from all sources";
        public override string Icon => VanillaSprites.SuperBrittleUpgradeIcon;
        public override void EditModel(Model model)
        {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
            {
                if (projectile.GetBehavior<TrackTargetModel>() == null)
                {
                    var track = new AddBonusDamagePerHitToBloonModel("bonusDamage", "weakening substance", 10, 1, 360, true, false, false, null);
                    projectile.AddBehavior(track);
                }
            }

        }
    }
    public class ExplosiveRounds : MutatorTemplate {
        public override string MutatorName => "Explosive Rounds";
        public override string MutatorDescription => "Projecitles explode on contact";
        public override string Icon => VanillaSprites.HeavyBombsUpgradeIcon;
        public override void EditModel(Model model) {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList()) {
                var bomb = Game.instance.model.GetTower(TowerType.BombShooter);
                var bombProj = bomb.GetAttackModel().weapons[0].projectile;
                var explosion = bombProj.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
                var fx = bombProj.GetBehavior<CreateEffectOnContactModel>().Duplicate();
                var sfx = bombProj.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate();
                projectile.AddBehavior(explosion);
                projectile.AddBehavior(fx);
                projectile.AddBehavior(sfx);
            }

        }
    }
    public class FreezingTouch : MutatorTemplate {
        public override string MutatorName => "Freezing Touch";
        public override string MutatorDescription => "Projecitles freezes Bloons";
        public override string Icon => VanillaSprites.RefreezeUpgradeIcon;
        public override void EditModel(Model model) {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList()) {
                if (!projectile.HasBehavior<FreezeModel>()) {
                    projectile.AddBehavior(Game.instance.model.GetTower(TowerType.IceMonkey, 0, 0, 0).GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().Duplicate());
                } else {
                    projectile.GetBehavior<FreezeModel>().lifespan += 1;
                }
            }

        }
    }
    public class MultiHit : MutatorTemplate {
        public override string MutatorName => "Multi Hit";
        public override string MutatorDescription => "Projectile can re-hit Bloons";
        public override string Icon => VanillaSprites.RefreezeUpgradeIcon;
        public override void EditModel(Model model) {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList()) {
                if (!projectile.HasBehavior<ClearHitBloonsModel>()) {
                    projectile.AddBehavior(new ClearHitBloonsModel("clearhit", 1));
                }
            }

        }
    }
    public class StaticShock : MutatorTemplate {
        public override string MutatorName => "Static Shock";
        public override string MutatorDescription => "Projectiles damages nearby bloons with a lightning attack";
        public override string Icon => VanillaSprites.HeartofThunderUpgradeIcon;
        public override void EditModel(Model model) {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList()) {
                var lightning = Game.instance.model.GetTower(TowerType.Druid, 2).GetAttackModel().weapons[1].Duplicate();
                lightning.projectile.GetDamageModel().damage = 1;
                projectile.AddBehavior(new CreateProjectileOnIntervalModel("lightning", lightning.projectile, lightning.emission, 15, true, 50, TargetType.First, true, false, false, null));
            }

        }
    }
    public class Aura : MutatorTemplate {
        public override string MutatorName => "Aura";
        public override string MutatorDescription => "Projectiles deal damage to nearby Bloons.";
        public override string Icon => VanillaSprites.SunAvatarUpgradeIcon;
        public override void EditModel(Model model) {
            foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList()) {
                var aura = Game.instance.model.GetTower(TowerType.BombShooter).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
                aura.projectile.radius = 20;
                aura.projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
                projectile.AddBehavior(new CreateProjectileOnIntervalModel("aura", aura.projectile, aura.emission, 4, false, 0, TargetType.First, true, false, false, null));
            }

        }
    }
    public class SunBlessing : MutatorTemplate {
        public override string MutatorName => "Sun's Blessing";
        public override string MutatorDescription => "Every 5 shot, shoot a huge Sun ball that deals more damage.";
        public override string Icon => VanillaSprites.TrueSonGodUpgradeIcon;
        public override void EditModel(Model model) {
            foreach (WeaponModel weapon in model.GetDescendants<WeaponModel>().ToList()) {
                var sunProjectile = weapon.Duplicate();
                sunProjectile.projectile.display = new("dcd6cd8511c9a03458a32f42f860882c");
                if(sunProjectile.projectile.HasBehavior<DamageModel>()) {
                    sunProjectile.projectile.GetDamageModel().damage *= 3;
                }
                weapon.AddBehavior(new AlternateProjectileModel("alternateSunBlessing", sunProjectile.projectile, sunProjectile.emission, 5));
            }
        }
    }
}
