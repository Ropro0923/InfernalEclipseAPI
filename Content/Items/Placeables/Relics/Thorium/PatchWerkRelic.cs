using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class PatchWerkRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Patch Werk Relic";

        public override int TileID => ModContent.TileType <PatchWerkRelicTile>();
    }
}
