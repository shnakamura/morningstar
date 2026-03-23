namespace Morningstar.Core.Graphics;

public readonly struct SpriteRenderData
{
    public readonly Sprite Sprite;

    public readonly SpriteBatchParameters Parameters;

    public SpriteRenderData(in Sprite sprite, in SpriteBatchParameters parameters)
    {
        Sprite = sprite;
        Parameters = parameters;
    }
}