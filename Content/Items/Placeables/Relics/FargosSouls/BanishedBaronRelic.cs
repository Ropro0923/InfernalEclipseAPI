using InfernalEclipseAPI.Content.Tiles.Relics.FargosSouls;
using InfernalEclipseAPI.Core.Systems;
using InfernumMode.Content.Items.Relics;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.FargosSouls
{
    [JITWhenModsEnabled(InfernalCrossmod.FargosSouls.Name)]
    [ExtendsFromMod(InfernalCrossmod.FargosSouls.Name)]
    public class BanishedBaronRelic : BaseRelicItem
    {
        public override bool IsLoadingEnabled(Mod mod) => InfernalConfig.Instance.DontEnableThis;
        public override string DisplayNameToUse => "Infernal Banished Baron Relic";

        public override int TileID => ModContent.TileType<BanishedBaronRelicTile>();
    }
}
