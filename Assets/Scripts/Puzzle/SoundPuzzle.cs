using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundPuzzle : MonoBehaviour {
    [Header("Entry/Exit")]
    [SerializeField]
    private Transform _playbackArea;
    [SerializeField]
    private float _playbackRadius = 2;
    [SerializeField]
    private GameObject _door;
    [Header("Puzzle Components")]
    [SerializeField] 
    [Tooltip("Object in the environment that will create sounds for the puzzle")]
    private List<SoundObject> _soundObjects;
    [SerializeField] 
    [Tooltip("Sound loaded into sound objects, ensure that the index of the sound matches the index of it's object")]
    private List<AudioClip> _puzzleSounds;

    private bool _haveAnswersBeenPlayed; 

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

        Utility.Shuffle(AnswerKey);

        foreach (SoundObject answer in AnswerKey) {
            Debug.Log(answer.SoundClip.name);
        }
    }

    private void Update() {
        // Cast a sphere to detect player and playback the answerkey for them
        if (!_haveAnswersBeenPlayed) {
            float playbackDelay = 0;
            Collider[] hitColliders = Physics.OverlapSphere(_playbackArea.position, _playbackRadius);

            foreach (Collider hit in hitColliders) {
                if (hit.CompareTag("Player")) {
                    foreach(SoundObject soundObject in AnswerKey) {
                        soundObject.SoundSource.PlayDelayed((ulong) playbackDelay);
                        playbackDelay = soundObject.SoundClip.length;
                    }

                    _haveAnswersBeenPlayed = true;
                    break;
                }  
            }
        }



        if (IsSolved()) {
            _door.SetActive(false);
        } else if (IsIncorrect()) {
            PlayerAnswers.Clear();
        }
    }

    public static bool IsSolved() => AnswerKey.SequenceEqual(PlayerAnswers);

    public static bool IsIncorrect() => PlayerAnswers.Count == AnswerKey.Count && !IsSolved();

    private void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 1, 0.25f);
        Gizmos.DrawSphere(_playbackArea.position, _playbackRadius);    
    }
}
