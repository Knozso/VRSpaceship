using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingScript : MonoBehaviour {

    public float missileSpeed;
    private GameObject target;

	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3(0,0,speed) * Time.deltaTime, Space.World);
        if (target != null)
        {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, missileSpeed);
            transform.LookAt(target.transform);
        }
	}

    public void setTarget(GameObject go)
    {
        target = go;
    }
}
