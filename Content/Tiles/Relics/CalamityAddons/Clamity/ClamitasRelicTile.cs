using InfernalEclipseAPI.Content.Items.Placeables.Relics.CalamityAddons.Clamity;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class ClamitasRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<ClamitasRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/CalamityAddons/Clamity/ClamitasRelicTile";
    }
}
