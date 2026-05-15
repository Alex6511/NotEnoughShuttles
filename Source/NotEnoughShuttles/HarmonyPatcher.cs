using HarmonyLib;
using UnityEngine;

namespace NotEnoughShuttles
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class HarmonyPatcher : MonoBehaviour
    {
        private const string HarmonyId = "com.NotEnoughShuttles.aero";

        public void Start()
        {
            var harmony = new Harmony(HarmonyId);
            harmony.PatchAll(typeof(HarmonyPatcher).Assembly);
            Debug.Log("[NotEnoughShuttles] Harmony patches applied.");
        }
    }
}
