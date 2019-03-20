using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition.Patches
{

    [HarmonyPatch(typeof(ThingWithComps), "SpawnSetup")]
    internal static class ThingWithComps_AddMissingIngredients
    {
        static void Postfix(ThingWithComps __instance)
        {
            CompIngredients ingredients = __instance.GetComp<CompIngredients>();
            if (ingredients == null || !__instance.def.IsIngestible)
                return;
            if (ingredients.ingredients.Count == 0)
            {
                ingredients.ingredients.Add(ThingCategoryDef.Named("FoodRaw").DescendantThingDefs.RandomElementByWeight(x => x.thingCategories.Contains(ThingCategoryDefOf.PlantFoodRaw) ? 1f : 0.5f));
            }
        }
    }
}
