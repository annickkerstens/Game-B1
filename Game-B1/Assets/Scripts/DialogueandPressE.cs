using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;         // Reference to the TextMeshProUGUI component
    public GameObject dialogueUI;                 // Reference to the GameObject that contains the text UI
    public GameObject interactPrompt;             // Reference to the GameObject that displays the interact prompt
    public GameObject interactCircle;             // Reference to the GameObject that shows the interaction circle
    public string[] initialLines;                 // Initial lines of dialogue
    public string[] postInteractionLines;         // Lines of dialogue after object interaction
    public AudioClip[] initialAudioClips;         // Audio clips for initial lines
    public AudioClip[] postInteractionAudioClips; // Audio clips for post-interaction lines
    public float textSpeed = 0.05f;               // Speed of text typing

    private int index;                            // Current index of the dialogue line
    private bool isPlayerInRange = false;         // To check if player is in range
    private bool isDialogueActive = false;        // To check if dialogue is currently active
    private string[] currentLines;                // Holds the current dialogue lines based on interaction state
    private AudioClip[] currentAudioClips;        // Holds the current audio clips based on interaction state
    private AudioSource audioSource;              // AudioSource component for playing audio

    void Start()
    {
        // Initialize the AudioSource
        audioSource = GetComponent<AudioSource>();

        // Ensure the dialogue UI, text component, interact prompt, and interact circle are assigned
        if (dialogueUI == null) { Debug.LogError("Dialogue UI is not assigned in the Inspector!"); }
        if (textComponent == null) { Debug.LogError("Text Component is not assigned in the Inspector!"); }
        if (interactPrompt == null) { Debug.LogError("Interact Prompt is not assigned in the Inspector!"); }
        if (interactCircle == null) { Debug.LogError("Interact Circle is not assigned in the Inspector!"); }

        textComponent.text = string.Empty;        // Clear text at the start
        dialogueUI.SetActive(false);              // Initially hide the dialogue UI
        interactPrompt.SetActive(false);          // Initially hide the interact prompt
        interactCircle.SetActive(false);          // Initially hide the interact circle
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            interactPrompt.SetActive(true);
            interactCircle.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isDialogueActive)
                {
                    StartDialogue();
                }
                else
                {
                    NextLine();
                }
            }
        }
        else
        {
            interactPrompt.SetActive(false);
            interactCircle.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (GameStateController.instance.objectInteracted)
        {
            currentLines = postInteractionLines;
            currentAudioClips = postInteractionAudioClips; // Use post-interaction audio
        }
        else
        {
            currentLines = initialLines;
            currentAudioClips = initialAudioClips;         // Use initial audio
        }

        dialogueUI.SetActive(true);
        interactPrompt.SetActive(false);
        interactCircle.SetActive(false);
        index = 0;
        isDialogueActive = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;

        // Play the audio clip for the current line
        if (currentAudioClips != null && index < currentAudioClips.Length && currentAudioClips[index] != null)
        {
            audioSource.clip = currentAudioClips[index];
            audioSource.Play();
        }

        foreach (char c in currentLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < currentLines.Length - 1)
        {
            index++;
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        StopAllCoroutines();
        textComponent.text = string.Empty;
        dialogueUI.SetActive(false);
        isDialogueActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (isDialogueActive)
            {
                EndDialogue();
            }
        }
    }
}
