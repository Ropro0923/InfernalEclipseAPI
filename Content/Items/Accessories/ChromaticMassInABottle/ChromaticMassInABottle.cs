using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using InfernumMode;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod;

namespace InfernalEclipseAPI.Content.Items.Accessories.ChromaticMassInABottle
{
    internal class ChromaticMassInABottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(6, 5));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.value = Item.buyPrice(copper: 0);
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 1;
            if (ModLoader.TryGetMod("CalamityMod", out Mod cal))
            {
                ModRarity r;
                cal.TryFind("Violet", out r);
                Item.rare = r.Type;
            }

            Item.accessory = true;

            Item.Infernum_Tooltips().DeveloperItem = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Color color = CalamityUtils.ColorSwap(Color.OrangeRed, Color.DarkRed, 2f);

            TooltipLine dedTo = new TooltipLine(Mod, "Dedicated", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.DedTo", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.Dedicated.Yob")));
            dedTo.OverrideColor = color;
            CalamityUtils.HoldShiftTooltip(tooltips, new TooltipLine[] { dedTo });
        }

        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("CalamityHunt", out Mod calamityHunt) && calamityHunt.TryFind("ChromaticMass", out ModItem ChormaticMass))
            {
                CreateRecipe()
                    .AddIngredient(ChormaticMass.Type, 1)
                    .AddIngredient(ItemID.Bottle, 1)
                    .Register();
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ItemID.Bottle, 1)
                    .AddIngredient(ItemID.LunarBar, 1)
                    .Register();
            }
        }
    }
}
