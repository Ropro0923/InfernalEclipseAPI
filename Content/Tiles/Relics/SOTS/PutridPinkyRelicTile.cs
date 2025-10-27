using InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class PutridPinkyRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<PutridPinkyRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/SOTS/PutridPinkyRelicTile";
    }
}
