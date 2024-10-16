using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleOnTriggerDialogue : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        //hier je van alles doen... andere scene/audio/animatie etc.
    }
}
