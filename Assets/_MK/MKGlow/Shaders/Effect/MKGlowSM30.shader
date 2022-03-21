﻿//////////////////////////////////////////////////////
// MK Glow Shader SM35								//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2021 All rights reserved.            //
//////////////////////////////////////////////////////
Shader "Hidden/MK/Glow/MKGlowSM30"
{
	SubShader
	{
		Tags {"LightMode" = "Always" "RenderType"="Opaque" "PerformanceChecks"="False"}
		Cull Off ZWrite Off ZTest Always

		/////////////////////////////////////////////////////////////////////////////////////////////
        // Presample - 0
        /////////////////////////////////////////////////////////////////////////////////////////////
		Pass
		{
			HLSLPROGRAM
			#pragma target 3.0
			#pragma vertex vertSimple
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#pragma require mrt4

			#pragma multi_compile __ _NORMALMAP
			#pragma multi_compile __ _ALPHABLEND_ON
			#pragma multi_compile __ OUTLINE_ON _COLORCOLOR_ON
			#pragma multi_compile __ UNDERLAY_ON
			#pragma multi_compile __ UNDERLAY_INNER

			#include "../Inc/Presample.hlsl"
			ENDHLSL
		}

		/////////////////////////////////////////////////////////////////////////////////////////////
        // Downsample - 1
        /////////////////////////////////////////////////////////////////////////////////////////////
		Pass
		{
			HLSLPROGRAM
			#pragma target 3.0
			#pragma vertex vertSimple
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#pragma require mrt4

			#pragma multi_compile __ _NORMALMAP
			#pragma multi_compile __ _ALPHABLEND_ON
			#pragma multi_compile __ OUTLINE_ON _COLORCOLOR_ON

			#include "../Inc/Downsample.hlsl"
			ENDHLSL
		}

		/////////////////////////////////////////////////////////////////////////////////////////////
        // Upsample - 2
        /////////////////////////////////////////////////////////////////////////////////////////////
		Pass
		{
			HLSLPROGRAM
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#pragma require mrt4

			#pragma multi_compile __ _NORMALMAP
			#pragma multi_compile __ _ALPHABLEND_ON
			#pragma multi_compile __ OUTLINE_ON _COLORCOLOR_ON

			#include "../Inc/Upsample.hlsl"
			ENDHLSL
		}

		/////////////////////////////////////////////////////////////////////////////////////////////
        // Composite - 3
        /////////////////////////////////////////////////////////////////////////////////////////////
		Pass
		{
			HLSLPROGRAM
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#pragma multi_compile __ _COLOROVERLAY_ON

			#pragma require mrt4

			#pragma multi_compile __ _ALPHATEST_ON
			#pragma multi_compile __ _ALPHABLEND_ON
			#pragma multi_compile __ OUTLINE_ON _COLORCOLOR_ON
			#pragma multi_compile __ UNDERLAY_ON

			#include "../Inc/Composite.hlsl"
			ENDHLSL
		}

		/////////////////////////////////////////////////////////////////////////////////////////////
        // Debug - 4
        /////////////////////////////////////////////////////////////////////////////////////////////
		Pass
		{
			HLSLPROGRAM
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#pragma multi_compile __ _COLOROVERLAY_ON

			#pragma require mrt4
			
			#pragma multi_compile __ _EMISSION _METALLICGLOSSMAP _SPECULARHIGHLIGHTS_OFF EDITOR_VISUALIZATION
			#pragma multi_compile __ _ALPHATEST_ON
			#pragma multi_compile __ _ALPHABLEND_ON
			#pragma multi_compile __ OUTLINE_ON _COLORCOLOR_ON
			#pragma multi_compile __ UNDERLAY_ON
			#pragma multi_compile __ UNDERLAY_INNER
			
			#include "../Inc/Debug.hlsl"
			ENDHLSL
		}
	}
	FallBack "Hidden/MK/Glow/MKGlowSM25"
}
