using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Consolaria
{
    public class OcramRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Ocram Relic";

        public override int TileID => ModContent.TileType<OcramRelicTile>();
    }
}
