Shader "Custom/InvertColor" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            float3 texColor = tex2D(_MainTex, IN.uv_MainTex).rgb;
            o.Albedo = 1.0 - texColor;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
