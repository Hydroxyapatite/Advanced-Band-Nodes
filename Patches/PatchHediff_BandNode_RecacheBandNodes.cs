using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Hydroxyapatite_AdvancedBandNodes
{
    [HarmonyPatch(
            typeof(Hediff_BandNode),
            nameof(Hediff_BandNode.RecacheBandNodes))]
    public class PatchHediff_BandNode_RecacheBandNodes
    {
        static void Postfix(
            Hediff_BandNode __instance,
            ref int ___cachedTunedBandNodesCount,
            ref HediffStage ___curStage
            )
        {
            int num = ___cachedTunedBandNodesCount;
            List<Map> maps = Find.Maps;
            for (int i = 0; i < maps.Count; i++)
            {
                foreach (Building item in maps[i].listerBuildings.AllBuildingsColonistOfDef(AdvancedBandNodeDefOf.Hydroxyapatite_AdvancedBandNode))
                {
                    if (item.TryGetComp<CompBandNode>().tunedTo == __instance.pawn && item.TryGetComp<CompPowerTrader>().PowerOn)
                    {
                        ___cachedTunedBandNodesCount += 4;
                    }
                }
            }
            if(num != ___cachedTunedBandNodesCount)
            {
                ___curStage = null;
                __instance.pawn.mechanitor?.Notify_BandwidthChanged();
            }
        }
    }
}
