Shader "Custom/FresnelEffect"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {} // 기본 텍스처
        _FresnelColor ("Fresnel Color", Color) = (0.0, 0.7, 1.0, 1.0) // 프레넬 색상
        _FresnelPower ("Fresnel Power", Range(1.0, 10.0)) = 2.0 // 프레넬 강도
        _FresnelIntensity ("Fresnel Intensity", Range(0.0, 2.0)) = 1.0 // 프레넬 밝기
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // 알파 블렌딩
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION; // 정점 위치
                float3 normal : NORMAL; // 법선 벡터
                float2 uv : TEXCOORD0; // UV 좌표
            };

            struct v2f
            {
                float2 uv : TEXCOORD0; // UV 좌표 전달
                float4 vertex : SV_POSITION; // 클립 공간의 정점 위치
                float3 worldNormal : TEXCOORD1; // 월드 공간의 법선 벡터
                float3 worldViewDir : TEXCOORD2; // 월드 공간의 뷰 방향 벡터
            };

            sampler2D _MainTex; // 텍스처 샘플러
            float4 _FresnelColor; // 프레넬 색상
            float _FresnelPower; // 프레넬 강도
            float _FresnelIntensity; // 프레넬 밝기

            // 정점 셰이더
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // 월드 좌표를 클립 좌표로 변환
                o.uv = v.uv; // UV 좌표 전달
                o.worldNormal = UnityObjectToWorldNormal(v.normal); // 월드 공간 법선 계산
                o.worldViewDir = normalize(UnityWorldSpaceViewDir(v.vertex)); // 월드 공간 뷰 방향 계산
                return o;
            }

            // 프래그먼트 셰이더
            fixed4 frag (v2f i) : SV_Target
            {
                // 텍스처 색상
                fixed4 col = tex2D(_MainTex, i.uv);

                // 프레넬 효과 계산
                float fresnel = pow(1.0 - dot(normalize(i.worldNormal), normalize(i.worldViewDir)), _FresnelPower);
                fresnel *= _FresnelIntensity;

                // 프레넬 색상 추가
                fixed4 fresnelColor = _FresnelColor * fresnel;

                // 최종 색상 = 텍스처 색상 + 프레넬 색상
                return col + fresnelColor;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
