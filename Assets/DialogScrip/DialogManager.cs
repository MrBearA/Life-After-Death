using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // UI elements for displaying dialogue
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    // Arrays to store dialogue messages and actors
    Message[] currentMessage;
    Actor[] currentActors;
    int activeMessage = 0; // Index of the currently displayed message
    public static bool isActive = false; // Flag to control dialogue display

    // Method to start and display dialogue
    public void OpenDialogue(Message[] message, Actor[] actors)
    {
        currentMessage = message;
        currentActors = actors;
        activeMessage = 0;
        isActive = true; // Activate dialogue display
        Debug.Log("start convo" + message.Length);
        DisplayMessage(); // Show the first message
        backgroundBox.LeanScale(Vector3.one, 0.5f); // Animate dialogue box appearance
    }

    // Display the current message and associated actor
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessage[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        AnimateTextColor(); // Animate text color change
    }

    // Move to the next message or end the dialogue
    public void NextMessage()
    {
        activeMessage++; // Move to the next message

        if (activeMessage < currentMessage.Length)
        {
            DisplayMessage(); // Display the next message
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo(); // Animate dialogue box disappearance
            isActive = false; // Deactivate dialogue display
        }
    }

    // Animate text color change for the message
    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0); // Fade out
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f); // Fade in
    }

    // Initialization
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero; // Hide dialogue box initially
    }

    // Update is called once per frame
    void Update()
    {
        // Check for player input to display the next message
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage(); // Display the next message
        }
    }
}
