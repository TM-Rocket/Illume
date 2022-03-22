using System.Collections;
using UnityEngine;

public class Tree : Interactable {
    public override void Interact() {
        GameObject waterOrb = GameObject.Find("WaterOrb");
        GameObject earthOrb = GameObject.Find("EarthOrb");

        if (waterOrb.transform.parent.name == "Spine2" && earthOrb.transform.parent.name == "Spine2") {
            InteractableRenderer.material.color = new Color(0, 255, 0);
            transform.localScale = new Vector3(1, 3, 1);

            earthOrb.SetActive(false);
            waterOrb.SetActive(false);

            gameObject.tag = "Untagged";

            StartCoroutine("Finish");
        }
    }

    public override string GetKeyToPress() => "E";

    private IEnumerator Finish() {
        yield return new WaitForSeconds(2);
        SceneLoader.Load("Menu");
    }
}
