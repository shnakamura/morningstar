using Morningstar.Content.Tiles.Incinerite;

namespace Morningstar.Content.Items.Incinerite;

public class IncineriteOreItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<IncineriteOreTile>());
        
        Item.width = 22;
        Item.height = 20;

        Item.rare = ItemRarityID.Green;

        Item.value = Item.sellPrice(silver: 5);
    }
}