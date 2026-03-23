namespace Morningstar.Core.Graphics;

/// <summary>
///     Provides <see cref="SpriteBatchParameters"/> extension methods.
/// </summary>
public static class SpriteBatchParametersExtensions
{
    /// <summary>
    ///     Returns a copy of the specified <see cref="SpriteBatchParameters"/> with a different <see cref="SpriteSortMode"/>.
    /// </summary>
    /// <param name="parameters">The source <see cref="SpriteBatchParameters"/>.</param>
    /// <param name="spriteSortMode">The <see cref="SpriteSortMode"/> to use in the returned instance.</param>
    /// <returns>A new <see cref="SpriteBatchParameters"/> with the updated <see cref="SpriteSortMode"/> value.</returns>
    public static SpriteBatchParameters WithSpriteSortMode(this SpriteBatchParameters parameters, SpriteSortMode spriteSortMode)
    {
        return new SpriteBatchParameters
        (
            spriteSortMode,
            parameters.BlendState,
            parameters.SamplerState,
            parameters.DepthStencilState,
            parameters.RasterizerState,
            parameters.Effect,
            parameters.TransformMatrix
        );
    }

    /// <summary>
    ///     Returns a copy of the specified <see cref="SpriteBatchParameters"/> with a different <see cref="BlendState"/>.
    /// </summary>
    /// <param name="parameters">The source <see cref="SpriteBatchParameters"/>.</param>
    /// <param name="blendState">The <see cref="BlendState"/> to use in the returned instance.</param>
    /// <returns>A new <see cref="SpriteBatchParameters"/> with the updated <see cref="BlendState"/> value.</returns>
    public static SpriteBatchParameters WithBlendState(this SpriteBatchParameters parameters, BlendState blendState)
    {
        return new SpriteBatchParameters
        (
            parameters.SpriteSortMode,
            blendState,
            parameters.SamplerState,
            parameters.DepthStencilState,
            parameters.RasterizerState,
            parameters.Effect,
            parameters.TransformMatrix
        );
    }

    /// <summary>
    ///     Returns a copy of the specified <see cref="SpriteBatchParameters"/> with a different <see cref="SamplerState"/>.
    /// </summary>
    /// <param name="parameters">The source <see cref="SpriteBatchParameters"/>.</param>
    /// <param name="samplerState">The <see cref="SamplerState"/> to use in the returned instance.</param>
    /// <returns>A new <see cref="SpriteBatchParameters"/> with the updated <see cref="SamplerState"/> value.</returns>
    public static SpriteBatchParameters WithSamplerState(this SpriteBatchParameters parameters, SamplerState samplerState)
    {
        return new SpriteBatchParameters
        (
            parameters.SpriteSortMode,
            parameters.BlendState,
            samplerState,
            parameters.DepthStencilState,
            parameters.RasterizerState,
            parameters.Effect,
            parameters.TransformMatrix
        );
    }

    /// <summary>
    ///     Returns a copy of the specified <see cref="SpriteBatchParameters"/> with a different <see cref="DepthStencilState"/>.
    /// </summary>
    /// <param name="parameters">The source <see cref="SpriteBatchParameters"/>.</param>
    /// <param name="depthStencilState">The <see cref="DepthStencilState"/> to use in the returned instance.</param>
    /// <returns>A new <see cref="SpriteBatchParameters"/> with the updated <see cref="DepthStencilState"/> value.</returns>
    public static SpriteBatchParameters WithDepthStencilState(this SpriteBatchParameters parameters, DepthStencilState depthStencilState)
    {
        return new SpriteBatchParameters
        (
            parameters.SpriteSortMode,
            parameters.BlendState,
            parameters.SamplerState,
            depthStencilState,
            parameters.RasterizerState,
            parameters.Effect,
            parameters.TransformMatrix
        );
    }

    /// <summary>
    ///     Returns a copy of the specified <see cref="SpriteBatchParameters"/> with a different <see cref="RasterizerState"/>.
    /// </summary>
    /// <param name="parameters">The source <see cref="SpriteBatchParameters"/>.</param>
    /// <param name="rasterizerState">The <see cref="RasterizerState"/> to use in the returned instance.</param>
    /// <returns>A new <see cref="SpriteBatchParameters"/> with the updated <see cref="RasterizerState"/> value.</returns>
    public static SpriteBatchParameters WithRasterizerState(this SpriteBatchParameters parameters, RasterizerState rasterizerState)
    {
        return new SpriteBatchParameters
        (
            parameters.SpriteSortMode,
            parameters.BlendState,
            parameters.SamplerState,
            parameters.DepthStencilState,
            rasterizerState,
            parameters.Effect,
            parameters.TransformMatrix
        );
    }

    /// <summary>
    ///     Returns a copy of the specified <see cref="SpriteBatchParameters"/> with a different <see cref="Effect"/>.
    /// </summary>
    /// <param name="parameters">The source <see cref="SpriteBatchParameters"/>.</param>
    /// <param name="effect">The <see cref="Effect"/> to use in the returned instance.</param>
    /// <returns>A new <see cref="SpriteBatchParameters"/> with the updated <see cref="Effect"/> value.</returns>
    public static SpriteBatchParameters WithEffect(this SpriteBatchParameters parameters, Effect effect)
    {
        return new SpriteBatchParameters
        (
            parameters.SpriteSortMode,
            parameters.BlendState,
            parameters.SamplerState,
            parameters.DepthStencilState,
            parameters.RasterizerState,
            effect,
            parameters.TransformMatrix
        );
    }

    /// <summary>
    ///     Returns a copy of the specified <see cref="SpriteBatchParameters"/> with a different <see cref="Matrix"/>.
    /// </summary>
    /// <param name="parameters">The source <see cref="SpriteBatchParameters"/>.</param>
    /// <param name="transformMatrix">The <see cref="Matrix"/> to use in the returned instance.</param>
    /// <returns>A new <see cref="SpriteBatchParameters"/> with the updated <see cref="Matrix"/> value.</returns>
    public static SpriteBatchParameters WithTransformMatrix(this SpriteBatchParameters parameters, in Matrix transformMatrix)
    {
        return new SpriteBatchParameters
        (
            parameters.SpriteSortMode,
            parameters.BlendState,
            parameters.SamplerState,
            parameters.DepthStencilState,
            parameters.RasterizerState,
            parameters.Effect,
            transformMatrix
        );
    }
}