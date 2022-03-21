using UnityEngine;

[System.Serializable]
public class Sound {
    public string Name;
    public AudioClip Clip;

    [Range(0.0f, 1.0f)]
    public float Volume;
    [Range(0.1f, 3.0f)]
    public float Pitch;
    [Range(0.0f, 1.0f)]
    public float Time;
    [Range(0.0f, 3.0f)]
    public float Speed=1;

    public bool Loop;

    [HideInInspector]
    public AudioSource Source;
}
