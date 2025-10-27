using InfernalEclipseAPI.Content.Items.Placeables.Relics.CalamityAddons;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class GoozmaRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<GoozmaRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/CalamityAddons/GoozmaRelicTile";
    }
}
