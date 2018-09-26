using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement pmovement;     // A reference to our PlayerMovement script
	public GameObject canvas;
	public GameObject messageBox;
	public GameObject pickupEffect;
	public float multiplier = 2.0f;
	public float duration = 4f;
	private bool coRun =false;
	public bool destr = false;
	GameOver go;
	private Text txt;

	// This function runs when we hit another object.
	// We get information about the collision and call it "collisionInfo".

	void Start(){
		messageBox.SetActive(false);
	}
	void OnCollisionEnter (Collision collisionInfo)
	{
		// We check if the object we collided with has a tag called "Obstacle".
		if (collisionInfo.collider.tag == "Obstacle")
		{
			pmovement.enabled = false;   // Disable the players movement.
			 canvas = GameObject.FindGameObjectWithTag("GO");
			 go = canvas.GetComponent<GameOver>();
				go.Pause();
				FindObjectOfType<AudioManager>().Pause("Gameplay");
				FindObjectOfType<AudioManager>().Play("GameOver");
			}

	}

	void OnTriggerEnter(Collider other) {

         if (other.tag == "Powerup" && coRun == false) {
					 FindObjectOfType<AudioManager>().PlaysOneShot("PowerUp");
					 //Debug.Log(other);
					 Scene scene = SceneManager.GetActiveScene();
					 string sname = scene.name.ToString();
					 //Debug.Log(sname);
					 int rnum;
					 // if(sname == "EndlessFin2"){
						//  rnum = Random.Range(0,3);
						//  rnum = 3;
					 // }else{
						 rnum = Random.Range(0,2);
					 //}
						messageBox.SetActive(true);
						txt = messageBox.GetComponent<Text>();
						coRun = true;
						if(rnum == 0){
								txt.text = "Speed Boost";
							StartCoroutine(PickupSpeed());
						}else if(rnum == 1){
							txt.text = "Invisible";
							StartCoroutine(PickupInvisible());
						}else{
							txt.text = "Destruction";
							StartCoroutine(PickupDestroy());
						}
         }
     }

	IEnumerator PickupSpeed(){

			//spawn effect on current position
				Instantiate(pickupEffect, transform.position, transform.rotation);

				pmovement.forwardForce *= multiplier;


				yield return new WaitForSeconds(duration);
				//return back to normal
				pmovement.forwardForce /= multiplier;
				messageBox.SetActive(false);
				coRun = false;

	}

	IEnumerator PickupInvisible(){
			Instantiate(pickupEffect, transform.position, transform.rotation);
				Collider col;
				col = gameObject.GetComponent<Collider>();

				//disable all colliders for player for given durations
				col.enabled = false;
				GetComponent<Collider>().enabled = false;
				yield return new WaitForSeconds(duration);
				//return back to normal
				col.enabled = true;
				messageBox.SetActive(false);
				coRun = false;


	}

	IEnumerator PickupDestroy(){

			//spawn effect on current position
				Instantiate(pickupEffect, transform.position, transform.rotation);
				destr = true;
				yield return new WaitForSeconds(duration);
				messageBox.SetActive(false);
				destr = false;
				coRun = false;


	}

}
