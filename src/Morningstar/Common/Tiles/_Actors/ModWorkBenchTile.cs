using Terraria.DataStructures;
using Terraria.ObjectData;

namespace Morningstar.Common.Tiles;

public abstract class ModWorkBenchTile : ModTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileTable[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileFrameImportant[Type] = true;

        Main.tileSolid[Type] = false;
        Main.tileSolidTop[Type] = true;
        
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Height = 1;

        TileObjectData.newTile.CoordinateHeights = [16];

        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        
        TileObjectData.newTile.Origin = Point16.Zero;

        TileObjectData.newTile.UsesCustomCanPlace = true;
        
        TileObjectData.addTile(Type);
        
        AdjTiles = [TileID.WorkBenches];

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
    }    
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}