using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthActionController : MonoBehaviour {
    [SerializeField]
    [Tooltip("Set of objects the player can toggle from. If only one object is present that object will be toggled with nothing.")]
    private List<GameObject> _objectSet;
    [SerializeField]
    private float _effectRadius = 1.0f;

    private int _activeObjectIndex = 0;

    private void Update() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _effectRadius);

        foreach (Collider hit in hitColliders) {
            if (hit.CompareTag("Player")) {
                // TODO: How can I get InputActions here?
                if (Input.GetKeyDown(KeyCode.F)) {
                    if (_objectSet.Count > 1) {
                        UpdateMultipleEarthActions();
                    } else {
                        UpdateSingleEarthAction();
                    }
                }
            }  
        }
    }

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

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0.0f, 1.0f, 0.5f, 0.4f);
        Gizmos.DrawSphere(transform.position, _effectRadius);    
    }

}
