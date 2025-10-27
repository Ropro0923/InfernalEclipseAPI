using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class StarScouterRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Star Scouter Relic";

        public override int TileID => ModContent.TileType <StarScouterRelicTile>();
    }
}
