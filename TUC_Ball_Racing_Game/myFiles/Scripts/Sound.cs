using UnityEngine.Audio;
using UnityEngine;

//custom class in order to appear we must declare as serializable
[System.Serializable]
public class Sound {

	public string name;

	//reference to audio clip
		public AudioClip clip;

		//we add slidders to make it easier for user to use
		[Range(0f, 1.5f)]
		public float volume;

		[Range(.1f, 3f)]
		public float pitch;

		//with the following property the public variable cannot be accessed
		//from editor but is can be used as a public variable
		[HideInInspector]
		public AudioSource source;

		public bool loop;
}
