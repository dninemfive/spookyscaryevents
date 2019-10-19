using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    public class GameCondition_HiddenUnlessNight : GameCondition
    {
        public float LightToBeActive = 0f;
        public bool IsActive => base.AffectedMaps.Where(x => GenCelestial.CurCelestialSunGlow(x) <= LightToBeActive).Any();
        
    }
}
