using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class CompParticleSpawner : ThingCompWithCheapHashInterval
    {
        ThingDef particle;
        int numParticles, ticksPerPulse;
        public override int TickInterval
        {
            get
            {
                return ticksPerPulse;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            if (IsCheapIntervalTick)
            {
                //copy MoteMaker shit, probably need settings for thrown particles
            }
        }
    }
}
