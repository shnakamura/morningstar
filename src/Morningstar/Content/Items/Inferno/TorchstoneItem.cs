using Morningstar.Content.Tiles.Inferno;

namespace Morningstar.Content.Items.Inferno;

public class TorchstoneItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.DefaultToPlaceableTile(ModContent.TileType<TorchstoneTile>());

        Item.width = 16;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient<TorchstoneWallItem>(4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}