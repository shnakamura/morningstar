namespace Morningstar.Core.Graphics;

/// <summary>
///     Provides <see cref="SpriteBatch" /> extension methods for working with
///     <see cref="SpriteBatchScope" />.
/// </summary>
public static class SpriteBatchScopeExtensions
{
    /// <summary>
    ///     Creates a new <see cref="SpriteBatchScope" /> for the specified <see cref="SpriteBatch" /> and
    ///     provided <see cref="SpriteBatchParameters"/>.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch" /> to operate on.</param>
    /// <param name="parameters">The <see cref="SpriteBatchParameters" /> to use when beginning the scope.</param>
    /// <returns>
    ///     A <see cref="SpriteBatchScope" /> that begins a draw call with the specified parameters and
    ///     restores the previous state when disposed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="spriteBatch" /> is <see langword="null" />.
    /// </exception>
    public static SpriteBatchScope Scope(this SpriteBatch spriteBatch, in SpriteBatchParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(spriteBatch, nameof(spriteBatch));

        return new SpriteBatchScope(spriteBatch, in parameters);
    }
}