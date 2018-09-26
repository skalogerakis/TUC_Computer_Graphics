using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;
	public GameObject explosionEffect;
	public float radius = 5f;
	public float force = 300f;

	//public PlayerCollision coll;

	// If the player clicks on the object
	public void Destroy ()
	{
		// Spawn a shattered object
		Instantiate(destroyedVersion, transform.position, transform.rotation);

		// Remove the current object
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Player"){
			PlayerCollision coll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
			if(coll.destr != true){
				Instantiate(destroyedVersion, transform.position, transform.rotation);
			}else{
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
			}

			Instantiate(destroyedVersion, transform.position, transform.rotation);
			// Remove the current object
			Destroy(gameObject);
		}

	}
}
