using Morningstar.Core.Graphics;
using Morningstar.Core.Skies;
using ReLogic.Content;
using Terraria.GameContent;

namespace Morningstar.Content.Biomes.Mire;

/// <summary>
///     The <see cref="ModSky" /> implementation for the Mire biome's sky.
/// </summary>
public sealed class MireSky : ModSky, ILoadable
{
    private static GraphicsDevice Device => Main.graphics.GraphicsDevice;

    /// <summary>
    ///     Gets the render target used for rendering the <see cref="MireSky" />.
    /// </summary>
    public static RenderTarget2D Target { get; private set; }

    /// <summary>
    ///     Gets the texture used for rendering the <see cref="MireSky" />'s close background layer.
    /// </summary>
    public static Asset<Texture2D> CloseBackgroundTexture { get; private set; }

    /// <summary>
    ///     Gets the texture used for rendering the <see cref="MireSky" />'s middle background layer.
    /// </summary>
    public static Asset<Texture2D> MiddleBackgroundTexture { get; private set; }

    /// <summary>
    ///     Gets the texture used for rendering the <see cref="MireSky" />'s far background layer.
    /// </summary>
    public static Asset<Texture2D> FarBackgroundTexture { get; private set; }

    /// <summary>
    ///     Gets the texture used for rendering the <see cref="MireSky" />'s sky.
    /// </summary>
    public static Asset<Texture2D> SkyTexture { get; private set; }

    /// <summary>
    ///     Gets the texture used for rendering the <see cref="MireSky" />'s moon.
    /// </summary>
    public static Asset<Texture2D> MoonTexture { get; private set; }

    /// <summary>
    ///     Gets the shader used for rendering the <see cref="MireSky" />'s sky.
    /// </summary>
    public static Asset<Effect> SkyEffect { get; private set; }

    /// <summary>
    ///     Gets the shader used for rendering the <see cref="MireSky" />'s moon.
    /// </summary>
    public static Asset<Effect> MoonEffect { get; private set; }

    void ILoadable.Load(Mod mod)
    {
        Main.QueueMainThreadAction(static () => Target = new RenderTarget2D(Device, Main.screenWidth / 2, Main.screenHeight / 2));

        On_Main.CheckMonoliths += On_Main_CheckMonoliths;

        Main.OnResolutionChanged += Main_OnResolutionChanged;

        CloseBackgroundTexture = ModContent.Request<Texture2D>($"{nameof(Morningstar)}/Assets/Textures/Backgrounds/MireSurfaceBackground_Close");
        MiddleBackgroundTexture = ModContent.Request<Texture2D>($"{nameof(Morningstar)}/Assets/Textures/Backgrounds/MireSurfaceBackground_Middle");
        FarBackgroundTexture = ModContent.Request<Texture2D>($"{nameof(Morningstar)}/Assets/Textures/Backgrounds/MireSurfaceBackground_Far");

        SkyTexture = ModContent.Request<Texture2D>($"{nameof(Morningstar)}/Assets/Textures/Backgrounds/MireSky");
        MoonTexture = ModContent.Request<Texture2D>($"{nameof(Morningstar)}/Assets/Textures/Backgrounds/MireMoon");

        SkyEffect = ModContent.Request<Effect>($"{nameof(Morningstar)}/Assets/Effects/MireSky", AssetRequestMode.ImmediateLoad);
        MoonEffect = ModContent.Request<Effect>($"{nameof(Morningstar)}/Assets/Effects/MireMoon", AssetRequestMode.ImmediateLoad);
    }

    void ILoadable.Unload()
    {
        Main.QueueMainThreadAction
        (
            static () =>
            {
                Target?.Dispose();
                Target = null;
            }
        );
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
        var parameters = new SpriteBatchParameters(spriteBatch).WithSamplerState(SamplerState.PointClamp);

        using (var scope = spriteBatch.Scope(in parameters))
        {
            spriteBatch.Draw(Target, Screen.Bounds, Color.White * Intensity);
        }
    }

    private void On_Main_CheckMonoliths(On_Main.orig_CheckMonoliths orig)
    {
        orig();

        if (Main.gameMenu)
        {
            return;
        }

        var bindings = Device.GetRenderTargets();

        Device.SetRenderTarget(Target);
        Device.Clear(Color.Transparent);

        var spriteBatch = Main.spriteBatch;

        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, Main.Rasterizer, default, Main.GameViewMatrix.EffectMatrix);

        DrawSky(spriteBatch);
        DrawMoon(spriteBatch);

        DrawMiddleBackground(spriteBatch);
        DrawFarBackground(spriteBatch);
        DrawCloseBackground(spriteBatch);

        spriteBatch.End();

        Device.SetRenderTargets(bindings);
        Device.Clear(Color.Transparent);
    }

    private static void Main_OnResolutionChanged(Vector2 size)
    {
        Main.QueueMainThreadAction
        (
            () =>
            {
                Target?.Dispose();
                Target = new RenderTarget2D(Device, (int)(size.X / 2f), (int)(size.Y / 2f));
            }
        );
    }

    private void DrawFarBackground(SpriteBatch spriteBatch)
    {
        var texture = FarBackgroundTexture.Value;

        var parallax = 0.1f;

        var position = new Vector2(-Main.screenPosition.X * parallax, -Main.screenPosition.Y * parallax + texture.Height / 2f) + new Vector2(0f, 250f);

        var tiles = Main.screenWidth / texture.Width + 2f;

        for (var i = -1; i < tiles; i++)
        {
            spriteBatch.Draw(texture, new Vector2(position.X + texture.Width * i, position.Y), Color.White);
        }
    }

    private void DrawMiddleBackground(SpriteBatch spriteBatch)
    {
        var texture = MiddleBackgroundTexture.Value;

        var parallax = 0.1f;

        var position = new Vector2(-Main.screenPosition.X * parallax + texture.Width / 2f, -Main.screenPosition.Y * parallax + texture.Height / 4f) + new Vector2(0f, 250f);

        var tiles = Main.screenWidth / texture.Width + 2f;

        for (var i = -1; i < tiles; i++)
        {
            spriteBatch.Draw(texture, new Vector2(position.X + texture.Width * i, position.Y), Color.White);
        }
    }

    private void DrawCloseBackground(SpriteBatch spriteBatch)
    {
        var texture = CloseBackgroundTexture.Value;

        var parallax = 0.1f;

        var position = new Vector2(-Main.screenPosition.X * parallax, -Main.screenPosition.Y * parallax + texture.Height / 2f) + new Vector2(0f, 250f);

        var tiles = Main.screenWidth / texture.Width + 2f;

        for (var i = -1; i < tiles; i++)
        {
            spriteBatch.Draw(texture, new Vector2(position.X + texture.Width * i, position.Y), Color.White);
        }
    }

    private void DrawSky(SpriteBatch spriteBatch)
    {
        var effect = SkyEffect.Value;

        effect.Parameters["uIntensity"].SetValue(0.025f);
        effect.Parameters["uTime"].SetValue((float)Main.time * 0.01f);
        effect.Parameters["uQuantization"].SetValue(32f);
        effect.Parameters["uScreenPosition"].SetValue(Main.screenPosition);
        effect.Parameters["uScreenResolution"].SetValue(Screen.Size);

        spriteBatch.End(out var parameters);
        spriteBatch.Begin(parameters.SpriteSortMode, parameters.BlendState, parameters.SamplerState, parameters.DepthStencilState, parameters.RasterizerState, effect, parameters.TransformMatrix);

        var texture = SkyTexture.Value;

        spriteBatch.Draw(texture, Screen.Bounds, Color.White);

        spriteBatch.End();
        spriteBatch.Begin(in parameters);
    }

    private void DrawMoon(SpriteBatch spriteBatch)
    {
        if (Main.dayTime)
        {
            return;
        }

        var texture = MoonTexture.Value;

        var top = (float)(-Main.screenPosition.Y / (Main.worldSurface * 16.0 - 600.0) * 200.0);

        var opacity = 1f - Main.cloudAlpha * 1.5f;
        var color = Color.White * opacity;

        var rotation = (float)(Main.time / 32400.0) * 2f - 7.3f;

        var origin = texture.Size() / 2f;

        var scale = 1f;
        var offset = 0.0;

        if (Main.time < 16200.0)
        {
            offset = Math.Pow(1.0 - Main.time / 32400.0 * 2.0, 2.0);
        }
        else
        {
            offset = Math.Pow((Main.time / 32400.0 - 0.5) * 2.0, 2.0);
        }

        var x = (float)(Main.time / 32400.0 * (Main.screenWidth + TextureAssets.Moon[Main.moonType].Width() * 2f)) - TextureAssets.Moon[Main.moonType].Width();
        var y = (float)(top + offset * 250.0 + 180.0);

        var position = new Vector2(x, y + Main.moonModY);

        scale = (float)(1.2 - offset * 0.4);

        var effect = ModContent.Request<Effect>("Morningstar/Assets/Effects/MireMoonBloom", AssetRequestMode.ImmediateLoad).Value;

        spriteBatch.End(out var parameters);
        spriteBatch.Begin(parameters.SpriteSortMode, BlendState.Additive, parameters.SamplerState, parameters.DepthStencilState, parameters.RasterizerState, effect, parameters.TransformMatrix);

        effect.Parameters["uColor"].SetValue((new Color(189, 52, 235) * opacity * 0.5f).ToVector3());

        var bloom = ModContent.Request<Texture2D>("Morningstar/Assets/Textures/Backgrounds/MireMoon_Bloom", AssetRequestMode.ImmediateLoad).Value;
        var bloomColor = new Color(189, 52, 235) * opacity;

        spriteBatch.Draw(bloom, position / 2f, null, bloomColor * 0f, rotation, bloom.Size() / 2f, scale, SpriteEffects.None, 0f);

        spriteBatch.End();

        effect = MoonEffect.Value;

        effect.Parameters["uQuantization"].SetValue(16f);

        spriteBatch.Begin(parameters.SpriteSortMode, parameters.BlendState, parameters.SamplerState, parameters.DepthStencilState, parameters.RasterizerState, effect, parameters.TransformMatrix);

        spriteBatch.Draw(texture, position / 2f, null, color, rotation, origin, scale, SpriteEffects.None, 0f);

        spriteBatch.End();
        spriteBatch.Begin(in parameters);
    }
}