using UnityEngine;

public class FillWater : MonoBehaviour{

    public GameObject Ocean; // Ocean/Water object
    private float _waterRising; // Store this constant in a Constants file (to-do later)

    // Start is called before the first frame update
    void Start() {
        _waterRising = 0.025f; // Initialize constant moving water rate
    }

    // Detect collisions from Particles
    void OnParticleCollision(GameObject other) {
        if(Ocean.transform.position.y < -0.5f) {
            Ocean.transform.position = Ocean.transform.position + new Vector3(0, _waterRising, 0); // Move water at a constant rate
        }
    }
}
