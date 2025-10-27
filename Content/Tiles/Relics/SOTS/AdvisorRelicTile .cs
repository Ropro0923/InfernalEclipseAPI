using InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class AdvisorRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<AdvisorRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/SOTS/AdvisorRelicTile";
    }
}
