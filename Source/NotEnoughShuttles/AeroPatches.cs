using ferram4;
using HarmonyLib;
using UnityEngine;

namespace NotEnoughShuttles
{
    /// <summary>
    /// Harmony patches that override FAR's wing aero for tagged shuttle parts.
    /// Replaces the inheritance approach in giuliodondi's FARSpaceShuttleAerodynamicModel
    /// so we don't need a forked FAR build — works against stock dkavolis FAR.
    /// </summary>
    internal static class AeroPatches
    {
        private static bool TryGetOverrideTag(FARWingAerodynamicModel instance, out ModuleNESAeroOverride tag)
        {
            tag = null;
            if (instance == null || instance.part == null) return false;
            tag = instance.part.FindModuleImplementing<ModuleNESAeroOverride>();
            return tag != null;
        }

        // Postfix on the private CalculateCoefficients. Harmony resolves private methods by name.
        // Mirrors giuliodondi's override at FARSpaceShuttleAerodynamicModel.cs:158
        [HarmonyPatch(typeof(FARWingAerodynamicModel), "CalculateCoefficients",
            new[] { typeof(double), typeof(double), typeof(double) })]
        internal static class CalculateCoefficients_Postfix
        {
            static void Postfix(
                FARWingAerodynamicModel __instance,
                double MachNumber, double AoA, double skinFrictionCoefficient,
                ref double ___Cl, ref double ___Cd)
            {
                if (!TryGetOverrideTag(__instance, out var tag)) return;
                if (!tag.InEnvelope(MachNumber, AoA)) return;

                var (cl, cd) = NasaTables.Lookup(MachNumber, AoA);
                ___Cl = cl;
                ___Cd = cd;
            }
        }

        // Postfix on the private CalculateAerodynamicCenter.
        // giuliodondi's override (FARSpaceShuttleAerodynamicModel.cs:152) just returns WC (wing centroid).
        // We mirror that for tagged parts only.
        [HarmonyPatch(typeof(FARWingAerodynamicModel), "CalculateAerodynamicCenter",
            new[] { typeof(double), typeof(double), typeof(Vector3d) })]
        internal static class CalculateAerodynamicCenter_Postfix
        {
            static void Postfix(
                FARWingAerodynamicModel __instance,
                double MachNumber, double AoA, Vector3d WC,
                ref Vector3d __result)
            {
                if (!TryGetOverrideTag(__instance, out _)) return;
                __result = WC;
            }
        }
    }
}
