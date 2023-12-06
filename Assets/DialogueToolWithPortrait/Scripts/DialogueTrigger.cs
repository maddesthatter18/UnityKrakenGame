using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{ //allows dialogue to be triggered by a trigger volume!
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueMangaer>().StartDialogue(dialogue);
    }
}
