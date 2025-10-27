using InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class BoreanStriderRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<BoreanStriderRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Thorium/BoreanStriderRelicTile";
    }
}
