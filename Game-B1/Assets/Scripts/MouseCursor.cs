/* 
 * MOUSE CURSOR
 * Attach this to an Image in the Canvas, to act as a crosshair
 * The CameraLookDetector script interacts with this to change
 * the crosshair if the player is looking at an object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
    Sprite DefaultCursor;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        DefaultCursor = image.sprite;
    }

    public void SetCursor(Sprite cursor = null) 
    {
      if (cursor == null) cursor = DefaultCursor;

      image.sprite = cursor;
    }
}
