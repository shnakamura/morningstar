namespace Morningstar.Content.Tiles.Inferno.Incinerite;

public class IncineriteOreTile : ModTile
{    
    /// <summary>
    ///     The map color of the tile.
    /// </summary>
    public static readonly Color Color = new(173, 77, 43);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        TileID.Sets.FriendlyFairyCanLureTo[Type] = true;
        TileID.Sets.Ore[Type] = true;
        
        // TODO: Maybe make some sort of constant lookup for metal detector values?
        Main.tileOreFinderPriority[Type] = 300;
        
        Main.tileShine[Type] = 1000; 
        Main.tileShine2[Type] = true;
        
        Main.tileSolid[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        
        AddMapEntry(Color, CreateMapEntryName());
        
        HitSound = SoundID.Tink;
        MineResist = 1f;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}