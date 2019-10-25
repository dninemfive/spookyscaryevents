using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class CompProperties_FireStarter : CompProperties
    {
        public int fireStartTicks = 250, rainDamageAmt = 10;
        public float precipitationThreshold = 0.1f, fireSize = 10f;
        public bool TakeDamageInRain = true;
#pragma warning disable CS0649
        public DamageDef rainDamage;

        public CompProperties_FireStarter()
        {
            base.compClass = typeof(CompFireStarter);
        }
    }
}
