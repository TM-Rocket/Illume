using System.Collections.Generic;
using UnityEngine;

public class StonePickup : Interactable {
    [SerializeField]
    private List<Vector3> _pickupPositions;
    [SerializeField]
    private List<Vector3> _pickupRotations;

    private void Pickup() {
        gameObject.tag = "Untagged";

        transform.parent = GameObject.Find("Torso").transform;
        transform.localPosition = _pickupPositions[0];
        transform.localEulerAngles = _pickupRotations[0];

        IsEnabled = false;
    }

    public override void Interact() => Pickup();

    public override string GetKeyToPress() => "E";
}
