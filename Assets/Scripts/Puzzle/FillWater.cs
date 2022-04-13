using UnityEngine;

public class FillWater : MonoBehaviour{
    private float _waterRising; // Store this constant in a Constants file (to-do later)

    public float DesiredHeight = 0.0f;

    public GameObject Ocean; // Ocean/Water object

    private void Start() {
        _waterRising = 0.025f; // Initialize constant moving water rate
    }

    // Detect collisions from Particles
    private void OnParticleCollision(GameObject other) {
        if(Ocean.transform.position.y < DesiredHeight) {
            Ocean.transform.position = Ocean.transform.position + new Vector3(0, _waterRising, 0); // Move water at a constant rate
        }
    }
}
