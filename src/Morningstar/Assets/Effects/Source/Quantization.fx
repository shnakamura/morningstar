sampler uImage0 : register(s0);

float uIntensity;

float4 PixelShaderFunction(float2 uv : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, uv);
    
    color.r = floor(color.r * uIntensity) / uIntensity;
    color.g = floor(color.g * uIntensity) / uIntensity;
    color.b = floor(color.b * uIntensity) / uIntensity;
    
    return color;
}

technique QuantizationTechnique
{
    pass QuantizationPass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}