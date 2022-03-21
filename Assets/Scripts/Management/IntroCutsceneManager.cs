using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroCutsceneManager : MonoBehaviour
{
    private PlayableDirector _part1, _part2;
    // Start is called before the first frame update
    void Start()
    {
        _part1 = GetComponent<PlayableDirector>();
        _part2 = GameObject.Find("IntroCutscenePart2").GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_part1.state != PlayState.Playing)
        {
            _part2.Play();
        }
    }
}