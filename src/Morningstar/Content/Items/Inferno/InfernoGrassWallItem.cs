using Morningstar.Content.Walls.Inferno;

namespace Morningstar.Content.Items.Inferno;

public class InfernoGrassWallItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableWall(ModContent.WallType<InfernoGrassWall>());
        
        Item.width = 24;
        Item.height = 24;
    }
}