using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace AncientMonkey.Weapons
{
    /// <summary>
    /// Builds FreezeModels by cloning the base Ice Monkey's freeze instead of calling
    /// the FreezeModel constructor directly. The constructor's parameter list changes
    /// between BTD6 versions; cloning + setting the stable <c>lifespan</c> field does not.
    /// </summary>
    public static class FreezeHelper
    {
        public static FreezeModel Freeze(float lifespan, string name = "FreezeModel_")
        {
            var freeze = Game.instance.model
                .GetTower(TowerType.IceMonkey, 0, 0, 0)
                .GetAttackModel().weapons[0].projectile
                .GetBehavior<FreezeModel>()
                .Duplicate();
            freeze.name = name;
            freeze.lifespan = lifespan;
            return freeze;
        }
    }
}