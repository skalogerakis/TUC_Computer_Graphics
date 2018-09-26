using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUp : MonoBehaviour {

  void Start(){
    transform.Rotate( 90, 0 , 0, Space.World);
  }

  void Update (){
   transform.Rotate( 0, 3 , 0, Space.World);
  }

}
