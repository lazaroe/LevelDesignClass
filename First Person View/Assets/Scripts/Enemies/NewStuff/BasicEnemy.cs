using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    
    private NavMeshAgent nav;
    
    [Header("Target and ReturnPoint")] 
    public Transform Player;
    public Transform OrigianlPosition;
    
    [Header("EnemyValues")] 
    public float LookAtSpeed = 3;
    public float MaxDistAwayFromPlayer = 10;
    public float MinDist = 1;
    public float speed = 3;


    private float swordactive = 0.5f;
    
    [Header("EnemyAttack")]
    public Transform ShootingPoint;
    public GameObject Bullets;
    float startTimer;
    public float TimeBetweenAttacks;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }
    

    public void FollowPlayerWhenInRange()
    {
        var rotation = Quaternion.LookRotation(Player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookAtSpeed);
        //the script above is the equivalent of "look at" but witha  smoth

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        var minDist = MinDist;
        if (Vector3.Distance(transform.position, Player.position) >= minDist
        ) //this checks the distance between enemy and player
        {
            nav.SetDestination(Player.position);



            if (Vector3.Distance(transform.position, Player.position) <= MaxDistAwayFromPlayer
            ) //this checks the distance between enemy and player
            {
                nav.SetDestination(transform.position);
                startTimer += Time.deltaTime;
                    if (startTimer >= TimeBetweenAttacks)
                    {
                        startTimer = 0f; 
                        StartCoroutine(AttackingArrow());
                    }
            }

        }
    }

    public void GoBackToOriginalPosition()
    {

        if (Vector3.Distance(transform.position, OrigianlPosition.position) >= MinDist)
        {
            nav.SetDestination(OrigianlPosition.position);
            print("GoingbackToPosition");
            
        }
    }

    IEnumerator AttackingArrow()
    {
            yield return new WaitForSeconds(swordactive);
            Instantiate(Bullets, ShootingPoint.transform.position, Quaternion.identity);
            
    }

    

}

