using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    public Material notLooking;
    public Material lookingAt;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material = notLooking;
    }
	
    public void watching()
    {
        GetComponent<Renderer>().material = lookingAt;
    }
    public void notWatching()
    {
        GetComponent<Renderer>().material = notLooking;
    }
}
