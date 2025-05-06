using Morningstar.Content.Walls.Razewood;

namespace Morningstar.Content.Items.Razewood;

public class AncientRazewoodWallItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.DefaultToPlaceableWall(ModContent.WallType<AncientRazewoodWall>());

        Item.width = 24;
        Item.height = 24;
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe(4)
            .AddIngredient<AncientRazewoodItem>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}