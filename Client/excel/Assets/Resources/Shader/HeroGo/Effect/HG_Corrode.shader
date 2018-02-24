// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "HeroGo/Effect/Corrode"
{
	Properties
	{
		_MainTex("Albedo", 2D) = "white" {}
		_Noise("Noise", 2D) = "gray" {}
		_Ramp("Ramp", 2D) = "white" {}

		_Factor("Factor", Range(0,1)) = 0
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		//Tags { "Queue"="Transparent" }
		LOD 100

		//Blend SrcAlpha One
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _Noise;
			sampler2D _Ramp;
			float4 _MainTex_ST;
			float _Factor;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 noise = tex2D(_Noise, i.uv);
				half3 nornoise = noise.rgb;
				fixed degree = saturate(noise.x - _Factor + 0.001f);
				fixed4 ramp = tex2D(_Ramp,1-degree.x);
				half3 normRamp = normalize(ramp);

				clip(degree - 0.001f);

				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				half weight = step(_Factor*5, degree);
				col.rgb = weight * col + (1 - weight) * ramp.rgb;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
