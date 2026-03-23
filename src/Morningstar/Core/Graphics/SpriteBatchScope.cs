namespace Morningstar.Core.Graphics;

/// <summary>
///     Represents a scope that temporarily changes the state of a <see cref="SpriteBatch" /> and
///     restores it upon disposal.
/// </summary>
/// <remarks>
///     When constructed, this structure ends the current <see cref="SpriteBatch" /> if one is active
///     and begins a new one with the specified <see cref="SpriteBatchParameters" />. When disposed,
///     it ends the current <see cref="SpriteBatch" /> if one is active, and restores the previous
///     state if one existed.
/// </remarks>
public readonly ref struct SpriteBatchScope : IDisposable
{
    private readonly bool restore;

    private readonly SpriteBatch spriteBatch;

    private readonly SpriteBatchParameters oldParameters;

    public SpriteBatchScope(SpriteBatch spriteBatch, in SpriteBatchParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(spriteBatch, nameof(spriteBatch));

        restore = spriteBatch.beginCalled;

        this.spriteBatch = spriteBatch;

        if (spriteBatch.beginCalled)
        {
            spriteBatch.End(out oldParameters);
        }

        spriteBatch.Begin(in parameters);
    }

    public void Dispose()
    {
        if (spriteBatch.beginCalled)
        {
            spriteBatch.End();
        }

        if (!restore)
        {
            return;
        }

        spriteBatch.Begin(in oldParameters);
    }
}