using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Summon;

namespace InfernalEclipseAPI.Common.Balance.Calamity
{
    public class NerfedSummonWeaponRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int index = 0; index < Recipe.numRecipes; ++index)
            {
                Recipe recipe = Main.recipe[index];
                if (recipe.HasResult(ItemID.SlimeStaff))
                    recipe.AddIngredient(ItemID.Emerald);
                if (recipe.HasResult(ModContent.ItemType<SquirrelSquireStaff>()))
                    recipe.AddIngredient(ItemID.Squirrel);
                if (recipe.HasResult(ModContent.ItemType<WulfrumController>()))
                {
                    recipe.requiredItem.Clear();
                    recipe.AddIngredient(ModContent.ItemType<WulfrumMetalScrap>(), 20);
                    recipe.AddIngredient(ModContent.ItemType<EnergyCore>(), 3);
                }
            }
        }
    }
}
