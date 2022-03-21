using UnityEngine;
using UnityEngine.InputSystem;

public class AnyKeyMenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject _anyKeyMenuUI;
    [SerializeField]
    private GameObject _mainMenuUI;

    private bool _isControllerButtonPressed = false;
    private bool _isComplete = false;

    private void Update() {
        // TODO: Upgrade Input System >= 1.3
        for (int i = 0; i < 20; i++) {
            if (Input.GetKeyDown("joystick 1 button " + i)) {
               _isControllerButtonPressed = true; 
               break;
            }
        }

        if ((Input.anyKey || _isControllerButtonPressed) && !_isComplete) {
            _anyKeyMenuUI.SetActive(false);
            _mainMenuUI.SetActive(true);

            _isComplete = true;
        } 
    }
}
