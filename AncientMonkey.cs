using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;

namespace blankdisplay
{
    public class BlankDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "NoneDisplay");
        }
    }
}
namespace AncientMonkey
{
    public class AncientMonkeyTower : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override string DisplayName => "Ancient Monkey";
        public override string Name => "AncientMonkey";
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0; 
        public override string Description => "The Ancient Monkey is very weak in the Beginning but you can make him stronger.";
        public override string Portrait => "AncientMonkeyIcon";
        public override string Icon => "AncientMonkeyIcon";
        public override bool IsValidCrosspath(int[] tiers) =>
   ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 0;
        }
    }
    [HarmonyPatch(typeof(NecroData), nameof(NecroData.RbePool))]
    internal static class Necro_RbePool
    {
        [HarmonyPrefix]
        private static bool Postfix(NecroData __instance, ref int __result)
        {
            var tower = __instance.tower;
            if (tower.towerModel.name.Contains("Ancient"))
            {
                
                __result = 9999;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
   
}
