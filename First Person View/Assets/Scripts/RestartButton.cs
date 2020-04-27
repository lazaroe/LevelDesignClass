using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Application.Quit();
            Debug.Log("We quit the game");
        }
    }
}
