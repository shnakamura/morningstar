using System.Collections.Generic;
using JetBrains.Annotations;

namespace Morningstar.Core.Graphics;

public sealed class RenderLayer
{
    private readonly List<SpriteRenderData> sprites = new();

    private readonly List<MeshRenderData> meshes = new();
    
    // TODO: Maybe allow for different batches/devices?
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

        // TODO: Replace with default parameters.
        Parameters = parameters ?? new SpriteBatchParameters();
    }

    public RenderLayer(int width, int height, in SpriteBatchParameters? parameters = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width, nameof(width));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height, nameof(height));

        // TODO: Render Target initialization should probably not be handled here. Consider implementing pooling.
        Main.QueueMainThreadAction(() => Target = new RenderTarget2D(GraphicsDevice, width, height));

        Buffered = true;

        // TODO: Replace with default parameters.
        Parameters = parameters ?? new SpriteBatchParameters();
    }
    
    /// <summary>
    ///     Queues the specified <see cref="SpriteRenderData"/> for rendering in this layer.
    /// </summary>
    /// <param name="data">The <see cref="SpriteRenderData"/> to add to the layer.</param>
    public void Draw(in SpriteRenderData data)
    {
        sprites.Add(data);
    }

    /// <summary>
    ///     Queues the specified <see cref="MeshRenderData"/> for rendering in this layer.
    /// </summary>
    /// <param name="data">The <see cref="MeshRenderData"/> to add to the layer.</param>
    public void Draw(in MeshRenderData data)
    {
        meshes.Add(data);
    }
    
    public void Clear()
    {
        sprites.Clear();
        meshes.Clear();
    }

    public void Flush()
    {
        using var scope = SpriteBatch.Scope(Parameters);
        
        if (Buffered)
        {
            DrawBuffer();
        }
        else
        {
            DrawSprites();
            DrawMeshes();
        }
    }

    private void DrawBuffer()
    {
        
    }
    
    private void DrawSprites()
    {
        if (sprites.Count == 0)
        {
            return;
        }

        for (var i = 0; i < sprites.Count; i++)
        {
            var data = sprites[i];
        }
    }
    
    // TODO: Mesh rendering through buffers.
    private void DrawMeshes()
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