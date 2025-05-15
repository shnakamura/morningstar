using Microsoft.Xna.Framework.Input;
using Morningstar.Content.Tiles.Inferno;
using Morningstar.Content.Walls.Inferno;
using SubworldLibrary;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace Morningstar.Content.Subworlds.Inferno;

public sealed class VolcanoPass(string name, float weight) : GenPass(name, weight)
{
    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        // TODO: Localize.
        progress.Message = "Generating the Volcano...";

        var origin = new Point(Main.maxTilesX / 2, Main.maxTilesY / 2);

        GenerateVolcano(in origin);
    }

    private static void GenerateVolcano(in Point origin)
    {
        GenerateChasm(in origin);
        GenerateEntrance(in origin);

        GenerateWalls(in origin);
    }

    private static void GenerateChasm(in Point origin)
    {
        WorldUtils.Gen
        (
            origin,
            new Shapes.Circle(128),
            Actions.Chain(new Modifiers.Blotches(), new Modifiers.Dither(0.1), new Actions.SetTile((ushort)ModContent.TileType<TorchstoneTile>()))
        );

        WorldUtils.Gen
        (
            origin,
            new Shapes.Circle(96),
            Actions.Chain(new Modifiers.Blotches(), new Modifiers.Dither(0.25), new Actions.SetTile((ushort)ModContent.TileType<SingestoneTile>()))
        );

        WorldUtils.Gen
        (
            origin,
            new Shapes.Circle(72),
            Actions.Chain(new Modifiers.Blotches(), new Modifiers.Dither(), new Actions.SetTile((ushort)ModContent.TileType<TorchslagTile>()))
        );

        WorldUtils.Gen
        (
            origin,
            new Shapes.Circle(48),
            new Actions.ClearTile()
        );

        WorldUtils.Gen
        (
            origin,
            new Shapes.Circle(64),
            Actions.Chain(new Modifiers.Blotches(), new Modifiers.Dither(0.75), new Actions.ClearTile())
        );
        
        WorldUtils.Gen
        (
            origin,
            new Shapes.Circle(128),
            Actions.Chain(new Modifiers.Blotches(), new Actions.PlaceWall((ushort)ModContent.WallType<TorchstoneWall>()))
        );
    }

    private static void GenerateEntrance(in Point origin)
    {
        WorldUtils.Gen
        (
            origin,
            new Shapes.Mound(32, 256),
            new Actions.ClearTile()
        );

        WorldUtils.Gen
        (
            origin,
            new Shapes.Mound(48, 256),
            Actions.Chain(new Modifiers.Blotches(), new Modifiers.Dither(0.75), new Actions.ClearTile())
        );
    }

    private static void GenerateWalls(in Point origin)
    {

    }
}

public sealed class TerrainSystem : ModSystem
{
    public override void PostUpdateEverything()
    {
        base.PostUpdateEverything();

        if (Main.keyState.IsKeyDown(Keys.F) && !Main.oldKeyState.IsKeyDown(Keys.F))
        {
            SubworldSystem.Enter<InfernoSubworld>();
        }
    }
}