using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nutrition.Needs;
using RimWorld;
using Verse;

namespace Nutrition.Thoughts
{
    public class ThoughtWorker_NeedFruit : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            Need_Fruit fruit = p.needs.TryGetNeed<Need_Fruit>();
            if (fruit == null)
            {
                return ThoughtState.Inactive;
            }
            switch (fruit.CurCategory)
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
