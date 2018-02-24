// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "HeroGo/General/OneDirLight/Bumped_Avatar_MultiLight"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Bump (RGB)", 2D) = "white" {}
		_Ramp("Toon Ramp (RGB)", 2D) = "gray" {}

		_ShadowColor("Shadow Color(Toon color in shadow)",Color) = (0.0,0.0,0.0,0.0)
		_LittenColor("Litten Color(Toon color lit)",Color) = (0.0,1.0,1.0,1.0)
		_SkinColor("Skin Color",Color) = (0.62,0.47,0.47,0.0)
		_Mask0("Extent Mask 0 (RGB)", 2D) = "gray" {}
			
		_DummyLightDir("Virtual light direction",Vector) = (0.707,0.707,0,0)
		_LightExposure("Light exposure",Range(0.5, 2)) = 1
		_FresnelPow("Fresnel Pow",Range(1, 6)) = 3
		_FresnelFactor("Fresnel Factor",Range(0, 1)) = 0.1
	}
	SubShader
	{
		Tags
		{
			"LightMode" = "ForwardBase"
			"RenderType" = "Opaque"
		}
		LOD 100

		Pass
		{
			Name "BUMPED_AVATAR_MULTILIGHT"

			Cull Back
			Lighting Off
			ZWrite On

			Fog{ Mode Off }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
					// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"
			#include "../Inc/Base.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float2 uv : TEXCOORD0;
			};
		
			struct v2f
			{
				float2 uv_MainTex		: TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float3 WorldNormal		: TEXCOORD2;
				float3 WorldTangent		: TEXCOORD3;
				float3 WorldBinormal	: TEXCOORD4;
				float3 viewDir			: TEXCOORD5;

				float4 HPosition		: SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _BumpMap;
			sampler2D _Ramp;
			float4 _MainTex_ST;

			sampler2D _Mask0;
			fixed4 _ShadowColor;
			fixed4 _LittenColor;
			fixed4 _SkinColor;

			real3 _DummyLightDir;
			real _LightExposure;
			real _FresnelPow;
			real _FresnelFactor;

			v2f vert(appdata v)
			{
				v2f o;
				o.HPosition = UnityObjectToClipPos(v.vertex);
				half3 binormal = cross(v.normal, v.tangent.xyz) * v.tangent.w;
				o.WorldNormal = mul(unity_ObjectToWorld, real4(v.normal,0));
				o.WorldTangent = mul(unity_ObjectToWorld, real4(v.tangent.xyz, 0));
				o.WorldBinormal = mul(unity_ObjectToWorld, real4(binormal, 0));

				o.viewDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, v.vertex).xyz);
				o.uv_MainTex = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.HPosition);

				return o;
			}


			fixed4 phong_term(in real3 vLight, in real3 vNormal, in real3 vView, in real spec_factor, in real spec_power, in fixed4 cAlbedo, in fixed4 cShadow, in fixed4 cLitten)
			{
				/// specular
				half3 Hn = normalize(vLight + vView);
				half3 NdotH = saturate(dot(vNormal, Hn));

				fixed4 c;
				fixed3 specular = pow(NdotH, spec_power);
				specular = specular * specular * spec_factor;

				c.rgb = cAlbedo * lerp(cShadow.rgb, cLitten.rgb, dot(vNormal, vLight));
				c.rgb += specular;
				c.a = cAlbedo.a;
				return c;
			}

			fixed4 rim_lighting_term(real3 vNormal, real3 vView, real factor, real offset)
			{
				real fresnel = 1.0 - saturate(dot(vNormal, vView));
				return pow(fresnel, factor) * _FresnelFactor;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				/// Albedo comes from a texture tinted by color
				fixed4 albedo = tex2D(_MainTex, IN.uv_MainTex);
				fixed4 mask0 = tex2D(_Mask0, IN.uv_MainTex);

				/// Normal map
				real3 bump = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
				//real3 bump = 2.0f * tex2D(_BumpMap, IN.uv_MainTex) -1.0f;
				//bump.y = -bump.y;

				real3 Nn = normalize(IN.WorldNormal);
				real3 Tn = normalize(IN.WorldTangent);
				real3 Bn = normalize(IN.WorldBinormal);

				Nn = Nn * bump.z + bump.x * Tn + bump.y * Bn;
				Nn = normalize(Nn);

				//fixed4 col = toon_term(_Ramp, normalize(_DummyLightDir.xyz), Nn, albedo, _ShadowColor, _LittenColor);
				real3 Ln = normalize(_WorldSpaceLightPos0.xyz);
				_ShadowColor = lerp(_ShadowColor,_SkinColor, mask0.g);
				//fixed4 col = toon_term(_Ramp, Ln, Nn, albedo, _ShadowColor, _LittenColor);
				//col.rgb *= _LightExposure;
				//
				//
				///// specular
				//half3 Hn = normalize(Ln + IN.viewDir);
				//half3 NdotH = saturate(dot(Nn, Hn));
				//fixed3 specular = pow( NdotH, 16) ;
				//col.xyz += specular * specular * mask0.b;
				fixed4 col = phong_term(Ln, Nn, IN.viewDir, mask0.b, 16, albedo, _ShadowColor, _LittenColor);
				
				fixed3 fresnel = rim_lighting_term(Nn, IN.viewDir, _FresnelPow, _FresnelFactor);
				col.xyz += fresnel * albedo.rgb;
				// apply fog
				UNITY_APPLY_FOG(IN.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
	FallBack "HeroGo/General/OneDirLight/Bumped"
}
