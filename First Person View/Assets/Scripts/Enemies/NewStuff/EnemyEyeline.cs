using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyEyeline : MonoBehaviour
{
    public GameObject player;
    private RaycastHit hit;
    public float sightDistance;
    public GameObject eyeline;
    public GameObject EnemyScripts;
    public GameObject RangeVisibility;

    void Start()
    {
        RangeVisibility.SetActive(false); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
            if (Physics.Raycast(eyeline.transform.position, (player.transform.position - eyeline.transform.position), out hit, sightDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player Seen");
                    //Attack Function
                    EnemyScripts.GetComponent<AgentWander>().enabled = false;
                    EnemyScripts.GetComponent<Patrol>().enabled = false;
                    EnemyScripts.GetComponent<BasicEnemy>().enabled = true;
                    RangeVisibility.SetActive(true); 
                }
            }
        }
    }
}
