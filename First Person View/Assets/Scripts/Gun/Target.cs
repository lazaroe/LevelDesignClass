using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject Dummy;
    public Transform target;
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            Dummy.SetActive(true);
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        Dummy.transform.position = target.transform.position;
    }
    
}
