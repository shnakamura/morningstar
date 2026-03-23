namespace Morningstar.Core.Graphics;

/// <summary>
///     Represents a mesh.
/// </summary>
/// <remarks>
///     This structure encapsulates all data required to draw a mesh using
///     <see cref="GraphicsDevice" />, allowing configurations to be reused, cached, or passed around
///     as a single value.
/// </remarks>
public readonly struct Mesh
{
    /// <summary>
    ///     The vertices of the mesh.
    /// </summary>
    public readonly VertexPositionColorTexture[] Vertices { get; }

    /// <summary>
    ///     The indices of the mesh.
    /// </summary>
    public readonly uint[] Indices { get; }

    /// <summary>
    ///     The primitive type of the mesh.
    /// </summary>
    public readonly PrimitiveType Type { get; }

    public Mesh(VertexPositionColorTexture[] vertices, uint[] indices, PrimitiveType type)
    {
        ArgumentNullException.ThrowIfNull(vertices, nameof(vertices));
        ArgumentNullException.ThrowIfNull(indices, nameof(indices));
        
        Vertices = vertices;
        Indices = indices;
        Type = type;
    }
}