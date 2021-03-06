﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Camera MainCamera;
	public GameObject bounds;
    public float rotateTowardsSpeed;
    public float flightSpeed;
    public float notMovingAngle;
	public bool turningAround = false;
	bool waitActive = false;

	// Update is called once per frame
	void Update () {
		if (!turningAround) {
			Move ();
		}
		else {
			evade ();
		}
    }

    void Move()
    {
        transform.position += transform.forward * flightSpeed;
		if (Vector3.Angle(transform.forward, MainCamera.transform.forward) > notMovingAngle)
        {	
			if (Vector3.Angle (transform.forward, Vector3.up) < 10.0f) {
				transform.rotation = Quaternion.LookRotation (Vector3.RotateTowards (transform.forward, -MainCamera.transform.up, rotateTowardsSpeed * Time.deltaTime, 0.0f));
			}
			else if (Vector3.Angle (transform.forward, Vector3.down) < 10.0f) {
				transform.rotation = Quaternion.LookRotation (Vector3.RotateTowards (transform.forward, MainCamera.transform.up, rotateTowardsSpeed * Time.deltaTime, 0.0f));
			}
			else {
				transform.rotation = Quaternion.LookRotation (Vector3.RotateTowards (transform.forward, MainCamera.transform.forward, rotateTowardsSpeed * Time.deltaTime, 0.0f));
			}
			//transform.eulerAngles = Vector3.RotateTowards(transform.forward, MainCamera.transform.forward, rotateTowardsSpeed * Time.deltaTime, 0.0f);
        }
		//transform.RotateAround(Vector3.zero, transform.forward, 10 * Time.deltaTime);
    }

	void evade(){
		if(transform.position.y > bounds.gameObject.GetComponent<BoxCollider>().size.y/2) {
			dive ();
		} else if (transform.position.y < -bounds.gameObject.GetComponent<BoxCollider>().size.y/2) {
			goUp ();
		} else {
			turnAround ();
		}
	}

	public void turnAround(){
		Vector3 targetAngles = transform.eulerAngles + 180f * Vector3.up; // what the new angles should be
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 2 * Time.deltaTime); 
		StartCoroutine(Wait());
	}

	public void dive(){
		Vector3 targetAngles = transform.eulerAngles + 90f * Vector3.right; // what the new angles should be
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 2 * Time.deltaTime); 
		StartCoroutine(Wait());
	}

	public void goUp(){
		Vector3 targetAngles = transform.eulerAngles - 90f * Vector3.right; // what the new angles should be
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 2 * Time.deltaTime); 
		StartCoroutine(Wait());
	}

	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (0.5f);
		waitActive = false;
		turningAround = false;
	}
}
