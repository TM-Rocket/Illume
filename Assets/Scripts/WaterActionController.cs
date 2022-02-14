using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActionController : MonoBehaviour, IInteractable {
    // Handled by ParticleEffects
    public void Interact() { }

    public string GetDescription() => "Tap";

    public string GetKeyToPress() => "R";
}
