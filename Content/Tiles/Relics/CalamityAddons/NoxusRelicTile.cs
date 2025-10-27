using InfernalEclipseAPI.Content.Items.Placeables.Relics.CalamityAddons;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class NoxusRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<NoxusRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/CalamityAddons/NoxusRelicTile";
    }
}
