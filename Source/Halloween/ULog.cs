﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace D9Halloween
{
    static class ULog
    {
        public static bool DEBUG = true;
        public static string modid = "D9Halloween";
        public static string prefix => "[" + modid + "] ";

        public static void Messsage(String s)
        {
            Log.Message(prefix + s);
        }

        public static void Warning(String s)
        {
            Log.Warning(prefix + s);
        }

        public static void Warning(String s, bool whatev)
        {
            Log.Warning(prefix + s, whatev);
        }

        public static void Error(String s)
        {
            Log.Error(prefix + s);
        }

        public static void Error(String s, bool over)
        {
            Log.Error(prefix + s, over);
        }

        public static void DebugMessage(String s)
        {
            if (DEBUG) Log.Message(prefix + s);
        }
    }
}
