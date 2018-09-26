using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	//access to sound class and use its properties
	public Sound[] sounds;
	//Audio manager is responsible for all sounds
	// Use this for initialization

	public static AudioManager instance;

	void Start(){
	}

	//awake is executed before update
	void Awake () {

		//we need to have only one audio manager so we create an instance to check that
		if(instance == null){
			instance = this;
		// 	Debug.Log("Not Settings");
		// }else if (instance == null && flag){
		// 	instance = this;
		// 	DontDestroyOnLoad(gameObject);
		// 	Debug.Log("Settings");
		}else{
			Destroy(gameObject);
			return;
		}

		// //to work with different scenes
		// DontDestroyOnLoad(gameObject);
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;

		}
	}


	public void Play(string name)
	{
		//find a sound in sounds array where the name of the sound is equal to passed parameter
		//this can be accessed from using.System (lambda expression)
		Sound s = Array.Find(sounds, sound => sound.name == name);
		//case of a typo don't do anything
		if(s == null)
			return;
		s.source.Play();

	}

	public void Pause(string name)
	{
		//find a sound in sounds array where the name of the sound is equal to passed parameter
		//this can be accessed from using.System (lambda expression)
		Sound s = Array.Find(sounds, sound => sound.name == name);
		//case of a typo don't do anything
		if(s == null)
			return;
		s.source.Pause();

	}

	public void PlaysOneShot(string name)
	{
		//find a sound in sounds array where the name of the sound is equal to passed parameter
		//this can be accessed from using.System (lambda expression)
		Sound s = Array.Find(sounds, sound => sound.name == name);
		//case of a typo don't do anything
		if(s == null)
			return;
		s.source.PlayOneShot(s.source.clip);

	}
}
