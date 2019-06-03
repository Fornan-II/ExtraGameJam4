using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueUIManager : MonoBehaviour
{
    public static DialogueUIManager Instance;

    public Story story;
    protected string mostRecentItem = "";

    public bool IsActive
    {
        get
        {
            return DialoguePanel.isActiveAndEnabled || ChoicePanel.isActiveAndEnabled;
        }
    }

    public PanelInfo DialoguePanel;
    public ChoicePanelInfo ChoicePanel;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance)
        {
            Debug.LogWarning("Hey there's more than one DialogueUIManager in the scene");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(Story dialogue)
    {
        story = dialogue;
        ContinueStory();
    }

    public void StopDialogue()
    {
        story = null;
        ChoicePanel.gameObject.SetActive(false);
        DialoguePanel.gameObject.SetActive(false);
    }

    public virtual void ContinueStory()
    {
        ChoicePanel.gameObject.SetActive(false);
        DialoguePanel.gameObject.SetActive(false);

        if (!story)
        {
            mostRecentItem = "";
            return;
        }

        if (story.canContinue)
        {
            mostRecentItem = story.Continue();
            DialoguePanel.SetText(mostRecentItem);
            DialoguePanel.gameObject.SetActive(true);
        }
        else if (story.currentChoices.Count > 0)
        {
            ChoicePanel.SetButtons(story.currentChoices.ToArray());
            ChoicePanel.SetText(mostRecentItem);
            ChoicePanel.gameObject.SetActive(true);
        }
        else
        {
            mostRecentItem = "";
            StopDialogue();
        }
    }

    public virtual void MakeDecision(int decisionIndex)
    {
        if(!story)
        {
            return;
        }

        story.ChooseChoiceIndex(decisionIndex);
        ContinueStory();
    }
}