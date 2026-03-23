namespace Morningstar.Core.Graphics;

public readonly struct SpriteRenderData(in Sprite sprite, in SpriteBatchParameters parameters)
{
    public readonly Sprite Sprite = sprite;

    public readonly SpriteBatchParameters Parameters = parameters;
}