using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfernalEclipseAPI.Common.Balance.Calamity
{
    public class CalamityAmmoRecipeTweaks : ModSystem
    {
        public override void PostAddRecipes()
        {
            if (!ModLoader.TryGetMod("CalamityAmmo", out Mod ammo))
                return;

            if (!ammo.TryFind<ModItem>("AutoCalculationCoil", out ModItem autoCoil))
                return;

            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (!recipe.HasResult(autoCoil))
                    continue;

                // Reduce Suspicious Scrap to 1
                for (int j = 0; j < recipe.requiredItem.Count; j++)
                {
                    Item req = recipe.requiredItem[j];

                    if (req.type == ModContent.ItemType<SuspiciousScrap>())
                    {
                        req.stack = 1;
                    }
                }

                recipe.AddIngredient<AscendantSpiritEssence>(1);

                for (int j = recipe.requiredItem.Count - 1; j >= 0; j--)
                {
                    Item req = recipe.requiredItem[j];

                    if (req.type == ModContent.ItemType<PlasmaDriveCore>())
                    {
                        recipe.requiredItem.RemoveAt(j);
                    }
                }


                // Replace crafting tile
                recipe.requiredTile.Clear();
                recipe.AddTile(ModContent.TileType<CosmicAnvil>());

                // Done — only one recipe should match
                break;
            }
        }
    }
}
