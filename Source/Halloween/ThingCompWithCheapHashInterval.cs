using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace D9Halloween
{
    abstract class ThingCompWithCheapHashInterval : ThingComp
    {
        private int? hashOffset = null;
        public abstract int TickInterval { get; }
        public bool IsCheapIntervalTick => (int)(Find.TickManager.TicksGame + hashOffset) % TickInterval == 0;

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            if (hashOffset == null) hashOffset = parent.thingIDNumber.HashOffset();
        }
    }
}
