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
    [HarmonyPatch(typeof(ThingWithComps), "PostIngested")]
    internal static class ThingWithComps_AddToNeeds
    {
        static void Postfix(ThingWithComps __instance, Pawn ingester)
        {
            if (ingester.needs.GetFoodGroups() == null)
                return;
            var ingredients = __instance.GetComp<CompIngredients>();
            if (ingredients != null)
            {
                var foodGroups = ingredients.ingredients.Select(ingredient => ingredient.GetCompProperties<CompProperties_FoodGroup>()).Where(x => x != null).Select(foodGroup => foodGroup.foodGroup);
                foreach (var foodGroup in foodGroups)
                {
                    ingester.needs.GetByFoodGroup(foodGroup).CurLevel += __instance.def.ingestible.CachedNutrition / foodGroups.Count();
                }
            }
        }
    }
}
