using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private float _checkRadius = 4f;

    private void Check()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _checkRadius);

        foreach (Collider hit in hitColliders)
        {
            if (hit.CompareTag("Interactables"))
            {
                //Test
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
