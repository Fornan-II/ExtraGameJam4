using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool IsInteractable = true;
    public Transform interactionWalkLocation;

    public virtual bool InteractWith(GameObject interacter)
    {
        if(IsInteractable)
        {
            return HandleInteract(interacter);
        }

        return false;
    }

    public virtual bool HandleInteract(GameObject interacter)
    {
        Debug.Log("Interact");
        return true;
    }
}
