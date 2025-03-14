using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Message[] message;
    public Actor[] actors;

    
    public void StartDialogue()
    {
        FindObjectOfType<DialogManager>().OpenDialogue(message, actors);
    }

}


[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}


