using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngangBuurthuis : MonoBehaviour
{
    void OnTriggerEnter(){
        SceneManager.LoadScene("Buurthuis", LoadSceneMode.Single);
    }

}
