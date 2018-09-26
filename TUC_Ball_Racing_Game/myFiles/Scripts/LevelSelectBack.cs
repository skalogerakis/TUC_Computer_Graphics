using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectBack : MonoBehaviour {

		//created an audioMixer to control via master the volume
		public AudioMixer audioMixer;

		public void BackGame(){
			SceneManager.LoadScene("MainMenu");
		}

		public void HoverSound(){
			FindObjectOfType<AudioManager>().PlaysOneShot("Hover");
		}

		public void ClickSound(){
			FindObjectOfType<AudioManager>().PlaysOneShot("Click");
		}

	}
