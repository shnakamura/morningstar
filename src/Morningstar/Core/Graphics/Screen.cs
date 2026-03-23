namespace Morningstar.Core.Graphics;

public static class Screen
{
    /// <summary>
    ///     Gets the size of the screen, in pixels.
    /// </summary>
    public static Vector2 Size => new(Main.screenWidth, Main.screenHeight);
    
    /// <summary>
    ///     Gets the center of the screen, in pixels.
    /// </summary>
    public static Vector2 Center => Size / 2f;
    
    /// <summary>
    ///     Gets the bounds of the screen, in pixels.
    /// </summary>
    public static Rectangle Bounds => new(0, 0, Main.screenWidth, Main.screenHeight);
}