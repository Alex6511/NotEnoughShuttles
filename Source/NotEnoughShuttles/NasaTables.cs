using System;

namespace NotEnoughShuttles
{
    /// <summary>
    /// Bilinear interpolation over NASA Operational Aerodynamic Data Book Vol.1 (Sept 1985)
    /// tables for the Space Shuttle Orbiter. Cl/Cd plus delta tables for flap/AC corrections.
    ///
    /// Tables are indexed [machIdx, aoaIdx] using shuttleMachArr / shuttleAoAArr as breakpoints.
    /// Lookup returns (Cl, Cd) with deltas applied — equivalent to giuliodondi's
    /// FARSpaceShuttleAerodynamicModel.getSpaceShuttleCoeffs().
    ///
    /// Data ported verbatim from kOS-Scripts/../FARShuttleAerodynamicModel/FARSpaceShuttleAerodynamicModel.cs
    /// (kept in repo at FARShuttleAerodynamicModel/FARSpaceShuttleAerodynamicModel.cs).
    /// </summary>
    internal static class NasaTables
    {
        private const double RadToDeg = 180.0 / Math.PI;

        // AoA breakpoints (degrees): 19 values from -10 to +50
        private static readonly double[] AoaArr =
        {
            -10, -5, -2.5, 0, 2.5, 5, 7.5, 10, 12.5, 15, 17.5, 20, 22.5, 25, 30, 35, 40, 45, 50
        };

        // Mach breakpoints: 25 values from 0.25 to 30
        private static readonly double[] MachArr =
        {
            0.25, 0.4, 0.6, 0.8, 0.85, 0.9, 0.92, 0.95, 0.98, 1.05, 1.1, 1.2, 1.3, 1.5, 2,
            2.5, 3, 4, 5, 8, 10, 15, 20, 25, 30
        };

        // TODO: port the four 25x19 tables (ClTable, CdTable, DeltaClTable, DeltaCdTable) from
        // FARShuttleAerodynamicModel/FARSpaceShuttleAerodynamicModel.cs lines 36–150.
        // Set TablesLoaded = true once data is in place — AeroPatches checks this flag and
        // skips the override entirely while tables are stubs (matches Path 2 behavior).
        public const bool TablesLoaded = false;

        private static readonly double[,] ClTable = new double[25, 19];
        private static readonly double[,] CdTable = new double[25, 19];
        private static readonly double[,] DeltaClTable = new double[25, 19];
        private static readonly double[,] DeltaCdTable = new double[25, 19];

        public static (double cl, double cd) Lookup(double mach, double aoaRad)
        {
            double aoaDeg = aoaRad * RadToDeg;

            int mIdx = FindIndex(MachArr, mach);
            int aIdx = FindIndex(AoaArr, aoaDeg);

            double aoa1 = AoaArr[aIdx],   aoa2 = AoaArr[aIdx + 1];
            double mach1 = MachArr[mIdx], mach2 = MachArr[mIdx + 1];

            double dAoa  = aoa2 - aoa1;
            double dMach = mach2 - mach1;
            double tAoa  = aoaDeg - aoa1;
            double tMach = mach - mach1;

            double cl  = BilinearLerp(ClTable,      mIdx, aIdx, dMach, dAoa, tMach, tAoa);
            double cd  = BilinearLerp(CdTable,      mIdx, aIdx, dMach, dAoa, tMach, tAoa);
            double dCl = BilinearLerp(DeltaClTable, mIdx, aIdx, dMach, dAoa, tMach, tAoa);
            double dCd = BilinearLerp(DeltaCdTable, mIdx, aIdx, dMach, dAoa, tMach, tAoa);

            return (cl + dCl, cd + dCd);
        }

        private static int FindIndex(double[] arr, double v)
        {
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] >= v) return i - 1;
            return arr.Length - 2;
        }

        private static double BilinearLerp(double[,] tbl, int mIdx, int aIdx,
                                           double dMach, double dAoa, double tMach, double tAoa)
        {
            double v11 = tbl[mIdx,     aIdx];
            double v12 = tbl[mIdx,     aIdx + 1];
            double v21 = tbl[mIdx + 1, aIdx];
            double v22 = tbl[mIdx + 1, aIdx + 1];

            double rowAtAoa1 = ((v21 - v11) / dMach) * tMach + v11;
            double rowAtAoa2 = ((v22 - v12) / dMach) * tMach + v12;
            return ((rowAtAoa2 - rowAtAoa1) / dAoa) * tAoa + rowAtAoa1;
        }
    }
}
