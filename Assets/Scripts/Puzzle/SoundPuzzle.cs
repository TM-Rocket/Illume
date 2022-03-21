using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class SoundPuzzle : MonoBehaviour {
    [Header("Entry/Exit")]
    [SerializeField]
    private Transform _playbackArea;
    [SerializeField]
    private float _playbackRadius = 2;
    [Header("Puzzle Components")]
    [SerializeField] 
    [Tooltip("Object in the environment that will create sounds for the puzzle")]
    private List<SoundObject> _soundObjects;
    [SerializeField] 
    [Tooltip("Sound loaded into sound objects, ensure that the index of the sound matches the index of it's object")]
    private List<AudioClip> _puzzleSounds;
    [Header("Cinematics")]
    [SerializeField]
    [Tooltip("Controls Raven NPC while puzzle is being completed")]
    private GameObject _raven; 
    [SerializeField]
    [Tooltip("Plays the cinematics attached to the puzzle")]
    private PlayableDirector _ravenEndCinematic;

    /**
     * Puzzle Logic
     */
    private bool _haveAnswersPlayed; 
    private float _playbackDelay = 0f;

    /**
     * Raven Logic
     */
    private Animator _ravenAnimator;
    private bool _hasEndCinematicPlayed = false;

    [HideInInspector]
    public static List<SoundObject> AnswerKey = new List<SoundObject>();
    [HideInInspector]
    public static List<SoundObject> PlayerAnswers = new List<SoundObject>(); 

    private void Awake() {
        for (int i = 0; i < _soundObjects.Count; i++) {
            _soundObjects[i].SoundClip = _puzzleSounds[i];

            // Add sound objects to the answer key
            AnswerKey.Add(_soundObjects[i]);
        }

        AnswerKey = Utility.Shuffle(AnswerKey);

        _ravenAnimator = _raven.GetComponent<Animator>();
        _ravenAnimator.SetBool("IsFlying", true);
    }

    private void Update() {
        // Cast a sphere to detect player and playback the answerkey for them
        if (!_haveAnswersPlayed) {
            Collider[] hitColliders = Physics.OverlapSphere(_playbackArea.position, _playbackRadius);

            foreach (Collider hit in hitColliders) {
                if (hit.CompareTag("Player")) {
                    StartCoroutine("PlaySoundClips");

                    _haveAnswersPlayed = true;
                    break;
                }  
            }
        }

        if (IsSolved()) {
            // Play ending cinematic
            if (!_hasEndCinematicPlayed) {
                _ravenAnimator.SetBool("IsFlying", false);
                _ravenEndCinematic.Play();
                _hasEndCinematicPlayed = true;
            }
        } else if (IsIncorrect()) {
            // Replay sound pattern to player
            StartCoroutine("PlaySoundClips");
            PlayerAnswers.Clear();
        }
    }

    private IEnumerator PlaySoundClips() {
        // Small playback delay for when puzzle is incorrectly answered
        yield return new WaitForSeconds(2);

        foreach(SoundObject soundObject in AnswerKey) {
            _playbackDelay = soundObject.SoundClip.length;
            soundObject.SoundSource.Play();

            yield return new WaitForSeconds(_playbackDelay);
        }
    }

    public static bool IsSolved() => AnswerKey.SequenceEqual(PlayerAnswers);

    public static bool IsIncorrect() => PlayerAnswers.Count == AnswerKey.Count && !IsSolved();

    private void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 1, 0.25f);
        Gizmos.DrawSphere(_playbackArea.position, _playbackRadius);    
    }
}
