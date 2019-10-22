using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using RimWorld;

namespace D9Halloween
{
    public class Pawn_Skeleton : Pawn, IThoughtGiver
    {
        //public new Pawn_HealthTracker_CantHeal health;

        public Thought_Memory GiveObservedThought()
        {
            Thought_MemoryObservation thought = ((Thought_MemoryObservation)ThoughtMaker.MakeThought(D9HDefOf.ObservedSpookySkeleton));
            thought.Target = this;
            return thought;
        }
        public void Crumble()
        {
            //spawn dust motes
            //leave bone pile filth
            Kill(null);
        }
    }
}
