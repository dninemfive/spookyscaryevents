using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class NightEvents : DefModExtension
    {
        SimpleCurve eventRangePerNight;
        List<IncidentInfo> events;
        public class IncidentInfo
        {
            [Flags]
            enum ActivationTime
            {
                Sunset,
                Midnight,
                Sunrise
            }
            ActivationTime? activationTimes;
            IntRange? delay;
            IncidentDef def;
            float weight;
        }
    }
}
