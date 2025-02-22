//Shader written by Keehan Roberts (@keehan12)
Shader "Custom/Diffuse_NoFog" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
}

SubShader {
	Tags {"RenderType" = "Opaque" "IgnoreProjector"="True"}
	LOD 200
	
CGPROGRAM
#pragma surface surf Lambert nofog

sampler2D _MainTex;
fixed4 _Color;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
}
ENDCG
}

Fallback "Legacy Shaders/Diffuse"
}