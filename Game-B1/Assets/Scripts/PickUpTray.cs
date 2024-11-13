using System.Collections;
using UnityEngine;
using TMPro;

public class TrayPickup : MonoBehaviour
{
    public TextMeshProUGUI interactText; // Reference to the TextMeshProUGUI component for the interact prompt
    public GameObject interactUI; // UI element that contains the interaction text (e.g., "Press G to pick up")
    public Transform playerHand; // Reference to where the tray should be positioned when picked up
    public string interactMessage = "Press G to pick up"; // Message to show when player is in range

    private bool isPlayerInRange = false; // To check if player is in range
    private bool isPickedUp = false; // To check if the tray is already picked up

    void Start()
    {
        // Ensure the interaction UI and text are set up
        if (interactUI == null) { Debug.LogError("Interact UI is not assigned in the Inspector!"); }
        if (interactText == null) { Debug.LogError("Interact Text is not assigned in the Inspector!"); }

        interactText.text = string.Empty; // Clear any text at start
        interactUI.SetActive(false); // Hide the interaction UI initially
    }

    void Update()
    {
        // Check if the player is in range and presses the 'G' key to pick up the tray
        if (isPlayerInRange && !isPickedUp && Input.GetKeyDown(KeyCode.G))
        {
            PickUpTray();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp) // Check if the player enters the trigger and tray is not picked up
        {
            isPlayerInRange = true;
            interactUI.SetActive(true);
            interactText.text = interactMessage; // Display the interaction message
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactUI.SetActive(false);
            interactText.text = string.Empty; // Clear the interaction message when player leaves
        }
    }

    private void PickUpTray()
    {
        isPickedUp = true;
        interactUI.SetActive(false); // Hide interaction prompt after picking up

        // Set the tray as a child of the player's hand
        transform.SetParent(playerHand);
        transform.localPosition = Vector3.zero; // Position tray correctly in the hand
        transform.localRotation = Quaternion.identity;

        // Disable the collider to prevent further interactions
        GetComponent<Collider>().enabled = false;

        // Disable rigidbody physics to prevent tray from falling
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

        Debug.Log("Tray picked up!");
    }
}
