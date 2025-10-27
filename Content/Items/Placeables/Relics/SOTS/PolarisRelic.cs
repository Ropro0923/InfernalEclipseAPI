using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS
{
    public class PolarisRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Polaris Relic";

        public override int TileID => ModContent.TileType<PolarisRelicTile>();
    }
}
