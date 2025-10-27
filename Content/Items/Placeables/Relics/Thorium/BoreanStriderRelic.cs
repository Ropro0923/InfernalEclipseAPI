using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class BoreanStriderRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Borean Strider Relic";

        public override int TileID => ModContent.TileType<BoreanStriderRelicTile>();
    }
}
