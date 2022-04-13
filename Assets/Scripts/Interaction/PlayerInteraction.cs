using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField]
    private GameObject _interactionUI;
    [SerializeField]
    private Image _interactionKeyImage;
    [Header("Button Sprites")]
    [SerializeField]
    private Sprite _XButton;
    [SerializeField]
    private Sprite _BButton;
    [SerializeField]
    private Sprite _EKey;
    [SerializeField]
    private Sprite _FKey;

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

            if (interactable != null && interactable.IsEnabled) {
                _canInteract = true;

                if (interactable.GetKeyToPress().Equals("E") && AnyKeyMenuManager._isControllerUsedForUI) {
                    _interactionKeyImage.sprite = _XButton;
                } else if (interactable.GetKeyToPress().Equals("E")) {
                    _interactionKeyImage.sprite = _EKey;
                }

                if (interactable.GetKeyToPress().Equals("F") && AnyKeyMenuManager._isControllerUsedForUI) {
                    _interactionKeyImage.sprite = _BButton;
                } else if (interactable.GetKeyToPress().Equals("F")) {
                    _interactionKeyImage.sprite = _FKey;
                }

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