using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;

namespace Morningstar.Content.Biomes.Mire;

/// <summary>
///     The <see cref="ModBiome" /> implementation for the Mire biome.
/// </summary>
public sealed class MireBiome : ModBiome
{
    public override CaptureBiome.TileColorStyle TileColorStyle { get; } = CaptureBiome.TileColorStyle.Mushroom;
    
    public override SceneEffectPriority Priority { get; } = SceneEffectPriority.BiomeHigh;

    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/Mire" + (Main.dayTime ? "Day" : "Night"));

    public override bool IsBiomeActive(Player player)
    {
        return player.HasBuff(BuffID.Invisibility);
    }
    
    public override void SpecialVisuals(Player player, bool isActive)
    {
        base.SpecialVisuals(player, isActive);

        player.ManageSpecialBiomeVisuals(MireSkyLoadingSystem.FILTER_NAME, isActive);

        Filters.Scene[MireVignetteLoadingSystem.FILTER_NAME].GetShader()
            .UseOpacity(1f)
            .UseIntensity(2.5f)
            .UseColor(Color.Purple);
        
        Filters.Scene[MireVignetteLoadingSystem.FILTER_NAME].GetShader().Shader.Parameters["uOuterRadius"].SetValue(5f);
        Filters.Scene[MireVignetteLoadingSystem.FILTER_NAME].GetShader().Shader.Parameters["uInnerRadius"].SetValue(0.25f);
        Filters.Scene[MireVignetteLoadingSystem.FILTER_NAME].GetShader().Shader.Parameters["uCurvature"].SetValue(1f);
            
        player.ManageSpecialBiomeVisuals(MireVignetteLoadingSystem.FILTER_NAME, isActive);
    }

    public override void OnInBiome(Player player)
    {
        base.OnInBiome(player);
        
        SpawnDust(player);
    }
    
    private static void SpawnDust(Player player)
    {
        if (!Main.rand.NextBool(25))
        {
            return;
        }
        
        Dust.NewDust(Main.screenPosition, Main.screenWidth, Main.screenHeight, ModContent.DustType<MireDust>());
    }
}