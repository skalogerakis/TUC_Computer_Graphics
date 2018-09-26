using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoins : MonoBehaviour {

	private Text txt;


	// Update is called once per frame
	void Update () {
		txt = gameObject.GetComponent<Text>();
		txt.text = PlayerPrefs.GetInt("Coin").ToString("0");

	}

}
