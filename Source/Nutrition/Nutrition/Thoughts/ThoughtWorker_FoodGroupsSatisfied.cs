using Nutrition.Needs;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition.Thoughts
{
    class ThoughtWorker_FoodGroupsSatisfied : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            var foodGroupNeeds = p.needs.GetFoodGroups();
            if (foodGroupNeeds.IsFullySatisfied())
            {
                return ThoughtState.ActiveAtStage(1);
            }
            if (foodGroupNeeds.IsSatisfied())
            {
                return ThoughtState.ActiveAtStage(0);
            }
            return ThoughtState.Inactive;
        }
    }
}
