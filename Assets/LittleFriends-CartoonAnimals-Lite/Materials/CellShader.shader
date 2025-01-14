Shader "Custom/CellShader"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" { }
        _Color ("Base Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _Color;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = normalize(mul((float3x3)unity_ObjectToWorld, v.normal));
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // Calculate light intensity
                float intensity = dot(normalize(i.normal), normalize(_WorldSpaceLightPos0.xyz));
                intensity = saturate(intensity); // Clamp to [0, 1]

                // Divide intensity into 4 levels
                float levels = 4.0; // Number of color levels
                intensity = floor(intensity * levels) / (levels - 1.0);

                // Apply texture and color
                half4 color = tex2D(_MainTex, i.uv) * _Color;
                return color * intensity;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
