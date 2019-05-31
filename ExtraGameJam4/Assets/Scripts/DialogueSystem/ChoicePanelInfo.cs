using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePanelInfo : PanelInfo
{
    public List<ButtonInfo> Choices;

    public void SetButtons(string[] buttonMessages)
    {
        int messageIndex = 0;
        foreach (ButtonInfo btn in Choices)
        {
            if(messageIndex >= buttonMessages.Length)
            {
                btn.gameObject.SetActive(false);
            }
            else
            {
                btn.SetInfo(buttonMessages[messageIndex], null);
                messageIndex++;
            }
        }
    }
}
