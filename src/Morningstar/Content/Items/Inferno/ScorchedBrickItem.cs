using Morningstar.Content.Tiles.Inferno;

namespace Morningstar.Content.Items.Inferno;

public class ScorchedBrickItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<ScorchedBrickTile>());

        Item.width = 16;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient<TorchslagItem>(2)
            .AddTile(TileID.Furnaces)
            .Register();
        
        CreateRecipe()
            .AddIngredient<TorchstoneItem>(2)
            .AddTile(TileID.Furnaces)
            .Register();
        
        CreateRecipe()
            .AddIngredient<SingestoneItem>(2)
            .AddTile(TileID.Furnaces)
            .Register();
        
        CreateRecipe()
            .AddIngredient<TorchstoneWallItem>(4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}