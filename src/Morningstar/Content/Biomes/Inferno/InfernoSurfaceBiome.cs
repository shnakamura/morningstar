using Terraria.Graphics.Capture;

namespace Morningstar.Content.Biomes.Inferno;

public sealed class InfernoSurfaceBiome : ModBiome
{
    public const int BIOME_TILE_COUNT = 100;

    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/Inferno");
    
    public override SceneEffectPriority Priority { get; } = SceneEffectPriority.BiomeHigh;
    
    public override CaptureBiome.TileColorStyle TileColorStyle { get; } = CaptureBiome.TileColorStyle.Crimson;
    
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle { get; } = ModContent.GetInstance<InfernoSurfaceBackground>();

    public override bool IsBiomeActive(Player player)
    {
        var biome = InfernoBiomeSystem.TileCount >= BIOME_TILE_COUNT;
        var surface = player.ZoneSkyHeight || player.ZoneOverworldHeight;

        return biome && surface;
    }
}