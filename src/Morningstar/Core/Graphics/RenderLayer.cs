using System.Collections.Generic;
using JetBrains.Annotations;
using Terraria.GameContent;

namespace Morningstar.Core.Graphics;

public sealed class RenderLayer
{
    private readonly List<SpriteRenderData> sprites = new();

    private readonly List<MeshRenderData> meshes = new();

    private SpriteBatch SpriteBatch => Main.spriteBatch;

    private GraphicsDevice GraphicsDevice => Main.graphics.GraphicsDevice;

    /// <summary>
    ///     Gets whether the layer is buffered.
    /// </summary>
    /// <remarks>
    ///     If <see langword="true" />, the layer renders to a <see cref="RenderTarget2D" /> and its
    ///     contents are drawn to the screen in a single draw call. Otherwise, the layer renders directly
    ///     to the screen.
    /// </remarks>
    public bool Buffered { get; }

    /// <summary>
    ///     Gets the parameters of the layer.
    /// </summary>
    public SpriteBatchParameters Parameters { get; }

    /// <summary>
    ///     Gets the render target of the layer. If <see langword="null" />, the layer does not use a
    ///     render target.
    /// </summary>
    [CanBeNull]
    public RenderTarget2D Target { get; private set; }

    public RenderLayer(in SpriteBatchParameters? parameters = null)
    {
        Buffered = false;

        Parameters = parameters ?? SpriteBatchParameters.Default;
    }

    public RenderLayer(int width, int height, in SpriteBatchParameters? parameters = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width, nameof(width));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height, nameof(height));

        Target = new RenderTarget2D(GraphicsDevice, width, height);

        Buffered = true;

        Parameters = parameters ?? SpriteBatchParameters.Default;
    }

    /// <summary>
    ///     Queues the specified <see cref="SpriteRenderData" /> for rendering in the layer.
    /// </summary>
    /// <param name="data">The <see cref="SpriteRenderData" /> to add to the layer.</param>
    public void Draw(in SpriteRenderData data)
    {
        sprites.Add(data);
    }

    /// <summary>
    ///     Queues the specified <see cref="MeshRenderData" /> for rendering in the layer.
    /// </summary>
    /// <param name="data">The <see cref="MeshRenderData" /> to add to the layer.</param>
    public void Draw(in MeshRenderData data)
    {
        meshes.Add(data);
    }

    /// <summary>
    ///     Clears all queued rendering data from the layer.
    /// </summary>
    public void Clear()
    {
        sprites.Clear();
        meshes.Clear();
    }

    public void Fill()
    {
        if (!Buffered)
        {
            return;
        }

        using var targetScope = Target.Scope(Color.Transparent);
        using var spriteBatchScope = SpriteBatch.Scope(Parameters);
        
        Flush_Sprites();
        Flush_Meshes();
    }

    public void Flush()
    {
        using var spriteBatchScope = SpriteBatch.Scope(Parameters);

        if (Buffered)
        {
            Flush_Buffer();
        }
        else
        {
            Flush_Sprites();
            Flush_Meshes();
        }

        Clear();
    }

    private void Flush_Buffer()
    {       
        SpriteBatch.Draw(Target, Screen.Bounds, Color.White);
    }

    private void Flush_Sprites()
    {
        if (sprites.Count == 0)
        {
            return;
        }

        for (var i = 0; i < sprites.Count; i++)
        {
            var data = sprites[i];
            
            using var spriteBatchScope = SpriteBatch.Scope(data.Parameters);

            // TODO: Grouping by parameters to minimize batching.
            SpriteBatch.Draw(in data.Sprite);
        }
    }

    // TODO: Mesh rendering through buffers.
    private void Flush_Meshes()
    {
        if (meshes.Count == 0)
        {
            return;
        }

        for (var i = 0; i < meshes.Count; i++)
        {
            var data = meshes[i];
        }
    }
}