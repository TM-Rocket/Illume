using System.Collections.Generic;
using UnityEngine;

public class EarthActionController : Interactable  {
    [SerializeField]
    [Tooltip("Set of objects the player can toggle from. If only one object is present that object will be toggled with nothing.")]
    private List<GameObject> _objectSet;

    private List<Animator> _objectAnimatorSet;

    private int _activeObjectIndex = 0;

    private bool _isOnState = false;

    protected override void Awake() {
        base.Awake();

        _objectAnimatorSet = new List<Animator>();

        foreach (GameObject obj in _objectSet) {
            Animator anim = obj.GetComponent<Animator>();
            _objectAnimatorSet.Add(anim);
        }
    }

    private void Update() => IsEnabled = StonePickup.IsStonePickedUp; 

    private void UpdateMultipleEarthActions() {
        _objectSet[_activeObjectIndex].SetActive(false);

        AudioManager.Instance.Play("earthAbility");

        if (_activeObjectIndex < _objectSet.Count - 1) {
            _activeObjectIndex++;
            _objectSet[_activeObjectIndex].SetActive(true);
        } else {
            _activeObjectIndex = 0;
            _objectSet[_activeObjectIndex].SetActive(true);
        }
    }

    private void UpdateSingleEarthAction() {
        AudioManager.Instance.Play("earthAbility");

        if (_isOnState) {
            // Play object 'down' animation when on
            _objectAnimatorSet[0].SetBool("isOn", false); 
            _isOnState = false;
        } else {
            // Play object 'up' animation when on
            _objectAnimatorSet[0].SetBool("isOn", true); 
            _isOnState = true;
        }
    }

    public override void Interact() {
        if (_objectSet.Count > 1) {
            UpdateMultipleEarthActions();
        } else {
            UpdateSingleEarthAction();
        }
    }

    public override string GetKeyToPress() => "F";
}
