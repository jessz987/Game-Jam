using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    GameObject currentlyTalkingTo;
    NPCDialogueHolder dialogueOfCurrentConversation;
    int indexInCurrentConversation;

    public static bool ActivePanel;
    public GameObject DialoguePanel;

    public bool InConversation
    {
        get
        {
            if (currentlyTalkingTo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public Text UIText;
    public Text playerUIText;

    void Start()
    {
        currentlyTalkingTo = null;
        dialogueOfCurrentConversation = null;
        indexInCurrentConversation = 0;
        ActivePanel = false;
    }

    public void BeginConversation(GameObject npc)
    {
        ActivePanel = true;
        DialoguePanel.SetActive(true);
        Debug.Log("talking to: " + npc.name);
        currentlyTalkingTo = npc;
        dialogueOfCurrentConversation = npc.GetComponent<NPCDialogueHolder>();
        indexInCurrentConversation = 0;

        AdvanceConversation();
    }

    public void EndConversation()
    {
        currentlyTalkingTo = null;
        dialogueOfCurrentConversation = null;
        indexInCurrentConversation = 0;

        ActivePanel = false;
        DialoguePanel.SetActive(false);
    }

    public void AdvanceConversation()
    {
        ActivePanel = true;
        if (currentlyTalkingTo != null)
        {
            if (indexInCurrentConversation < dialogueOfCurrentConversation.npcDialogueSequence.Length)
            {
                Debug.Log("in npc dialog at index: " + indexInCurrentConversation);
                DisplayText(dialogueOfCurrentConversation.npcDialogueSequence[indexInCurrentConversation], UIText);

            }
            else
            {
                Debug.Log("in player dialog at index: " + indexInCurrentConversation);
                if (indexInCurrentConversation < ((dialogueOfCurrentConversation.npcDialogueSequence.Length - 1 + dialogueOfCurrentConversation.playerDialogueSequence.Length)))
                {
                    DisplayText(dialogueOfCurrentConversation.playerDialogueSequence[indexInCurrentConversation - dialogueOfCurrentConversation.npcDialogueSequence.Length], playerUIText);
                }
            }

            indexInCurrentConversation++;

            
            if (indexInCurrentConversation > ((dialogueOfCurrentConversation.npcDialogueSequence.Length + dialogueOfCurrentConversation.playerDialogueSequence.Length)))
            {
                Debug.Log("index: " + indexInCurrentConversation);
                Debug.Log("end conversation");
                EndConversation();
            }

        }
        else
        {
            Debug.Log("We're not currently talking to anyone!");
        }
    }

    public void DisplayText(string line, Text uiText)
    {
        uiText.text = line;
    }
}