using Morningstar.Content.Tiles.Inferno;

namespace Morningstar.Content.Biomes.Inferno;

public sealed class InfernoBiomeSystem : ModSystem
{
    /// <summary>
    ///     Gets or sets how many tiles from the Inferno are nearby the player.
    /// </summary>
    public static int TileCount { get; private set; }

    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
    {
        base.TileCountsAvailable(tileCounts);

        TileCount = tileCounts[ModContent.TileType<TorchstoneTile>()] +
                    tileCounts[ModContent.TileType<TorchslagTile>()] +
                    tileCounts[ModContent.TileType<SingestoneTile>()] +
                    tileCounts[ModContent.TileType<InfernoGrassTile>()];
    }
}