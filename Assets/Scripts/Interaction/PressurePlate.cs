using UnityEngine;

public class PressurePlate : MonoBehaviour {
    [SerializeField]
    private GameObject _door;

    private void Check() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.7f);

        foreach (Collider hit in hitColliders) {
            if (hit.CompareTag("Interactable") && hit.transform.parent.name != "Fist.R_end") {
                _door.SetActive(false);
            }

            if (hit.CompareTag("Interactable") && hit.transform.parent.name == "Fist.R_end") {
                _door.SetActive(true);
            }
        }
    }

    private void Update() => Check();
}
