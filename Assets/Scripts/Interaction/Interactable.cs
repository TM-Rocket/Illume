using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    protected Renderer InteractableRenderer;

    // All Interactables are enabled by default
    public bool IsEnabled = true;

    protected virtual void Awake() {
        InteractableRenderer = gameObject.GetComponent<Renderer>();
    }

    public abstract void Interact();
    public virtual string GetDescription() => "Interact";
    public virtual string GetKeyToPress() => "E";
}

