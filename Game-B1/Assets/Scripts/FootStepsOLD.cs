using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject terrainFoot;
    private AudioSource terrainFootPrev;
    private AudioSource terrainFootNext;

    // LIST OF TERRAINS
    public AudioSource footstepGrass;  // 1
    public AudioSource footstepFloor;
    public AudioSource footstepSand;
    public AudioSource footstepStreet;

    private void Start()
    {
        terrainFootNext = terrainFootPrev = footstepGrass;  // PLAYER STARTING TERRAIN
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        terrainFoot = FindObjectOfType<TerrainDetector>().PlayerTerrain();

        if (terrainFoot == null) return;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            switch (terrainFoot.name)
            {
                case "GRASS":
                    PlayFootstep(footstepGrass);
                    break;
                case "FLOOR":
                    PlayFootstep(footstepFloor);
                    break;
                case "SAND":
                    PlayFootstep(footstepSand);
                    break;
                case "STREET":
                    PlayFootstep(footstepStreet);
                    break;
                default:
                    break;
            }

            if (terrainFootPrev != terrainFootNext)
            {
                terrainFootNext.Stop();
                terrainFootNext = terrainFootPrev;
            }
        }
    }

    private void PlayFootstep(AudioSource footstepSound)
    {
        if (footstepSound != terrainFootPrev)
        {
            terrainFootPrev = footstepSound;
            footstepSound.PlayOneShot(footstepSound.clip);
        }
    }
}