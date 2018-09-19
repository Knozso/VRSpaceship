using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireColliderScript : MonoBehaviour {

	public GameObject cannon;

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag.Equals("Player")) {
			Debug.Log ("ENEMY FIRING");
			cannon.gameObject.GetComponent<EnemyFireScript> ().canFire = true;
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("ENEMY STOPPING");
		if(other.gameObject.tag.Equals("Player")){
			cannon.gameObject.GetComponent<EnemyFireScript>().canFire = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
