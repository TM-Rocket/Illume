using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCollider : MonoBehaviour {
    [HideInInspector]
    public static Vector3 RespawnPosition;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.position = RespawnPosition;
        }
    } 
}
