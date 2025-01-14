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
            // �ؽ�ó ���ø�
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

            // ���� ���
            o.Albedo = c.rgb;

            // ��Ż�� �� �������Ͻ� ����
            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;

            // ���̼��� ���Ѵٸ� �� �κп��� ����
            o.Emission = c.rgb * 0.1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
