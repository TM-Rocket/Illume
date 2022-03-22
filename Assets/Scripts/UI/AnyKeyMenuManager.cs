using UnityEngine;
using UnityEngine.InputSystem;

public class AnyKeyMenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject _anyKeyMenuUI;
    [SerializeField]
    private GameObject _mainMenuUI;

    // Uses controller for UI if a controller is plugged in 
    public static bool _isControllerUsedForUI = false;

    private bool _isControllerButtonPressed = false;
    private bool _isComplete = false;

    private void Update() {
        if (Gamepad.current != null) {
            _isControllerUsedForUI = true;
        }

        if (Input.anyKey && !_isComplete) {
            _anyKeyMenuUI.SetActive(false);
            _mainMenuUI.SetActive(true);

            _isComplete = true;
        } 
    }
}
