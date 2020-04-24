using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject WinningScreen;
    public GameObject OtherCanvas;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            WinningScreen.SetActive(true);
            OtherCanvas.SetActive(false);
        }
    }
}
