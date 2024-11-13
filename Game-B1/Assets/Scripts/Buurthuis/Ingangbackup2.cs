using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingangbackup2 : MonoBehaviour
{
    void OnTriggerEnter(){
        SceneManager.LoadScene("backup2", LoadSceneMode.Single);
    }

}
