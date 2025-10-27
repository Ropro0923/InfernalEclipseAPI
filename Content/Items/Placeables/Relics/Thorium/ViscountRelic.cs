using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class ViscountRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Viscount Relic";

        public override int TileID => ModContent.TileType <ViscountRelicTile>();
    }
}
