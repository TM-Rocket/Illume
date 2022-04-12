using UnityEngine;
using UnityEngine.Playables;

public class ExpositionTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _expositionTimeline;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            _expositionTimeline.Play();
    }
}
