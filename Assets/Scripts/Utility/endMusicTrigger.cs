using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endMusicTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("endMusic");
            FindObjectOfType<AudioManager>().Stop("caveBGM");
            FindObjectOfType<AudioManager>().Stop("caveSFX");
        }
    }
}
