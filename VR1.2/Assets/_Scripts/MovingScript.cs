using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour {

    private Vector3 normalizeDirection;
    private Vector3 target;
	public float destructionTime = 1.0f;
    public float speed = 10f;

    public void SetDirection( Vector3 targ )
    {
        target = targ;
        normalizeDirection = (target).normalized;
    }

    void Update()
    {
        transform.position += normalizeDirection * speed * Time.deltaTime;
		Destroy (gameObject, destructionTime);
    }
}
