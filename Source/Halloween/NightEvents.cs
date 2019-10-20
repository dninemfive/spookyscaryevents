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
            public enum ActivationTime
            {
                Never = 0,
                Sunset = 1,
                Midnight = 2,
                Sunrise = 3
            }
            public ActivationTime activationTimes;
            public IntRange? delay;
            public IncidentDef def;
            public float weight;
        }
    }
}
