using UnityEngine;

public class AnyKeyMenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject _anyKeyMenuUI;
    [SerializeField]
    private GameObject _mainMenuUI;

    private bool _isComplete = false;

    private void Update() {
       if (Input.anyKey && !_isComplete) {
           _anyKeyMenuUI.SetActive(false);
           _mainMenuUI.SetActive(true);

           _isComplete = true;
       } 
    }
}
