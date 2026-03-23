using Terraria.GameContent;

namespace Morningstar.Core.Graphics;

[Autoload(Side = ModSide.Client)]
public sealed class RenderHooks : ModSystem
{
    public override void Load()
    {
        base.Load();
        
        On_Main.DrawInfernoRings += On_MainOnDrawInfernoRings;
    }

    private void On_MainOnDrawInfernoRings(On_Main.orig_DrawInfernoRings orig, Main self)
    {
        orig(self);

        Main.instance.LoadItem(ItemID.Meowmere);
        
        var sprite = new Sprite(TextureAssets.Item[ItemID.Meowmere], (Screen.Center + Screen.Size / 4f) / 2f);
        var data = new SpriteRenderData(in sprite);

        sprite = new Sprite(TextureAssets.Item[ItemID.Meowmere], Screen.Center - Screen.Size / 4f);
        data = new SpriteRenderData(in sprite);
        
        RenderLayers.Background.Draw(in data);
        RenderLayers.Background.Flush();
    }
}