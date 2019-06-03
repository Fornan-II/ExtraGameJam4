using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class CharacterInteract : Interactable
{
    public TextAsset jsonDialogue;

    public override bool HandleInteract(GameObject interacter)
    {
        if(!DialogueUIManager.Instance)
        {
            return false;
        }

        DialogueUIManager.Instance.StartDialogue(new Story(jsonDialogue.text));
        return true;
    }
}
