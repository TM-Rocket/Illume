using System.Collections;
using UnityEngine;

public class SoundObject : Interactable  {
    [HideInInspector] 
    public AudioClip SoundClip;
    [HideInInspector] 
    public AudioSource SoundSource;

    private bool _isInCoroutine = false;

    private void Start() {
        SoundSource = gameObject.AddComponent<AudioSource>();
        SoundSource.clip = SoundClip;

        SoundSource.volume = 1.0f;
        SoundSource.pitch = 1.0f;
        SoundSource.loop = false;
    }

    private void Update() {
        if (SoundPuzzle.IsSolved()) {
            InteractableRenderer.material.SetColor("_Color", Color.green);

            // Disable the interaction once the puzzle is complete
            IsEnabled = false;
        } else if (SoundPuzzle.IsIncorrect()) {
            StartCoroutine("FlashBlockColor");
        } 
    }

    public override void Interact() {
        // Only play sounds when puzzle isn't solved and 'Red' blocks aren't flashing
        if (!SoundPuzzle.IsSolved() && !_isInCoroutine) {
            SoundSource.Play();

            SoundPuzzle.PlayerAnswers.Add(this);

            if (!SoundPuzzle.IsSolved()) {
                InteractableRenderer.material.SetColor("_Color", Color.yellow);
            }
        }
    }

    public override string GetDescription() => "Press";

    public override string GetKeyToPress() => "E";

    private IEnumerator FlashBlockColor() {
        _isInCoroutine = true;

        InteractableRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(2);
        InteractableRenderer.material.SetColor("_Color", Color.white);

        _isInCoroutine = false;
    }
}
