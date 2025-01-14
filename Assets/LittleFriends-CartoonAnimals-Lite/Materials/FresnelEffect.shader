Shader "Custom/FresnelEffect"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {} // �⺻ �ؽ�ó
        _FresnelColor ("Fresnel Color", Color) = (0.0, 0.7, 1.0, 1.0) // ������ ����
        _FresnelPower ("Fresnel Power", Range(1.0, 10.0)) = 2.0 // ������ ����
        _FresnelIntensity ("Fresnel Intensity", Range(0.0, 2.0)) = 1.0 // ������ ���
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // ���� ����
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION; // ���� ��ġ
                float3 normal : NORMAL; // ���� ����
                float2 uv : TEXCOORD0; // UV ��ǥ
            };

            struct v2f
            {
                float2 uv : TEXCOORD0; // UV ��ǥ ����
                float4 vertex : SV_POSITION; // Ŭ�� ������ ���� ��ġ
                float3 worldNormal : TEXCOORD1; // ���� ������ ���� ����
                float3 worldViewDir : TEXCOORD2; // ���� ������ �� ���� ����
            };

            sampler2D _MainTex; // �ؽ�ó ���÷�
            float4 _FresnelColor; // ������ ����
            float _FresnelPower; // ������ ����
            float _FresnelIntensity; // ������ ���

            // ���� ���̴�
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // ���� ��ǥ�� Ŭ�� ��ǥ�� ��ȯ
                o.uv = v.uv; // UV ��ǥ ����
                o.worldNormal = UnityObjectToWorldNormal(v.normal); // ���� ���� ���� ���
                o.worldViewDir = normalize(UnityWorldSpaceViewDir(v.vertex)); // ���� ���� �� ���� ���
                return o;
            }

            // �����׸�Ʈ ���̴�
            fixed4 frag (v2f i) : SV_Target
            {
                // �ؽ�ó ����
                fixed4 col = tex2D(_MainTex, i.uv);

                // ������ ȿ�� ���
                float fresnel = pow(1.0 - dot(normalize(i.worldNormal), normalize(i.worldViewDir)), _FresnelPower);
                fresnel *= _FresnelIntensity;

                // ������ ���� �߰�
                fixed4 fresnelColor = _FresnelColor * fresnel;

                // ���� ���� = �ؽ�ó ���� + ������ ����
                return col + fresnelColor;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
