using Nutrition.Needs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition
{
    public class CompFoodGroup : ThingComp
    {
        public CompProperties_FoodGroup Props => (CompProperties_FoodGroup)props;
        public override void PostIngested(Pawn ingester)
        {
            if (ingester.needs.GetFoodGroups() == null)
                return;
            ingester.needs.GetByFoodGroup(Props.foodGroup).CurLevel += parent.def.ingestible.CachedNutrition;
        }
        public override string CompInspectStringExtra()
        {
            return base.CompInspectStringExtra() + "Food Groups: " + Props.foodGroup.ToString("G");
        }
    }
}
