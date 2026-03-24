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
    /// <summary>
    ///     Whether the scope should restore the previous state of the <see cref="SpriteBatch" /> upon
    ///     disposal.
    /// </summary>
    private readonly bool restore;

    /// <summary>
    ///     The <see cref="SpriteBatch" /> whose state is being changed by the scope.
    /// </summary>
    private readonly SpriteBatch spriteBatch;

    /// <summary>
    ///     The previous parameters of the <see cref="SpriteBatch" /> before the new parameters were
    ///     set.
    /// </summary>
    /// <value>
    ///     If the <see cref="SpriteBatch" /> was not bound to any parameters before applying the new
    ///     parameters, this will be <see langword="default" />; otherwise, it contains the previous
    ///     parameters.
    /// </value>
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