using System.Collections.Generic;
using UnityEngine;

public class EarthPuzzle : MonoBehaviour {
    [SerializeField]
    private GameObject _door; 
    [SerializeField]
    private GameObject _buttonGuard;

    [HideInInspector]
    public static List<EarthButton> PressedButtons = new List<EarthButton>();

    private void Update() {
        if (CanOpenFinalButton()) {
            _buttonGuard.SetActive(false);
        } else if (IsSolved()) {
            _door.SetActive(false);
        }
    }

    public static bool CanOpenFinalButton() => PressedButtons.Count == 3;

    public static bool IsSolved() => PressedButtons.Count == 4;
}
