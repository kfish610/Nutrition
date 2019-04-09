using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace Nutrition.Needs
{
    public abstract class Need_FoodGroup : Need
    {
        public override int GUIChangeArrow => -1;
        public override float MaxLevel => 1f;

        public const float BaseFoodGroupFallPerTick = 1E-6f;
        public const float BaseMissingSeverityPerInterval = 5E-4f;
        public const float PercentageThreshFoodGroupLow = 0.15f;
        public const float PercentageThreshFoodGroupSatisfied = 0.75f;
        public FoodGroupCategory CurCategory
        {
            get
            {
                if (CurLevelPercentage <= 0)
                {
                    return FoodGroupCategory.FoodGroupMissing;
                }
                if (CurLevelPercentage < PercentageThreshFoodGroupLow)
                {
                    return FoodGroupCategory.FoodGroupLow;
                }
                if (CurLevelPercentage < PercentageThreshFoodGroupSatisfied)
                {
                    return FoodGroupCategory.FoodGroupSatisfied;
                }
                return FoodGroupCategory.FoodGroupFullySatisfied;
            }
        }
        public bool Missing => CurCategory == FoodGroupCategory.FoodGroupMissing;
        public bool Low => CurCategory == FoodGroupCategory.FoodGroupLow;
        public bool Satisfied => CurCategory == FoodGroupCategory.FoodGroupSatisfied;
        public bool FullySatisfied => CurCategory == FoodGroupCategory.FoodGroupFullySatisfied;
        public float FoodGroupFallPerTick => FoodGroupFallPerTickByCategory(CurCategory);
        public float IncreaseWanted => MaxLevel - CurLevel;
        public Need_FoodGroup(Pawn pawn)
            : base(pawn)
        {
        }
        private float FoodGroupFallPerTickByCategory(FoodGroupCategory category)
        {
            switch (category)
            {
                case FoodGroupCategory.FoodGroupFullySatisfied:
                case FoodGroupCategory.FoodGroupSatisfied:
                    return BaseFoodGroupFallPerTick;
                case FoodGroupCategory.FoodGroupLow:
                    return BaseFoodGroupFallPerTick * 0.5f;
                case FoodGroupCategory.FoodGroupMissing:
                    return BaseFoodGroupFallPerTick * 0.15f;
                default:
                    throw new NotImplementedException();
            }
        }
        public override void SetInitialLevel()
        {
            CurLevelPercentage = 0.8f;
        }
        public override string GetTipString()
        {
            return LabelCap + ": " + CurLevelPercentage.ToStringPercent() + " (" + CurLevel.ToString("0.##") + " / " + MaxLevel.ToString("0.##") + ")\n" + def.description;
        }
        public override void DrawOnGUI(Rect rect, int maxThresholdMarkers = int.MaxValue, float customMargin = -1f, bool drawArrows = true, bool doTooltip = true)
        {
            if (threshPercents == null)
            {
                threshPercents = new List<float>();
            }
            threshPercents.Clear();
            threshPercents.Add(PercentageThreshFoodGroupLow);
            base.DrawOnGUI(rect, maxThresholdMarkers, customMargin, drawArrows, doTooltip);
        }
    }
}
