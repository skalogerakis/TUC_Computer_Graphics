using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	//static so that we cannot change it
	public static bool GameIsPaused = false;

	public string sceneName;

	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		//press esc to trigger pause menu
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameIsPaused)
			{
				Resume();
			}else if(!GameIsPaused){
				Pause();
			}
		}
	}

	//reverse than Pause method
	public void Resume(){
		pauseMenuUI.SetActive(false);
		//normal game speed
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	//freeze time ingame and change GameIsPaused to true
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu(){
			Time.timeScale = 1f;
			SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame(){
			Application.Quit();
	}

	public void HoverSound(){
		FindObjectOfType<AudioManager>().PlaysOneShot("Hover");
	}

	public void ClickSound(){
		FindObjectOfType<AudioManager>().PlaysOneShot("Click");
	}

	//we insert in each scene different name
	public void Restart(){
		GameIsPaused = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene(sceneName);
	}
}
