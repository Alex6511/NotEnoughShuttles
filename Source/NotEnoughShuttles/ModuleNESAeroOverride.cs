namespace NotEnoughShuttles
{
    /// <summary>
    /// Tag module. Presence on a part signals our Harmony aero patches to override
    /// FAR's wing coefficient calculation with NASA-table lookup for that part.
    /// Configured per-part via ModuleManager (see GameData/NotEnoughShuttles/AeroOverride.cfg).
    /// </summary>
    public class ModuleNESAeroOverride : PartModule
    {
        [KSPField(isPersistant = false)]
        public double minOverrideAoARad = -10.0 * 0.017453292519943295;

        [KSPField(isPersistant = false)]
        public double maxOverrideAoARad = 50.0 * 0.017453292519943295;

        [KSPField(isPersistant = false)]
        public double minOverrideMach = 0.25;

        [KSPField(isPersistant = false)]
        public double maxOverrideMach = 30.0;

        public bool InEnvelope(double machNumber, double aoaRad)
        {
            return aoaRad >= minOverrideAoARad
                && aoaRad <= maxOverrideAoARad
                && machNumber >= minOverrideMach
                && machNumber <= maxOverrideMach;
        }
    }
}
