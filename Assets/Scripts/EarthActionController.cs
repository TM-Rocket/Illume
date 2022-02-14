using System.Collections.Generic;
using UnityEngine;

public class EarthActionController : MonoBehaviour, IInteractable {
    [SerializeField]
    [Tooltip("Set of objects the player can toggle from. If only one object is present that object will be toggled with nothing.")]
    private List<GameObject> _objectSet;

    private int _activeObjectIndex = 0;

    private void UpdateMultipleEarthActions() {
        _objectSet[_activeObjectIndex].SetActive(false);

        if (_activeObjectIndex < _objectSet.Count - 1) {
            _activeObjectIndex++;
            _objectSet[_activeObjectIndex].SetActive(true);
        } else {
            _activeObjectIndex = 0;
            _objectSet[_activeObjectIndex].SetActive(true);
        }
    }

    private void UpdateSingleEarthAction() {
        if (_objectSet[0].activeSelf) {
            _objectSet[0].SetActive(false);
        } else {
            _objectSet[0].SetActive(true);
        }
    }

    public string GetDescription() => "Cast";

    public void Interact() {
        if (_objectSet.Count > 1) {
            UpdateMultipleEarthActions();
        } else {
            UpdateSingleEarthAction();
        }
    }
}
