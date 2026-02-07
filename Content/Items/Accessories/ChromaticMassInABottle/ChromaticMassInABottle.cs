using Terraria.DataStructures;
using InfernumMode;
using CalamityMod.Rarities;

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
            Item.rare = ModContent.RarityType<BurnishedAuric>();
            Item.accessory = true;

            Item.Infernum_Tooltips().DeveloperItem = true;
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
