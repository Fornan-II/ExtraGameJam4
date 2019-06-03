using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class ButtonInfo : MonoBehaviour
{
    public Text choiceMessage;
    protected int choiceIndex = -1;

    public void SetInfo(Choice choice)
    {
        choiceMessage.text = choice.text;
        choiceIndex = choice.index;
    }

    public virtual void OnClick()
    {
        DialogueUIManager.Instance.MakeDecision(choiceIndex);
        choiceIndex = -1;
    }
}
