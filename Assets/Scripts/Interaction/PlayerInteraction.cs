using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField]
    private GameObject _interactionUI;
    [SerializeField]
    private Text _interactionText;
    [SerializeField]
    private Text _interactionKeyText;

    private bool _canInteract;
    private GameObject _interactObject;
    private PlayerInput _playerInput;
    private InputAction _stoneAction;
    private InputAction _interactAction;

    private void Awake() {
        _playerInput = GetComponent<PlayerInput>();
        _stoneAction = _playerInput.actions["StoneAction"];
        _interactAction = _playerInput.actions["Interact"];
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Interactable") {
            _interactObject = other.gameObject;

            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable != null) {
                _canInteract = true;
                _interactionKeyText.text = interactable.GetKeyToPress();
                _interactionUI.SetActive(_canInteract);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Interactable") {
            _canInteract = false;
            _interactionUI.SetActive(_canInteract);
        }
    }

    private void Update() {
        if (_canInteract == true && _interactObject.tag == "Interactable") {
            Interactable interactable = _interactObject.GetComponent<Interactable>();

            if (interactable.GetKeyToPress().Equals("E")) {
                if (_interactAction.triggered) {
                    interactable.Interact();
                }
            } else if (interactable.GetKeyToPress().Equals("F")) {
                if (_stoneAction.triggered) {
                    interactable.Interact();
                }
            }
        } else {
            _canInteract = false;
            _interactionUI.SetActive(_canInteract);
            _interactObject = null;
        }
    }
}