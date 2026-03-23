sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);

float4 uSourceRect;

float3 uColor;
float3 uSecondaryColor;

float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;

float2 uDirection;

float uOpacity;
float uTime;
float uProgress;
float uIntensity;

float2 uImageSize1;
float2 uImageSize2;
float2 uImageSize3;

float2 uImageOffset;

float uSaturation;

float2 uZoom;

float uOuterRadius;
float uInnerRadius;
float uCurvature;

float4 PixelShaderFunction(float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
    
    float2 curve = pow(abs(coords * 2.0 - 1.0), 1.0 / uCurvature);
    
    float edge = pow(length(curve), uCurvature);
    float vignette = 1.0 - uIntensity * smoothstep(uInnerRadius, uOuterRadius, edge);
    
    color.rgb = lerp(uColor, color.rgb, vignette);
    color.rgb *= uOpacity;
    
    return color;
}

technique VignetteTechnique
{
    pass VignettePass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}

