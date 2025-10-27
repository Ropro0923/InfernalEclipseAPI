using InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class SubspaceSerpentRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<SubspaceSerpentRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/SOTS/SubspaceSerpentRelicTile";
    }
}
