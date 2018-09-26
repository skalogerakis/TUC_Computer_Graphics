using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	private Rigidbody rb;

	public float speed = 10f;
	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force

	//We use "Fixed"Update to interact with physics.
	void Update ()
	{

		// Add a forward force
		rb.AddForce(0, 0.0f, forwardForce * Time.deltaTime);
		//transform.Rotate(Vector3(15,30,45) * Time.deltaTime);

		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))	// If the player is pressing the "d" or right arrow key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))  // If the player is pressing the "a" or left arrow key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
}
		void Start(){
			rb = GetComponent<Rigidbody>();
			FindObjectOfType<AudioManager>().Play("Gameplay");
		}


}
