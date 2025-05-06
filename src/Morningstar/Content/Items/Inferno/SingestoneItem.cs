using Morningstar.Content.Tiles.Inferno;

namespace Morningstar.Content.Items.Inferno;

public class SingestoneItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<SingestoneTile>());

        Item.width = 16;
        Item.height = 16;
    }
}