using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UitgangBuurthuis : MonoBehaviour
{
    void OnTriggerEnter(){
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

}

