sampler uImage0 : register(s0);

float3 uColor;

float4 PixelShaderFunction(float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
    
    if (!any(color))
    {
        return color;
    }

    float gradient = 1.0 - coords.y;
    
    color.rgb *= uColor;

    return float4(color.r, color.g, color.b, gradient);
}

technique MireMoonBloomTechnique
{
    pass MireMoonBloomPass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}