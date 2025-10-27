using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS
{
    public class GlowmothRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Glowmoth Relic";

        public override int TileID => ModContent.TileType<GlowmothRelicTile>();
    }
}
