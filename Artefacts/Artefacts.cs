
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using UnityEngine;

namespace AncientMonkey.Artefacts
{
    public class Artefacts
    {
        public class HeavyProjectiles : ArtefactTemplate
        {
            public override string ArtefactName => "Heavy Projectile";
            public override string ArtefactDescription => "Projectiles have 2X damage and pierce but they move slower and attack 2X slower.";
            public override string Icon => VanillaSprites.HeavyBombsUpgradeIcon;
            public override void EditModel(Model model)
            {
                foreach(ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
                {
                    projectile.pierce *= 2;
                }
                foreach (DamageModel damageModel in model.GetDescendants<DamageModel>().ToList())
                {
                    damageModel.damage *= 2;
                }
                foreach (TravelStraitModel travelStraitModel in model.GetDescendants<TravelStraitModel>().ToList())
                {
                    travelStraitModel.speed /= 2;
                    travelStraitModel.speedFrames /= 2;
                }
                foreach (WeaponModel weapon in model.GetDescendants<WeaponModel>().ToList())
                {
                    weapon.rate *= 2;
                }
            }
        }
        public class TrackingEye : ArtefactTemplate
        {
            public override string ArtefactName => "Tracking Eye";
            public override string ArtefactDescription => "All projectile now seek their target and they last longer but shoot 25% slower.";
            public override string Icon => VanillaSprites.EnhancedEyesightUpgradeIcon;
            public override void EditModel(Model model)
            {
                foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
                {
                    if (projectile.GetBehavior<TrackTargetModel>() == null)
                    {
                        var track = new TrackTargetModel("target", 6000, true, false, 360, true, 120, false, false);
                        projectile.AddBehavior(track);
                    }
                }
                foreach (WeaponModel weapon in model.GetDescendants<WeaponModel>().ToList())
                {
                    weapon.rate *= 1.25f;
                }
                foreach (TravelStraitModel travelStraitModel in model.GetDescendants<TravelStraitModel>().ToList())
                {
                    travelStraitModel.lifespan *= 1.5f;
                    travelStraitModel.lifespanFrames = Mathf.RoundToInt(travelStraitModel.lifespanFrames * 1.5f);
                }
            }
        }
        public class FistFight : ArtefactTemplate
        {
            public override string ArtefactName => "Fist Fight";
            public override string ArtefactDescription => "Weapons have their range divided by 3 but increase damage, pierce and attack speed by 35%";
            public override string Icon => VanillaSprites.EpicRangeUpgradeIcon;
            public override void EditModel(Model model)
            {
                foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
                {
                    projectile.pierce *= 1.35f;
                }
                foreach (WeaponModel weapon in model.GetDescendants<WeaponModel>().ToList())
                {
                    weapon.rate /= 1.35f;
                }
                foreach (AttackModel attackModel in model.GetDescendants<AttackModel>().ToList())
                {
                    attackModel.range /= 3;
                }
                foreach (DamageModel damageModel in model.GetDescendants<DamageModel>().ToList())
                {
                    damageModel.damage *= 1.35f;
                }
                if (model is AttackModel attack)
                {
                    attack.range /= 3;
                }
            }
        }
        public class StrongButShort : ArtefactTemplate
        {
            public override string ArtefactName => "Strong But Short";
            public override string ArtefactDescription => "Bloons debuff duration is halved but their effect strength is doubled";
            public override string Icon => VanillaSprites.GlueSplatterUpgradeIcon;
            public override void EditModel(Model model)
            {
                foreach (AddBehaviorToBloonModel debuff in model.GetDescendants<AddBehaviorToBloonModel>().ToList())
                {
                    debuff.lifespanFrames /= 2;
                    debuff.lifespan /= 2;
                    foreach (DamageOverTimeModel dot in debuff.GetDescendants<DamageOverTimeModel>().ToList())
                    {
                        dot.damage *= 2;
                    }
                }
                foreach (SlowModel slow in model.GetDescendants<SlowModel>().ToList())
                {
                    slow.multiplier /= 2f;
                    slow.lifespan /= 2;
                    slow.lifespanFrames /= 2;
                }
            }
        }
        public class BouncingCastle : ArtefactTemplate
        {
            public override string ArtefactName => "Bouncing Castle";
            public override string ArtefactDescription => "Projectile now bounce everywhere but they have reduce lifespan.";
            public override string Icon => VanillaSprites.SpikeopultUpgradeIcon;
            public override void EditModel(Model model)
            {
                foreach (ProjectileModel projectile in model.GetDescendants<ProjectileModel>().ToList())
                {
                    if (projectile.GetBehavior<ProjectileBlockerCollisionReboundModel>() == null)
                    {
                        projectile.AddBehavior(new ProjectileBlockerCollisionReboundModel("bounce", true, true));
                    }
                    if (projectile.GetBehavior<MapBorderReboundModel>() == null)
                    {
                        projectile.AddBehavior(new MapBorderReboundModel("bounce", true));
                    }
                }
                foreach (TravelStraitModel travelStraitModel in model.GetDescendants<TravelStraitModel>().ToList())
                {
                    travelStraitModel.lifespan *= 0.8f;
                    travelStraitModel.lifespanFrames = Mathf.RoundToInt(travelStraitModel.lifespanFrames * 0.8f);
                }
            }
        }
    }
}
