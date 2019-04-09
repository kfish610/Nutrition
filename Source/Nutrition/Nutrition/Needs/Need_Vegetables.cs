using Nutrition.Needs;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace Nutrition.Needs
{
    public class Need_Vegetables : Need_FoodGroup
    {
        public Need_Vegetables(Pawn pawn)
            : base(pawn)
        {
        }

        public override void NeedInterval()
        {
            if (!IsFrozen)
            {
                CurLevel -= FoodGroupFallPerTick * 150;
                if (Missing)
                {
                    HealthUtility.AdjustSeverity(pawn, NutrHediffDefOf.MissingVegetables, BaseMissingSeverityPerInterval);
                }
                else
                {
                    HealthUtility.AdjustSeverity(pawn, NutrHediffDefOf.MissingVegetables, -BaseMissingSeverityPerInterval);
                }
            }
        }
    }
}
