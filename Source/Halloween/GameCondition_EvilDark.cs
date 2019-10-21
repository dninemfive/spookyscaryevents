using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class GameCondition_EvilDark : GameCondition
    {
        const float thresholdToEnd = 0.7f;//, thresholdToDamage = .25f;
        public Map map => base.SingleMap;
        public DamageDef damage;
        public static int damageAmt => HalloweenSettings.evilDarkDamage;
        public static int pen => HalloweenSettings.evilDarkPen;
        public override void GameConditionTick()
        {
            base.GameConditionTick();
            if (GenCelestial.CurCelestialSunGlow(base.SingleMap) > thresholdToEnd) End();
            foreach (Pawn pawn in map.mapPawns.AllPawns) if (map.glowGrid.PsychGlowAt(pawn.Position) == PsychGlow.Dark) DamagePawn(pawn);
        }
        public void DamagePawn(Pawn pawn)
        {
            IEnumerable<BodyPartRecord> notMissingParts = pawn.health.hediffSet.GetNotMissingParts();
            if (notMissingParts.Count() > 0)
            {
                List<BodyPartRecord> parts = (from b in notMissingParts where b.coverageAbs > 0 && !pawn.health.hediffSet.PartIsMissing(b) select b).ToList();
                int rand = new IntRange(0, parts.Count() - 1).RandomInRange;
                if (rand < parts.Count())
                {
                    BodyPartRecord part = parts.ElementAt(rand);
                    if (part != null)
                    {
                        pawn.TakeDamage(new DamageInfo(damage, damageAmt, pen, hitPart: parts.ElementAt(rand)));
                    }
                }
            }
        }
        #region misc
        public override bool AllowEnjoyableOutsideNow(Map map)
        {
            return false;
        }
        public override float SkyGazeChanceFactor(Map map)
        {
            return 0;
        }
        public override float SkyGazeJoyGainFactor(Map map)
        {
            return 0;
        }
        #endregion misc
    }
}
