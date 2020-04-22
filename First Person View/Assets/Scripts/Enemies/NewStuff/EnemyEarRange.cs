using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEarRange : MonoBehaviour
{
    public GameObject player;
    private RaycastHit hit;
    public float hearingDistance;
    private bool playerinRange;
    public GameObject eyeline;
    public GameObject EnemyScripts;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
           Debug.Log("Heard Brick");
           //Do Something
        }

        if (other.CompareTag("Player"))
        {
            playerinRange = true;
        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (playerinRange)
        {
            if (Physics.Raycast(eyeline.transform.position,
                (player.transform.position - eyeline.transform.position), out hit, hearingDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Heard Player");
                    //In hearing range
                    EnemyScripts.GetComponent<AgentWander>().enabled = true;
                    EnemyScripts.GetComponent<AgentTarget>().enabled = false;
                    EnemyScripts.GetComponent<Patrol>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinRange = false;
        }
    }
}
