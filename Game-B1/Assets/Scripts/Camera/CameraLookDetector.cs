/* 
 * CAMERA LOOK DETECTOR
 * Detects what the camera is looking at
 * If it is looking at something that has a collider, it will attempt 
 * to tell the MouseCursor script to change its cursor
 * If the Interact key is pressed while looking at an object
 * it will attempt to run the 'Interact Function' of the targets' Object Interaction script
 */

using UnityEngine;
using System.Collections;

public class CameraLookDetector : MonoBehaviour
{
    Camera cam;
    public MouseCursor mouseCursor;

    public KeyCode interactKey = KeyCode.E;

    public float maxInteractionDistance = 2.0f;

    ObjectInteraction currentLookTarget;
    void Start()
    {
        cam = GetComponent<Camera>();
        currentLookTarget = null;
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxInteractionDistance))
          LookAtInteractible(hit.transform.GetComponent<ObjectInteraction>() ?? null);
        else
          LookAtInteractible(null);

        if (Input.GetKeyDown(interactKey) && currentLookTarget != null)
        {
          currentLookTarget.OnInteract();
        }

    }

    void LookAtInteractible(ObjectInteraction obj)
    {
      currentLookTarget = obj;
      if (obj != null && obj.cursor != null)
        mouseCursor.SetCursor(obj.cursor);
      else 
        mouseCursor.SetCursor();
    }


}