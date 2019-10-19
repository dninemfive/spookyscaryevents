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
        Game game;
        Dictionary<long, IncidentInfo> incidents;

        public Dictionary<float, Dictionary<int, float>> SunriseTimes, SunsetTimes;
        GameComponent_HalloweenTracker(Game g)
        {
            game = g;
            GetSunriseAndSunsetTimes();
        }
        public override void ExposeData()
        {
            base.ExposeData();
            //if loading and mod list hash != saved hash, GetSunriseAndSunsetTimes();
        }
        public override void GameComponentTick()
        {
            base.GameComponentTick();
        }
        private void GetSunriseAndSunsetTimes()
        {
            SunriseTimes = new Dictionary<float, Dictionary<int, float>>();
            foreach(Map map in game.Maps)
            {
                float lat = Find.WorldGrid.LongLatOf(map.Tile).x;
                if (!SunriseTimes.ContainsKey(lat)) {
                    Dictionary<int, float> temp = new Dictionary<int, float>();
                    for (int t = 0; t < GenDate.TicksPerYear; t++)
                    {
                        int last0 = 0;

                    }
                }
            }
        }
    }
}
