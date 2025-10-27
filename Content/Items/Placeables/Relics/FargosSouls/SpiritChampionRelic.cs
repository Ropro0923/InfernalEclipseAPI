using InfernalEclipseAPI.Content.Tiles.Relics.FargosSouls;
using InfernalEclipseAPI.Core.Systems;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.FargosSouls
{
    [JITWhenModsEnabled(InfernalCrossmod.FargosSouls.Name)]
    [ExtendsFromMod(InfernalCrossmod.FargosSouls.Name)]
    public class SpiritChampionRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Champion of Spirit Relic";

        public override int TileID => ModContent.TileType<SpiritChampionRelicTile>();
    }
}
