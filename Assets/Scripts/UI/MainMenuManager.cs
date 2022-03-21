using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class MainMenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject _mainMenuUI;
    [SerializeField]
    private CinemachineVirtualCamera _mainMenuVCam;
    [SerializeField] 
    private CinemachineVirtualCamera _playerVCam;
    [Header("Menu Buttons")]
    [SerializeField]
    [Tooltip("Used to select the start button for gamepads when the menu loads")]
    private Button _startButton;

    [HideInInspector]
    public static bool IsMainMenuFocused = true;

    private void Awake() {
        // Ensure priorities are setup properly
        _mainMenuVCam.Priority = 1;
        _playerVCam.Priority = 0;
        _startButton.Select();
    }

    public void SwitchToPlayerCamera() {
        if (IsMainMenuFocused) {
            _mainMenuVCam.Priority = 0;
            _playerVCam.Priority = 1;

            _mainMenuUI.gameObject.SetActive(false);
        }

        IsMainMenuFocused = !IsMainMenuFocused;
    }
}
