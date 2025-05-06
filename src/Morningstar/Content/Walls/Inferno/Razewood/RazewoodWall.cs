namespace Morningstar.Content.Walls.Inferno.Razewood;

public class RazewoodWall : ModWall
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.wallHouse[Type] = true;
        
        // TODO: Add map color
        AddMapEntry(new Color());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}