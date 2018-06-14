using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    private void Start()
    {
        if ( GameController.gameController.FirstTime )
        {
            TriggerDialogue();
            //TODO: set firstTime to false after running this once
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.dialogueManager.StartDialogue(dialogue);
    }
}
