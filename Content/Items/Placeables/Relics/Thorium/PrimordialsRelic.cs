using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class PrimordialsRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Primordials Relic";

        public override int TileID => ModContent.TileType<PrimordialsRelicTile>();
    }
}
