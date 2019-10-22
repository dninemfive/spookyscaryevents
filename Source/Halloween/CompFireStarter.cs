using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace D9Halloween
{
    [StaticConstructorOnStartup]
    class CompFireStarter : ThingCompWithCheapHashInterval
    {
        public CompProperties_FireStarter Props => (CompProperties_FireStarter)base.props;
        public override int TickInterval => Props.fireStartTicks;
        public int damageAmt => (int)(Props.rainDamageAmt * PrecipRate);
        public float precipThreshold => Props.precipitationThreshold;
        public float size => Props.fireSize;
        public Map map => base.parent.Map;
        public bool DrawFire => !GridsUtility.Roofed(base.parent.Position, map) && PrecipRateTooHigh;
        public bool PrecipRateTooHigh => PrecipRate > precipThreshold;
        public Pawn pawn => base.parent as Pawn;
        public float PrecipRate
        {
            get
            {
                WeatherManager man = base.parent.Map.weatherManager;
                return man.RainRate < 0 ? man.SnowRate < 0 ? 0 : man.SnowRate : man.RainRate;
            }
        }
        public override void CompTick()
        {
            base.CompTick();
            if (pawn.Dead) base.parent.Destroy();
            if (IsCheapIntervalTick)
            {
                base.parent.Map.weatherDecider.DisableRainFor(TickInterval + 100);
                if (PrecipRateTooHigh)
                {
                    TakeDamageFromRain();
                }
                else
                {
                    FireUtility.TryStartFireIn(base.parent.Position, map, size);
                }
            }
        }
        public void TakeDamageFromRain()
        {
            if(pawn == null)
            {
                ULog.Error("CompFireStarter parent is not pawn");
                return;
            }
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
                        pawn.TakeDamage(new DamageInfo(Props.rainDamage, damageAmt, 0f, hitPart: parts.ElementAt(rand)));
                    }
                }
            }
        }
        public override void PostPreApplyDamage(DamageInfo dinfo, out bool absorbed)
        {
            if (dinfo.Def == DamageDefOf.Burn || dinfo.Def == DamageDefOf.Burn || dinfo.Def == DamageDefOf.Burn) HealWounds(dinfo.Amount);
            if (dinfo.Def == DamageDefOf.Frostbite)
            {
                absorbed = false;
                return;
            }
            absorbed = true;
        }
        public void HealWounds(float amount)
        {
            foreach(Hediff_Injury hi in pawn.health.hediffSet.hediffs)
            {
                if(hi != null)
                {
                    hi.Severity -= amount / 100f;
                }
            }
        }
        #region fireOverlay
        public static readonly Graphic FireGraphic = GraphicDatabase.Get<Graphic_Flicker>("Things/Special/Fire", ShaderDatabase.TransparentPostLight, Vector2.one, Color.white);
        public override void PostDraw()
        {
            base.PostDraw();
            if (DrawFire)
            {
                Vector3 drawPos = base.parent.DrawPos;
                drawPos.y += 0.046875f;
                FireGraphic.Draw(drawPos, Rot4.North, base.parent, 0f);
            }
        }
        #endregion fireOverlay
    }
}
