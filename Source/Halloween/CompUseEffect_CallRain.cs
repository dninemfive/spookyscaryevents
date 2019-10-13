using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class CompUseEffect_CallRain : CompUseEffect_Artifact
    {
        public static Dictionary<WeatherDef, float> weatherWeights = new Dictionary<WeatherDef, float>
        {
            { D9HDefOf.Rain, 1f },
            { D9HDefOf.FoggyRain, .5f },
            { D9HDefOf.RainyThunderstorm, .25f }
        };
        public override void DoEffect(Pawn usedBy)
        {
            base.DoEffect(usedBy);
            usedBy.Map.weatherManager.TransitionTo(weatherWeights.RandomElementByWeight(x => x.Value).Key);
        }
        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
            if (weatherWeights.ContainsKey(p.Map.weatherManager.curWeather))
            {
                failReason = "D9HalloweenAlreadyRaining".Translate();
                return false;
            }
            failReason = null;
            return true;
        }
    }
}
