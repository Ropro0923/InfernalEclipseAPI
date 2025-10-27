using InfernalEclipseAPI.Content.Tiles.Relics.FargosSouls;
using InfernalEclipseAPI.Core.Systems;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.FargosSouls
{
    [JITWhenModsEnabled(InfernalCrossmod.FargosSouls.Name)]
    [ExtendsFromMod(InfernalCrossmod.FargosSouls.Name)]
    public class CursedCoffinRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Cursed Coffin Relic";

        public override int TileID => ModContent.TileType<CursedCoffinRelicTile>();
    }
}
