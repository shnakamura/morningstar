using Morningstar.Content.Walls.Incinerite;

namespace Morningstar.Content.Items.Incinerite;

public class IncineriteBrickWallItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableWall(ModContent.WallType<IncineriteBrickWall>());
        
        Item.width = 24;
        Item.height = 24;
    }
    
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe(4)
            .AddIngredient<IncineriteBrickItem>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}