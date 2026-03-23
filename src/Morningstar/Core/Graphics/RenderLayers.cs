namespace Morningstar.Core.Graphics;

public static class RenderLayers
{
    public static readonly RenderLayer Background = new();
    public static readonly RenderLayer BackgroundPixellated = new(Main.screenWidth, Main.screenHeight);
}