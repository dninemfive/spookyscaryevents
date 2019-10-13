using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace D9Halloween
{
    class IncidentWorker_QueueConditionAndEvent : IncidentWorker
    {
        public const float SunriseHour = CaravanNightRestUtility.WakeUpHour;
        public const float SunsetHour = CaravanNightRestUtility.RestStartHour;
        public const int TicksSunsetToSunrise = (int)(GenDate.TicksPerHour * (SunsetHour - SunriseHour));

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            GameComponent_HalloweenTracker tracker = Current.Game.GetComponent<GameComponent_HalloweenTracker>();
            IncidentQueuer ext = base.def.GetModExtension<IncidentQueuer>();
            if(tracker != null && ext != null)
            {
                GameConditionManager gameConditionManager = parms.target.GameConditionManager;
                int duration = Mathf.RoundToInt(TicksSunsetToSunrise);
                GameCondition cond = GameConditionMaker.MakeCondition(base.def.gameCondition, duration, TicksToSunsetTonight(parms.target as Map) + ext.conditionTicksFromSunset);
                gameConditionManager.RegisterCondition(cond);
                return true;
            }
            return false;
        }
        public int TicksToSunsetTonight(Map map)
        {
            if (map == null)
            {
                ULog.DebugMessage("IncidentWorker.QueueConditionAndEvent.TicksToSunsetTonight(): Map was null");
                return 0;
            }
            return (int)(GenDate.TicksPerHour * (SunsetHour - GenLocalDate.HourFloat(map)));
        }
    }
}
