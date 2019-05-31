using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour
{
    public Text Title;
    public Text Body;

    public void SetTitle(string msg)
    {
        if(Title)
        {
            Title.text = msg;
        }
        else
        {
            Debug.LogWarning("Hey I got no title, don't set me");
        }
    }

    public void SetText(string msg)
    {
        if (Body)
        {
            Body.text = msg;
        }
        else
        {
            Debug.LogWarning("Hey I got no body, don't set me");
        }
    }
}
