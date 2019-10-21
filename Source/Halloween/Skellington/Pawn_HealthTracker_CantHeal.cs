using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class Pawn_HealthTracker_CantHeal : Pawn_HealthTracker
    {
        private Pawn pawn;
        public Pawn_HealthTracker_CantHeal(Pawn pawn) : base(pawn)
        {
            this.pawn = pawn;
            hediffSet = new HediffSet(pawn);
            capacities = new PawnCapacitiesHandler(pawn);
            summaryHealth = new SummaryHealthHandler(pawn);
            surgeryBills = new BillStack(pawn);
            immunity = new ImmunityHandler(pawn);
            beCarriedByCaravanIfSick = pawn.RaceProps.Humanlike;
        }
        public new void HealthTick()
        {
            
        }
    }
}
