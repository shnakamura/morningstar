namespace Morningstar.Content.Tiles.Inferno;

public class SingestoneTile : ModTile
{
    /// <summary>
    ///     The map color of the tile.
    /// </summary>
    public static readonly Color Color = new(88, 77, 68);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;

        Main.tileMerge[Type][ModContent.TileType<TorchslagTile>()] = true;
        Main.tileMerge[Type][ModContent.TileType<TorchstoneTile>()] = true;
        
        AddMapEntry(Color);

        HitSound = SoundID.Tink;
        MineResist = 0.5f;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}