using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class QueenJellyfishRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Queen Jellyfish Relic";

        public override int TileID => ModContent.TileType<QueenJellyfishRelicTile>();
    }
}
