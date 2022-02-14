using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private bool _canInteract;
    private GameObject _interactObject;

    [SerializeField]
    private GameObject _interactionUI;
    [SerializeField]
    private Text _interactionText;

    // Within interaction range
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            _interactObject = other.gameObject;

            IInteractable interactable = other.GetComponent<IInteractable>();

            if (interactable != null)
            {
                _canInteract = true;
                _interactionText.text = interactable.GetDescription();
                _interactionUI.SetActive(_canInteract);
            }
        }
    }

    // Out of interaction range
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            _canInteract = false;
            _interactionUI.SetActive(_canInteract);
        }
    }

    private void Update()
    {
        // Collision detection and object remains interactable
        if (_canInteract == true && _interactObject.tag == "Interactable")
        {
            IInteractable interactable = _interactObject.GetComponent<IInteractable>();
            _interactionText.text = interactable.GetDescription();

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }
        // Condition not met to interact
        else
        {
            _canInteract = false;
            _interactionUI.SetActive(_canInteract);
            _interactObject = null;
        }
    }
}