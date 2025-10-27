using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class BurriedChampionRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Burried Champion Relic";

        public override int TileID => ModContent.TileType<BurriedChampionRelicTile>();
    }
}
