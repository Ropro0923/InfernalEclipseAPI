using InfernalEclipseAPI.Content.Items.Placeables.Relics.CalamityAddons.Clamity;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class PyrogenRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<PyrogenRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/CalamityAddons/Clamity/PyrogenRelicTile";
    }
}
