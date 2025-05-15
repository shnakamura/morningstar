namespace Morningstar.Content.Biomes.Inferno;

public sealed class InfernoSurfaceBackground : ModSurfaceBackgroundStyle
{
    public override void ModifyFarFades(float[] fades, float transitionSpeed) 
    {
        for (var i = 0; i < fades.Length; i++) 
        {
            if (i == Slot) 
            {
                fades[i] += transitionSpeed;
            }
            else 
            {
                fades[i] -= transitionSpeed;
            }

            fades[i] = MathHelper.Clamp(fades[i], 0f, 1f);
        }
    }
    
    public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
    {
        return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/Inferno/InfernoSurfaceBackground_Close");
    }

    public override int ChooseMiddleTexture()
    {
        return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/Inferno/InfernoSurfaceBackground_Middle");
    }

    public override int ChooseFarTexture()
    {
        return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/Inferno/InfernoSurfaceBackground_Far");
    }
}