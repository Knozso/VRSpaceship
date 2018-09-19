using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour {

    public Rigidbody lazer;
    private bool secondShot = true;
	public void Start()
	{
		secondShot = true;
	}
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
			Fire();
        }
		if (Input.GetKey("f7"))
		{
			Fire();
		}

    }

    public void Fire()
    {
        if (secondShot)
        {
			Rigidbody lazerClone = Instantiate(lazer, transform.position + transform.right * 4 + transform.forward * 10, Quaternion.LookRotation(transform.forward, Vector3.up));
            MovingScript a = lazerClone.GetComponent<MovingScript>();
            a.SetDirection(transform.forward);
            secondShot = false;
        }
        else
        {
			Rigidbody lazerClone = Instantiate(lazer, transform.position + transform.right * 8 + transform.forward * 10, Quaternion.LookRotation(transform.forward, Vector3.up));
            MovingScript a = lazerClone.GetComponent<MovingScript>();
            a.SetDirection(transform.forward);
            secondShot = true;
        }
    }
}
