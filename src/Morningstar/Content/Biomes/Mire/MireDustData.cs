namespace Morningstar.Content.Biomes.Mire;

public readonly struct MireDustData
{
    /// <summary>
    ///     Gets the spawn position of the dust, in world coordinates.
    /// </summary>
    public Vector2 SpawnPosition { get; }

    /// <summary>
    ///     Gets the duration of the dust, in ticks.
    /// </summary>
    public int Duration { get; }
    
    public MireDustData(Vector2 spawnPosition, int duration)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(duration, nameof(duration));
        
        SpawnPosition = spawnPosition;
        Duration = duration;
    }
}