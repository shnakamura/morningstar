namespace Morningstar.Content.Walls.Inferno;

public class InfernoGrassWall : ModWall
{
    /// <summary>
    ///     The map color of the wall.
    /// </summary>
    public static readonly Color Color = new(61, 57, 31);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        AddMapEntry(Color);
    }

    public override bool Drop(int i, int j, ref int type)
    {
        return false;
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}