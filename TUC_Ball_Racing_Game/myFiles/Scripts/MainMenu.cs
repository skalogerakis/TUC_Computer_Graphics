using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	//public string newGameScene;

	// Use this for initialization
	void Start () {
		FindObjectOfType<AudioManager>().Play("Menu");
	}

	// Update is called once per frame
	void Update () {
	}

	public void NewGame(){
		SceneManager.LoadScene("LevelSelect");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void SettingsGame(){
		SceneManager.LoadScene("SettingsMenu");
	}

	public void HoverSound(){
		FindObjectOfType<AudioManager>().PlaysOneShot("Hover");
	}

	public void ClickSound(){
		FindObjectOfType<AudioManager>().PlaysOneShot("Click");
	}

}
