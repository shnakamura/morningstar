using Morningstar.Content.Walls.Inferno;

namespace Morningstar.Content.Items.Inferno;

public class TorchstoneWallItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableWall(ModContent.WallType<TorchstoneWall>());

        Item.width = 24;
        Item.height = 24;
    }
    
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe(4)
            .AddIngredient<TorchstoneItem>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}