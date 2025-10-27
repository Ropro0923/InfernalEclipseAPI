using InfernalEclipseAPI.Content.Tiles.Relics.FargosSouls;
using InfernalEclipseAPI.Core.Systems;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.FargosSouls
{
    [JITWhenModsEnabled(InfernalCrossmod.FargosSouls.Name)]
    [ExtendsFromMod(InfernalCrossmod.FargosSouls.Name)]
    public class DeathChampionRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Champion of Death Relic";

        public override int TileID => ModContent.TileType<DeathChampionRelicTile>();
    }
}
