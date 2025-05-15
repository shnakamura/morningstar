using Morningstar.Common.Moise;
using Morningstar.Content.Tiles.Inferno;
using Morningstar.Content.Walls.Inferno;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace Morningstar.Content.Subworlds.Inferno;

public sealed class TerrainPass(string name, float weight) : GenPass(name, weight)
{
    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        GenerateTerrain(progress);
        GenerateCraters(progress);
        
        GenerateDirt(progress);
    }

    private static void GenerateDirt(GenerationProgress progress)
    {
        // TODO: Localize.
        progress.Message = "Generating dirt blotches...";
        
        var count = 20;

        for (var i = 0; i < count; i++)
        {
            if (i == 4 || i == 5)
            {
                continue;
            }

            var radius = WorldGen.genRand.Next(6, 13);

            var spacing = Main.maxTilesX / (count + 1);

            var x = spacing * (i + 1);
            var y = 0;

            for (var j = 0; j < Main.maxTilesY - 10; j++)
            {
                if (!WorldGen.SolidTile(x, j))
                {
                    continue;
                }

                y = j;

                break;
            }

            var origin = new Point(x, y) + new Point(WorldGen.genRand.Next(-2, 3), WorldGen.genRand.Next(-2, 3));
            
            WorldUtils.Gen
            (
                origin,
                new Shapes.Circle(radius),
                Actions.Chain
                (
                    new Modifiers.OnlyTiles((ushort)ModContent.TileType<TorchstoneTile>(), (ushort)ModContent.TileType<TorchslagTile>(), (ushort)ModContent.TileType<SingestoneTile>()),
                    new Modifiers.RadialDither(radius / 4f, radius),
                    new Modifiers.Blotches(),
                    new Actions.SetTile(TileID.Dirt)
                )
            );
            
            WorldUtils.Gen
            (
                origin,
                new Shapes.Circle(radius),
                Actions.Chain
                (
                    new Modifiers.OnlyTiles(TileID.Dirt),
                    new Modifiers.IsTouchingAir(true),
                    new Modifiers.Blotches(),
                    new Actions.SetTile((ushort)ModContent.TileType<InfernoGrassTile>())
                )
            );
        }
    }
    
    private static void GenerateTerrain(GenerationProgress progress)
    {
        // TODO: Localize.
        progress.Message = "Scorching the Inferno...";
        
        var baseNoise = new FastNoiseLite();
        
        baseNoise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        baseNoise.SetSeed(WorldGen.genRand.Next());
        baseNoise.SetFrequency(0.01f);

        var detailNoise = new FastNoiseLite();
        
        detailNoise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        detailNoise.SetSeed(WorldGen.genRand.Next());
        detailNoise.SetFrequency(0.1f);

        var surfaceMin = (int)(Main.maxTilesY * 0.2f);
        var surfaceMax = (int)(Main.maxTilesX * 0.25f);

        for (var x = 0; x < Main.maxTilesX; x++)
        {
            var baseHeight = baseNoise.GetNoise(x, 0) * 20f;
            var detailHeight = detailNoise.GetNoise(x, 0) * 6f;

            var height = Utils.Clamp((int)((surfaceMin + surfaceMax) / 2f + baseHeight + detailHeight), surfaceMin, surfaceMax);
           
            for (var y = height; y < Main.maxTilesY; y++)
            {
                WorldGen.PlaceTile(x, y, ModContent.TileType<TorchstoneTile>(), true, true);
            }
            
            progress.Set(x / (float)Main.maxTilesX);
        }
    }

    private static void GenerateCraters(GenerationProgress progress)
    {
        // TODO: Localize.
        progress.Message = "Creating craters...";
        
        var count = 10;

        for (var i = 0; i < count; i++)
        {
            if (i == 4 || i == 5)
            {
                continue;
            }
            
            var radius = WorldGen.genRand.Next(6, 13);

            var spacing = Main.maxTilesX / (count + 1);
            
            var x = spacing * (i + 1);
            var y = 0;
            
            for (var j = 0; j < Main.maxTilesY - 10; j++)
            {
                if (!WorldGen.SolidTile(x, j))
                {
                    continue;
                }
                
                y = j;

                break;
            }

            var origin = new Point(x, y) + new Point(WorldGen.genRand.Next(-2, 3), WorldGen.genRand.Next(-2, 3));
           
            var midRadius = radius + radius / 2;
            var outerRadius = radius + radius;
            
            WorldUtils.Gen
            (
                origin,
                new Shapes.Circle(radius),
                Actions.Chain
                (
                    new Modifiers.RadialDither(radius / 2f, radius),
                    new Modifiers.Blotches(),
                    new Actions.ClearTile(true),
                    new Actions.ClearWall(true)
                )
            );
            
            WorldUtils.Gen
            (
                origin,
                new Shapes.Circle(midRadius),
                Actions.Chain
                (
                    new Modifiers.Dither(0.25f),
                    new Modifiers.Blotches(3),
                    new Modifiers.OnlyTiles((ushort)ModContent.TileType<TorchstoneTile>()),
                    new Actions.SetTile((ushort)ModContent.TileType<TorchslagTile>())
                )
            );

            WorldUtils.Gen
            (
                origin,
                new Shapes.Circle(outerRadius),
                Actions.Chain
                (
                    new Modifiers.Dither(0.25f),
                    new Modifiers.Blotches(),
                    new Modifiers.OnlyTiles((ushort)ModContent.TileType<TorchstoneTile>()),
                    new Actions.SetTile((ushort)ModContent.TileType<SingestoneTile>())
                )
            );

            for (var j = 0; j < 10; j++)
            {
                var bushOffset = WorldGen.genRand.Next(-15, 15);
                var bushSteps = WorldGen.genRand.Next(50, 100);
                
                WorldUtils.Gen
                (
                    origin + new Point(bushOffset, radius),
                    new ShapeFloodFill(bushSteps),
                    Actions.Chain
                    (
                        new Modifiers.Dither(0.1),
                        new Modifiers.Blotches(1),
                        new Actions.PlaceWall((ushort)ModContent.WallType<TorchstoneWall>())
                    )
                );
            }
            
            var tunnelData = new ShapeData();
            
            var tunnelOffset = WorldGen.genRand.Next(-5, 5);
            var tunnelDepth = WorldGen.genRand.Next(60, 80);

            WorldUtils.Gen
            (
                origin + new Point(tunnelOffset, 0),
                new Shapes.Rectangle(1, tunnelDepth),
                Actions.Chain
                (
                    new Modifiers.Blotches(2, 0.2),
                    new Actions.ClearTile().Output(tunnelData),
                    new Modifiers.Expand(1),
                    new Modifiers.OnlyTiles((ushort)ModContent.TileType<TorchstoneTile>()),
                    new Actions.SetTile((ushort)ModContent.TileType<SingestoneTile>()).Output(tunnelData),
                    new Actions.PlaceWall((ushort)ModContent.WallType<TorchstoneWall>())
                )
            );
                        
            WorldUtils.Gen
            (
                origin,
                new Shapes.Circle(radius),
                Actions.Chain
                (
                    new Modifiers.OnlyTiles((ushort)ModContent.TileType<TorchstoneTile>(), (ushort)ModContent.TileType<TorchslagTile>(), (ushort)ModContent.TileType<SingestoneTile>()),
                    new Modifiers.RadialDither(radius / 4f, radius),
                    new Modifiers.Blotches(),
                    new Actions.SetTile(TileID.Dirt)
                )
            );
            
            WorldUtils.Gen
            (
                origin,
                new Shapes.Circle(radius),
                Actions.Chain
                (
                    new Modifiers.OnlyTiles(TileID.Dirt),
                    new Modifiers.IsTouchingAir(true),
                    new Modifiers.Blotches(),
                    new Actions.SetTile((ushort)ModContent.TileType<InfernoGrassTile>())
                )
            );
            
            progress.Set(i / (float)count);
        }
    }
}