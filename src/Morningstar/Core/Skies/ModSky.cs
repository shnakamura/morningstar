using Terraria.Graphics.Effects;

namespace Morningstar.Core.Skies;

/// <summary>
///     Provides a base implementation for <see cref="CustomSky" /> that manages state and intensity.
/// </summary>
public abstract class ModSky : CustomSky
{
    /// <summary>
    ///     Represents the minimum depth used by vanilla background rendering.
    /// </summary>
    /// <remarks>
    ///     This matches the hardcoded depth value used by Terraria when drawing background
    ///     elements in <see cref="Main.DrawBackground"/>. It is used in depth checks such as:
    ///     <code>
    ///     if (minDepth &lt; 3.40282347E+38f)
    ///     {
    ///         // Rendering
    ///     }
    ///     </code>
    ///     Using this value ensures the background draws before most foreground
    ///     elements but after certain background layers.
    /// </remarks>
    public const float MIN_DEPTH = 3.40282347E+38f;

    /// <summary>
    ///     Represents the maximum depth used by vanilla background rendering.
    /// </summary>
    /// <remarks>
    ///     This matches the hardcoded depth value used by Terraria when drawing background
    ///     elements in <see cref="Main.DrawBackground"/>. It is used in depth checks such as:
    ///     <code>
    ///     if (maxDepth &gt;= 3.40282347E+38f)
    ///     {
    ///         // Rendering
    ///     }
    ///     </code>
    ///     Using this value ensures the background draws before most foreground
    ///     elements but after certain background layers.
    /// </remarks>
    public const float MAX_DEPTH = 3.40282347E+38f;
    
    private float intensity;

    /// <summary>
    ///     Gets or sets the intensity of the sky.
    /// </summary>
    /// <value>
    ///     A value clamped between <c>0f</c> and <c>1f</c>.
    /// </value>
    public float Intensity
    {
        get => intensity;
        protected set => intensity = Math.Clamp(value, 0f, 1f);
    }

    /// <summary>
    ///     Gets whether the sky is enabled or not.
    /// </summary>
    public bool Enabled { get; protected set; }

    /// <summary>
    ///     Gets the rate at which the sky fades in and out.
    /// </summary>
    public virtual float Fade { get; } = 0.01f;

    public override void Update(GameTime gameTime)
    {
        Intensity += Enabled ? Fade : -Fade;
    }

    public override void Activate(Vector2 position, params object[] args)
    {
        Enabled = true;
    }

    public override void Deactivate(params object[] args)
    {
        Enabled = false;
    }

    public override void Reset()
    {
        Enabled = false;

        Intensity = 0f;
    }

    public override bool IsActive()
    {
        return Enabled || Intensity > 0f;
    }
}