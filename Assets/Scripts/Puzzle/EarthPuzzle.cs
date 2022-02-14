using System.Collections.Generic;
using UnityEngine;

public class EarthPuzzle : MonoBehaviour {
    [SerializeField]
    private GameObject _door; 

    [HideInInspector]
    public static List<EarthButton> PressedButtons = new List<EarthButton>();

    private void Update() {
        if (IsSolved()) {
            _door.SetActive(false);
        }
    }

    public static bool IsSolved() => PressedButtons.Count == 4;
}
