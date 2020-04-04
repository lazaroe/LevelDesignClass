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
    public float stuntTime = 2;
    private float stuntSpeed = 0;
    
    
    private float swordactive = 0.5f;
    
    [Header("EnemyAttack")] 
    public GameObject EnemSwordWeapon;
    public Transform ShootingPoint;
    public GameObject Arrows;
    public bool Swordsman;
    public bool Archer;
    float startTimer;
    public float TimeBetweenAttacks;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            StartCoroutine(Stunt());
        }
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
                
                //Do Stuff Like Attack
                if (Swordsman == true)
                {
                    startTimer += Time.deltaTime;
                    if (startTimer >= TimeBetweenAttacks)
                    {
                        startTimer = 0f;
                        StartCoroutine(AttackingSword());
                    }
                }
                if (Archer == true)
                        {
                            startTimer += Time.deltaTime;
                            if (startTimer >= TimeBetweenAttacks)
                            {
                                startTimer = 0f;
                                StartCoroutine(AttackingArrow());
                            }
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

    IEnumerator AttackingSword()
    {
        EnemSwordWeapon.SetActive(true);
        yield return new WaitForSeconds(swordactive);
        EnemSwordWeapon.SetActive(false);
    }

    IEnumerator AttackingArrow()
    {
            yield return new WaitForSeconds(swordactive);
            Instantiate(Arrows, ShootingPoint.transform.position, Quaternion.identity);
            
    }

    IEnumerator Stunt()
    {
        nav.speed = stuntSpeed;
        yield return new WaitForSeconds(stuntTime);
        nav.speed = speed;
    }
    

}

