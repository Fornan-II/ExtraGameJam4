using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public Text choiceMessage;
    public delegate void OnSelectCallback();
    public OnSelectCallback CallbackAction;

    public void SetInfo(string msg, OnSelectCallback onClick)
    {
        choiceMessage.text = msg;
        CallbackAction = onClick;
    }

    public void OnClick()
    {
        CallbackAction.Invoke();
    }
}
