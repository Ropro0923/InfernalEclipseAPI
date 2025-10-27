using InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class LichRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<LichRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Thorium/LichRelicTile";
    }
}
