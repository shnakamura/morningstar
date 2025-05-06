using Morningstar.Content.Tiles.Razewood;

namespace Morningstar.Content.Items.Razewood;

public class RazewoodItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<RazewoodTile>());

        Item.width = 18;
        Item.height = 24;
    }
    
    public override void AddRecipes()
    {
        base.AddRecipes();
        
        CreateRecipe()
            .AddIngredient<RazewoodWallItem>(4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}