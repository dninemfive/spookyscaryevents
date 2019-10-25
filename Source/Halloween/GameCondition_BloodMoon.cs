using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace D9Halloween
{
    class GameCondition_BloodMoon : GameCondition_HalloweenNight
    {
        public static int MaxSkeletons => HalloweenSettings.bloodMoonMaxSkeletons;
        public static float spawnThresh => HalloweenSettings.bloodMoonSkeletonThresh;
        List<IntVec3> validSkeletonCells;
        IEnumerable<Pawn_Skeleton> skeletons => base.SingleMap.mapPawns.AllPawns.Where(x => x is Pawn_Skeleton).Cast<Pawn_Skeleton>();
        public override float[] skytArgs
        {
            get
            {
                //sky glow, some other shit
                return new float[] { 1f, 1f, 1f };
            }
        }
        public override SkyColorSet ConditionColors
        {
            get
            {
                return new SkyColorSet(new ColorInt(0, 0, 0).ToColor, Color.white, new Color(0.6f, 0.6f, 0.6f), 0.65f);
            }
        }
        public override void GameConditionTick()
        {
            base.GameConditionTick();
            DoSkeletonPulse();
            
        }
        public override void End()
        {
            foreach (Pawn_Skeleton skel in skeletons) skel.Crumble();
            base.End();                        
        }
        public void DoSkeletonPulse()
        {
            //validSkeletonCells = GetValidSkeletonCells();
            //if there aren't too many skeletons,
            //get a number of skeletons to spawn (e.g. sqrt(max-current))
            //for i < n, 
            //spawn skeleton in random spot
            //spots must be non-stone natural ground in an unroofed area
            if(skeletons.Count() < MaxSkeletons)
            {
                int numToSpawn = (int)Mathf.Sqrt(skeletons.Count() - MaxSkeletons);
                for (int i = 0; i < numToSpawn; i++) SpawnSkeleton();
            }
        }
        public void SpawnSkeleton()
        {
            IntVec3 cellToSpawnIn = validSkeletonCells.RandomElement();
            PawnGenerationRequest req = new PawnGenerationRequest(D9HDefOf.D9SkeletonKind);
            Pawn_Skeleton skele = (Pawn_Skeleton)PawnGenerator.GeneratePawn(req);
            GenSpawn.Spawn(skele, cellToSpawnIn, base.SingleMap);
        }
        //should have a cache and dirty routine so we're not getting this too often
        public void Update()
        {
            validSkeletonCells = GetValidSkeletonCells();
        }
        public List<IntVec3> GetValidSkeletonCells()
        {
            Map map = base.SingleMap;
            return map.AllCells.Where((IntVec3 c) => map.terrainGrid.TerrainAt(c).affordances.Contains(TerrainAffordanceDefOf.Diggable) &&
                                           map.glowGrid.GameGlowAt(c) < spawnThresh &&
                                           GridsUtility.UsesOutdoorTemperature(c, map) &&
                                           !GridsUtility.Fogged(c, map) &&
                                           c.Standable(map)
                                           ).ToList();
        }
        //TemperatureOffset?
    }
}
