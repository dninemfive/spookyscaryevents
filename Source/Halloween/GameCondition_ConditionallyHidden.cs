using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    public abstract class GameCondition_ConditionallyHidden : GameCondition
    {
        public abstract bool IsActive(Map map);
    }
}
