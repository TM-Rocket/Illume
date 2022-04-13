using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using Cinemachine;

public class MainMenuManager : MonoBehaviour {
    [Header("Cinematics")]
    [SerializeField]
    private CinemachineVirtualCamera _mainMenuVCam;
    [SerializeField] 
    private CinemachineVirtualCamera _playerVCam;
    [SerializeField]
    private PlayableDirector _introCutscene;
    [SerializeField]
    private List<GameObject> _cinematicUIElements;
    [Header("Menu UI")]
    [SerializeField]
    private GameObject _mainMenuUI;
    [SerializeField]
    private Button _startButton;

    [HideInInspector]
    public static bool IsMainMenuFocused = true;

    private void Awake() {
        // Disable canvas' attached to cutescenes
        foreach (GameObject uiElement in _cinematicUIElements) {
            uiElement.SetActive(false);
        }

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

        // Re-enable canvas' attached to cutescenes
        foreach (GameObject uiElement in _cinematicUIElements) {
            uiElement.SetActive(true);
        }

        _introCutscene.Play();
    }
}
