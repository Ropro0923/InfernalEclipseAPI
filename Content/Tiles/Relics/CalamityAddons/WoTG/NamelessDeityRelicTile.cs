using InfernalEclipseAPI.Content.Items.Placeables.Relics.CalamityAddons.WoTG;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.CalamityAddons.WoTG
{
    public class NamelessDeityRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<NamelessDeityRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/CalamityAddons/WoTG/NamelessDeityRelicTile";
    }
}
