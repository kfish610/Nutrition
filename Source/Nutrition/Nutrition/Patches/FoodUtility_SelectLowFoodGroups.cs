using Harmony;
using Nutrition.Needs;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition.Patches
{
    [HarmonyPatch(typeof(FoodUtility), "FoodOptimality")]
    internal static class FoodUtility_SelectLowFoodGroups
    {
        static float Postfix(float __result, Pawn eater, Thing foodSource, ThingDef foodDef)
        {
            var lowOrMissingFoodGroupNeeds = eater.needs.GetFoodGroups().GetLowOrMissing();
            if (lowOrMissingFoodGroupNeeds == null)
            {
                return __result;
            }
            if ((foodSource != null && lowOrMissingFoodGroupNeeds.Any(x => x.GetFilter().Worker.Matches(foodSource))) || (foodDef != null && lowOrMissingFoodGroupNeeds.Any(x => x.GetFilter().Worker.AlwaysMatches(foodDef))))
            {
                return __result + 75;
            }
            return __result;
        }
    }
}
