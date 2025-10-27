using InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class PrimordialsRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<PrimordialsRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Thorium/PrimordialsRelicTile";
    }
}
