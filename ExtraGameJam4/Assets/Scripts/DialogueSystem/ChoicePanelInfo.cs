using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class ChoicePanelInfo : PanelInfo
{
    public List<ButtonInfo> Choices;

    public void SetButtons(Choice[] buttonChoices)
    {
        int messageIndex = 0;
        foreach (ButtonInfo btn in Choices)
        {
            if(messageIndex >= buttonChoices.Length)
            {
                btn.gameObject.SetActive(false);
            }
            else
            {
                btn.SetInfo(buttonChoices[messageIndex]);
                messageIndex++;
            }
        }
    }
}
