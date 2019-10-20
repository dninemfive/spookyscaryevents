using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    public class GameCondition_HalloweenNight : GameCondition
    {
        List<NightEvents.IncidentInfo> events;
        public bool WasActiveLastTick;
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
            if (WasActiveLastTick && !IsActive(base.SingleMap))
            {
                if((bool)events.Where(x => (x.activationTimes & NightEvents.IncidentInfo.ActivationTime.Sunrise) != NightEvents.IncidentInfo.ActivationTime.Never)?.TryRandomElementByWeight(x => x.weight, out NightEvents.IncidentInfo res)) 
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
