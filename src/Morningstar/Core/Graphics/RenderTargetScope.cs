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
    private readonly GraphicsDevice device;

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