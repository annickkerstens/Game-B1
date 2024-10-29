using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deuropen : MonoBehaviour
{
  
   Animator animator;
   AudioSource audioSource;
   bool isOpen;

   public AudioClip deurOpenGeluid;

   void Start() {
      animator = GetComponent<Animator>();
      audioSource = GetComponent<AudioSource>();
      isOpen = false;
   }

   public void Openen() {
      if(isOpen == false) {
         animator.SetTrigger("Open");
         audioSource.PlayOneShot(deurOpenGeluid);
         isOpen = true;
      } else {
         animator.SetTrigger("Sluit");
         isOpen = false;
      }
    
   }

}