using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour {

	public int enemieCount = 5;
	private int remainingEnemies;

	public TextMesh enemiesText;

	// Use this for initialization
	void Start () {
		remainingEnemies = enemieCount;
		enemiesText.text = "Remaining Enemies: " + remainingEnemies + "/" + enemieCount;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AnEnemyWasKilled(){
		remainingEnemies--;
		enemiesText.text = "Remaining Enemies: " + remainingEnemies + "/" + enemieCount;
	}
}
