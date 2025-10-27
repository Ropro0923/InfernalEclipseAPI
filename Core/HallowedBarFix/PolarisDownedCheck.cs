using SOTS;

namespace InfernalEclipseAPI.Core.HallowedBarFix
{
    [ExtendsFromMod("SOTS")]
    public class PolarisDownedCheck
    {
        public static bool isPolarisDowned()
        {
            return SOTSWorld.downedAmalgamation;
        }
    }
}
