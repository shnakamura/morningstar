namespace Morningstar.Content.Tiles.Incinerite;

public class IncineriteBrickTile : ModTile
{
    /// <summary>
    ///     The map color of the tile.
    /// </summary>
    public static readonly Color Color = new(237, 161, 38);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        
        AddMapEntry(Color);

        HitSound = SoundID.Tink;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}