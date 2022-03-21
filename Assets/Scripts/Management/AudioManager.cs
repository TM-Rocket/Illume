using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound[] Sounds;

    public static AudioManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Sounds) {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
            s.Source.time = s.Time;
            s.Source.pitch = s.Speed;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(Sounds, s => s.Name == name); 

        if (s == null) {
            Debug.LogWarning("AudioManager: Could not find Sound with name: " + name);
            return;
        }

        s.Source.Play();
    }

    public void Stop(string name) {
        Sound s = Array.Find(Sounds, s => s.Name == name);
        s.Source.Stop();
    }
}
