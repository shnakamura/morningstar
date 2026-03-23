using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Morningstar.Content.Biomes.Mire;

/// <summary>
///     Handles registration of the <see cref="MireSky"/>.
/// </summary>
[Autoload(Side = ModSide.Client)]
public sealed class MireSkyLoadingSystem : ModSystem
{
    private const string PASS_NAME = "FilterMiniTower";
    
    /// <summary>
    ///     The unique identifier of the <see cref="MireSky"/>.
    /// </summary>
    public const string FILTER_NAME = $"{nameof(Morningstar)}:{nameof(MireSkyLoadingSystem)}";
    
    /// <summary>
    ///     The opacity applied to the Mire biome overlay.
    /// </summary>
    /// <value>
    ///     A value in the range of <c>0f</c> to <c>1f</c>.
    /// </value>
    public const float FILTER_OPACITY = 0.25f;
    
    /// <summary>
    ///     The color tint applied to the Mire biome overlay.
    /// </summary>
    public static readonly Color FilterColor = new(9, 0, 45);
    
    // TODO - nakamurash: Consider making ModSky an ILoadable for automatic registration.
    public override void Load()
    {
        base.Load();

        Filters.Scene[FILTER_NAME] = new Filter(new ScreenShaderData(PASS_NAME).UseOpacity(FILTER_OPACITY).UseColor(FilterColor), EffectPriority.VeryHigh);

        SkyManager.Instance[FILTER_NAME] = new MireSky();
        SkyManager.Instance[FILTER_NAME].Load();
    }
}