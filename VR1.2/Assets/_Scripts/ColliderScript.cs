using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {
	private bool can = true;

	public int health = 10;
	public GameObject fireExplosion;
	public GameObject fusionExplosion;

	public GameObject enemyCounter;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals ("Torpedo")) {
			if (can) {
				FusionExplosion ();
				can = false;
			}
		} 
		else {
			health--;
			Debug.Log (health);
			if (other.gameObject.tag.Equals ("Lazer")) {
				Destroy (other.gameObject);
			}
			else if(other.gameObject.tag.Equals("Player")){
				other.gameObject.transform.parent.GetComponent<PlayerMovement> ().turningAround = true;
			}
		}
	}

	void Update(){

		if (can) {
			if (health <= 0) {
				FireExplosion ();
				can = false;
			}
		}
	}

	public void FireExplosion(){
		var exp = fireExplosion.GetComponent<ParticleSystem>();
		exp.Play();
		StartCoroutine(TemporarilyDeactivate(exp.duration-0.1f));
		this.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer> ().enabled = false;

		enemyCounter.gameObject.GetComponent<EnemyCounter> ().AnEnemyWasKilled ();

		Destroy (this.gameObject.transform.parent.gameObject, 2f);
	}

	private IEnumerator TemporarilyDeactivate(float duration) {
		yield return new WaitForSeconds(duration);
	}

	public void FusionExplosion(){
		var exp = fusionExplosion.GetComponent<ParticleSystem> ();
		exp.Play ();
		this.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer> ().enabled = false;

		enemyCounter.gameObject.GetComponent<EnemyCounter> ().AnEnemyWasKilled ();

		Destroy(this.gameObject.transform.parent.gameObject, exp.duration);
	}
}
