using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS
{
    public class LuxRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Lux Relic";

        public override int TileID => ModContent.TileType<LuxRelicTile>();
    }
}
