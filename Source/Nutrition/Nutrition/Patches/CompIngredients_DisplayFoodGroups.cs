using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition.Patches
{
    [HarmonyPatch(typeof(CompIngredients), "CompInspectStringExtra")]
    internal static class CompIngredients_DisplayFoodGroups
    {
        static void Postfix(CompIngredients __instance, ref string __result)
        {
            if (__instance.ingredients == null || __instance.ingredients.Count == 0)
                return;
            __result += "\n" + "Nutrition.FoodGroups".Translate() + ": ";
            __result += string.Join(", ", __instance.ingredients.Select(ingredient => ingredient.GetCompProperties<CompProperties_FoodGroup>()).Where(x => x != null).Select(foodGroup => foodGroup.foodGroup.ToString("G")).ToArray());
        }
    }
}
