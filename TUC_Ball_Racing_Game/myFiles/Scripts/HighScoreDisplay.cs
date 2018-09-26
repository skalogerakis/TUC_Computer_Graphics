using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {

	private Text txt;
	// Use this for initialization
	void Start () {
		 txt = gameObject.GetComponent<Text>();
		 txt.text = PlayerPrefs.GetInt("HighScore",0).ToString("0");
	}

}
