using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightTrigger : MonoBehaviour
{
    public PostProcessVolume volume;

    private ColorGrading _colorGradingLayer;

    public float saturation = 0.0f;
    public float contrast = 0.0f;
    public float postExposure = 1.0f;
    public float temperature = 25.0f;

    public float duration = 0.0f;

    private float progress;

    void Start()
    {
        volume.profile.TryGetSettings(out _colorGradingLayer);

        if (gameObject.name == "NightTrigger" || gameObject.name == "DayTrigger")
        {
            StartCoroutine(ChangeLighting());
        }
    }

    private System.Collections.IEnumerator ChangeLighting()
    {
        // saturation, contrast, postExposure, colorFilter, temperature

        float startSaturation = _colorGradingLayer.saturation.value;
        float startContrast = _colorGradingLayer.contrast.value;
        float startExposure = _colorGradingLayer.postExposure.value;
        float startTemperature = _colorGradingLayer.temperature.value;

        progress = 0f;

        while (progress < 1f)
        {
            progress = Mathf.Clamp01(progress + Time.deltaTime / duration);
            _colorGradingLayer.saturation.value = Mathf.Lerp(startSaturation, saturation, progress);
            _colorGradingLayer.contrast.value = Mathf.Lerp(startContrast, contrast, progress);
            _colorGradingLayer.postExposure.value = Mathf.Lerp(startExposure, postExposure, progress);
            _colorGradingLayer.temperature.value = Mathf.Lerp(startTemperature, temperature, progress);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeLighting());
        }
    }
}