namespace Morningstar.Core.Graphics;

/// <summary>
///     Represents a scope that temporarily changes the current render target of a
///     <see cref="GraphicsDevice" /> and restores it upon disposal.
/// </summary>
/// <remarks>
///     When constructed, this structure stores the current render target bindings and sets a new
///     <see cref="RenderTarget2D" />. When disposed, it restores the previous render target bindings.
/// </remarks>
public readonly struct RenderTargetScope : IDisposable
{
    /// <summary>
    ///     The <see cref="GraphicsDevice" /> whose state is being changed by the scope.
    /// </summary>
    private readonly GraphicsDevice device;

    /// <summary>
    ///     The previous render target bindings of the <see cref="GraphicsDevice" /> before the new render
    ///     target was set.
    /// </summary>
    /// <value>
    ///     If the <see cref="GraphicsDevice" /> was not bound to any render target before setting the new
    ///     render target, this will be <see langword="null" />; otherwise, it contains the previous render
    ///     target bindings.
    /// </value>
    private readonly RenderTargetBinding[] bindings;

    public RenderTargetScope(RenderTarget2D target, Color? color = null)
    {
        ArgumentNullException.ThrowIfNull(target, nameof(target));

        device = target.GraphicsDevice;
        bindings = device.GetRenderTargets();

        device.SetRenderTarget(target);

        if (!color.HasValue)
        {
            return;
        }

        device.Clear(color.Value);
    }

    public void Dispose()
    {
        if (bindings.Length > 0)
        {
            device.SetRenderTargets(bindings);
        }
        else
        {
            device.SetRenderTarget(null);
        }
    }
}