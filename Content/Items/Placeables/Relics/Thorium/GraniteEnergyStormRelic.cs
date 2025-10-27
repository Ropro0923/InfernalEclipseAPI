using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class GraniteEnergyStormRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Granite Energy Storm Relic";

        public override int TileID => ModContent.TileType <GraniteEnergyStormRelicTile>();
    }
}
