using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition
{
    [DefOf]
    class NutrHediffDefOf
    {
        public static HediffDef MissingVegetables = null;
        public static HediffDef MissingFruit = null;
        public static HediffDef MissingGrain = null;
        public static HediffDef MissingProtein = null;
        public static HediffDef MissingDairy = null;
        static NutrHediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(NutrHediffDefOf));
        }
    }
}
