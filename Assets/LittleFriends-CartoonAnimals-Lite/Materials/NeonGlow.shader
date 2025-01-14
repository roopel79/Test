Shader "Custom/NeonGlow" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _GlowColor ("Glow Color", Color) = (0, 1, 1, 1)
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 1.0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 300

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed4 _GlowColor;
        float _GlowIntensity;

        struct Input {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            float3 texColor = tex2D(_MainTex, IN.uv_MainTex).rgb;
            float glow = dot(texColor, float3(0.3, 0.59, 0.11)) * _GlowIntensity;
            o.Albedo = texColor + _GlowColor.rgb * glow;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
