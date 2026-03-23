using ReLogic.Content;

namespace Morningstar.Core.Graphics;

/// <summary>
///     Represents a sprite.
/// </summary>
/// <remarks>
///     This structure encapsulates all data required to draw a sprite using a <see cref="SpriteBatch"/>,
///     allowing configurations to be reused, cached, or passed around as a single value.
/// </remarks>
public readonly struct Sprite
{
    /// <summary>
    ///     The texture of the sprite.
    /// </summary>
    public readonly Asset<Texture2D> Texture;

    /// <summary>
    ///     The position of the sprite, in screen coordinates.
    /// </summary>
    public readonly Vector2 Position;

    /// <summary>
    ///     The scale of the sprite, where <see cref="Vector2.One" /> is the original size of the texture.
    /// </summary>
    public readonly Vector2 Scale;

    /// <summary>
    ///     The origin of the sprite, in texture coordinates.
    /// </summary>
    public readonly Vector2 Origin;

    /// <summary>
    ///     The color of the sprite.
    /// </summary>
    /// <value>
    ///     Defaults to <see cref="Color.White" />.
    /// </value>
    public readonly Color Color;

    /// <summary>
    ///     The rotation of the sprite, in radians.
    /// </summary>
    public readonly float Rotation;

    /// <summary>
    ///     The source rectangle of the sprite, in texture coordinates. If <see langword="null" />, the
    ///     entire texture will be used.
    /// </summary>
    public readonly Rectangle? Source;

    /// <summary>
    ///     The destination rectangle of the sprite, in screen coordinates. If <see langword="null" />, the
    ///     sprite will be drawn at <see cref="Position" /> with a size of <see cref="Scale" />.
    /// </summary>
    /// <value>
    ///     The destination rectangle, or <see langword="null"/> to use <see cref="Position"/> and <see cref="Scale"/>.
    /// </value>
    public readonly Rectangle? Destination;

    /// <summary>
    ///     The effects of the sprite.
    /// </summary>
    /// <value>
    ///     Defaults to <see cref="SpriteEffects.None" />.
    /// </value>
    public readonly SpriteEffects Effects;

    public Sprite(Asset<Texture2D> texture, Vector2 position, Color? color = null)
    {
        Texture = texture;
        Position = position;
        Color = color ?? Color.White;
        Scale = Vector2.One;
    }
}