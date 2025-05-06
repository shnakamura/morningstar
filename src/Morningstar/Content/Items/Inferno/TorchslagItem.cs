using Morningstar.Content.Tiles.Inferno;

namespace Morningstar.Content.Items.Inferno;

public class TorchslagItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<TorchslagTile>());

        Item.width = 16;
        Item.height = 16;
    }
}