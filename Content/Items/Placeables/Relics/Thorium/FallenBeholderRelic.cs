using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class FallenBeholderRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Fallen Beholder Relic";

        public override int TileID => ModContent.TileType <FallenBeholderRelicTile>();
    }
}
