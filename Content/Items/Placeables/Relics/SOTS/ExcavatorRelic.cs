using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS
{
    public class ExcavatorRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Excavator Relic";

        public override int TileID => ModContent.TileType<ExcavatorRelicTile>();
    }
}
