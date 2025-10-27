using InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class PharohsCurseRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<PharohsCurseRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/SOTS/PharohsCurseRelicTile";
    }
}
