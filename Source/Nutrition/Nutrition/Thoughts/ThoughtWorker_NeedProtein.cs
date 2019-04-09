using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nutrition.Needs;
using RimWorld;
using Verse;

namespace Nutrition.Thoughts
{
    public class ThoughtWorker_NeedProtein : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            Need_Protein protein = p.needs.TryGetNeed<Need_Protein>();
            if (protein == null)
            {
                return ThoughtState.Inactive;
            }
            switch (protein.CurCategory)
            {
                case FoodGroupCategory.FoodGroupFullySatisfied:
                case FoodGroupCategory.FoodGroupSatisfied:
                    return ThoughtState.Inactive;
                case FoodGroupCategory.FoodGroupLow:
                    return ThoughtState.ActiveAtStage(0);
                case FoodGroupCategory.FoodGroupMissing:
                    return ThoughtState.ActiveAtStage(1);
                default:
                    throw new NotImplementedException();
            }
        }
    }

}
