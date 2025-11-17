using InfernalEclipseAPI.Content.Tiles.Relics.FargosSouls;
using InfernumMode.Content.Items.Relics;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using InfernalEclipseAPI.Core.Systems;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.FargosSouls
{
    [JITWhenModsEnabled(InfernalCrossmod.FargosSouls.Name)]
    [ExtendsFromMod(InfernalCrossmod.FargosSouls.Name)]
    public class EridanusRelic : BaseRelicItem
    {
        public override bool IsLoadingEnabled(Mod mod) => InfernalConfig.Instance.DontEnableThis;
        public override string DisplayNameToUse => "Infernal Eridanus, Champion of Cosmos Relic";

        public override int TileID => ModContent.TileType<EridanusRelicTile>();

        public override Color? PersonalMessageColor => Color.Plum;

        public override string PersonalMessage => Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.EridanusRelic");
    }
}
