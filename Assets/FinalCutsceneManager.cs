using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinalCutsceneManager : MonoBehaviour
{
    private PlayableDirector _PlayableDirector;
    private bool _played, _caveBGM;
    // Start is called before the first frame update
    void Start()
    {
        _PlayableDirector = GetComponent<PlayableDirector>();
        _caveBGM = false;
    }

    // Update is called once per frame
    void Update() {
        if (_PlayableDirector.state == PlayState.Playing) {
            _played = true;
            FindObjectOfType<AudioManager>().Stop("caveBGM"); 
            FindObjectOfType<AudioManager>().Stop("caveSFX");
        }
    }
}
