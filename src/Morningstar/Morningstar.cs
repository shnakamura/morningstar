namespace Morningstar;

/// <summary>
///     The <see cref="Mod" /> implementation for the Morningstar mod.
/// </summary>
public sealed class Morningstar : Mod
{
    /// <summary>
    ///     Gets the singleton instance of the <see cref="Morningstar" /> class. Shorthand for
    ///     <c>ModContent.GetInstance&lt;Morningstar&gt;()</c>.
    /// </summary>
    public static Morningstar Instance => ModContent.GetInstance<Morningstar>();
}