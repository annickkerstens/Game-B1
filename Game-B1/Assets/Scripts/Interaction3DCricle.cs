using UnityEngine;

public class InteractionCircle : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;  // Key to trigger interaction

    // Method to make the interaction circle disappear
    public void HideInteractionCircle()
    {
        gameObject.SetActive(false);
        Debug.Log("Interaction circle removed after item pickup.");
    }
}
