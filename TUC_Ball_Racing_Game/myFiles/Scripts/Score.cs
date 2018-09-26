using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//we update current score and highscore
public class Score : MonoBehaviour {
	//we need public variables to access from unity
	public Transform player;

	private Text scoreText;

	void Start(){

	}
	// Update is called once per frame
	void Update () {
		//score updates based on player position
		PlayerMovement movement;
		scoreText = gameObject.GetComponent<Text>();
		int posnumber = (int)player.position.z;
		scoreText.text = player.position.z.ToString("0");

		movement = player.GetComponent<PlayerMovement>();

		//PlayerPrefs is used to store data
		if(posnumber > PlayerPrefs.GetInt("HighScore",0) && movement.enabled == false){
			PlayerPrefs.SetInt("HighScore",posnumber);
		}


	}
}
