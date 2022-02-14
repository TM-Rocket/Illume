using UnityEngine;

public class SoundObject : MonoBehaviour, IInteractable
{
    private Renderer _renderer;

    [HideInInspector] 
    public AudioClip SoundClip;
    [HideInInspector] 
    public AudioSource SoundSource;

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
            gameObject.tag = "Untagged";
        } else if (SoundPuzzle.IsIncorrect()) {
            _renderer.material.SetColor("_Color", Color.white);
        } 
    }

    public string GetDescription()
    {
        return "Play";
    }

    public void Interact()
    {
        if (!SoundPuzzle.IsSolved())
        {
            SoundSource.Play();

            SoundPuzzle.PlayerAnswers.Add(this);

            if (!SoundPuzzle.IsSolved())
            {
                _renderer.material.SetColor("_Color", Color.yellow);
            }
        }
    }
}
