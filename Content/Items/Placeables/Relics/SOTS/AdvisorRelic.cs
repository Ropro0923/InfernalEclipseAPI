using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS
{
    public class AdvisorRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Advisor Relic";

        public override int TileID => ModContent.TileType<AdvisorRelicTile>();
    }
}
