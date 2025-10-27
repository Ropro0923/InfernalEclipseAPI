using InfernalEclipseAPI.Content.Items.Placeables.Relics.Consolaria;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class OcramRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<OcramRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Consolaria/OcramRelicTile";
    }
}
