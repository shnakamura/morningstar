using System.Collections.Generic;
using SubworldLibrary;
using Terraria.WorldBuilding;

namespace Morningstar.Content.Subworlds.Inferno;

public sealed class InfernoSubworld : Subworld
{
    public override List<GenPass> Tasks { get; } =
    [
        new TerrainPass("Terrain", 0f)
    ];
    
    public override int Width { get; } = 800;

    public override int Height { get; } = 600;

    public override void OnEnter()
    {
        base.OnEnter();

        SubworldSystem.hideUnderworld = true;
    }
}