sampler uImage0 : register(s0);

float uQuantization;

float4 PixelShaderFunction(float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
    
    if (!any(color))
    {
        return color;
    }

    color.r = floor(color.r * uQuantization) / uQuantization;
    color.g = floor(color.g * uQuantization) / uQuantization;
    color.b = floor(color.b * uQuantization) / uQuantization;

    float gradient = 1.0 - coords.y;

    return color * gradient;
}

technique MireMoonTechnique
{
    pass MireMoonPass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}