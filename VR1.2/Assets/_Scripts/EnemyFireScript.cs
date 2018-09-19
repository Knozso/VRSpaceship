using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireScript : MonoBehaviour {

	public Rigidbody lazer;
	public float enemyFireRate = 0.2f;
	public bool canFire = false;
	bool waitActive = false;
	bool timeDone = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canFire && timeDone) {
			Fire ();
			timeDone = false;
			StartCoroutine(Wait());
		}
	}

	void Fire(){
		Rigidbody lazerClone = Instantiate(lazer, transform.position + transform.right * 4 + transform.forward * 10, Quaternion.LookRotation(transform.forward, Vector3.up));
		MovingScript a = lazerClone.GetComponent<MovingScript>();
		a.SetDirection(transform.forward);
	}

	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (enemyFireRate);
		waitActive = false;
		timeDone = true;
	}
}
