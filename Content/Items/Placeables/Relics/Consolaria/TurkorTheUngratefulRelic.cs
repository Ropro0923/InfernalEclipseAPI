using InfernalEclipseAPI.Content.Tiles.Relics.Thorium;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.Consolaria
{
    public class TurkorTheUngratefulRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Turkor The Ungreateful Relic";

        public override int TileID => ModContent.TileType<TurkorTheUngratefulRelicTile>();
    }
}
