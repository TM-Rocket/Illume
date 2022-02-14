using UnityEngine;

public class FillWater : MonoBehaviour{
    [SerializeField]
    private float _desiredHeight = 0.0f;
    private float _waterRising; // Store this constant in a Constants file (to-do later)

    public GameObject Ocean; // Ocean/Water object

    private void Start() {
        _waterRising = 0.025f; // Initialize constant moving water rate
    }

    // Detect collisions from Particles
    private void OnParticleCollision(GameObject other) {
        if(Ocean.transform.position.y < _desiredHeight) {
            Ocean.transform.position = Ocean.transform.position + new Vector3(0, _waterRising, 0); // Move water at a constant rate
        }
    }
}
