using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	private int maxHealth;
	public int health = 10;

	public TextMesh healthText;
	public TextMesh hitText;

	bool waitActive = false;


	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag.Equals("Lazer")){
			Debug.Log ("HIT!!!");
			health --;
			healthText.text = "HP: " + health + "/" + maxHealth;
			hitText.color = Color.red;
			hitText.text = "YOU HAVE BEEN HIT";
			StartCoroutine (Wait());
		}	
	}


	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (1.0f);
		waitActive = false;
		hitText.text = " ";
	}

	// Use this for initialization
	void Start () {
		maxHealth = health;
		healthText.text = "HP: " + health + "/" + maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Debug.Log ("GAME OVER");

		}
	}
}
