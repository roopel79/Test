Shader "Custom/MetallicShader"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 1.0
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
        _Color ("Base Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float _Metallic;
        float _Smoothness;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // 텍스처 샘플링
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

            // 색상 출력
            o.Albedo = c.rgb;

            // 메탈릭 및 스무스니스 설정
            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;

            // 에미션을 원한다면 이 부분에서 설정
            o.Emission = c.rgb * 0.1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
