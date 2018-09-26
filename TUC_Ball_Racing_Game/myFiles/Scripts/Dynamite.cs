using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour {

	public float delay = 3f;
	public float radius = 5f;
	public float force = 300f;
	bool hasExploded = false;

	public GameObject explosionEffect;
	// Use this for initialization
	float countdown;

	void Start () {
		countdown = delay;
	}

	// Update is called once per frame
	void Update () {
		countdown -=Time.deltaTime;
		if(countdown <=0f && !hasExploded)
		{
			Explode();
			hasExploded = true;
		}
	}

	void Explode(){
		Instantiate(explosionEffect, transform.position, transform.rotation);

		//function that allows us to create a shpere that we want the objects to interact with
		//returns array
		Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position,radius);
		//in the first loop we destroy and in the second we apply forces
		foreach(Collider nearbyObject in collidersToDestroy)
		{
			//destroy in pieces
			Destructible des = nearbyObject.GetComponent<Destructible>();
			if(des != null){
				des.Destroy();
			}
		}

		Collider[] collidersToMove = Physics.OverlapSphere(transform.position,radius);

		foreach(Collider nearbyObject in collidersToMove)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if(rb != null)
			{
				//built in unity function
				rb.AddExplosionForce(force, transform.position, radius);
			}
		}

		Destroy(gameObject);
	}
}
