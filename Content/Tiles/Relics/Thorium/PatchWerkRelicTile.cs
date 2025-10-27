using InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class PatchWerkRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<PatchWerkRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Thorium/PatchWerkRelicTile";
    }
}
