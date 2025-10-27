using InfernalEclipseAPI.Content.Items.Placeables.Relics.FargosSouls;
using InfernalEclipseAPI.Core.Systems;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.FargosSouls
{
    [JITWhenModsEnabled(InfernalCrossmod.FargosSouls.Name)]
    [ExtendsFromMod(InfernalCrossmod.FargosSouls.Name)]
    public class LifeChampionRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<LifeChampionRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/FargosSouls/LifeChampionRelicTile";
    }
}
