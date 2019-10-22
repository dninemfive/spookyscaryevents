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
        public static float bloodMoonSkeletonThresh = 0.3f;
        #endregion BloodMoon
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref evilDarkDamage, "evilDarkDamage");
            Scribe_Values.Look(ref evilDarkPen, "evilDarkPen");
            Scribe_Values.Look(ref bloodMoonMaxSkeletons, "bloodMoonMaxSkeletons");
            Scribe_Values.Look(ref bloodMoonSkeletonThresh, "bloodMoonSkeletonThresh");
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
            string buf1 = "", buf2 = "", buf3 = "", buf4 = "";
            base.DoSettingsWindowContents(inRect);
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.TextFieldNumericLabeled<int>("D9HEDDmg".Translate(), ref HalloweenSettings.evilDarkDamage, ref buf1, max: (int)1E+6);
            listingStandard.TextFieldNumericLabeled<int>("D9HEDPen".Translate(), ref HalloweenSettings.evilDarkPen, ref buf2, max: (int)1E+6);
            listingStandard.TextFieldNumericLabeled<int>("D9HBMSkel".Translate(), ref HalloweenSettings.bloodMoonMaxSkeletons, ref buf3, max: 1000);
            listingStandard.TextFieldNumericLabeled<float>("D9HBMThre".Translate(), ref HalloweenSettings.bloodMoonSkeletonThresh, ref buf4, 0f, 1f);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory()
        {
            return "D9HalloweenName".Translate();
        }
    }
}
