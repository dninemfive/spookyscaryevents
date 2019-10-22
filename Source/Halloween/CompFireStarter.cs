using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class CompFireStarter : ThingCompWithCheapHashInterval
    {
        public override int TickInterval => 20;
    }
}
