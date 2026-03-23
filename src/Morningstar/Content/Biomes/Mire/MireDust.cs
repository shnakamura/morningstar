using Morningstar.Core.Graphics;
using ReLogic.Content;

namespace Morningstar.Content.Biomes.Mire;

public class MireDust : ModDust
{
    /// <summary>
    ///     The color of the dust.
    /// </summary>
    public static readonly Color DustColor = new(189, 52, 235);
    
    /// <summary>
    ///     Gets the texture used for rendering the dust.
    /// </summary>
    public static Asset<Texture2D> DustTexture { get; private set; }
    
    /// <summary>
    ///     Gets the texture used for rendering the dust's bloom.
    /// </summary>
    public static Asset<Texture2D> BloomTexture { get; private set; }
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        if (Main.dedServ)
        {
            return;
        }

        DustTexture = ModContent.Request<Texture2D>(Texture);
        BloomTexture = ModContent.Request<Texture2D>(Texture + "_Bloom");
    }

    public override void OnSpawn(Dust dust)
    {
        base.OnSpawn(dust);

        dust.noLightEmittence = true;
        dust.noGravity = true;
        dust.noLight = true;

        dust.alpha = 255;
        dust.color = DustColor;

        dust.frame = new Rectangle(0, Main.rand.Next(3) * 14, 14, 14);
        
        dust.customData = new MireDustData(dust.position, Main.rand.Next(2, 5) * 60);
    }

    public override bool Update(Dust dust)
    {
        dust.position += dust.velocity;

        UpdateVelocity(dust);
        UpdateDuration(dust);
        
        dust.rotation += dust.velocity.X * 0.01f;

        dust.alpha = (int)MathHelper.Clamp(dust.alpha, 0, 255);
        
        return false;
    }

    private void UpdateVelocity(Dust dust)
    {
        dust.velocity.X += Main.windSpeedCurrent / 4f;
        dust.velocity.Y -= 0.01f;

        if (!Main.rand.NextBool(5))
        {
            return;
        }
        
        dust.velocity = dust.velocity.RotatedByRandom(0.1f);
    }

    private void UpdateDuration(Dust dust)
    {
        if (dust.customData is not MireDustData data)
        {
            return;
        }

        dust.fadeIn++;
        
        if (dust.fadeIn < data.Duration)
        {
            dust.alpha -= 5;
        }
        else
        {
            dust.alpha += 1;

            if (dust.alpha < 255)
            {
                return;
            }
            
            dust.active = false;
        }
    }

    public override bool PreDraw(Dust dust)
    {
        if (dust.customData is not MireDustData data)
        {
            return false;
        }
        
        var interpolation = Vector2.Lerp(Main.screenPosition, Main.screenPosition - 2f * (data.SpawnPosition - Main.screenPosition), 0.5f);
        var size = Screen.Size * Main.UIScale;
        
        var position = dust.position - interpolation;

        while (position.X < 0f)
        {
            position.X += size.X;
        }
        
        while (position.Y < 0f)
        {
            position.Y += size.Y;
        }

        position.X %= size.X;
        position.Y %= size.Y;

        position *= Main.GameViewMatrix.Zoom;

        position -= 3f * ((size * Main.GameViewMatrix.Zoom) - size) / 4f;

        DrawBloom(dust, in position);
        DrawDust(dust, in position);
        
        return false;
    }

    private void DrawDust(Dust dust, in Vector2 position)
    {
        var texture = DustTexture.Value;
        
        var color = dust.GetAlpha(dust.color);
        var origin = dust.frame.Size() / 2f;
        
        Main.EntitySpriteDraw(texture, position, dust.frame, color, dust.rotation, origin, dust.scale, SpriteEffects.None, 0);
    }
    
    private void DrawBloom(Dust dust, in Vector2 position)
    {
        var texture = BloomTexture.Value;

        var frame = new Rectangle(0, dust.frame.Y / dust.frame.Height * 34, 34, 34);
        
        var color = dust.GetAlpha(dust.color);

        color.A = 0;
        
        var origin = frame.Size() / 2f;
        
        Main.EntitySpriteDraw(texture, position, frame, color, dust.rotation, origin, dust.scale, SpriteEffects.None, 0);
    }
}