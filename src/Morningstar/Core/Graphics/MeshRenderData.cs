namespace Morningstar.Core.Graphics;

public readonly struct MeshRenderData(in Mesh mesh, in SpriteBatchParameters parameters)
{
    public readonly Mesh Mesh = mesh;

    public readonly SpriteBatchParameters Parameters = parameters;
}