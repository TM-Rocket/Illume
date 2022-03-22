using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FallingCutsceneManager : MonoBehaviour
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
            FindObjectOfType<AudioManager>().Stop("adventureBGM"); 
        }

        if (_PlayableDirector.state != PlayState.Playing && _played) {
            if (_caveBGM == false) {
                FindObjectOfType<AudioManager>().Stop("introBGM");
                FindObjectOfType<AudioManager>().Play("caveBGM"); 
                FindObjectOfType<AudioManager>().Play("caveSFX");
            }
            _caveBGM = true;
        }
    }
}
