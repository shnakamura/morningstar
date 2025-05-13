using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace Morningstar.Common.Tiles;

public abstract class ModPianoTile : ModTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileFrameImportant[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        
        TileObjectData.newTile.Origin = new Point16(1, 1);
        
        TileObjectData.newTile.CoordinateHeights = [16, 16];
        
        TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
        
        TileObjectData.newTile.AnchorInvalidTiles = [127];
        
        TileObjectData.newTile.StyleHorizontal = true;
        
        TileObjectData.newTile.LavaDeath = false;
        
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      
        TileObjectData.addTile(Type);

        AdjTiles = [TileID.Pianos];
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}