using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActionController : MonoBehaviour, IInteractable
{
    public string GetDescription() => "Tap";

    // Handled by ParticleEffects
    public void Interact() { }
}
