using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneDetector : MonoBehaviour
{

    private BoxCollider _collider;
    private PlayableDirector _PlayableDirector;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _PlayableDirector = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _PlayableDirector.Play();
        }
    }
}
