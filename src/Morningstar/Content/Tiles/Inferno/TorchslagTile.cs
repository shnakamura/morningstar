namespace Morningstar.Content.Tiles.Inferno;

public class TorchslagTile : ModTile
{
    /// <summary>
    ///     The map color of the tile.
    /// </summary>
    public static readonly Color Color = new(52, 43, 54);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        
        Main.tileMerge[Type][ModContent.TileType<SingestoneTile>()] = true;
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