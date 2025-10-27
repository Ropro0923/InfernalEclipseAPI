using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS
{
    public class PutridPinkyRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Putrid Pinky Relic";

        public override int TileID => ModContent.TileType<PutridPinkyRelicTile>();
    }
}
