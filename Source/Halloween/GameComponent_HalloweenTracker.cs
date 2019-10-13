using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class GameComponent_HalloweenTracker : GameComponent
    {
        Dictionary<long, IncidentInfo> incidents;
        GameComponent_HalloweenTracker(Game game)
        {
        }
        public override void GameComponentTick()
        {
            base.GameComponentTick();

        }
    }
}
