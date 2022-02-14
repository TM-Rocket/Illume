using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "Revive Tree";
    }

    public void Interact()
    {
        if (GameObject.Find("WaterOrb").transform.parent.name == "Spine2" && GameObject.Find("EarthOrb").transform.parent.name == "Spine2")
        {
            Debug.Log("WIN WIN WIN");
        }
    }
}
