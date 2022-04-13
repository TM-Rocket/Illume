using System.Collections.Generic;
using UnityEngine;

public class WaterPuzzle : MonoBehaviour {
    [SerializeField]
    private GameObject _door; 
    [SerializeField]
    [Tooltip("Temporary: Used to change the height of the water once the first switch is triggered.")]
    private FillWater _waterLevelControl;

    [HideInInspector]
    public static List<WaterButton> PressedButtons = new List<WaterButton>();

    private void Update() {
        if(IsFirstSwitchOn()) {
            _waterLevelControl.DesiredHeight = 19.5f;
        } else if (IsSolved()) {
            _waterLevelControl.DesiredHeight = 23.0f;
            _door.SetActive(false);
        }
    }

    public static bool IsFirstSwitchOn() => PressedButtons.Count == 1;

    public static bool IsSolved() => PressedButtons.Count == 2;
}
