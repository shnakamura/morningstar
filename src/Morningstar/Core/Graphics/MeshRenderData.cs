namespace Morningstar.Core.Graphics;

public readonly struct MeshRenderData
{
    public readonly Mesh Mesh;

    public readonly SpriteBatchParameters Parameters;

    public MeshRenderData(in Mesh mesh, in SpriteBatchParameters parameters)
    {
        Mesh = mesh;
        Parameters = parameters;
    }
}