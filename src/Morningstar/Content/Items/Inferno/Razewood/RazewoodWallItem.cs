using Morningstar.Content.Walls.Inferno.Razewood;

namespace Morningstar.Content.Items.Inferno.Razewood;

public class RazewoodWallItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.DefaultToPlaceableWall(ModContent.WallType<RazewoodWall>());

        Item.width = 24;
        Item.height = 24;
    }
    
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe(4)
            .AddIngredient<RazewoodItem>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}