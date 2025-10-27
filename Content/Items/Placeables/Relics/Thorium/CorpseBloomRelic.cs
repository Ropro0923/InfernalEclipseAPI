using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class CorpseBloomRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Corpse Bloom Relic";

        public override int TileID => ModContent.TileType<CorpseBloomRelicTile>();
    }
}
