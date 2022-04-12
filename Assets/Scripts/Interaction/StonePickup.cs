using System.Collections.Generic;
using UnityEngine;

public class StonePickup : Interactable {
    [SerializeField]
    private List<Vector3> _pickupPositions;
    [SerializeField]
    private List<Vector3> _pickupRotations;
    [SerializeField]
    private GameObject _torsoReference;

    private void Pickup() {
        gameObject.tag = "Untagged";

        AudioManager.Instance.Play("pickup");

        transform.parent = _torsoReference.transform;
        transform.localPosition = _pickupPositions[0];
        transform.localEulerAngles = _pickupRotations[0];

        IsEnabled = false;
    }

    public override void Interact() => Pickup();

    public override string GetKeyToPress() => "E";
}
