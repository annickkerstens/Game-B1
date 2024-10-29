/* 
 * OBJECT INTERACTION
 * Attach this to every object that needs to be interactible.
 * Here you can define:
 * - What is the object's name (used only for debugging)
 * - What is its icon (used as a crosshair)
 * - What function should it run upon interaction (make a separate script with a public function
 *   and connect it here)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public string objectName;
    public Sprite cursor;
    public UnityEvent interactFunction;

    public void OnInteract() {
      Debug.Log("Interacted with " + objectName);
      if (interactFunction != null)
        interactFunction.Invoke();
    }
}
