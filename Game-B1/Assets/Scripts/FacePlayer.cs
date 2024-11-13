using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform player; // Drag your player GameObject here in the Inspector.

    void Update()
    {
        if (player != null)
        {
            // Look at the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Keep the NPC level with the ground.
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
