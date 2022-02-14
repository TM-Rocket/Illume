using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    private Material _mat;

    private void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
    }

    public string GetDescription()
    {
        return "Revive Tree";
    }

    public void Interact()
    {
        GameObject waterOrb = GameObject.Find("WaterOrb");
        GameObject earthOrb = GameObject.Find("EarthOrb");

        if (waterOrb.transform.parent.name == "Spine2" && earthOrb.transform.parent.name == "Spine2")
        {
            _mat.color = new Color(0, 255, 0);
            transform.localScale = new Vector3(1, 3, 1);

            earthOrb.SetActive(false);
            waterOrb.SetActive(false);

            gameObject.tag = "Untagged";
        }
    }
}
