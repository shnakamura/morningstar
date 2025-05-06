using Morningstar.Content.Tiles.Razewood;

namespace Morningstar.Content.Items.Razewood;

public class AncientRazewoodItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.DefaultToPlaceableTile(ModContent.TileType<AncientRazewoodTile>());

        Item.width = 18;
        Item.height = 24;
    }

    public override void AddRecipes()
    {
        base.AddRecipes();
        
        CreateRecipe()
            .AddIngredient<AncientRazewoodWallItem>(4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}