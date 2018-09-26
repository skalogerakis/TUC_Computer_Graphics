using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundManager : MonoBehaviour {

	public GameObject[] groundPrefabs;

	private Transform playerTransform;

	//where in z should we spawm the object
	private float spawnZ = 0.0f;

	//we need to learn the length of the object
	private float groundlength = 20.0f;

	//we need to know the number of ground on the screen
	private int amnGroundOnScreen = 25;

	//keep track of existing ground
	private List<GameObject> activeGround;

	//wait so that we don't destroy or create new objects too early or too soon
	private float safeZone = 30.0f;

	//keep track of prefab list index
	private int lastPrefabIndex = 0;



	// Use this for initialization
	void Start () {
		//initialize activeGround list
		activeGround = new List<GameObject>();

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		//we need to know how many times we spawn the ground
		for(int i = 0; i < amnGroundOnScreen ; i++){
			//first two grounds spawn ground without any obstacles
			if (i < 2){
				SpawnGround(0);
			}else{
				SpawnGround();
			}

		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//every time we cross a ground that we created we spawn a new one
		if(playerTransform.position.z - safeZone > (spawnZ - amnGroundOnScreen * groundlength)){
			SpawnGround();
			DeleteGround();
			DestroyAllObstacles();
			DestroyAllPowerUps();
			DestroyBoosts();
		}
	}



	private void SpawnGround(int prefabIndex = -1)
	{
		//to spawn everything under GroundManager
		GameObject go;

		//for the beginning case
		if(prefabIndex == -1){
			go = Instantiate (groundPrefabs[RandomPrefabIndex()]) as GameObject;
		}else{
			go = Instantiate (groundPrefabs[prefabIndex]) as GameObject;
		}

		go.transform.SetParent(transform);

		//move ground
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ +=groundlength;

		//every time we spawn a new ground we put it on the List
		activeGround.Add(go);
	}

	private void DeleteGround(){
		//we evert time destroy the first element and then we remove it from the list

		Destroy(activeGround[0]);
		activeGround.RemoveAt(0);

	}

	//used to destroy all grand children obstacles
	void DestroyAllObstacles()
 {
      GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Obstacle");
     for(var i = 0 ; i < gameObjects.Length ; i ++)
     {
			 if(playerTransform.position.z> gameObjects[i].transform.position.z){
				 Destroy(gameObjects[i]);
			 }

     }
 }

 void DestroyAllPowerUps()
{
		 GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Powerup");
		for(var i = 0 ; i < gameObjects.Length ; i ++)
		{
			if(playerTransform.position.z> gameObjects[i].transform.position.z){
				Destroy(gameObjects[i]);
			}

		}
}

void DestroyBoosts()
{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Boost");

	 for(var i = 0 ; i < gameObjects.Length ; i ++)
	 {
		 if(playerTransform.position.z> gameObjects[i].transform.position.z){
			 Destroy(gameObjects[i]);
		 }

	 }
}

// void DestroyDest()
// {
// 		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Destination");
// 		Transform opp = GameObject.FindGameObjectWithTag ("Player").transform;
// 	 for(var i = 0 ; i < gameObjects.Length ; i ++)
// 	 {
// 		 if(opp.position.z> gameObjects[i].transform.position.z){
// 			 Destroy(gameObjects[i]);
// 		 }
//
// 	 }
// }

	//random generete prefabs so that we cant get the same one twice
	private int RandomPrefabIndex(){
		if(groundPrefabs.Length <= 1)
			return 0;

		//to make sure that executes at least one time
		int randomIndex = lastPrefabIndex;
		while(randomIndex == lastPrefabIndex){
			randomIndex = Random.Range (0, groundPrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
