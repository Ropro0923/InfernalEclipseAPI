using InfernalEclipseAPI.Content.Items.Placeables.Relics.CalamityAddons.Clamity;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class WallofBronzeRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<WallofBronzeRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/CalamityAddons/Clamity/WallofBronzeRelicTile";
    }
}
