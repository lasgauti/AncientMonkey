using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppSystem.IO;

namespace AncientMonkey.StrongerWeapons
{
    public class StatsBuff
    {
        public enum BuffTypes
        {
            Damage,
            AttackSpeed,
            Range,
            Pierce,
            Money,
            AbilityCooldown,
            ProjectileLifespan,
            ProjectileSpeed,
            DebuffDuration,
            DebuffDamage,
            MIB
        }
        public BuffTypes buffType;
        public string icon;
        public StatsBuff(BuffTypes buffType, string icon)
        {
            this.buffType = buffType;
            this.icon = icon;
        }
        public void ApplyBuff(TowerModel towerModel, float strength, Operations operation)
        {
            if(buffType == BuffTypes.Damage)
            {
                foreach (var item in towerModel.GetDescendants<DamageModel>().ToArray())
                {
                    if(operation == Operations.Multiply)
                    {
                        item.damage *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.damage /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.damage += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.damage -= strength;
                    }
                }  
                if(towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<DamageModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.damage *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.damage /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.damage += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.damage -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<DamageModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.damage *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.damage /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.damage += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.damage -= strength;
                            }
                        }
                    }
                }
                
            }
            if (buffType == BuffTypes.Range)
            {
                if (operation == Operations.Multiply)
                {
                    towerModel.range *= strength;
                }
                if (operation == Operations.Divide)
                {
                    towerModel.range /= strength;
                }
                if (operation == Operations.Add)
                {
                    towerModel.range += strength;
                }
                if (operation == Operations.Subtract)
                {
                    towerModel.range -= strength;
                }
                foreach (var item in towerModel.GetDescendants<AttackModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.range *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.range /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.range += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.range -= strength;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<AttackModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.range *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.range /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.range += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.range -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<AttackModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.range *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.range /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.range += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.range -= strength;
                            }
                        }
                    }
                }

            }
            if (buffType == BuffTypes.AttackSpeed)
            {
                foreach (var item in towerModel.GetDescendants<WeaponModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.rate *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.rate /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.rate += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.rate -= strength;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<WeaponModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.rate *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.rate /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.rate += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.rate -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<WeaponModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.rate *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.rate /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.rate += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.rate -= strength;
                            }
                        }
                    }
                }

            }
            if (buffType == BuffTypes.Pierce)
            {
                foreach (var item in towerModel.GetDescendants<ProjectileModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.pierce *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.pierce /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.pierce += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.pierce -= strength;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<ProjectileModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.pierce *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.pierce /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.pierce += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.pierce -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<ProjectileModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.pierce *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.pierce /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.pierce += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.pierce -= strength;
                            }
                        }
                    }
                }

            }
            if (buffType == BuffTypes.DebuffDuration)
            {
                foreach (var item in towerModel.GetDescendants<SlowModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.lifespan *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.lifespan /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.lifespan += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.lifespan -= strength;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<SlowModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<SlowModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;
                            }
                        }
                    }
                }
                foreach (var item in towerModel.GetDescendants<AddBehaviorToBloonModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.lifespan *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.lifespan /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.lifespan += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.lifespan -= strength;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<AddBehaviorToBloonModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<AddBehaviorToBloonModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;
                            }
                        }
                    }
                }
                foreach (var item in towerModel.GetDescendants<FreezeModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.lifespan *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.lifespan /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.lifespan += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.lifespan -= strength;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<FreezeModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<FreezeModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;
                            }
                        }
                    }
                }
            }
            if (buffType == BuffTypes.DebuffDamage)
            {
                foreach (var item in towerModel.GetDescendants<DamageOverTimeModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.damage *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.damage /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.damage += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.damage -= strength;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<DamageOverTimeModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.damage *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.damage /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.damage += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.damage -= strength;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<DamageOverTimeModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.damage *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.damage /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.damage += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.damage -= strength;
                            }
                        }
                    }
                }
            }
            if (buffType == BuffTypes.Money)
            {
                foreach (var item in towerModel.GetDescendants<CashModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.minimum *= strength;
                        item.maximum *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.minimum /= strength;
                        item.maximum /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.minimum += strength;
                        item.maximum += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.minimum -= strength;
                        item.maximum -= strength;
                    }
                }
            }
            if (buffType == BuffTypes.AbilityCooldown)
            {
                foreach (var item in towerModel.GetDescendants<AbilityModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.cooldown *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.cooldown /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.cooldown += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.cooldown -= strength;
                    }
                }
            }
            if (buffType == BuffTypes.ProjectileLifespan)
            {
                foreach (var item in towerModel.GetDescendants<TravelStraitModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.lifespan *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.lifespan /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.lifespan += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.lifespan -= strength;
                    }
                    if(item.lifespan >= 10)
                    {
                        item.lifespan = 10;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<TravelStraitModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;
                            }
                            if (item.lifespan >= 10)
                            {
                                item.lifespan = 10;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<TravelStraitModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.lifespan *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.lifespan /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.lifespan += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.lifespan -= strength;

                            }
                            if (item.lifespan >= 10)
                            {
                                item.lifespan = 10;
                            }
                        }
                    }
                }

            }
            if (buffType == BuffTypes.ProjectileSpeed)
            {
                foreach (var item in towerModel.GetDescendants<TravelStraitModel>().ToArray())
                {
                    if (operation == Operations.Multiply)
                    {
                        item.speed *= strength;
                    }
                    if (operation == Operations.Divide)
                    {
                        item.speed /= strength;
                    }
                    if (operation == Operations.Add)
                    {
                        item.speed += strength;
                    }
                    if (operation == Operations.Subtract)
                    {
                        item.speed -= strength;
                    }
                    if(item.speed >= 650)
                    {
                        item.speed = 650;
                    }
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.tower.GetDescendants<TravelStraitModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.speed *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.speed /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.speed += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.speed -= strength;
                            }
                            if (item.speed >= 650)
                            {
                                item.speed = 650;
                            }
                        }
                    }
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var item in createTowerModel.towerModel.GetDescendants<TravelStraitModel>().ToArray())
                        {
                            if (operation == Operations.Multiply)
                            {
                                item.speed *= strength;
                            }
                            if (operation == Operations.Divide)
                            {
                                item.speed /= strength;
                            }
                            if (operation == Operations.Add)
                            {
                                item.speed += strength;
                            }
                            if (operation == Operations.Subtract)
                            {
                                item.speed -= strength;
                            }
                            if (item.speed >= 650)
                            {
                                item.speed = 650;
                            }
                        }
                    }
                }

            }
            if (buffType == BuffTypes.MIB)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                foreach (var damageModel in towerModel.GetDescendants<DamageModel>().ToArray())
                {
                    damageModel.immuneBloonProperties = BloonProperties.None;
                }
                if (towerModel.HasDescendant<CreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<CreateTowerModel>().ToArray())
                    {
                        foreach (var damageModel in createTowerModel.tower.GetDescendants<DamageModel>().ToArray())
                        {
                            damageModel.immuneBloonProperties = BloonProperties.None;
                        }
                    } 
                }
                if (towerModel.HasDescendant<TowerCreateTowerModel>())
                {
                    foreach (var createTowerModel in towerModel.GetDescendants<TowerCreateTowerModel>().ToArray())
                    {
                        foreach (var damageModel in createTowerModel.towerModel.GetDescendants<DamageModel>().ToArray())
                        {
                            damageModel.immuneBloonProperties = BloonProperties.None;
                        }
                    }
                }
            }
        }
    }
}
