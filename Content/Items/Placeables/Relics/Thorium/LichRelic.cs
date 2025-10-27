using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class LichRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Lich Relic";

        public override int TileID => ModContent.TileType <LichRelicTile>();
    }
}
