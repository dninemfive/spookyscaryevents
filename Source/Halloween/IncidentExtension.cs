using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class IncidentQueuer : DefModExtension
    {
        public IncidentDef incidentToQueue = null;
        public GameConditionDef conditionToStart = GameConditionDefOf.ToxicFallout; //TODO: default to Darkest Night
        public int incidentTicksFromSunset = 0, conditionTicksFromSunset = 0;
    }
}
