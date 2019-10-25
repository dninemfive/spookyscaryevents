using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    [DefOf]
    public static class D9HDefOf
    {
        public static WeatherDef Rain;
        public static WeatherDef RainyThunderstorm;
        public static WeatherDef FoggyRain;
        public static ThoughtDef ObservedSpookySkeleton;
        public static GameConditionDef D9DarkestNight;
        public static ThingDef D9Skeleton;
        public static PawnKindDef D9SkeletonKind;

        static D9HDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(WeatherDefOf));
        }
    }
}
