using UnityEngine;

public class WaterButton : MonoBehaviour, IInteractable {
    private Renderer _renderer;
    private bool _isPressed;

    private void Awake() => _renderer = GetComponent<Renderer>();

    public string GetDescription() => "Press";

    public void Interact() { 
        if (!WaterPuzzle.IsSolved() && !_isPressed) {
            WaterPuzzle.PressedButtons.Add(this);

            _renderer.material.SetColor("_Color", Color.green);
            _isPressed = true;
        }
    } 
}
