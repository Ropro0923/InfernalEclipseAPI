using InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class PolarisRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<PolarisRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/SOTS/PolarisRelicTile";
    }
}
