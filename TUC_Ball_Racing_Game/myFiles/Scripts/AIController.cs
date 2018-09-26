using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	private GameObject go;
	private Rigidbody rb;
	private float force = 30.0f;
	public float sforce = 22.0f;

	void FixedUpdate(){
		rb = gameObject.GetComponent<Rigidbody>();
		rb.inertiaTensorRotation = Quaternion.identity;
	}

	void Update(){

		Vector3 target = new Vector3(0,0,100000000);

		Vector3 dir = (target - transform.position).normalized;
         RaycastHit hit = new RaycastHit();
         if(Physics.Raycast(transform.position, transform.forward, out hit,5.0f))
         {
             if (hit.transform != transform)
             {Debug.DrawLine(transform.position, hit.point, Color.blue);
                 dir += hit.normal * force;
             }
         }
         Vector3 leftR = transform.position;
         Vector3 rightR = transform.position;

         leftR.x -= 1;
         rightR.x += 1;

         if(Physics.Raycast(leftR, transform.forward, out hit,5.0f))
         {
             if (hit.transform != transform)
             {Debug.DrawLine(leftR, hit.point, Color.red);
                 dir += hit.normal * force;
             }
         }

         if(Physics.Raycast(rightR, transform.forward, out hit,5.0f))
         {
             if (hit.transform != transform)
             {Debug.DrawLine(rightR, hit.point, Color.yellow);
                 dir += hit.normal * force;
             }

         }

         Quaternion rot = Quaternion.LookRotation(dir);
         transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
         transform.position += transform.forward*sforce*Time.deltaTime;
	}

}
