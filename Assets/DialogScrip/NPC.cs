using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogTrigger trigger;
    public string[] dialogue;
    public string name;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (trigger != null)
            {
                trigger.StartDialogue();
            }
            else
            {
                Debug.LogWarning("DialogTrigger is not assigned to the NPC.");
            }

        }
    }
}


