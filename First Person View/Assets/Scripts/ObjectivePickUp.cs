using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivePickUp : MonoBehaviour
{
    public GameObject FinishLine;
    public GameObject Objective1;
    public GameObject Objective2;
    public GameObject NotPickedUp;
    public GameObject PickedUp;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FinishLine.SetActive(true);
            NotPickedUp.SetActive(false);
            PickedUp.SetActive(true);
            Objective1.SetActive(false);
            Objective2.SetActive(true);
        }
}
}
