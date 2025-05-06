namespace Morningstar.Content.Tiles.Inferno.Razewood;

public class AncientRazewoodTile : ModTile
{
    /// <summary>
    ///     The map color of the tile.
    /// </summary>
    public static readonly Color Color = new(86, 76, 58);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        
        AddMapEntry(Color);
        
        HitSound = SoundID.Dig;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}