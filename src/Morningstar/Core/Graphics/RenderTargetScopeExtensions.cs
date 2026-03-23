namespace Morningstar.Core.Graphics;

/// <summary>
///     Provides <see cref="RenderTarget2D" /> extension methods for working with
///     <see cref="RenderTargetScope" />.
/// </summary>
public static class RenderTargetScopeExtensions
{
    /// <summary>
    ///     Creates a new <see cref="RenderTargetScope" /> for the specified <see cref="RenderTarget2D" />.
    /// </summary>
    /// <param name="target">The <see cref="RenderTarget2D" /> to set as the current render target.</param>
    /// <param name="color">
    ///     An optional <see cref="Color" /> used to clear the render target. If <see langword="null" />,
    ///     the render target is not cleared.
    /// </param>
    /// <returns>
    ///     A <see cref="RenderTargetScope" /> that sets the specified render target and restores the
    ///     previous
    ///     render target bindings when disposed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="target" /> is <see langword="null" />.
    /// </exception>
    public static RenderTargetScope Scope(this RenderTarget2D target, Color? color = null)
    {
        ArgumentNullException.ThrowIfNull(target, nameof(target));

        return new RenderTargetScope(target, color);
    }
}