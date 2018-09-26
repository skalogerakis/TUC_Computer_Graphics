using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectInfo : MonoBehaviour {

	// Use this for initialization
	public string scene1;
	public string scene2;
	void Start () {
			FindObjectOfType<AudioManager>().Play("Selection");
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				//Select Level
				if(hit.transform.name == "Player1"){
					SceneManager.LoadScene(scene1);
				}else if(hit.transform.name == "Player3"){
					SceneManager.LoadScene(scene2);
				}
			}
		}
	}
}
