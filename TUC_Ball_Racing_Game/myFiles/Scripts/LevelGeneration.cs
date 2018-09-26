using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {


	public Transform[] SpawnPoints;
	public GameObject[] objects;
	// Use this for initialization
	void Start () {
		int spawnIndex = Random.Range(0, SpawnPoints.Length);
		int objectIndex = Random.Range(0, objects.Length);
		Instantiate(objects[objectIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
	}

}
