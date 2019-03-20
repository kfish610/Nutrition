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
        public static HediffDef MissingVegetables;
        public static HediffDef MissingFruit;
        public static HediffDef MissingGrain;
        public static HediffDef MissingProtein;
        public static HediffDef MissingDairy;
        static NutrHediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(NutrHediffDefOf));
        }
    }
}
