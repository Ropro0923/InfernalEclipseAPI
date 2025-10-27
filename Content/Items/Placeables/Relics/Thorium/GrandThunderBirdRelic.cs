using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class GrandThunderBirdRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Grand Thunder Bird Relic";

        public override int TileID => ModContent.TileType<GrandThunderBirdRelicTile>();
    }
}
