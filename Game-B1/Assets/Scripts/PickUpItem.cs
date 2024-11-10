using UnityEngine;
using TMPro;  // Add this namespace for TMP

public class PickupItem : MonoBehaviour
{
    public string itemName = "Default Item";
    public float pickupRange = 3f;
    public KeyCode pickupKey = KeyCode.E;

    [SerializeField] private TextMeshProUGUI pickupPrompt;  // Use TextMeshProUGUI here
    private Transform player;  // To track the player's position

    private void Start()
    {
        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Hide the prompt initially
        if (pickupPrompt != null)
        {
            pickupPrompt.gameObject.SetActive(false);  // Initially hide the TMP text
        }
        else
        {
            Debug.LogError("PickupPrompt UI TextMeshPro object not found. Make sure it's assigned in the Inspector.");
        }
    }

    private void Update()
    {
        if (player == null) return;

        // Check if player is close enough to see the prompt
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= pickupRange)
        {
            ShowPickupPrompt();
            if (Input.GetKeyDown(pickupKey))
            {
                PickUp();
            }
        }
        else
        {
            // Hide the prompt if the player is out of range
            HidePickupPrompt();
        }
    }

    private void ShowPickupPrompt()
    {
        if (pickupPrompt != null && !pickupPrompt.gameObject.activeSelf)
        {
            pickupPrompt.gameObject.SetActive(true);  // Show the TMP text
        }
    }

    private void HidePickupPrompt()
    {
        if (pickupPrompt != null && pickupPrompt.gameObject.activeSelf)
        {
            pickupPrompt.gameObject.SetActive(false);  // Hide the TMP text
        }
    }

    public void PickUp()
    {
        Debug.Log("Picked up " + itemName);
        HidePickupPrompt();  // Hide the prompt immediately after the item is picked up
        Destroy(gameObject);  // Destroy the item after picking up
    }
}
