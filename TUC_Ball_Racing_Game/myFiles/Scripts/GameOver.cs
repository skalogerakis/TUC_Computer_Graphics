using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	//static so that we cannot change it
	public static bool GameIsPaused = false;

	public string sceneName;

	public GameObject GameOverMenuUI;


	void OnCollisionEnter (Collision collisionInfo)
	{
		// We check if the object we collided with has a tag called "Obstacle".
		if (collisionInfo.collider.tag == "Obstacle")
		{
			Pause();
		}
	}

	//freeze time ingame and change GameIsPaused to true
	public void Pause(){
		GameOverMenuUI.SetActive(true);
		Time.timeScale =1.0f;
		GameIsPaused = true;
	}

	public void LoadMenu(){
			Time.timeScale = 1f;
			SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame(){
			Application.Quit();
	}

	//we insert in each scene different name
	public void Restart(){
		Time.timeScale = 1f;
		GameIsPaused = true;
		SceneManager.LoadScene(sceneName);
	}

	public void HoverSound(){
		FindObjectOfType<AudioManager>().PlaysOneShot("Hover");
	}

	public void ClickSound(){
		FindObjectOfType<AudioManager>().PlaysOneShot("Click");
	}
}
