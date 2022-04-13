using UnityEngine;

public class BallPickup : Interactable {
    [SerializeField]
    private Vector3 _pickupPosition;
    [SerializeField]
    private Vector3 _pickupRotation;

    private bool dropped = true;
    
    private void Pickup() {
        transform.parent = GameObject.Find("Fist.R_end").transform;
        transform.localPosition = _pickupPosition;
        transform.localEulerAngles = _pickupRotation;

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
        }
    }


    public override void Interact() {
        if (dropped) {
            Pickup();
        } else {
            Drop();
        }
    }

    public override string GetKeyToPress() => "E";
}
