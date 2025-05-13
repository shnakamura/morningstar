using Terraria.Enums;
using Terraria.ObjectData;

namespace Morningstar.Common.Tiles;

public abstract class ModChairTile : ModTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileFrameImportant[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);

        TileObjectData.newTile.CoordinateHeights = [16, 18];
        
        TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
        
        TileObjectData.newTile.StyleWrapLimit = 2;
        TileObjectData.newTile.StyleMultiplier = 2;
        
        TileObjectData.newTile.StyleHorizontal = true;
        
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        
        TileObjectData.addAlternate(1);
        
        TileObjectData.addTile(Type);

        AdjTiles = [TileID.Chairs];
        
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}