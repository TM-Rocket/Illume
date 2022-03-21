using System.Collections.Generic;
using UnityEngine;

public class OrbPickup : Interactable {
    [SerializeField]
    private List<Vector3> _pickupPositions;
    [SerializeField]
    private List<Vector3> _pickupRotations;

    [SerializeField]
    private int _orbNum;

    private void Pickup() {
        gameObject.tag = "Untagged";

        transform.parent = GameObject.Find("Torso").transform;
        if (_orbNum == 1) {
            InteractableRenderer.material.color = new Color(0, 0, 255);
            transform.localPosition = _pickupPositions[0];
            transform.localEulerAngles = _pickupRotations[0];
        } else if (_orbNum == 2) {
            InteractableRenderer.material.color = new Color(0, 255, 0);
            transform.localPosition = _pickupPositions[1];
            transform.localEulerAngles = _pickupRotations[1];
        }
    }

    public override void Interact() => Pickup();

    public override string GetDescription() => "Grab";

    public override string GetKeyToPress() => "E";
}
