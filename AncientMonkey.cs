using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using Random = System.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
	[HarmonyPatch(typeof(Il2CppAssets.Scripts.Simulation.SimulationBehaviors.NecroData), nameof(NecroData.RbePool))]
	internal static class Necro_RbePool
	{
		[HarmonyPrefix]
		private static bool Postfix(NecroData __instance, ref int __result)
		{
			var tower = __instance.tower;
			if (tower.towerModel.name.Contains("Ancient"))
			{

				__result = 9999;

			}
			return false;
		}
	}
}
