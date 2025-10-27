using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Consolaria
{
    public class LepusRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Lepus Relic";

        public override int TileID => ModContent.TileType<LepusRelicTile>();
    }
}
