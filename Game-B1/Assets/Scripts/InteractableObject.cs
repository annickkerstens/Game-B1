using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    void OnMouseDown() // or any other interaction event
    {
        GameStateController.instance.objectInteracted = true;
        Debug.Log("Object has been interacted with!");
    }
}
