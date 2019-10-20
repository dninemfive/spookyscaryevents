using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    public class GameCondition_NightActiveWithEvents : GameCondition_ConditionallyHidden
    {
        List<NightEvents.IncidentInfo> events;
        public virtual float LightToBeActive {
            get //needed to use virtual
            {
                return 0f;
            }
        }
        public override bool IsActive(Map map)
        {
            return map.GameConditionManager.ConditionIsActive(base.def) && GenCelestial.CurCelestialSunGlow(map) <= LightToBeActive;
        }
    }
}
