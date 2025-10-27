using InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class ForgottenOneRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<ForgottenOneRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Thorium/ForgottenOneRelicTile";
    }
}
