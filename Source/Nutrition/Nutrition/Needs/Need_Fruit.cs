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
    public class Need_Fruit : Need_FoodGroup
    {
        public Need_Fruit(Pawn pawn)
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
                    HealthUtility.AdjustSeverity(pawn, NutrHediffDefOf.MissingFruit, BaseMissingSeverityPerInterval);
                }
                else
                {
                    HealthUtility.AdjustSeverity(pawn, NutrHediffDefOf.MissingFruit, -BaseMissingSeverityPerInterval);
                }
            }
        }
    }
}
