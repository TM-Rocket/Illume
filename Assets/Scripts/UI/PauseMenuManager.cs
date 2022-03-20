using UnityEngine;

public class PauseMenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject _pauseMenuUI;
    [SerializeField]
    [Tooltip("Controls the enabling/disabling of this player controller while pausing")]
    private PlayerMovement _playerController;

    private bool _isPauseMenuUp = false;

    private void Update() {
        if (Input.GetButtonDown("Pause") && !MainMenuManager.IsMainMenuFocused) {
            if (_isPauseMenuUp) {
                ClearPauseMenu();
            } else {
                ShowPauseMenu();
            }
        }    
    }

    public void ShowPauseMenu() {
        _pauseMenuUI.SetActive(true);
        _playerController.OnDisable();

        _isPauseMenuUp = true;

        Time.timeScale = 0;
    }

    public void ClearPauseMenu() {
        _pauseMenuUI.SetActive(false);
        _playerController.OnEnable();

        _isPauseMenuUp = false;

        Time.timeScale = 1;
    }
}
