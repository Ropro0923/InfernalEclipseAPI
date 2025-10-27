namespace InfernalEclipseAPI.Common.Balance.Calamity
{
    public class NerfedVanillaRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            if (ModContent.GetInstance<InfernalConfig>().CalamityBalanceChanges)
            {
                for (int index = 0; index < Recipe.numRecipes; ++index)
                {
                    Recipe recipe = Main.recipe[index];
                    if (recipe.HasResult(ItemID.LuckyHorseshoe))
                        recipe.AddIngredient(ItemID.SunplateBlock, 5);
                    if (recipe.HasResult(ItemID.CatBast))
                    {
                        recipe.RemoveIngredient(178);
                        recipe.AddIngredient(ItemID.Amber, 4);
                    }
                }
            }
        }
    }
}
