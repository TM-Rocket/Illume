//////////////////////////////////////////////////////
// MK Glow Settings PPSV2	    	    	        //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Glow.LWRP
{
    internal sealed class SettingsPPSV2 : MK.Glow.Settings
    {
        public static implicit operator SettingsPPSV2(MK.Glow.LWRP.MKGlow input)
        {
            SettingsPPSV2 settings = new SettingsPPSV2();
            
            //Main
            settings.allowComputeShaders = false;
            settings.allowGeometryShaders = false;
            settings.renderPriority = input.renderPriority;
            settings.debugView = input.debugView;
            settings.quality = input.quality;
            settings.antiFlickerMode = input.antiFlickerMode;
            settings.workflow = input.workflow;
            settings.selectiveRenderLayerMask = input.selectiveRenderLayerMask;
            settings.anamorphicRatio = input.anamorphicRatio;
            settings.lumaScale = input.lumaScale;

            //Bloom
            settings.bloomThreshold = input.bloomThreshold;
            settings.bloomScattering = input.bloomScattering;
            settings.bloomIntensity = input.bloomIntensity;
            settings.blooming = input.blooming;

            //LensSurface
            settings.allowLensSurface = input.allowLensSurface;
            settings.lensSurfaceDirtTexture = input.lensSurfaceDirtTexture;
            settings.lensSurfaceDirtIntensity = input.lensSurfaceDirtIntensity;
            settings.lensSurfaceDiffractionTexture = input.lensSurfaceDiffractionTexture;
            settings.lensSurfaceDiffractionIntensity = input.lensSurfaceDiffractionIntensity;

            //LensFlare
            settings.allowLensFlare = input.allowLensFlare;
            settings.lensFlareStyle = input.lensFlareStyle;
            settings.lensFlareGhostFade = input.lensFlareGhostFade;
            settings.lensFlareGhostIntensity = input.lensFlareGhostIntensity;
            settings.lensFlareThreshold = input.lensFlareThreshold;
            settings.lensFlareScattering = input.lensFlareScattering;
            settings.lensFlareColorRamp = input.lensFlareColorRamp;
            settings.lensFlareChromaticAberration = input.lensFlareChromaticAberration;
            settings.lensFlareGhostCount = input.lensFlareGhostCount;
            settings.lensFlareGhostDispersal = input.lensFlareGhostDispersal;
            settings.lensFlareHaloFade = input.lensFlareHaloFade;
            settings.lensFlareHaloIntensity = input.lensFlareHaloIntensity;
            settings.lensFlareHaloSize = input.lensFlareHaloSize;

            settings.SetLensFlarePreset(input.lensFlareStyle);

            //Glare
            settings.allowGlare = input.allowGlare;
            settings.glareBlend = input.glareBlend;
            settings.glareIntensity = input.glareIntensity;
            settings.glareThreshold = input.glareThreshold;
            settings.glareStreaks = input.glareStreaks;
            settings.glareScattering = input.glareScattering;
            settings.glareStyle = input.glareStyle;
            settings.glareAngle = input.glareAngle;

            //Sample0
            settings.glareSample0Scattering = input.glareSample0Scattering;
            settings.glareSample0Angle = input.glareSample0Angle;
            settings.glareSample0Intensity = input.glareSample0Intensity;
            settings.glareSample0Offset = input.glareSample0Offset;
            //Sample1
            settings.glareSample1Scattering = input.glareSample1Scattering;
            settings.glareSample1Angle = input.glareSample1Angle;
            settings.glareSample1Intensity = input.glareSample1Intensity;
            settings.glareSample1Offset = input.glareSample1Offset;
            //Sample2
            settings.glareSample2Scattering = input.glareSample2Scattering;
            settings.glareSample2Angle = input.glareSample2Angle;
            settings.glareSample2Intensity = input.glareSample2Intensity;
            settings.glareSample2Offset = input.glareSample2Offset;
            //Sample3
            settings.glareSample3Scattering = input.glareSample3Scattering;
            settings.glareSample3Angle = input.glareSample3Angle;
            settings.glareSample3Intensity = input.glareSample3Intensity;
            settings.glareSample3Offset = input.glareSample3Offset;

            settings.SetGlarePreset(input.glareStyle);

            return settings;
        }
    }
}
