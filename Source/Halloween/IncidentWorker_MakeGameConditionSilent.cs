using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;

namespace D9Halloween
{
    class IncidentWorker_MakeNightCondition : IncidentWorker_MakeGameCondition
    {
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            GameConditionManager gameConditionManager = parms.target.GameConditionManager;
            int duration = Mathf.RoundToInt(base.def.durationDays.RandomInRange * 60000f);
            GameCondition cond = GameConditionMaker.MakeCondition(base.def.gameCondition, duration, 0);
            gameConditionManager.RegisterCondition(cond);
            //base.SendStandardLetter();    //it's that easy!
            return true;
        }
    }
}
