using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsColliderExit : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag.Equals ("Player")) {
			other.gameObject.transform.parent.GetComponent<PlayerMovement> ().turningAround = true;

		}
	}

	void Update (){
		
	}
}
