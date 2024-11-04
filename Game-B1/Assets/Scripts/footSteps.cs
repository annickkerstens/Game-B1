using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSteps : MonoBehaviour
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

  private void Start(){
    terrainFootNext = terrainFootPrev = footstepGrass;  // 0 - PLAYER STARTING TERRAIN
  }


  void Update()
  {
    audioSource = GetComponent<AudioSource>();

    terrainFoot = FindObjectOfType<TerrainDetector>().PlayerTerrain();
    Debug.Log(terrainFoot);

        if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)  )
            {

              switch(terrainFoot.name)
              {
                    case "GRASS":                           // 2
                          footstepGrass.enabled   = true;   // 2
                          terrainFootPrev = footstepGrass;  // 2
                          break;
                    case "FLOOR":
                          footstepFloor.enabled   = true;
                          terrainFootPrev = footstepFloor;
                          break;
                    case "SAND":
                          footstepSand.enabled   = true;
                          terrainFootPrev = footstepSand;
                          break;
                    case "STREET":
                          footstepStreet.enabled   = true;
                          terrainFootPrev = footstepStreet;
                          break;
                    default:
                          break;

              }


              if(terrainFootPrev != terrainFootNext)
                {
                    terrainFootNext.enabled = false;
                    terrainFootNext = terrainFootPrev;
                }

            }else{
              footstepGrass.enabled = false;  // 3
              footstepFloor.enabled = false;
              footstepSand.enabled = false;
              footstepStreet.enabled = false;

            }

  }

}
