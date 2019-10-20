using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace D9Halloween
{
    public class GameCondition_HalloweenNight : GameCondition
    {
        List<NightEvents.IncidentInfo> events;
        public bool WasActiveLastTick;
        public const float midnightHour = 0f;
        public bool IsMidnight => GenLocalDate.HourFloat(base.SingleMap.Tile) == midnightHour;
        public virtual float[] skytArgs //hilarious pun, I know
        {
            get
            {
                return new float[] { 1f, 1f, 1f };
            }
        }
        public virtual SkyColorSet ConditionColors
        {
            get;
        }
        public virtual float LightToBeActive {
            get //needed to use virtual
            {
                return 0f;
            }
        }
        public override void Init()
        {
            base.Init();
            WasActiveLastTick = !IsActive(base.SingleMap);
        }
        public override void GameConditionTick()
        {
            base.GameConditionTick();
            if(!WasActiveLastTick && IsActive(base.SingleMap))
            {
                IEnumerable<NightEvents.IncidentInfo> sunsetEvents = events.Where(x => (x.activationTimes & NightEvents.IncidentInfo.ActivationTime.Sunset) != NightEvents.IncidentInfo.ActivationTime.Never);
                if (sunsetEvents.Any())
                {
                    sunsetEvents.TryRandomElementByWeight(x => x.weight, out NightEvents.IncidentInfo res);
                    if(res.def != null)
                    {
                        res.def.Worker.TryExecute(StorytellerUtility.DefaultParmsNow(res.def.category, base.SingleMap));
                    }
                }
            }
            if (IsMidnight)
            {
                IEnumerable<NightEvents.IncidentInfo> midnightEvents = events.Where(x => (x.activationTimes & NightEvents.IncidentInfo.ActivationTime.Midnight) != NightEvents.IncidentInfo.ActivationTime.Never);
                if (midnightEvents.Any())
                {
                    midnightEvents.TryRandomElementByWeight(x => x.weight, out NightEvents.IncidentInfo res);
                    if (res.def != null)
                    {
                        res.def.Worker.TryExecute(StorytellerUtility.DefaultParmsNow(res.def.category, base.SingleMap));
                    }
                }
            }
            if (WasActiveLastTick && !IsActive(base.SingleMap))
            {
                IEnumerable<NightEvents.IncidentInfo> sunriseEvents = events.Where(x => (x.activationTimes & NightEvents.IncidentInfo.ActivationTime.Sunrise) != NightEvents.IncidentInfo.ActivationTime.Never);
                if (sunriseEvents.Any())
                {
                    sunriseEvents.TryRandomElementByWeight(x => x.weight, out NightEvents.IncidentInfo res);
                    if (res.def != null)
                    {
                        res.def.Worker.TryExecute(StorytellerUtility.DefaultParmsNow(res.def.category, base.SingleMap));
                    }
                }
                End();
            }
        }
        public bool IsActive(Map map)
        {
            return map.GameConditionManager.ConditionIsActive(base.def) && GenCelestial.CurCelestialSunGlow(map) <= LightToBeActive;
        }
        #region misc
        public override bool AllowEnjoyableOutsideNow(Map map)
        {
            return !IsActive(map);
        }
        public override float SkyGazeChanceFactor(Map map)
        {
            return IsActive(map) ? 0 : 1;
        }
        public override float SkyGazeJoyGainFactor(Map map)
        {
            return IsActive(map) ? 0 : 1;
        }
        #endregion misc
        public override SkyTarget? SkyTarget(Map map)
        {
            return new SkyTarget(skytArgs[0], ConditionColors, skytArgs[1], skytArgs[2]);
        }        
    }
}
