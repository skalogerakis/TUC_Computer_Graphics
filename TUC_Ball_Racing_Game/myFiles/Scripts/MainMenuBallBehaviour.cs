using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBallBehaviour : MonoBehaviour {

	void Update (){
		transform.Rotate(0.1f, 0.1f ,0.1f, Space.World);
	}
}
