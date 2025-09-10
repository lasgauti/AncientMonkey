using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AncientMonkey.Artefacts;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace AncientMonkey.StrongerWeapons
{
    public class Common : StrongerWeaponTemplate
    {
        public override WeaponTemplate.Rarity Rarity => WeaponTemplate.Rarity.Common;
        public override List<BuffKey> BuffKeys()
        {
            var list = new List<BuffKey>();
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Damage, VanillaSprites.MapBuffIconDamage), 1.03f, 1.05f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Pierce, VanillaSprites.MapBuffIconPierce), 1.04f, 1.07f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Range, VanillaSprites.MapBuffIconRange), 1.03f, 1.06f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AttackSpeed, VanillaSprites.MapBuffIconVillage2xx), 1.02f, 1.04f, Operations.Divide));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileLifespan, VanillaSprites.LongLifeSpikesUpgradeIcon), 1.03f, 1.05f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileSpeed, VanillaSprites.PrimaryTrainingUpgradeIcon), 1.02f, 1.05f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Money, VanillaSprites.BuffIconVillagexx4), 1.04f, 1.07f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDamage, VanillaSprites.BloonLiquefierUpgradeIcon), 1.04f, 1.07f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDuration, VanillaSprites.GlueHoseUpgradeIcon), 1.04f, 1.07f, Operations.Multiply));
            return list;
        }
        public override int BuffMaxCount => 4;
        public override int BuffMinCount => 2;
    }
    public class Rare : StrongerWeaponTemplate
    {
        public override WeaponTemplate.Rarity Rarity => WeaponTemplate.Rarity.Rare;
        public override List<BuffKey> BuffKeys()
        {
            var list = new List<BuffKey>();
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Damage, VanillaSprites.MapBuffIconDamage), 1.05f, 1.09f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Pierce, VanillaSprites.MapBuffIconPierce), 1.07f, 1.11f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Range, VanillaSprites.MapBuffIconRange), 1.05f, 1.09f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AttackSpeed, VanillaSprites.MapBuffIconVillage2xx), 1.04f, 1.07f, Operations.Divide));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileLifespan, VanillaSprites.LongLifeSpikesUpgradeIcon), 1.05f, 1.08f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileSpeed, VanillaSprites.PrimaryTrainingUpgradeIcon), 1.05f, 1.08f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Money, VanillaSprites.BuffIconVillagexx4), 1.06f, 1.10f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDamage, VanillaSprites.BloonLiquefierUpgradeIcon), 1.06f, 1.11f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDuration, VanillaSprites.GlueHoseUpgradeIcon), 1.06f, 1.1f, Operations.Multiply));
            return list;
        }
        public override int BuffMaxCount => 4;
        public override int BuffMinCount => 2;
    }
    public class Epic : StrongerWeaponTemplate
    {
        public override WeaponTemplate.Rarity Rarity => WeaponTemplate.Rarity.Epic;
        public override List<BuffKey> BuffKeys()
        {
            var list = new List<BuffKey>();
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Damage, VanillaSprites.MapBuffIconDamage), 1.07f, 1.12f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Pierce, VanillaSprites.MapBuffIconPierce), 1.1f, 1.14f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Range, VanillaSprites.MapBuffIconRange), 1.07f, 1.12f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AttackSpeed, VanillaSprites.MapBuffIconVillage2xx), 1.07f, 1.11f, Operations.Divide));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileLifespan, VanillaSprites.LongLifeSpikesUpgradeIcon), 1.07f, 1.12f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileSpeed, VanillaSprites.PrimaryTrainingUpgradeIcon), 1.07f, 1.12f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Money, VanillaSprites.BuffIconVillagexx4), 1.08f, 1.13f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDamage, VanillaSprites.BloonLiquefierUpgradeIcon), 1.08f, 1.14f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDuration, VanillaSprites.GlueHoseUpgradeIcon), 1.08f, 1.13f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.MIB, VanillaSprites.MonkeyIntelligenceBureauUpgradeIcon), 1f, 1f, Operations.Add));
            return list;
        }
        public override int BuffMaxCount => 4;
        public override int BuffMinCount => 3;
    }
    public class Legendary : StrongerWeaponTemplate
    {
        public override WeaponTemplate.Rarity Rarity => WeaponTemplate.Rarity.Legendary;
        public override List<BuffKey> BuffKeys()
        {
            var list = new List<BuffKey>();
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Damage, VanillaSprites.MapBuffIconDamage), 1.1f, 1.15f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Pierce, VanillaSprites.MapBuffIconPierce), 1.12f, 1.16f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Range, VanillaSprites.MapBuffIconRange), 1.1f, 1.15f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AttackSpeed, VanillaSprites.MapBuffIconVillage2xx), 1.09f, 1.14f, Operations.Divide));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileLifespan, VanillaSprites.LongLifeSpikesUpgradeIcon), 1.09f, 1.15f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileSpeed, VanillaSprites.PrimaryTrainingUpgradeIcon), 1.09f, 1.15f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Money, VanillaSprites.BuffIconVillagexx4), 1.1f, 1.15f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDamage, VanillaSprites.BloonLiquefierUpgradeIcon), 1.11f, 1.15f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDuration, VanillaSprites.GlueHoseUpgradeIcon), 1.11f, 1.15f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.MIB, VanillaSprites.MonkeyIntelligenceBureauUpgradeIcon), 1f, 1f, Operations.Add));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AbilityCooldown, VanillaSprites.HomelandDefenseUpgradeIcon), 1.03f, 1.05f, Operations.Divide));
            return list;
        }
        public override int BuffMaxCount => 5;
        public override int BuffMinCount => 3;
    }
    public class Exotic : StrongerWeaponTemplate
    {
        public override WeaponTemplate.Rarity Rarity => WeaponTemplate.Rarity.Exotic;
        public override List<BuffKey> BuffKeys()
        {
            var list = new List<BuffKey>();
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Damage, VanillaSprites.MapBuffIconDamage), 1.12f, 1.17f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Pierce, VanillaSprites.MapBuffIconPierce), 1.14f, 1.18f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Range, VanillaSprites.MapBuffIconRange), 1.12f, 1.17f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AttackSpeed, VanillaSprites.MapBuffIconVillage2xx), 1.11f, 1.16f, Operations.Divide));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileLifespan, VanillaSprites.LongLifeSpikesUpgradeIcon), 1.11f, 1.17f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileSpeed, VanillaSprites.PrimaryTrainingUpgradeIcon), 1.11f, 1.17f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Money, VanillaSprites.BuffIconVillagexx4), 1.12f, 1.16f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDamage, VanillaSprites.BloonLiquefierUpgradeIcon), 1.12f, 1.18f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDuration, VanillaSprites.GlueHoseUpgradeIcon), 1.13f, 1.17f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.MIB, VanillaSprites.MonkeyIntelligenceBureauUpgradeIcon), 1f, 1f, Operations.Add));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AbilityCooldown, VanillaSprites.HomelandDefenseUpgradeIcon), 1.05f, 1.07f, Operations.Divide));
            return list;
        }
        public override int BuffMaxCount => 5;
        public override int BuffMinCount => 4;
    }
    public class Godly : StrongerWeaponTemplate
    {
        public override WeaponTemplate.Rarity Rarity => WeaponTemplate.Rarity.Godly;
        public override List<BuffKey> BuffKeys()
        {
            var list = new List<BuffKey>();
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Damage, VanillaSprites.MapBuffIconDamage), 1.14f, 1.19f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Pierce, VanillaSprites.MapBuffIconPierce), 1.16f, 1.2f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Range, VanillaSprites.MapBuffIconRange), 1.14f, 1.2f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AttackSpeed, VanillaSprites.MapBuffIconVillage2xx), 1.13f, 1.18f, Operations.Divide));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileLifespan, VanillaSprites.LongLifeSpikesUpgradeIcon), 1.13f, 1.19f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileSpeed, VanillaSprites.PrimaryTrainingUpgradeIcon), 1.13f, 1.19f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Money, VanillaSprites.BuffIconVillagexx4), 1.14f, 1.18f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDamage, VanillaSprites.BloonLiquefierUpgradeIcon), 1.15f, 1.19f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDuration, VanillaSprites.GlueHoseUpgradeIcon), 1.15f, 1.18f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.MIB, VanillaSprites.MonkeyIntelligenceBureauUpgradeIcon), 1f, 1f, Operations.Add));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AbilityCooldown, VanillaSprites.HomelandDefenseUpgradeIcon), 1.07f, 1.1f, Operations.Divide));
            return list;
        }
        public override int BuffMaxCount => 6;
        public override int BuffMinCount => 4;
    }
    public class Omega : StrongerWeaponTemplate
    {
        public override WeaponTemplate.Rarity Rarity => WeaponTemplate.Rarity.Omega;
        public override List<BuffKey> BuffKeys()
        {
            var list = new List<BuffKey>();
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Damage, VanillaSprites.MapBuffIconDamage), 1.16f, 1.21f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Pierce, VanillaSprites.MapBuffIconPierce), 1.18f, 1.22f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Range, VanillaSprites.MapBuffIconRange), 1.16f, 1.22f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AttackSpeed, VanillaSprites.MapBuffIconVillage2xx), 1.15f, 1.2f, Operations.Divide));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileLifespan, VanillaSprites.LongLifeSpikesUpgradeIcon), 1.15f, 1.21f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.ProjectileSpeed, VanillaSprites.PrimaryTrainingUpgradeIcon), 1.15f, 1.21f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.Money, VanillaSprites.BuffIconVillagexx4), 1.16f, 1.21f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDamage, VanillaSprites.BloonLiquefierUpgradeIcon), 1.17f, 1.21f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.DebuffDuration, VanillaSprites.GlueHoseUpgradeIcon), 1.18f, 1.20f, Operations.Multiply));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.MIB, VanillaSprites.MonkeyIntelligenceBureauUpgradeIcon), 1f, 1f, Operations.Add));
            list.Add(new BuffKey(new StatsBuff(StatsBuff.BuffTypes.AbilityCooldown, VanillaSprites.HomelandDefenseUpgradeIcon), 1.09f, 1.11f, Operations.Divide));
            return list;
        }
        public override int BuffMaxCount => 6;
        public override int BuffMinCount => 5;
    }
}
