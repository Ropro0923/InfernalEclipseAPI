using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium
{
    public class ForgottenOneRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Forgotten One Relic";

        public override int TileID => ModContent.TileType<ForgottenOneRelicTile>();
    }
}
