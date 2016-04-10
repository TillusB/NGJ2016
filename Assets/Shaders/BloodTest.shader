Shader "Unlit/BloodTest"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	}
	SubShader
	{
//		Tags {"Queue" = "Overlay" }
		ZWrite Off
	    Blend SrcAlpha OneMinusSrcAlpha     
//	    Blend SrcAlpha One     

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag	
			#include "UnityCG.cginc"	
			float4 _TintColor;
			sampler2D _MainTex;	
			struct v2f {
			    float4  pos : SV_POSITION;
			    float2  uv : TEXCOORD0;
			};	
			float4 _MainTex_ST;		
			v2f vert (appdata_base v){
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
			    return o;
			}	
			
			fixed4 frag (v2f i) : COLOR
			{
				// sample the texture
				half4 texcol= tex2D (_MainTex, i.uv) * _TintColor; 
				half4 finalColor= texcol;		


//				finalColor.a = floor((finalColor.a/0.1)*0.5) * 0.25; //4 colors
//				finalColor.a = floor((finalColor.a/0.1)*0.25) * 0.5; //2 colors 
				finalColor.a = floor(finalColor.a*4.0) * 0.33333333; //3 colors 


				return finalColor;
			}


			ENDCG
		}
	}

}
