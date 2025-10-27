using InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class LuxRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<LuxRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/SOTS/LuxRelicTile";
    }
}
