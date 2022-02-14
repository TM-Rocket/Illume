using UnityEngine;

public class EarthButton : MonoBehaviour {
    private Renderer _renderer;
    private bool _isPressed;

    private void Awake() => _renderer = GetComponent<Renderer>();

    private void OnTriggerEnter(Collider other) { 
        if (!EarthPuzzle.IsSolved() && !_isPressed) {
            EarthPuzzle.PressedButtons.Add(this);

            _renderer.material.SetColor("_Color", Color.green);
            _isPressed = true;
        }
    } 
}
