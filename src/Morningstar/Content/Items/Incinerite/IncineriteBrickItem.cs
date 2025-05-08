using Morningstar.Content.Tiles.Incinerite;

namespace Morningstar.Content.Items.Incinerite;

public class IncineriteBrickItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<IncineriteBrickTile>());

        Item.width = 16;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        base.AddRecipes();
        
        CreateRecipe(5)
            .AddRecipeGroup(ItemID.StoneBlock, 5)
            .AddTile(TileID.Furnaces)
            .Register();
        
        CreateRecipe(5)
            .AddIngredient<IncineriteBrickWallItem>(4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}