using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehaviour : MonoBehaviour {
	 private int coinC = 0;

	// //we need to refence to canvas so that we can count and keep track of total Coins
	 void Start(){

	 	coinC = PlayerPrefs.GetInt("Coin");
		transform.Rotate( 90, 0 , 0, Space.World);

	 }
	 //Executes once per fram used in that occasion to rotate coin
	 void Update (){
	 	transform.Rotate( 0, 3 , 0, Space.World);
	 }

	void OnTriggerEnter(Collider collider){
		switch(collider.gameObject.name){
			case "Player":
			{
				FindObjectOfType<AudioManager>().PlaysOneShot("Coin");
				coinC = PlayerPrefs.GetInt("Coin");
				coinC++;

				PlayerPrefs.SetInt("Coin",coinC);
				Destroy(this.gameObject);
				break;
			}
			default:
			{
				Destroy(this.gameObject);
				break;
			}
		}
	}
}
