using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPuzzle : MonoBehaviour {
    [SerializeField]
    private GameObject _door; 

    [HideInInspector]
    public static List<WaterButton> PressedButtons = new List<WaterButton>();

    private void Update() {
        if (IsSolved()) {
            _door.SetActive(false);
        }
    }


    public static bool IsSolved() => PressedButtons.Count == 2;
}
