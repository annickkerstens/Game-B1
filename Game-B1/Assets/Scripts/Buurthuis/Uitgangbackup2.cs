using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uitgangbackup2 : MonoBehaviour
{
    void OnTriggerEnter(){
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

}

