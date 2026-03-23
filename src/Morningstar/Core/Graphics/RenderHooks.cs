using Terraria.GameContent;

namespace Morningstar.Core.Graphics;

[Autoload(Side = ModSide.Client)]
public sealed class RenderHooks : ModSystem
{
    public override void Load()
    {
        base.Load();
        
        On_Main.CheckMonoliths += On_MainOnCheckMonoliths;
        On_Main.DrawInfernoRings += On_MainOnDrawInfernoRings;
    }

    private void On_MainOnCheckMonoliths(On_Main.orig_CheckMonoliths orig)
    {
        orig();
    }

    private void On_MainOnDrawInfernoRings(On_Main.orig_DrawInfernoRings orig, Main self)
    {
        orig(self);

        Main.instance.LoadItem(ItemID.Meowmere);
        
        var sprite = new Sprite(TextureAssets.Item[ItemID.Meowmere], Screen.Center);
        var data = new SpriteRenderData(in sprite, new SpriteBatchParameters(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, default, Main.Transform));
        
        Main.spriteBatch.Draw(TextureAssets.Item[ItemID.Meowmere].Value, new Vector2(100f, 100f), Color.White);
        
        RenderLayers.Background.Draw(in data);
        RenderLayers.Background.Flush();
    }
}