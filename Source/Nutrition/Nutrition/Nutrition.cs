using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Nutrition
{
    [StaticConstructorOnStartup]
    public static class Nutrition
    {
        public const string Id = "Nutrition";
        public const string Name = "Nutrition";
        public const string Version = "0.1";
        static Nutrition()
        {
            HarmonyInstance.Create(Id).PatchAll();
            ThingCategoryDefOf.MeatRaw.childThingDefs.ForEach(def =>
            {
                if (def.comps != null)
                {
                    def.comps.Add(new CompProperties_FoodGroup()
                    {
                        foodGroup = FoodGroup.Protein
                    });
                }
                else
                {
                    def.comps = new List<CompProperties>
                    {
                        new CompProperties_FoodGroup()
                        {
                            foodGroup = FoodGroup.Protein
                        }
                    };
                }
            });
            Log("Initialized");
        }

        public static void Log(string message) => Verse.Log.Message(prefixMessage(message));
        private static string prefixMessage(string message) => $"[{Name} v{Version}] {message}";
    }
}
