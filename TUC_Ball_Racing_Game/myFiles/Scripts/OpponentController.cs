using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour {

	//reference to NavMeshAgent
	public NavMeshAgent agent;
	public NavMeshSurface nm;
	// void Start(){
	// 	agent = this.GetComponent<NavMeshAgent>();
	// 	if(agent == null){
	// 		Debug.LogError("The nav mesh component is not attached to "+ gameObject.name);
	// 	}
	// }
	// Update is called once per frame
	//public GameObject testObj;
	//private bool canHover = false;
	private GameObject[] gos;

	void Start(){
		nm.BuildNavMesh();
		//GameObject[] gos;

		gos = GameObject.FindGameObjectsWithTag("Destination");
		GameObject mdist = gos[0];
		Vector3 position = transform.position;
		Vector3 iniMax =  gos[0].transform.position - position;
		float distance = iniMax.sqrMagnitude;

		foreach(GameObject go in gos){
			//Debug.Log(go.transform.position);
			Vector3 diff = go.transform.position - position;
			if(diff.z<0){
				Debug.Log("return");
				continue;
			}
			float curDist = diff.sqrMagnitude;
			if(curDist > distance){
				mdist = go;
				distance = curDist;
			}
		}
		Debug.Log(distance);
		Vector3 fdest = mdist.transform.position;
		agent.SetDestination(fdest);
	}

	void Update () {
		nm.BuildNavMesh();
			// if(Input.GetMouseButtonDown(0)){
			// 	//retuens a ray going from camera through a screen point
			// 	Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			//
			// 	// Transform destination;
			// 	//
			// 	// GameObject[] gameObject = GameObject.FindGameObjectsWithTag ("Destination");
			//   RaycastHit hit;
			//
			// 	if( Physics.Raycast(ray, out hit))
			// 	{
			// 		agent.SetDestination(hit.point);
			// 	}


				// RaycastHit hit;
				// Ray targetFind = new Ray(transform.position, Vector3.forward);
				// //Debug.DrawRay(transform.position, Vector3.forward, Color.green);
				// Debug.Log("Target found1");
				// if(Physics.Raycast(targetFind, out hit)){
				// 	Debug.Log("Target found2 in " +hit.point);
				// 	if(hit.collider.tag == "Destination"){
				// 		Debug.Log("Target found3");
				// 		agent.SetDestination(hit.point);
				// 	}
				// }
				// //
				//  Vector3 targetVector = gameObject[0].transform.position;
				// //
				//  Ray ray = new Ray(transform.position, targetVector);
				// // //Ray ray = cam.ScreenPointToRay(targetVector);
				// // //shoot ray and keep it in ray variable
				// // //if we hit something the statement below is executed
				// // //if(Physics.Raycast(ray, out hit)){
				//  if(Physics.Raycast(ray,  out hit)){
				// // 	//move our agent to destination we want
				//  	agent.SetDestination(targetVector);
				//  }
			//}


	}
	public void TrigNav(){
		//nm.BuildNavMesh();
		gos = GameObject.FindGameObjectsWithTag("Destination");
		GameObject mdist = gos[0];
		Vector3 position = transform.position;
		Vector3 iniMax =  gos[0].transform.position - position;
		float distance = iniMax.sqrMagnitude;

		foreach(GameObject go in gos){
			//Debug.Log(go.transform.position);
			Vector3 diff = go.transform.position - position;
			if(diff.z<0){
				Debug.Log("return");
				continue;
			}
			float curDist = diff.sqrMagnitude;
			if(curDist > distance){
				mdist = go;
				distance = curDist;
			}
		}
		Debug.Log(distance);
		Vector3 fdest = mdist.transform.position;
		agent.SetDestination(fdest);
	}
}
