using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition
{
    public class CompProperties_FoodGroup : CompProperties
    {
        public FoodGroup foodGroup;
        public CompProperties_FoodGroup()
        {
            compClass = typeof(CompFoodGroup);
        }
    }
}
