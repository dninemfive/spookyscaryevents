using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace D9Halloween
{
    class GameCondition_DarkestNight : GameCondition_HalloweenNight
    {
        public override SkyColorSet ConditionColors
        {
            get
            {
                return new SkyColorSet(new ColorInt(0, 0, 0).ToColor, Color.white, new Color(0.6f, 0.6f, 0.6f), 0.65f);
            }
        }
        //TemperatureOffset?

    }
}
