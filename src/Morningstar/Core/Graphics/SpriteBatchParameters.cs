namespace Morningstar.Core.Graphics;

/// <summary>
///     Represents the parameters used when beginning a <see cref="SpriteBatch" /> through
///     <see cref="SpriteBatch.Begin()" />.
/// </summary>
/// <remarks>
///     This structure encapsulates all rendering state required by <see cref="SpriteBatch.Begin()" />,
///     allowing configurations to be reused, cached, or passed around as a single value.
/// </remarks>
public readonly struct SpriteBatchParameters
{
    /// <summary>
    ///     Gets the default <see cref="SpriteBatchParameters" /> configuration.
    /// </summary>
    public static SpriteBatchParameters Default { get; } = new
    (
        SpriteSortMode.Deferred,
        BlendState.NonPremultiplied,
        SamplerState.PointClamp,
        DepthStencilState.Default,
        RasterizerState.CullNone,
        default,
        Main.Transform
    );
    
    /// <summary>
    ///     Gets the <see cref="SpriteSortMode"/> of the parameters.
    /// </summary>
    public SpriteSortMode SpriteSortMode { get; }

    /// <summary>
    ///     Gets the <see cref="BlendState"/> of the parameters.
    /// </summary>
    public BlendState BlendState { get; }

    /// <summary>
    ///     Gets the <see cref="SamplerState"/> of the parameters.
    /// </summary>
    public SamplerState SamplerState { get; }

    /// <summary>
    ///     Gets the <see cref="DepthStencilState"/> of the parameters.
    /// </summary>
    public DepthStencilState DepthStencilState { get; }

    /// <summary>
    ///     Gets the <see cref="RasterizerState"/> of the parameters.
    /// </summary>
    public RasterizerState RasterizerState { get; }

    /// <summary>
    ///     Gets the <see cref="Effect"/> of the parameters.
    /// </summary>
    public Effect Effect { get; }

    /// <summary>
    ///     Gets the <see cref="Matrix"/> used as the transform of the parameters.
    /// </summary>
    public Matrix TransformMatrix { get; }

    public SpriteBatchParameters
    (
        SpriteSortMode spriteSortMode,
        BlendState blendState,
        SamplerState samplerState,
        DepthStencilState depthStencilState,
        RasterizerState rasterizerState,
        Effect effect,
        in Matrix transformMatrix
    )
    {
        SpriteSortMode = spriteSortMode;
        BlendState = blendState;
        SamplerState = samplerState;
        DepthStencilState = depthStencilState;
        RasterizerState = rasterizerState;
        Effect = effect;
        TransformMatrix = transformMatrix;
    }

    public SpriteBatchParameters(SpriteBatch spriteBatch)
    {
        ArgumentNullException.ThrowIfNull(spriteBatch, nameof(spriteBatch));
        
        SpriteSortMode = spriteBatch.sortMode;
        BlendState = spriteBatch.blendState;
        SamplerState = spriteBatch.samplerState;
        DepthStencilState = spriteBatch.depthStencilState;
        RasterizerState = spriteBatch.rasterizerState;
        Effect = spriteBatch.customEffect;
        TransformMatrix = spriteBatch.transformMatrix;
    }
}