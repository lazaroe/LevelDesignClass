using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class HomingMissle3D : MonoBehaviour {

	public Transform rocketTarget;
	public Rigidbody rocketRigidbody;
	public float turnR;
	public float rocketVelocity;
	public GameObject ExplosionEffect;
	public float explosionEffectTime = 1;
	public float DestroyTime = 4;

	void Start()
	{
		rocketTarget = GameObject.FindWithTag("Player").transform;
		transform.LookAt(rocketTarget.transform);
		rocketRigidbody = this.GetComponent<Rigidbody>();
	}
	

	private void FixedUpdate()
	{
		if (rocketTarget == null)
		{
			Destroy(gameObject); //How do I prevent it from giving me an error?
		}
		
		LookAtPlayer();
		
		rocketRigidbody.velocity = transform.forward * rocketVelocity;
		Destroy (gameObject, DestroyTime);
	}
	void OnCollisionEnter(Collision collision)
    {
	    if (collision.gameObject.tag == "Shield")
	    {
		    rocketVelocity = -3f;
		    rocketRigidbody.useGravity = true; //This is for when the missiles hit the shield

	    }
	    
	    else
	    {
		    
		    GameObject clone = (GameObject) Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
		    Destroy(clone, explosionEffectTime);
		    Destroy(gameObject);
	    }
    }

	public void LookAtPlayer()
	{
		var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);
		rocketRigidbody.MoveRotation (Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turnR));
	}
	
}
