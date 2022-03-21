using UnityEngine;

public class InteractionParticle : MonoBehaviour {
    [SerializeField]
    private Interactable _interactableObject;
    [SerializeField]
    private ParticleSystem _interactionParticle;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && _interactableObject.IsEnabled) {
            _interactionParticle.Play();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            _interactionParticle.Stop();
        }
    }
}
