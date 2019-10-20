using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace D9Halloween
{
    class GameCondition_DarkestNight : GameCondition_NightActiveWithEvents
    {
        public override bool AllowEnjoyableOutsideNow(Map map)
        {
            return !base.IsActive(map);
        }
        #region skygaze
        public override float SkyGazeChanceFactor(Map map)
        {
            return base.IsActive(map) ? 0 : 1;
        }
        public override float SkyGazeJoyGainFactor(Map map)
        {
            return base.IsActive(map) ? 0 : 1;
        }
        #endregion skygaze
        //TemperatureOffset?
        //SkyTarget
        //SkyOverlays
        //GameConditionDraw
    }
}
