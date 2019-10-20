using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace D9Halloween
{
    class GameCondition_BloodMoon : GameCondition_HalloweenNight
    {
        public override float[] skytArgs
        {
            get
            {
                //sky glow, some other shit
                return new float[] { 1f, 1f, 1f };
            }
        }
        public override SkyColorSet ConditionColors
        {
            get
            {
                return new SkyColorSet(new ColorInt(0, 0, 0).ToColor, Color.white, new Color(0.6f, 0.6f, 0.6f), 0.65f);
            }
        }
        public override void GameConditionTick()
        {
            base.GameConditionTick();
            //if there aren't too many skeletons,
                //get a number of skeletons to spawn (e.g. sqrt(max-current))
                    //for i < n, 
                        //spawn skeleton in random spot
                        //spots must be non-stone natural ground in an unroofed area
        }
        //TemperatureOffset?
    }
}
