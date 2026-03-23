sampler uImage0 : register(s0);

float uIntensity;
float uTime;
float uQuantization;

float2 uScreenPosition;
float2 uScreenResolution;

float4 PixelShaderFunction(float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
    
    if (!any(color))
    {
        return color;
    }

    float2 center = coords - 0.5;

    float offsetX = sin((center.y + uTime * 0.04) * 6.0) * uIntensity;
    float offsetY = cos((center.x + uTime * 0.05) * 8.0) * uIntensity;

    coords += float2(offsetX, offsetY);

    float2 screenOffset = uScreenPosition / uScreenResolution;

    float2 coordsClose = frac(coords * 1.2 + screenOffset * 0.08);
    float2 coordsMiddle = frac(coords * 1.0 + screenOffset * 0.05);
    float2 coordsFar = frac(coords * 0.8 + screenOffset * 0.02);

    float4 closeLayer = tex2D(uImage0, coordsClose);
    float4 middleLayer = tex2D(uImage0, coordsMiddle);
    float4 farLayer = tex2D(uImage0, coordsFar);

    float4 result = farLayer * 0.5 + middleLayer * 0.35 + closeLayer * 0.15;

    float pulse = sin(uTime * 0.4) * 0.05 + 0.95;
    
    result.rgb *= pulse;

    result.r = floor(result.r * uQuantization) / uQuantization;
    result.g = floor(result.g * uQuantization) / uQuantization;
    result.b = floor(result.b * uQuantization) / uQuantization;

    return result;
}

technique MireSkyTechnique
{
    pass MireSkyPass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}