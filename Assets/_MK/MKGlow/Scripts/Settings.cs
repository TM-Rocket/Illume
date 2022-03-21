//////////////////////////////////////////////////////
// MK Glow Settings 	    	    	       		//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2021 All rights reserved.            //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Glow
{
    //The default settings for each pipeline is set in the script itself
    //this could be optimized some day...
    //Used for passing user based settings into the pipeline
    internal abstract class Settings
    {
        //Main
        protected bool _allowGeometryShaders;
        internal bool allowGeometryShaders
        { 
            get { return _allowGeometryShaders; }
            set { _allowGeometryShaders = value; }
        }

        protected bool _allowComputeShaders;
        internal bool allowComputeShaders 
        { 
            get { return _allowComputeShaders; }
            set { _allowComputeShaders = value; }
        }

        protected RenderPriority _renderPriority;
        internal RenderPriority renderPriority 
        { 
            get { return _renderPriority; }
            set { _renderPriority = value; }
        }

        protected MK.Glow.DebugView _debugView;
        internal MK.Glow.DebugView debugView
        { 
            get { return _debugView; }
            set { _debugView = value; }
        }

        protected MK.Glow.Quality _quality;
        internal MK.Glow.Quality quality
        { 
            get { return _quality; }
            set { _quality = value; }
        }

        protected MK.Glow.AntiFlickerMode _antiFlickerMode;
        internal MK.Glow.AntiFlickerMode antiFlickerMode
        { 
            get { return _antiFlickerMode; }
            set { _antiFlickerMode = value; }
        }

        protected MK.Glow.Workflow _workflow;
        internal MK.Glow.Workflow workflow
        { 
            get { return _workflow; }
            set { _workflow = value; }
        }

        protected LayerMask _selectiveRenderLayerMask;
        internal LayerMask selectiveRenderLayerMask
        { 
            get { return _selectiveRenderLayerMask; }
            set { _selectiveRenderLayerMask = value; }
        }

        protected float _anamorphicRatio;
        internal float anamorphicRatio
        { 
            get { return _anamorphicRatio; }
            set { _anamorphicRatio = Mathf.Clamp(value, -1f, 1f); }
        }

        protected float _lumaScale;
        internal float lumaScale
        { 
            get { return _lumaScale; }
            set { _lumaScale = Mathf.Clamp01(value); }
        }

        protected float _blooming;
		internal float blooming
		{ 
			get { return _blooming; }
			set { _blooming = Mathf.Clamp01(value); }
		}

        //Bloom
		protected MK.Glow.MinMaxRange _bloomThreshold;
		internal MK.Glow.MinMaxRange bloomThreshold
		{ 
			get { return _bloomThreshold; }
			set { _bloomThreshold = value; }
		}

		protected float _bloomScattering;
		internal float bloomScattering
		{ 
			get { return _bloomScattering; }
			set { _bloomScattering = Mathf.Clamp(value, 0f, 10f); }
		}
        
		protected float _bloomIntensity;
		internal float bloomIntensity
		{ 
			get { return _bloomIntensity; }
			set { _bloomIntensity = Mathf.Max(0, value); }
		}

        //LensSurface
		protected bool _allowLensSurface;
		internal bool allowLensSurface
		{ 
			get { return _allowLensSurface; }
			set { _allowLensSurface = value; }
		}

		protected Texture2D _lensSurfaceDirtTexture;
		internal Texture2D lensSurfaceDirtTexture
		{ 
			get { return _lensSurfaceDirtTexture; }
			set { _lensSurfaceDirtTexture = value; }
		}

		protected float _lensSurfaceDirtIntensity;
		internal float lensSurfaceDirtIntensity
		{ 
			get { return _lensSurfaceDirtIntensity; }
			set { _lensSurfaceDirtIntensity = Mathf.Max(0f, value); }
		}

        protected Texture2D _lensSurfaceDirtDistortionTexture;
		internal Texture2D lensSurfaceDirtDistortionTexture
		{ 
			get { return _lensSurfaceDirtDistortionTexture; }
			set { _lensSurfaceDirtDistortionTexture = value; }
		}

        protected float _lensSurfaceDirtDistortion;
		internal float lensSurfaceDirtDistortion
		{ 
			get { return _lensSurfaceDirtDistortion; }
			set { _lensSurfaceDirtDistortion = Mathf.Max(0f, value); }
		}

		protected Texture2D _lensSurfaceDiffractionTexture;
		internal Texture2D lensSurfaceDiffractionTexture
		{ 
			get { return _lensSurfaceDiffractionTexture; }
			set { _lensSurfaceDiffractionTexture = value; }
		}

		protected float _lensSurfaceDiffractionIntensity;
		internal float lensSurfaceDiffractionIntensity
		{ 
			get { return _lensSurfaceDiffractionIntensity; }
			set { _lensSurfaceDiffractionIntensity = Mathf.Max(0f, value); }
		}

        //LensFlare
		protected bool _allowLensFlare;
		internal bool allowLensFlare
		{ 
			get { return _allowLensFlare; }
			set { _allowLensFlare = value; }
		}

        protected LensFlareStyle _lensFlareStyle;
        internal LensFlareStyle lensFlareStyle
		{ 
			get { return _lensFlareStyle; }
			set { _lensFlareStyle = value; }
		}

		protected float _lensFlareGhostFade;
		internal float lensFlareGhostFade
		{ 
			get { return _lensFlareGhostFade; }
			set { _lensFlareGhostFade = Mathf.Max(0f, value); }
		}

		protected float _lensFlareGhostIntensity;
		internal float lensFlareGhostIntensity
		{ 
			get { return _lensFlareGhostIntensity; }
			set { _lensFlareGhostIntensity = Mathf.Max(0f, value); }
		}

		protected MK.Glow.MinMaxRange _lensFlareThreshold;
		internal MK.Glow.MinMaxRange lensFlareThreshold
		{ 
			get { return _lensFlareThreshold; }
			set { _lensFlareThreshold = value; }
		}

		protected float _lensFlareScattering;
		internal float lensFlareScattering
		{ 
			get { return _lensFlareScattering; }
			set { _lensFlareScattering = Mathf.Clamp(value, 0f, 10f); }
		}

		protected Texture2D _lensFlareColorRamp;
		internal Texture2D lensFlareColorRamp
		{ 
			get { return _lensFlareColorRamp; }
			set { _lensFlareColorRamp = value; }
		}

		protected float _lensFlareChromaticAberration;
		internal float lensFlareChromaticAberration
		{ 
			get { return _lensFlareChromaticAberration; }
			set { _lensFlareChromaticAberration = value; }
		}

		protected int _lensFlareGhostCount;
		internal int lensFlareGhostCount
		{ 
			get { return _lensFlareGhostCount; }
			set { _lensFlareGhostCount = Mathf.Clamp(value, 0, 5); }
		}

		protected float _lensFlareGhostDispersal;
		internal float lensFlareGhostDispersal
		{ 
			get { return _lensFlareGhostDispersal; }
			set { _lensFlareGhostDispersal = Mathf.Clamp(value, -1f, 1f); }
		}

		protected float _lensFlareHaloFade;
		internal float lensFlareHaloFade
		{
			get { return _lensFlareHaloFade; }
			set { _lensFlareHaloFade = Mathf.Max(0f, value); }
		}
        
		protected float _lensFlareHaloIntensity;
		internal float lensFlareHaloIntensity
		{ 
			get { return _lensFlareHaloIntensity; }
			set { _lensFlareHaloIntensity = Mathf.Max(0f, value); }
		}

		protected float _lensFlareHaloSize;
		internal float lensFlareHaloSize
		{ 
			get { return _lensFlareHaloSize; }
			set { _lensFlareHaloSize = Mathf.Clamp01(value); }
		}

        /// <summary>
        /// Set a preset for the glare effect
        /// </summary>
        internal void SetLensFlarePreset(LensFlareStyle lensFlareStyle)
        {
            switch(lensFlareStyle)
            {
                case LensFlareStyle.Average:
                    lensFlareGhostFade = 7.5f;
                    lensFlareGhostCount = 3;
                    lensFlareGhostDispersal = 0.67f;

                    lensFlareHaloFade = 7.5f;
                    lensFlareHaloSize = 0.5f;
                break;
                case LensFlareStyle.MultiAverage:
                    lensFlareGhostFade = 7.5f;
                    lensFlareGhostCount = 4;
                    lensFlareGhostDispersal = 0.4f;

                    lensFlareHaloFade = 7.5f;
                    lensFlareHaloSize = 0.5f;
                break;
                case LensFlareStyle.Old:
                    lensFlareGhostFade = 7.5f;
                    lensFlareGhostCount = 3;
                    lensFlareGhostDispersal = -1;

                    lensFlareHaloFade = 7.5f;
                    lensFlareHaloSize = 0.5f;
                break;
                case LensFlareStyle.OldFocused:
                    lensFlareGhostFade = 7.5f;
                    lensFlareGhostCount = 3;
                    lensFlareGhostDispersal = -0.75f;

                    lensFlareHaloFade = 7.5f;
                    lensFlareHaloSize = 0.2f;
                break;
                case LensFlareStyle.Distorted:
                    lensFlareGhostFade = 7.5f;
                    lensFlareGhostCount = 3;
                    lensFlareGhostDispersal = 0.62f;

                    lensFlareHaloFade = 7.5f;
                    lensFlareHaloSize = 0.56f;
                break;
                default:
                    //Custom no change at all
                break;
            }
        }

        //Glare
		protected bool _allowGlare;
		internal bool allowGlare
		{ 
			get { return _allowGlare; }
			set { _allowGlare = value; }
		}
        
        protected float _glareBlend;
        internal float glareBlend
        { 
            get { return _glareBlend; }
            set { _glareBlend = Mathf.Clamp01(value); }
        }

        protected float _glareIntensity;
        internal float glareIntensity
        {
            get { return _glareIntensity; }
            set { _glareIntensity = Mathf.Max(0, value); }
        }

        protected float _glareAngle;
        internal float glareAngle
        {
            get { return _glareAngle; }
            set { _glareAngle = Mathf.Clamp(value, 0, 360); }
        }

		protected MK.Glow.MinMaxRange _glareThreshold;
		internal MK.Glow.MinMaxRange glareThreshold
		{ 
			get { return _glareThreshold; }
            set { _glareThreshold = value; }
		}

        protected int _glareStreaks;
		internal int glareStreaks
		{ 
			get { return _glareStreaks; }
			set { _glareStreaks = Mathf.Clamp(value, 1, 4); }
		}

        protected float _glareScattering;
        internal float glareScattering
        {
            get { return _glareScattering; }
            set { _glareScattering = Mathf.Max(0, value); }
        }

        protected GlareStyle _glareStyle;
        internal GlareStyle glareStyle
        {
            get { return _glareStyle; }
            set { _glareStyle = value; }
        }

        //Sample0
        protected float _glareSample0Scattering;
        internal float glareSample0Scattering
        {
            get { return _glareSample0Scattering; }
            set { _glareSample0Scattering = value; }
        }

        protected float _glareSample0Angle;
        internal float glareSample0Angle
        {
            get { return _glareSample0Angle; }
            set { _glareSample0Angle = value; }
        }

        protected float _glareSample0Intensity;
        internal float glareSample0Intensity
        {
            get { return _glareSample0Intensity; }
            set { _glareSample0Intensity = Mathf.Max(0, value); }
        }

        protected float _glareSample0Offset;
        internal float glareSample0Offset
        {
            get { return _glareSample0Offset; }
            set { _glareSample0Offset = value; }
        }

        //Sample1
        protected float _glareSample1Scattering;
        internal float glareSample1Scattering
        {
            get { return _glareSample1Scattering; }
            set { _glareSample1Scattering = value; }
        }

        protected float _glareSample1Angle;
        internal float glareSample1Angle
        {
            get { return _glareSample1Angle; }
            set { _glareSample1Angle = value; }
        }

        protected float _glareSample1Intensity;
        internal float glareSample1Intensity
        {
            get { return _glareSample1Intensity; }
            set { _glareSample1Intensity = Mathf.Max(0, value); }
        }

        protected float _glareSample1Offset;
        internal float glareSample1Offset
        {
            get { return _glareSample1Offset; }
            set { _glareSample1Offset = value; }
        }

        //Sample2
        protected float _glareSample2Scattering;
        internal float glareSample2Scattering
        {
            get { return _glareSample2Scattering; }
            set { _glareSample2Scattering = value; }
        }

        protected float _glareSample2Angle;
        internal float glareSample2Angle
        {
            get { return _glareSample2Angle; }
            set { _glareSample2Angle = value; }
        }

        protected float _glareSample2Intensity;
        internal float glareSample2Intensity
        {
            get { return _glareSample2Intensity; }
            set { _glareSample2Intensity = Mathf.Max(0, value); }
        }

        protected float _glareSample2Offset;
        internal float glareSample2Offset
        {
            get { return _glareSample2Offset; }
            set { _glareSample2Offset = value; }
        }

        //Sample3
        protected float _glareSample3Scattering;
        internal float glareSample3Scattering
        {
            get { return _glareSample3Scattering; }
            set { _glareSample3Scattering = value; }
        }

        protected float _glareSample3Angle;
        internal float glareSample3Angle
        {
            get { return _glareSample3Angle; }
            set { _glareSample3Angle = value; }
        }

        protected float _glareSample3Intensity;
        internal float glareSample3Intensity
        {
            get { return _glareSample3Intensity; }
            set { _glareSample3Intensity = Mathf.Max(0, value); }
        }

        protected float _glareSample3Offset;
        internal float glareSample3Offset
        {
            get { return _glareSample3Offset; }
            set { _glareSample3Offset = value; }
        }

        /// <summary>
        /// Set a preset for the glare effect
        /// </summary>
        internal void SetGlarePreset(GlareStyle glareStyle)
        {
            switch(glareStyle)
            {
                case GlareStyle.Line:
                    glareStreaks = 1;
                    glareSample0Angle = 90;
                    glareSample0Scattering = 5;
                    glareSample0Offset = 0;
                    glareSample0Intensity = 1;
                break;
                case GlareStyle.Tri:
                    glareStreaks = 3;

                    glareSample0Angle = 0;
                    glareSample0Scattering = 2.5f;
                    glareSample0Offset = 2.5f;
                    glareSample0Intensity = 1;

                    glareSample1Angle = 120;
                    glareSample1Scattering = 2.5f;
                    glareSample1Offset = 2.5f;
                    glareSample1Intensity = 1;

                    glareSample2Angle = 240;
                    glareSample2Scattering = 2.5f;
                    glareSample2Offset = 2.5f;
                    glareSample2Intensity = 1;
                break;
                case GlareStyle.Cross:
                    glareStreaks = 2;

                    glareSample0Angle = 45;
                    glareSample0Scattering = 5f;
                    glareSample0Offset = 0f;
                    glareSample0Intensity = 1;

                    glareSample1Angle = 135;
                    glareSample1Scattering = 5f;
                    glareSample1Offset = 0f;
                    glareSample1Intensity = 1;

                break;
                default:
                case GlareStyle.DistortedCross:
                    glareStreaks = 2;

                    glareSample0Angle = 60;
                    glareSample0Scattering = 5f;
                    glareSample0Offset = 0f;
                    glareSample0Intensity = 1;

                    glareSample1Angle = 120;
                    glareSample1Scattering = 5f;
                    glareSample1Offset = 0f;
                    glareSample1Intensity = 1;

                break;
                case GlareStyle.Star:
                    glareStreaks = 3;

                    glareSample0Angle = 0;
                    glareSample0Scattering = 5f;
                    glareSample0Offset = 0f;
                    glareSample0Intensity = 1;

                    glareSample1Angle = 60;
                    glareSample1Scattering = 5f;
                    glareSample1Offset = 0f;
                    glareSample1Intensity = 1;

                    glareSample2Angle = 120;
                    glareSample2Scattering = 5f;
                    glareSample2Offset = 0f;
                    glareSample2Intensity = 1;

                break;
                case GlareStyle.Flake:
                    glareStreaks = 4;

                    glareSample0Angle = 45;
                    glareSample0Scattering = 5f;
                    glareSample0Offset = 0f;
                    glareSample0Intensity = 1;

                    glareSample1Angle = 90;
                    glareSample1Scattering = 5f;
                    glareSample1Offset = 0f;
                    glareSample1Intensity = 1;

                    glareSample2Angle = 135;
                    glareSample2Scattering = 5f;
                    glareSample2Offset = 0f;
                    glareSample2Intensity = 1;

                    glareSample3Angle = 180;
                    glareSample3Scattering = 5f;
                    glareSample3Offset = 0f;
                    glareSample3Intensity = 1;
                break;
                case GlareStyle.Custom:
                    //no change
                break;
            }
        }
    }
}
