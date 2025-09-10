using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AncientMonkey.UI;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using UnityEngine.UIElements;

namespace AncientMonkey.Helper {
    public static class Actions {
        public static void ExtraLuckAction(AncientMonkey mod, InGame game, ModHelperPanel panel, Tower tower, BarSmoothing barSmoothing, TextButtonOption textButton, TextSmoothing textSmoothing) {

            if (game.GetCash() >= mod.ExtraLuckCost) {
                game.AddCash(mod.ExtraLuckCost * -1); 
                mod.ExtraLuckLevel += 1; 
                mod.ExtraLuckCost *= (float)Settings.settingsValue["ExtraLuckCostIncreaseMultiplier"];
                barSmoothing.SetTarget(mod.ExtraLuckLevel);
                textSmoothing.SetTarget(mod.ExtraLuckLevel * 5);
                textButton.Rebuild(mod.ExtraLuckLevel != mod.ExtraLuckMax, "Extra Luck : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.ExtraLuckCost)));
            }
        }
        public static void ExtraWeaponSlotAction(AncientMonkey mod, InGame game, ModHelperPanel panel, Tower tower, BarSmoothing barSmoothing, TextButtonOption textButton, TextSmoothing textSmoothing) {

            if (game.GetCash() >= mod.extraWeaponSlotCost) {
                game.AddCash(mod.extraWeaponSlotCost * -1);
                mod.extraWeaponSlotLevel += 1;
                mod.newWeaponSlot += 1;
                mod.extraWeaponSlotCost *= (float)Settings.settingsValue["ExtraWeaponSlotIncreaseMultiplier"];
                barSmoothing.SetTarget(mod.extraWeaponSlotLevel);
                textSmoothing.SetTarget(mod.extraWeaponSlotLevel);
                textButton.Rebuild(mod.extraWeaponSlotLevel != mod.extraWeaponSlotLevelMax, "Extra Weapon Slot : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.extraWeaponSlotCost)));
            }
        }
        public static void ExtraAbilitySlotAction(AncientMonkey mod, InGame game, ModHelperPanel panel, Tower tower, BarSmoothing barSmoothing, TextButtonOption textButton, TextSmoothing textSmoothing) {

            if (game.GetCash() >= mod.ExtraAbilitySlotCost) {
                game.AddCash(mod.ExtraAbilitySlotCost * -1);
                mod.ExtraAbilitySlotLevel += 1;
                mod.abilitySlot += 1;
                mod.ExtraAbilitySlotCost *= (float)Settings.settingsValue["ExtraAbilitySlotIncreaseMultiplier"];
                barSmoothing.SetTarget(mod.ExtraAbilitySlotLevel);
                textSmoothing.SetTarget(mod.ExtraAbilitySlotLevel);
                textButton.Rebuild(mod.ExtraAbilitySlotLevel != mod.ExtraAbilitySlotLevelMax, "Extra Ability Slot : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.ExtraAbilitySlotCost)));
            }
        }
        public static void ExtraStrongerWeaponSlotAction(AncientMonkey mod, InGame game, ModHelperPanel panel, Tower tower, BarSmoothing barSmoothing, TextButtonOption textButton, TextSmoothing textSmoothing) {

            if (game.GetCash() >= mod.strongExtraWeaponSlotCost) {
                game.AddCash(mod.strongExtraWeaponSlotCost * -1);
                mod.strongExtraWeaponSlotLevel += 1;
                mod.strongWeaponSlot += 1;
                mod.strongExtraWeaponSlotCost *= (float)Settings.settingsValue["ExtraStrongerSlotIncreaseMultiplier"];
                barSmoothing.SetTarget(mod.strongExtraWeaponSlotLevel);
                textSmoothing.SetTarget(mod.strongExtraWeaponSlotLevel);
                textButton.Rebuild(mod.strongExtraWeaponSlotLevel != mod.strongExtraWeaponSlotLevelMax, "Extra Ability Slot : $" + TextManager.ConvertNumberToText((int)Mathf.Round(mod.strongerWeaponCost)));
            }
        }
    }
}
