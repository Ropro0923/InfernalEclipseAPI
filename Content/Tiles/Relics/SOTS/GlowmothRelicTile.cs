using InfernalEclipseAPI.Content.Items.Placeables.Relics.SOTS;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class GlowmothRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<GlowmothRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/SOTS/GlowmothRelicTile";
    }
}
