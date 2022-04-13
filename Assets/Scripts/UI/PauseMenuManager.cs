using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour {
    [SerializeField]
    [Tooltip("Controls the enabling/disabling of this player controller while pausing")]
    private PlayerMovement _playerController;
    [SerializeField]
    private List<GameObject> _cinematicUIElements;
    [Header("Menu UI")]
    [SerializeField]
    private GameObject _pauseMenuUI;
    [SerializeField]
    [Tooltip("Used to select the start button for gamepads when the menu loads")]
    private Button _resumeButton;

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
        _resumeButton.Select();
        _pauseMenuUI.SetActive(true);
        _playerController.OnDisable();

        // Disable canvas' attached to cutescenes
        foreach (GameObject uiElement in _cinematicUIElements) {
            uiElement.SetActive(false);
        }

        _isPauseMenuUp = true;

        Time.timeScale = 0;
    }

    public void ClearPauseMenu() {
        _pauseMenuUI.SetActive(false);
        _playerController.OnEnable();

        // Re-enable canvas' attached to cutescenes
        foreach (GameObject uiElement in _cinematicUIElements) {
            uiElement.SetActive(true);
        }

        _isPauseMenuUp = false;

        Time.timeScale = 1;
    }
}
