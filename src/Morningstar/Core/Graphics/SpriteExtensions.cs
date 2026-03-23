namespace Morningstar.Core.Graphics;

/// <summary>
///     Provides <see cref="Sprite" /> extension methods.
/// </summary>
public static class SpriteExtensions
{
    /// <summary>
    ///     Draws the specified <see cref="Sprite" /> using the provided <see cref="SpriteBatch" />.
    /// </summary>
    /// <param name="sprite">The <see cref="Sprite" /> to draw.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch" /> used for drawing.</param>
    /// <remarks>
    ///     If <see cref="Sprite.Destination" /> is not <see langword="null" />, the <see cref="Sprite" />
    ///     is drawn using the destination rectangle; otherwise, it is drawn using
    ///     <see cref="Sprite.Position" /> and <see cref="Sprite.Scale" />.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="spriteBatch" /> is <see langword="null" />.
    /// </exception>
    public static void Draw(this Sprite sprite, SpriteBatch spriteBatch)
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