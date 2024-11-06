using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component
    public GameObject dialogueUI;          // Reference to the GameObject that contains the text UI
    public GameObject interactPrompt;      // Reference to the GameObject that displays the interact prompt
    public GameObject interactCircle;      // Reference to the GameObject that shows the interaction circle
    public string[] lines;                 // Lines of dialogue
    public float textSpeed = 0.05f;        // Speed of text typing

    private int index;                     // Current index of the dialogue line
    private bool isPlayerInRange = false; // To check if player is in range
    private bool isDialogueActive = false; // To check if dialogue is currently active

    void Start()
    {
        // Ensure the dialogue UI, text component, interact prompt, and interact circle are assigned
        if (dialogueUI == null) { Debug.LogError("Dialogue UI is not assigned in the Inspector!"); }
        if (textComponent == null) { Debug.LogError("Text Component is not assigned in the Inspector!"); }
        if (interactPrompt == null) { Debug.LogError("Interact Prompt is not assigned in the Inspector!"); }
        if (interactCircle == null) { Debug.LogError("Interact Circle is not assigned in the Inspector!"); }

        textComponent.text = string.Empty; // Clear text at the start
        dialogueUI.SetActive(false); // Initially hide the dialogue UI
        interactPrompt.SetActive(false); // Initially hide the interact prompt
        interactCircle.SetActive(false); // Initially hide the interact circle
    }

    void Update()
    {
        // Check if the player is in range and presses the 'E' key
        if (isPlayerInRange)
        {
            interactPrompt.SetActive(true); // Show interact prompt
            interactCircle.SetActive(true);  // Show the interaction circle
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E key pressed while in range.");
                if (!isDialogueActive)
                {
                    StartDialogue();
                }
                else
                {
                    NextLine(); // Advance to the next line on pressing 'E'
                }
            }
        }
        else
        {
            interactPrompt.SetActive(false); // Hide interact prompt when out of range
            interactCircle.SetActive(false);  // Hide the interaction circle when out of range
        }
    }

    public void StartDialogue()
    {
        dialogueUI.SetActive(true); // Show the dialogue UI
        interactPrompt.SetActive(false); // Hide the interact prompt when dialogue starts
        interactCircle.SetActive(false);  // Hide the interaction circle when dialogue starts
        Debug.Log("Dialogue started.");
        index = 0;                  // Reset index to the first line
        isDialogueActive = true;    // Set dialogue state to active
        StartCoroutine(TypeLine()); // Start typing the first line
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty; // Clear text before typing
        Debug.Log("Typing line: " + lines[index]); // Log the line being typed
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;                // Append characters one by one
            yield return new WaitForSeconds(textSpeed); // Wait for the specified time
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1) // Check if there are more lines
        {
            index++;                            // Move to the next line
            StopAllCoroutines();                // Stop the typing coroutine if it's running
            StartCoroutine(TypeLine());         // Start typing the next line
        }
        else
        {
            Debug.Log("No more lines to display. Ending dialogue.");
            EndDialogue();                      // End dialogue if no more lines
        }
    }

    void EndDialogue()
    {
        // Ensure any running coroutines are stopped
        StopAllCoroutines();

        // Clear the text to ensure it disappears
        textComponent.text = string.Empty; 
        dialogueUI.SetActive(false); // Hide the dialogue UI
        isDialogueActive = false;    // Set dialogue state to inactive
        Debug.Log("Dialogue ended."); // Log dialogue end
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            isPlayerInRange = true; // Set player in range to true
            Debug.Log("Player entered NPC range."); // Log player entry
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player exits the trigger
        {
            isPlayerInRange = false; // Set player in range to false
            Debug.Log("Player exited NPC range."); // Log player exit
            if (isDialogueActive)
            {
                EndDialogue(); // End dialogue if the player exits while it's active
            }
        }
    }
}