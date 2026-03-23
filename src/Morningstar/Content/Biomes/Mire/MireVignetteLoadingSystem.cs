using ReLogic.Content;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Morningstar.Content.Biomes.Mire;

[Autoload(Side = ModSide.Client)]
public sealed class MireVignetteLoadingSystem : ModSystem
{
    private const string PASS_NAME = "FilterMiniTower";
    
    /// <summary>
    ///     The unique identifier of the <see cref="MireSky"/>.
    /// </summary>
    public const string FILTER_NAME = $"{nameof(Morningstar)}:{nameof(MireVignetteLoadingSystem)}";
    
    public override void Load()
    {
        base.Load();
        
        var effect = ModContent.Request<Effect>($"{nameof(Morningstar)}/Assets/Effects/Vignette", AssetRequestMode.ImmediateLoad);

        Filters.Scene[FILTER_NAME] = new Filter(new ScreenShaderData(effect, "VignettePass"), EffectPriority.VeryHigh);
        Filters.Scene[FILTER_NAME].Load();
    }
}
