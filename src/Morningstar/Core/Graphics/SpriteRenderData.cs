namespace Morningstar.Core.Graphics;

public readonly struct SpriteRenderData(in Sprite sprite, in SpriteBatchParameters? parameters = null)
{
    /// <summary>
    ///     Gets the sprite to render.
    /// </summary>
    public readonly Sprite Sprite = sprite;

    /// <summary>
    ///     Gets the parameters to render the sprite with.
    /// </summary>
    /// <value>
    ///     Defaults to <see cref="SpriteBatchParameters.Default" /> if not specified.
    /// </value>
    public readonly SpriteBatchParameters Parameters = parameters ?? SpriteBatchParameters.Default;
}