using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturationDropStopper : MonoBehaviour
{
    private GameObject SaturationDropTrigger;

    private void Start() {
        SaturationDropTrigger = GameObject.Find("Saturation Drop Trigger");
    }

    private void OnTriggerEnter(Collider other) {
        SaturationDropTrigger.SetActive(false);
    }
}
