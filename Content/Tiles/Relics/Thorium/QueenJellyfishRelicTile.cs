using InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class QueenJellyfishRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<QueenJellyfishRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Thorium/QueenJellyfishRelicTile";
    }
}
