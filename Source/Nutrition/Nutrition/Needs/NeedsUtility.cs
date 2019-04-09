using Nutrition.SpecialThingFilters;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition.Needs
{
    static class NeedsUtility
    {
        public static IEnumerable<Need_FoodGroup> GetFoodGroups(this Pawn_NeedsTracker needs)
        {
            Need_Dairy dairy = needs.TryGetNeed<Need_Dairy>();
            if (dairy == null)
            {
                yield break;
            }
            yield return dairy;
            yield return needs.TryGetNeed<Need_Fruit>();
            yield return needs.TryGetNeed<Need_Vegetables>();
            yield return needs.TryGetNeed<Need_Protein>();
            yield return needs.TryGetNeed<Need_Grain>();
        }
        public static bool IsFullySatisfied(this IEnumerable<Need_FoodGroup> foodGroupNeeds)
        {
            return foodGroupNeeds.All(x => x.FullySatisfied);
        }
        public static bool IsSatisfied(this IEnumerable<Need_FoodGroup> foodGroupNeeds)
        {
            return foodGroupNeeds.All(x => x.Satisfied);
        }
        public static IEnumerable<Need_FoodGroup> GetLowOrMissing(this IEnumerable<Need_FoodGroup> foodGroupNeeds)
        {
            return foodGroupNeeds.Where(x => x.Missing || x.Low);
        }
        public static Need_FoodGroup GetLowest(this IEnumerable<Need_FoodGroup> foodGroupNeeds)
        {
            float min = foodGroupNeeds.Min(x => x.CurLevel);
            return foodGroupNeeds.First(x => x.CurLevel == min);
        }
        public static T As<T>(this Need_FoodGroup foodGroupNeed) where T : Need_FoodGroup
        {
            if (foodGroupNeed is T foodGroup)
            {
                return foodGroup;
            }
            return null;
        }
        public static SpecialThingFilterDef GetFilter(this Need_FoodGroup foodGroupNeed)
        {
            if (foodGroupNeed is Need_Vegetables)
            {
                return SpecialThingFilterDef.Named("AllowVegetables");
            }
            if (foodGroupNeed is Need_Fruit)
            {
                return SpecialThingFilterDef.Named("AllowFruit");
            }
            if (foodGroupNeed is Need_Grain)
            {
                return SpecialThingFilterDef.Named("AllowGrain");
            }
            if (foodGroupNeed is Need_Protein)
            {
                return SpecialThingFilterDef.Named("AllowProtein");
            }
            if (foodGroupNeed is Need_Dairy)
            {
                return SpecialThingFilterDef.Named("AllowDairy");
            }
            throw new NotImplementedException();
        }
        public static Need_FoodGroup GetByFoodGroup(this Pawn_NeedsTracker needs, FoodGroup foodGroup)
        {
            switch(foodGroup)
            {
                case FoodGroup.Vegetable:
                    return needs.TryGetNeed<Need_Vegetables>();
                case FoodGroup.Fruit:
                    return needs.TryGetNeed<Need_Fruit>();
                case FoodGroup.Grain:
                    return needs.TryGetNeed<Need_Grain>();
                case FoodGroup.Protein:
                    return needs.TryGetNeed<Need_Protein>();
                case FoodGroup.Dairy:
                    return needs.TryGetNeed<Need_Dairy>();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
