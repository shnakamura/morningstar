using Terraria.Localization;
using Terraria.ObjectData;

namespace Morningstar.Content.Tiles.Incinerite;

public class IncineriteBarTile : ModTile
{
    /// <summary>
    ///     The map color of the tile.
    /// </summary>
    public static readonly Color Color = new(237, 161, 38);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileShine[Type] = 1100;
        
        Main.tileSolid[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        
        TileObjectData.addTile(Type);
        
        AddMapEntry(Color, Language.GetText("MapObject.MetalBar"));
        
        HitSound = SoundID.Tink;
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}