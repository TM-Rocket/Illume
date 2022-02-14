using System.Collections;
using UnityEngine;

public class SoundObject : MonoBehaviour, IInteractable
{
    private Renderer _renderer;

    [HideInInspector] 
    public AudioClip SoundClip;
    [HideInInspector] 
    public AudioSource SoundSource;

    private bool _isInCoroutine = false;

    private void Awake() => _renderer = gameObject.GetComponent<Renderer>();

    private void Start() {
        SoundSource = gameObject.AddComponent<AudioSource>();
        SoundSource.clip = SoundClip;

        SoundSource.volume = 1.0f;
        SoundSource.pitch = 1.0f;
        SoundSource.loop = false;
    }

    private void Update() {
        if (SoundPuzzle.IsSolved()) {
            _renderer.material.SetColor("_Color", Color.green);
        } else if (SoundPuzzle.IsIncorrect()) {
            StartCoroutine("FlashBlockColor");
        } 
    }

    public string GetDescription()
    {
        return "Press";
    }

    public void Interact()
    {
        // Only play sounds when puzzle isn't solved and 'Red' blocks aren't flashing
        if (!SoundPuzzle.IsSolved() && !_isInCoroutine)
        {
            SoundSource.Play();

            SoundPuzzle.PlayerAnswers.Add(this);

            if (!SoundPuzzle.IsSolved())
            {
                _renderer.material.SetColor("_Color", Color.yellow);
            }
        }
    }

    private IEnumerator FlashBlockColor() {
        _isInCoroutine = true;

        _renderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(2);
        _renderer.material.SetColor("_Color", Color.white);

        _isInCoroutine = false;
    }
}
