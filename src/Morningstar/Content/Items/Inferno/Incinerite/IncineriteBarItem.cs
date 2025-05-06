using Morningstar.Content.Tiles.Inferno.Incinerite;

namespace Morningstar.Content.Items.Inferno.Incinerite;

public class IncineriteBarItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<IncineriteBarTile>());

        Item.width = 30;
        Item.height = 24;

        Item.rare = ItemRarityID.Green;

        Item.value = Item.sellPrice(silver: 20);
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient<IncineriteOreItem>(4)
            .AddTile(TileID.Furnaces)
            .Register();
    }
}