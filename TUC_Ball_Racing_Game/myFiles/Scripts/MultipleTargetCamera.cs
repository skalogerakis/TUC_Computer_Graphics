using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour {

	public List<Transform> targets;

	public Vector3 offset;

	private Vector3 velocity;
	public float smoothTime = .5f;

	public float minZoom = 40f;
	public float maxZoom = 10f;
	public float zoomLimiter = 50f;
	private Camera cam;

	void Start(){
		cam = GetComponent<Camera>();
	}
	//late update suitable for camera movement
	void LateUpdate(){
		//case we don't have a player so that we won't get error
		if(targets.Count == 0){
			return;
		}
		Move();
		Zoom();
	}

	void Zoom(){
		//Lerp linearly interpolates between two values depending on a third value;
		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/zoomLimiter);
		//to zoom in or out and find suitable camera position we access through script fieldOfView(camera element)
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);

	}

	void Move(){
		//in each frame we find the center of all shown items
		Vector3 centerPoint = GetCenterPoint();

		Vector3 newPosition = centerPoint + offset;

		transform.position = newPosition;

		//smoothDamp is to smooth the movement of our camera in case we need it

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
	}

	//this function returns the width of the bound box that we want our camera to zoom out
	//finds the players with the most distance
	float GetGreatestDistance(){
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for(int i =0 ; i < targets.Count; i++){
			bounds.Encapsulate(targets[i].position);
		}

		return bounds.size.x;
	}

	Vector3 GetCenterPoint(){
		//in case we have only one player
		if(targets.Count == 1){
			return targets[0].position;
		}

		//bounds is a function that makes a square and can easily spot the center of the given objects
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for(int i = 0; i<targets.Count; i++){
			bounds.Encapsulate(targets[i].position);
		}
		return bounds.center;
	}
}
