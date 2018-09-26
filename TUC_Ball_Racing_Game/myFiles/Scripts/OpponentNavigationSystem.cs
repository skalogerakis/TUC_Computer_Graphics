using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentNavigationSystem : MonoBehaviour {

// 	// Use this for initialization
// private NavMeshSurface surface;
//
// 	private GameObject[] gos;
// 	NavMeshAgent agentf;
// 	GameObject nav;
// 	NavMeshSurface nm;
// 	OpponentController oc;
//
// 	void Start(){
// 		nav = GameObject.FindWithTag("Nav");
// 		//nm = nav.GetComponent<NavMeshSurface>();
// 		//agentf = nav.GetComponent<NavMeshAgent>();
// 		//nm.BuildNavMesh();
// 	}
//
// 	void OnTriggerEnter(Collider agent){
//
// 		if(agent.tag == "AI"){
// 			Debug.Log("Collision with AI");
// 			//GameObject nav = GameObject.FindWithTag("Nav");
// 		//	nm.BuildNavMesh();
// 		GameObject cs = agent.gameObject;
// 			cs.GetComponent<OpponentController>().TrigNav();
// 		// 	GameObject curObj = agent.transform.gameObject;
// 		// 	gos = GameObject.FindGameObjectsWithTag ("Destination");
// 		// 	GameObject mdist = gos[0];
// 		// 	Vector3 position = curObj.transform.position;
// 		// 	Vector3 iniMax =  gos[0].transform.position - position;
// 		// 	float distance = iniMax.sqrMagnitude;
// 		//
// 		// 	foreach(GameObject go in gos){
// 		// 		//Debug.Log(go.transform.position);
// 		// 		Vector3 diff = go.transform.position - position;
// 		// 		if(diff.z<0){
// 		// 			Debug.Log("return");
// 		// 			return;
// 		// 		}
// 		// 		float curDist = diff.sqrMagnitude;
// 		// 		if(curDist > distance){
// 		// 			mdist = go;
// 		// 			distance = curDist;
// 		// 		}
// 		// 	}
// 		// 	Debug.Log(distance);
// 		// 	Vector3 fdest = mdist.transform.position;
// 		//
// 		// 	agentf.SetDestination(fdest);
// 		 }
//
// 	}

}
