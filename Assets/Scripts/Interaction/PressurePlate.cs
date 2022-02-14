using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;

    private void Check()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale);

        foreach (Collider hit in hitColliders)
        {
            if (hit.CompareTag("Interactable") && hit.transform.parent.name != "RightHand")
            {
                _door.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
}
