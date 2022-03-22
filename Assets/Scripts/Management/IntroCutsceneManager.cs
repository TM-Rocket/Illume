using UnityEngine;
using UnityEngine.Playables;

public class IntroCutsceneManager : MonoBehaviour
{
    private PlayableDirector _part1, _part2;
    private bool _part1Played, _part2Played, _playAdventureBGM;

    void Start() {
        _part1 = GetComponent<PlayableDirector>();
        _part2 = GameObject.Find("IntroCutscenePart2").GetComponent<PlayableDirector>();
        _playAdventureBGM = false;

    }

    void Update() {
        if(_part1.state == PlayState.Playing) {
             if(_part1Played == false){
                 FindObjectOfType<AudioManager>().Play("introBGM");
             }
            _part1Played = true;

        }

        if(_part1.state != PlayState.Playing && _part1Played && !_part2Played) {
            _part2Played = true;
        }

        if(_part1Played == true && _part2Played == true)
        {   
            if(_playAdventureBGM == false){
            FindObjectOfType<AudioManager>().Play("adventureBGM"); 
            }
            _playAdventureBGM = true;
            
        }
    }
}
