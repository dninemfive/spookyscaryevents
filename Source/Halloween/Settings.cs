using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using UnityEngine;

namespace D9Halloween
{
    class HalloweenSettings : ModSettings
    {
        #region EvilDark
        public static int evilDarkDamage = 2, evilDarkPen = 1;
        #endregion EvilDark
        #region BloodMoon
        public static int bloodMoonMaxSkeletons = 200;
        #endregion BloodMoon
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref evilDarkDamage, "evilDarkDamage");
            Scribe_Values.Look(ref evilDarkPen, "evilDarkPen");
            Scribe_Values.Look(ref bloodMoonMaxSkeletons, "bloodMoonMaxSkeletons");
        }
    }

    public class HalloweenMod : Mod
    {
        HalloweenSettings settings;
        public HalloweenMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<HalloweenSettings>();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            string buf1 = "", buf2 = "", buf3 = "";
            base.DoSettingsWindowContents(inRect);
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.TextFieldNumericLabeled<int>("D9HEDDmg".Translate(), ref settings.evilDarkDamage, ref buf1, max: (int)1E+6);
            listingStandard.TextFieldNumericLabeled<int>("D9HEDPen".Translate(), ref settings.evilDarkPen, ref buf2, max: (int)1E+6);
            listingStandard.TextFieldNumericLabeled<int>("D9HBMSkel".Translate(), ref settings.bloodMoonMaxSkeletons, ref buf3, max: 1000);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory()
        {
            return "D9HalloweenName".Translate();
        }
    }
}
