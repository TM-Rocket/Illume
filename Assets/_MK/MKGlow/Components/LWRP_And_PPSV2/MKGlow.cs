//////////////////////////////////////////////////////
// MK Glow PostProcessing Stack     	            //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;
using System.Collections.Generic;

namespace MK.Glow.LWRP
{
    [Serializable]
    [PostProcess(typeof(MKGlowRenderer), PostProcessEvent.BeforeStack, "MK/MKGlow")]
    public sealed class MKGlow : PostProcessEffectSettings
    {
        [System.Serializable]
        public sealed class RenderPriorityParameter : ParameterOverride<RenderPriority>
        {
            public override void Interp(RenderPriority from, RenderPriority to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class Texture2DParameter : ParameterOverride<Texture2D>
        {
            public override void Interp(Texture2D from, Texture2D to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class DebugViewParameter : ParameterOverride<MK.Glow.DebugView>
        {
            public override void Interp(MK.Glow.DebugView from, MK.Glow.DebugView to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class QualityParameter : ParameterOverride<MK.Glow.Quality>
        {
            public override void Interp(MK.Glow.Quality from, MK.Glow.Quality to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class AntiFlickerModeParameter : ParameterOverride<MK.Glow.AntiFlickerMode>
        {
            public override void Interp(MK.Glow.AntiFlickerMode from, MK.Glow.AntiFlickerMode to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class WorkflowParameter : ParameterOverride<MK.Glow.Workflow>
        {
            public override void Interp(MK.Glow.Workflow from, MK.Glow.Workflow to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class LayerMaskParameter : ParameterOverride<LayerMask>
        {
            public override void Interp(LayerMask from, LayerMask to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class MinMaxRangeParameter : ParameterOverride<MK.Glow.MinMaxRange>
        {
            public override void Interp(MK.Glow.MinMaxRange from, MK.Glow.MinMaxRange to, float t)
            {
                value.minValue = Mathf.Lerp(from.minValue, to.minValue, t);
                value.maxValue = Mathf.Lerp(from.maxValue, to.maxValue, t);
            }
        }

        [System.Serializable]
        public sealed class GlareStyleParameter : ParameterOverride<GlareStyle>
        {
            public override void Interp(GlareStyle from, GlareStyle to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        [System.Serializable]
        public sealed class LensFlareStyleParameter : ParameterOverride<LensFlareStyle>
        {
            public override void Interp(LensFlareStyle from, LensFlareStyle to, float t)
            {
                value = t > 0 ? to : from;
            }
        }

        #if UNITY_EDITOR && !UNITY_CLOUD_BUILD
        public bool showEditorMainBehavior = true;
		public bool showEditorBloomBehavior;
		public bool showEditorLensSurfaceBehavior;
		public bool showEditorLensFlareBehavior;
		public bool showEditorGlareBehavior;
        /// <summary>
        /// Keep this value always untouched, editor internal only
        /// </summary>
        public bool isInitialized = false;
        #endif
        
        //Main
        public BoolParameter allowGeometryShaders = new BoolParameter() { value = true };
        public BoolParameter allowComputeShaders = new BoolParameter() { value = true };
        public RenderPriorityParameter renderPriority = new RenderPriorityParameter() { value = RenderPriority.Balanced };
        public DebugViewParameter debugView = new DebugViewParameter() { value = MK.Glow.DebugView.None };
        public QualityParameter quality = new QualityParameter() { value = MK.Glow.Quality.High };
        public AntiFlickerModeParameter antiFlickerMode = new AntiFlickerModeParameter() { value = MK.Glow.AntiFlickerMode.Balanced };
        public WorkflowParameter workflow = new WorkflowParameter() { value = MK.Glow.Workflow.Threshold };
        public LayerMaskParameter selectiveRenderLayerMask = new LayerMaskParameter() { value = -1 };
        [Range(-1f, 1f)]
        public FloatParameter anamorphicRatio = new FloatParameter() { value = 0 };
        [Range(0f, 1f)]
		public FloatParameter lumaScale = new FloatParameter() { value = 0.5f };
        [Range(0f, 1f)]
		public FloatParameter blooming = new FloatParameter() { value = 0f };

        //Bloom
        [MK.Glow.MinMaxRange(0, 10)]
        public MinMaxRangeParameter bloomThreshold = new MinMaxRangeParameter() { value = new MinMaxRange(1.25f, 10f) };
        [Range(1f, 10f)]
		public FloatParameter bloomScattering = new FloatParameter() { value = 7f };
		public FloatParameter bloomIntensity = new FloatParameter() { value = 0f };

        //LensSurface
        public BoolParameter allowLensSurface = new BoolParameter() { overrideState = true, value = false };
		public Texture2DParameter lensSurfaceDirtTexture = new Texture2DParameter();
		public FloatParameter lensSurfaceDirtIntensity = new FloatParameter() { value = 0.0f };
		public Texture2DParameter lensSurfaceDiffractionTexture = new Texture2DParameter();
		public FloatParameter lensSurfaceDiffractionIntensity = new FloatParameter() { value = 0.0f };

        //LensFlare
        public BoolParameter allowLensFlare = new BoolParameter() { overrideState = true, value = false };
        public LensFlareStyleParameter lensFlareStyle = new LensFlareStyleParameter() { value = LensFlareStyle.Average };
        [Range(0f, 25f)]
		public FloatParameter lensFlareGhostFade = new FloatParameter() { value = 10f };
		public FloatParameter lensFlareGhostIntensity = new FloatParameter() { value = 0.0f };
        [MK.Glow.MinMaxRange(0, 10)]
		public MinMaxRangeParameter lensFlareThreshold = new MinMaxRangeParameter() { value = new MinMaxRange(1.3f, 10f) };
        [Range(0f, 8f)]
		public FloatParameter lensFlareScattering = new FloatParameter() { value = 5f };
		public Texture2DParameter lensFlareColorRamp = new Texture2DParameter();
        [Range(-100f, 100f)]
		public FloatParameter lensFlareChromaticAberration = new FloatParameter() { value = 53f };
        [Range(0, 5)]
		public IntParameter lensFlareGhostCount = new IntParameter() { value = 3 };
        [Range(-1f, 1f)]
		public FloatParameter lensFlareGhostDispersal = new FloatParameter() { value = 0.6f };
        [Range(0f, 25f)]
		public FloatParameter lensFlareHaloFade = new FloatParameter() { value = 2f };
		public FloatParameter lensFlareHaloIntensity = new FloatParameter() { value = 0.0f };
        [Range(0f, 1f)]
		public FloatParameter lensFlareHaloSize = new FloatParameter() { value = 0.4f };

        //Glare
        public BoolParameter allowGlare = new BoolParameter() { overrideState = true, value = false };
        [Range(0.0f, 1.0f)]
        public FloatParameter glareBlend = new FloatParameter() { value = 0.33f };
        public FloatParameter glareIntensity = new FloatParameter() { value = 1f };
        [Range(0.0f, 360.0f)]
        public FloatParameter glareAngle = new FloatParameter() { value = 0f };
        [MK.Glow.MinMaxRange(0, 10)]
        public MinMaxRangeParameter glareThreshold = new MinMaxRangeParameter() { value = new MinMaxRange(1.25f, 10f)};
        [Range(1, 4)]
		public IntParameter glareStreaks = new IntParameter() { value = 4 };
        [Range(0.0f, 4.0f)]
        public FloatParameter glareScattering = new FloatParameter() { value = 2f };
        public GlareStyleParameter glareStyle = new GlareStyleParameter() { value = GlareStyle.DistortedCross };
        //Sample0
        [Range(0f, 10f)]
        public FloatParameter glareSample0Scattering = new FloatParameter() { value = 5.0f };
        [Range(0f, 360f)]
        public FloatParameter glareSample0Angle = new FloatParameter() { value = 0.0f };
        public FloatParameter glareSample0Intensity = new FloatParameter() { value = 0.0f };
        [Range(0f, 10f)]
        public FloatParameter glareSample0Offset = new FloatParameter() { value = 0.0f };
        //Sample1
        [Range(0f, 10f)]
        public FloatParameter glareSample1Scattering = new FloatParameter() { value = 5.0f };
        [Range(0f, 360f)]
        public FloatParameter glareSample1Angle = new FloatParameter() { value = 45.0f };
        public FloatParameter glareSample1Intensity = new FloatParameter() { value = 0.0f };
        [Range(0f, 10f)]
        public FloatParameter glareSample1Offset = new FloatParameter() { value = 0.0f };
        //Sample0
        [Range(0f, 10f)]
        public FloatParameter glareSample2Scattering = new FloatParameter() { value = 5.0f };
        [Range(0f, 360f)]
        public FloatParameter glareSample2Angle = new FloatParameter() { value = 90.0f };
        public FloatParameter glareSample2Intensity = new FloatParameter() { value = 0.0f };
        [Range(0f, 10f)]
        public FloatParameter glareSample2Offset = new FloatParameter() { value = 0.0f };
        //Sample0
        [Range(0f, 10f)]
        public FloatParameter glareSample3Scattering = new FloatParameter() { value = 5.0f };
        [Range(0f, 360f)]
        public FloatParameter glareSample3Angle = new FloatParameter() { value = 135.0f };
        public FloatParameter glareSample3Intensity = new FloatParameter() { value = 0.0f };
        [Range(0f, 10f)]
        public FloatParameter glareSample3Offset = new FloatParameter() { value = 0.0f };

        public override bool IsEnabledAndSupported(PostProcessRenderContext context)
        {
            if(workflow == Workflow.Selective && (UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset || PipelineProperties.xrEnabled))
                return false;
            else
                return Compatibility.IsSupported && enabled.value;
        }

        /*
        /// <summary>
        /// Load some mobile optimized settings
        /// </summary>
        //[ContextMenu("Load Preset For Mobile")]
        internal void LoadMobilePreset()
        {
            bloomScattering.value = 5f;
            renderPriority.value = RenderPriority.Performance;
            quality.value = Quality.Low;
            allowGlare.value = false;
            allowLensFlare.value = false;
            lensFlareScattering.value = 5;
            allowLensSurface.value = false;
        }

        /// <summary>
        /// Load some quality optimized settings
        /// </summary>
        //[ContextMenu("Load Preset For Quality")]
        internal void LoadQualityPreset()
        {
            bloomScattering.value = 7f;
            renderPriority.value = RenderPriority.Quality;
            quality.value = Quality.High;
            allowGlare.value = false;
            allowLensFlare.value = false;
            lensFlareScattering.value = 6;
            allowLensSurface.value = false;
        }
        */
    }
    
    public sealed class MKGlowRenderer : PostProcessEffectRenderer<MKGlow>
    {
		private Effect effect = new Effect();
        private RenderTarget _source, _destination;

        public override void Init()
        {
            effect.Enable(RenderPipeline.SRP);
        }

        public override void Release()
        {
            effect.Disable();
        }

        public override void Render(PostProcessRenderContext context)
        {
            context.command.BeginSample(PipelineProperties.CommandBufferProperties.commandBufferName);
            _source.renderTargetIdentifier = context.source;
            _destination.renderTargetIdentifier = context.destination;
            SettingsPPSV2 settings = this.settings;
            LWRP.CameraDataPPSv2 cameraData = context.camera;
			effect.Build(_source, _destination, settings, context.command, cameraData, context.camera);
            context.command.EndSample(PipelineProperties.CommandBufferProperties.commandBufferName);
        }
    }
}