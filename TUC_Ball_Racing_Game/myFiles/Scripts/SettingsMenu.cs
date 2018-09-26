using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

	//created an audioMixer to control via master the volume
	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;

	//public string newGameScene;

	Resolution[] resolutions;

	void Start(){
		//DontDestroyOnLoad(gameObject);
		FindObjectOfType<AudioManager>().Play("Settings");
		//every pc has different resolutions so need to find every time all resolutions available
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		//we can't simply add an option
		//we must convert it in string
		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for(int i = 0; i < resolutions.Length; i++){
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);

			//there is no function that compares all together so we need to check differently height and width
			if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		// to get the new resolution
		resolutionDropdown.RefreshShownValue();

	}

	public void SetResolution(int resolutionIndex){
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	//all of these are accessed from unity menu and can see the changes dynamically happen
	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetVolume(float mus)
	{
		Debug.Log(mus);
		audioMixer.SetFloat("volume", mus);
	}

	public void SetFullscreen(bool isFullscreen){
		Screen.fullScreen = isFullscreen;
	}

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
