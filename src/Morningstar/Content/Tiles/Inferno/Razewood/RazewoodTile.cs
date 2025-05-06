namespace Morningstar.Content.Tiles.Inferno.Razewood;

public class RazewoodTile : ModTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        
        // TODO: Add map color.
        AddMapEntry(new Color());
        
        HitSound = SoundID.Dig;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}