using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS
{
    public class SubspaceSerpentRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Supspace Serpent Relic";

        public override int TileID => ModContent.TileType<SubspaceSerpentRelicTile>();
    }
}
