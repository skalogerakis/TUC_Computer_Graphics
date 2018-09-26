using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour {

	private GameObject[] gos;
	public Transform player;
	private int Count;
	private int position;
	private Text positionText;
	//private Transform opps;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		positionText = gameObject.GetComponent<Text>();
		Count = 0;
		gos = GameObject.FindGameObjectsWithTag ("AI");

		foreach(GameObject go in gos){
			//opps = go.transform.position.z;
			float diff = go.transform.position.z - player.transform.position.z;
			if(diff < 0){
				Count++;
			}
		}
		position = gos.Length - Count +1;
		if(position == 1){
			positionText.text = "1st";
		}else if( position == 2){
			positionText.text = "2nd";
		}else if( position == 3){
			positionText.text = "3rd";
		}
		else{
			positionText.text = (position+"th").ToString();
		}
		Count = 0;
	}
}
