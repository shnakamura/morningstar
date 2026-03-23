using System.Runtime.CompilerServices;

namespace Morningstar.Core.Graphics;

public static class SpriteBatchExtensions
{
    public static void Begin(this SpriteBatch spriteBatch, in SpriteBatchParameters parameters)
    {
        spriteBatch.Begin
        (
            parameters.SpriteSortMode,
            parameters.BlendState,
            parameters.SamplerState,
            parameters.DepthStencilState,
            parameters.RasterizerState,
            parameters.Effect,
            parameters.TransformMatrix
        );
    }
    
    public static void End(this SpriteBatch spriteBatch, out SpriteBatchParameters parameters)
    {
        spriteBatch.End();

        parameters = new SpriteBatchParameters(spriteBatch);
    }
}