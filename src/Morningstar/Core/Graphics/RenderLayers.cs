using Terraria.GameContent;

namespace Morningstar.Core.Graphics;

public sealed class RenderLayers : ModSystem
{
    public static RenderLayer Background { get; private set; }
    
    public static RenderLayer Background_Pixellated { get; private set; }

    public override void Load()
    {
        base.Load();
        
        Main.QueueMainThreadAction(static () =>
        {
            Background = new RenderLayer();
            Background_Pixellated = new RenderLayer(Main.screenWidth / 2, Main.screenHeight / 2);
        });
        
        On_Main.CheckMonoliths += On_MainOnCheckMonoliths;
    }

    private void On_MainOnCheckMonoliths(On_Main.orig_CheckMonoliths orig)
    {
        orig();
        
        Main.instance.LoadItem(ItemID.Meowmere);
        
        var sprite = new Sprite(TextureAssets.Item[ItemID.Meowmere], Screen.Center + Screen.Size / 16f);
        var data = new SpriteRenderData(in sprite, SpriteBatchParameters.Default.WithTransformMatrix(Main.Transform * Matrix.CreateScale(0.5f)));
        
        RenderLayers.Background_Pixellated.Draw(in data);
        
        Background_Pixellated.Fill();
    }
}