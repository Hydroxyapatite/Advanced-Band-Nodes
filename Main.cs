using HarmonyLib;
using Verse;

namespace Hydroxyapatite_AdvancedBandNodes
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("rimworld.hydroxyapatite.AdvancedBandNodes");
            harmony.PatchAll();
        }
    }
}
