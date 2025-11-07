using InfernalEclipseAPI.Core.Systems;
using SOTS;

namespace InfernalEclipseAPI.Core.Players.SOTSPlayerOverrides
{
    [JITWhenModsEnabled(InfernalCrossmod.SOTS.Name)]
    [ExtendsFromMod(InfernalCrossmod.SOTS.Name)]
    public class VigorPlayerAdjustments : ModPlayer
    {
        public override void ResetEffects()
        {
            SOTSPlayer sotsPlayer = SOTSPlayer.ModPlayer(Player);

            if (sotsPlayer.VigorDashes > 25)
            {
                sotsPlayer.VigorDashes = 25;
            }
        }
    }
}
