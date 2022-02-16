using UnityEngine;

public class BallPickup : MonoBehaviour, IInteractable {
    private Material _mat;

    [SerializeField]
    private Vector3 _pickupPosition;
    [SerializeField]
    private Vector3 _pickupRotation;

    private string description = "Pickup";
    private bool dropped = true;

    private void Pickup() {
        transform.parent = GameObject.Find("RightHand").transform;
        transform.localPosition = _pickupPosition;
        transform.localEulerAngles = _pickupRotation;

        description = "Drop";
        dropped = false;
    }

    private void Drop() {
        RaycastHit hit;
        float distance = 10f;
        Vector3 targetLocation;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance)) {
            targetLocation = hit.point;

            transform.parent = GameObject.Find("Interactables").transform;
            transform.position = targetLocation;
            transform.localEulerAngles = new Vector3(0,0,0);

            dropped = true;
            description = "Pickup";
        }
    }

    public string GetDescription() => description;

    public void Interact() {
        if (dropped) {
            Pickup();
        } else {
            Drop();
        }
    }

    public string GetKeyToPress() => "E";
}
