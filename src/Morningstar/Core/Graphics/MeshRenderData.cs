namespace Morningstar.Core.Graphics;

public readonly struct MeshRenderData(in Mesh mesh, in SpriteBatchParameters? parameters = null)
{
    /// <summary>
    ///     Gets the mesh to render.
    /// </summary>
    public readonly Mesh Mesh = mesh;

    /// <summary>
    ///     Gets the parameters to render the sprite with.
    /// </summary>
    /// <value>
    ///     Defaults to <see cref="SpriteBatchParameters.Default" /> if not specified.
    /// </value>
    public readonly SpriteBatchParameters Parameters = parameters ?? SpriteBatchParameters.Default;
}