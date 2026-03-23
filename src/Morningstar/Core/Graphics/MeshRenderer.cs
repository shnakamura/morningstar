namespace Morningstar.Core.Graphics;

public sealed class MeshRenderer : ILoadable
{
    /// <summary>
    ///     The initial capacity of the vertex buffer, in vertices.
    /// </summary>
    public const int INITIAL_VERTEX_BUFFER_SIZE = 1024;

    /// <summary>
    ///     The initial capacity of the index buffer, in indices.
    /// </summary>
    public const int INITIAL_INDEX_BUFFER_SIZE = INITIAL_VERTEX_BUFFER_SIZE + INITIAL_VERTEX_BUFFER_SIZE / 2;

    private static GraphicsDevice GraphicsDevice => Main.graphics.GraphicsDevice;

    /// <summary>
    ///     Gets the index buffer.
    /// </summary>
    public static DynamicIndexBuffer IndexBuffer { get; private set; }

    /// <summary>
    ///     Gets the vertex buffer.
    /// </summary>
    public static DynamicVertexBuffer VertexBuffer { get; private set; }

    void ILoadable.Load(Mod mod)
    {
        Main.QueueMainThreadAction
        (
            static () =>
            {
                IndexBuffer = new DynamicIndexBuffer(GraphicsDevice, IndexElementSize.ThirtyTwoBits, INITIAL_INDEX_BUFFER_SIZE, BufferUsage.WriteOnly);
                VertexBuffer = new DynamicVertexBuffer(GraphicsDevice, VertexPositionColorTexture.VertexDeclaration, INITIAL_VERTEX_BUFFER_SIZE, BufferUsage.WriteOnly);
            }
        );
    }

    void ILoadable.Unload()
    {
        Main.QueueMainThreadAction
        (
            static () =>
            {
                IndexBuffer?.Dispose();
                IndexBuffer = null;

                VertexBuffer?.Dispose();
                VertexBuffer = null;
            }
        );
    }

    /// <summary>
    ///     Sets the data of the vertex and index buffers with the specified vertices and indices.
    /// </summary>
    /// <param name="vertices">The mesh vertices.</param>
    /// <param name="indices">The mesh indices.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="vertices" /> or <paramref name="indices" /> is
    ///     <see langword="null" />.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     Thrown if <paramref name="vertices" /> or <paramref name="indices" /> is empty.
    /// </exception>
    /// <remarks>
    ///     Buffers are automatically resized if the provided data exceeds their current capacity.
    /// </remarks>
    public static void SetData(VertexPositionColorTexture[] vertices, uint[] indices)
    {
        ArgumentNullException.ThrowIfNull(vertices, nameof(vertices));
        ArgumentNullException.ThrowIfNull(indices, nameof(indices));

        if (vertices.Length == 0)
        {
            throw new ArgumentException("Vertices cannot be empty.", nameof(vertices));
        }

        if (indices.Length == 0)
        {
            throw new ArgumentException("Indices cannot be empty.", nameof(indices));
        }

        EnsureVerticesCapacity(vertices.Length);
        EnsureIndicesCapacity(indices.Length);

        VertexBuffer.SetData(vertices, 0, vertices.Length, SetDataOptions.Discard);
        IndexBuffer.SetData(indices, 0, indices.Length, SetDataOptions.Discard);
    }

    private static void EnsureVerticesCapacity(int vertexCount)
    {
        if (VertexBuffer.VertexCount >= vertexCount)
        {
            return;
        }

        var length = Math.Max(VertexBuffer.VertexCount * 2, vertexCount);

        VertexBuffer.Dispose();
        VertexBuffer = new DynamicVertexBuffer(GraphicsDevice, VertexPositionColorTexture.VertexDeclaration, length, BufferUsage.WriteOnly);
    }

    private static void EnsureIndicesCapacity(int indexCount)
    {
        if (IndexBuffer.IndexCount >= indexCount)
        {
            return;
        }

        var length = Math.Max(IndexBuffer.IndexCount * 2, indexCount);

        IndexBuffer.Dispose();
        IndexBuffer = new DynamicIndexBuffer(GraphicsDevice, IndexElementSize.ThirtyTwoBits, length, BufferUsage.WriteOnly);
    }
}