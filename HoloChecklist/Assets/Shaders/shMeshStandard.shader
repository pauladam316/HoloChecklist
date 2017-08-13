// Upgrade NOTE: replaced 'UNITY_INSTANCE_ID' with 'UNITY_VERTEX_INPUT_INSTANCE_ID'

Shader "Unlit/Standard Unlit"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Main Color", Color) = (1,1,1,1)
		_Tint("Selection Tint", Color) = (1,1,1,1)

		[HideInInspector] _Cutoff("Alpha cutoff", Range(0,1)) = 0
		[HideInInspector] _Mode("__mode", Float) = 0
		[HideInInspector] _SrcBlend("__src", Float) = 1.0
		[HideInInspector] _DstBlend("__dst", Float) = 0.0
		[HideInInspector] _ZWrite("__zw", Int) = 1.0
	}  
	SubShader
	{	
		Pass
		{
			Tags{ "RenderType" = "Opaque" "IgnoreProjector" = "True" }
			LOD 100

			ZWrite [_ZWrite]
			Blend[_SrcBlend][_DstBlend]

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"

			struct appdata
			{
				fixed4 vertex : POSITION;
				fixed2 uv : TEXCOORD0;
				fixed4 color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				fixed2 uv : TEXCOORD0;
				fixed4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			sampler2D _MainTex;
			fixed4 _MainTex_ST;
			fixed4 _Color; 
			fixed4 _Tint;
			fixed _Cutoff;

			UNITY_INSTANCING_CBUFFER_START(MyProperties)
			UNITY_INSTANCING_CBUFFER_END

			v2f vert (appdata v)
			{
				v2f o;

				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.color = v.color;
				return o;
			}
			
			fixed4 frag (v2f i) : Color
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				clip(col.a - _Cutoff);
				col *= _Color;
				col *= i.color;
				col *= _Tint;
				UNITY_SETUP_INSTANCE_ID(i);
				return col;
			}
			ENDCG
		}
	}
CustomEditor "ShaderRenderMode"
}
