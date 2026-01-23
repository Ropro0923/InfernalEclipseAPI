using System.Collections.Generic;
using CalamityMod;
using InfernumMode;
using InfernumMode.Content.Rarities.InfernumRarities;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace InfernalEclipseAPI.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    public class PhantomSuitPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 32;
            Item.value = 10000;
            Item.rare = ModContent.RarityType<InfernumRedSparkRarity>();
            if (ModLoader.TryGetMod("NoxusBoss", out Mod noxus))
            {
                ModRarity r;
                noxus.TryFind("NamelessDeityRarity", out r);
                Item.rare = r.Type;
            }
            Item.vanity = true;

            Item.Infernum_Tooltips().DeveloperItem = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Color color = CalamityUtils.ColorSwap(Color.OrangeRed, Color.DarkRed, 2f);

            TooltipLine dedTo = new TooltipLine(Mod, "Dedicated", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.DedTo", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.Dedicated.Akira")));
            dedTo.OverrideColor = color;
            CalamityUtils.HoldShiftTooltip(tooltips, new TooltipLine[] { dedTo });
        }
    }
}
