using InfernalEclipseAPI.Content.Tiles.Trophies;

namespace InfernalEclipseAPI.Content.Items.Placeables.Trophies
{
    public class TerraBladeTrophy : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<TerraBladeTrophyTile>(), 0);
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Blue;
        }
    }
}
