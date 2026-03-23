namespace Morningstar.Core.Graphics;

/// <summary>
///     Provides <see cref="SpriteBatch" /> extension methods for working with <see cref="Sprite" />.
/// </summary>
public static class SpriteExtensions
{
    /// <summary>
    ///     Draws a <see cref="Sprite" /> using the specified <see cref="SpriteBatch" />.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch" /> used for drawing.</param>
    /// <param name="sprite">The <see cref="Sprite" /> to draw.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="spriteBatch" /> is <see langword="null" />.
    /// </exception>
    /// <remarks>
    ///     If <see cref="Sprite.Destination" /> is not <see langword="null" />, the <see cref="Sprite" />
    ///     is drawn using the destination rectangle; otherwise, it is drawn using
    ///     <see cref="Sprite.Position" /> and <see cref="Sprite.Scale" />.
    /// </remarks>
    public static void Draw(this SpriteBatch spriteBatch, in Sprite sprite)
    {
        ArgumentNullException.ThrowIfNull(spriteBatch, nameof(spriteBatch));

        if (sprite.Destination.HasValue)
        {
            spriteBatch.Draw(sprite.Texture.Value, sprite.Destination.Value, sprite.Source, sprite.Color, sprite.Rotation, sprite.Origin, sprite.Effects, 0f);
        }
        else
        {
            spriteBatch.Draw(sprite.Texture.Value, sprite.Position, sprite.Source, sprite.Color, sprite.Rotation, sprite.Origin, sprite.Scale, sprite.Effects, 0f);
        }
    }
}