using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;	// A variable that stores a reference to our Player
	public Vector3 offset;		// A variable that allows us to offset the position (x, y, z)

	// Update is called once per frame
	void FixedUpdate () {
		// Set our position to the players position and offset it
		// By that way we parent camera to player movement
		transform.position = player.position + offset;
	}
}
