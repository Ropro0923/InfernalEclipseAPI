using InfernalEclipseAPI.Content.Tiles.Relics.FargosSouls;
using InfernumMode.Content.Items.Relics;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using InfernalEclipseAPI.Core.Systems;

namespace InfernalEclipseAPI.Content.Items.Placeables.Relics.FargosSouls
{
    [JITWhenModsEnabled(InfernalCrossmod.FargosSouls.Name)]
    [ExtendsFromMod(InfernalCrossmod.FargosSouls.Name)]
    public class DevianttRelic : BaseRelicItem
    {
        public override string DisplayNameToUse => "Infernal Deviantt Relic";

        public override int TileID => ModContent.TileType<DevianttRelicTile>();

        public override Color? PersonalMessageColor => Color.Pink;

        public override string PersonalMessage => Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.DeviRelic");
    }
}
