using UnityEngine;

public class WaterButton : Interactable {
    private bool _isPressed;

    public override void Interact() { 
        if (!WaterPuzzle.IsSolved() && !_isPressed) {
            WaterPuzzle.PressedButtons.Add(this);

            InteractableRenderer.material.SetColor("_Color", Color.green);
            _isPressed = true;
        }
    } 

    public override string GetKeyToPress() => "E";
}
