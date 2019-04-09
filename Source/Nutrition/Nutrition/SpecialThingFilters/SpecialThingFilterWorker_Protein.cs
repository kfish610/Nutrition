using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition.SpecialThingFilters
{
    public class SpecialThingFilterWorker_Protein : SpecialThingFilterWorker
    {
        public override bool Matches(Thing t)
        {
            if (!t.def.IsIngestible)
                return false;
            CompIngredients ingredients = t.TryGetComp<CompIngredients>();
            if (ingredients != null)
            {
                foreach (var ingredient in ingredients.ingredients)
                {
                    CompProperties_FoodGroup foodGroup = ingredient.GetCompProperties<CompProperties_FoodGroup>();
                    if (foodGroup != null)
                    {
                        return foodGroup.foodGroup == FoodGroup.Protein;
                    }
                }
            }
            else
            {
                CompProperties_FoodGroup foodGroup = t.def.GetCompProperties<CompProperties_FoodGroup>();
                if (foodGroup != null)
                {
                    return foodGroup.foodGroup == FoodGroup.Protein;
                }
            }
            return false;
        }
        public override bool CanEverMatch(ThingDef def)
        {
            return def.IsIngestible && def.GetCompProperties<CompProperties_Ingredients>() != null || AlwaysMatches(def);
        }
        public override bool AlwaysMatches(ThingDef def)
        {
            CompProperties_FoodGroup foodGroup = def.GetCompProperties<CompProperties_FoodGroup>();
            if (foodGroup != null)
            {
                return foodGroup.foodGroup == FoodGroup.Protein;
            }
            return false;
        }
    }
}
