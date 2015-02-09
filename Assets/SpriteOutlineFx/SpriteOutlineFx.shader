Shader "Hidden/Sprite Outline"
{
    Properties
    {
        _MainTex  ("-", 2D) = ""{}
        _Distance ("-", Float) = 1
        _Color    ("-", Color) = (1, 0, 0, 0)
    }

    CGINCLUDE

    #include "UnityCG.cginc"

    sampler2D _MainTex;
    float2 _MainTex_TexelSize;
    float _Distance;
    half3 _Color;

    half4 frag(v2f_img i) : SV_Target 
    {
        half4 source = tex2D(_MainTex, i.uv);

        half a1 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2(-1, -1) * _Distance).a;
        half a2 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2( 0, -1) * _Distance).a;
        half a3 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2(+1, -1) * _Distance).a;

        half a4 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2(-1, 0) * _Distance).a;
        half a6 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2(+1, 0) * _Distance).a;

        half a7 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2(-1, 1) * _Distance).a;
        half a8 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2( 0, 1) * _Distance).a;
        half a9 = tex2D(_MainTex, i.uv + _MainTex_TexelSize * half2(+1, 1) * _Distance).a;

        half gx = -a1 -a2 * 2 -a3 + a7 + a8 * 2 + a9;
        half gy = -a1 -a4 * 2 -a7 + a3 + a6 * 2 + a9;

        half w = sqrt(gx * gx + gy * gy) / 4;

        return half4(lerp(source.rgb, _Color, w), 1);
    }

    ENDCG 

    Subshader
    {
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Fog { Mode off }      
            CGPROGRAM
            #pragma target 3.0
            #pragma glsl
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }
    }
}
