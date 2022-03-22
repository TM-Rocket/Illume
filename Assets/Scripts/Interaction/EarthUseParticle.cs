using UnityEngine;

public class EarthUseParticle : MonoBehaviour {
    [SerializeField]
    private ParticleSystem _useEarthParticle;

    public void PlayEarthParticle() => _useEarthParticle.Play();

    public void StopEarthParticle() => _useEarthParticle.Stop();
}
