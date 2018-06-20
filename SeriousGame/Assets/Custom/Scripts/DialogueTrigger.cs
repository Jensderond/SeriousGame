using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    private void Start()
    {
        GameController.gameController.FirstTime = false;
        if ( !GameController.gameController.FirstTime )
        {
            TriggerDialogue();
            GameController.gameController.FirstTime = true;
            //TODO: set firstTime to false after running this once
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.dialogueManager.StartDialogue(dialogue);
    }
}
