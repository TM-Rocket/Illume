using System.Collections.Generic;
using UnityEngine;

public class OrbPickup : MonoBehaviour, IInteractable {
    private Material _mat;

    [SerializeField]
    private List<Vector3> _pickupPositions;
    [SerializeField]
    private List<Vector3> _pickupRotations;

    [SerializeField]
    private int _orbNum;

    private void Start() => _mat = GetComponent<MeshRenderer>().material;

    private void Pickup() {
        gameObject.tag = "Untagged";

        transform.parent = GameObject.Find("Spine2").transform;
        if (_orbNum == 1) {
            _mat.color = new Color(0, 0, 255);
            transform.localPosition = _pickupPositions[0];
            transform.localEulerAngles = _pickupRotations[0];
        } else if (_orbNum == 2) {
            _mat.color = new Color(0, 255, 0);
            transform.localPosition = _pickupPositions[1];
            transform.localEulerAngles = _pickupRotations[1];
        }
    }

    public void Interact() => Pickup();

    public string GetDescription() => "Grab";

    public string GetKeyToPress() => "E";
}
