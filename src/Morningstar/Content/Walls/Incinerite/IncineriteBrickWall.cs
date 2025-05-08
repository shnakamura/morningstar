namespace Morningstar.Content.Walls.Incinerite;

public class IncineriteBrickWall : ModWall
{
    /// <summary>
    ///     The map color of the wall.
    /// </summary>
    public static readonly Color Color = new(164, 111, 26);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.wallHouse[Type] = true;

        AddMapEntry(Color);
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}