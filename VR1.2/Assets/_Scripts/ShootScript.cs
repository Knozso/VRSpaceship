using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour {

    public Rigidbody missile;
    public Transform radialProgress;
    public float timeTillShoot = 3f;

	public TextMesh rocketText;

	private int rocketCount;
	public int maxRocketCount = 3;

    private GameObject target;
    private bool canShoot = true;
    private float selectTime = 0f;

    public void Start()
    {
        radialProgress.GetComponent<Image>().fillAmount = selectTime / timeTillShoot;
        canShoot = true;
		rocketCount = maxRocketCount;

		rocketText.text = "Rockets: " + rocketCount + "/" + maxRocketCount;
        //Shoot();
    }

    public void Update()
    {
		if(rocketCount >0){
			if (canShoot) {
				selectTime += Time.deltaTime;
				radialProgress.GetComponent<Image> ().fillAmount = selectTime / timeTillShoot;

				if (selectTime >= timeTillShoot) {
					Shoot ();
				}
			}
        }
    }

    public void setTarget(GameObject targ)
    {
        target = targ;
    }

    public void Shoot()
    {        
        Rigidbody missileClone = Instantiate(missile, transform.position + new Vector3(0, 0, 1), new Quaternion(0, 0, 0, 0));
        TargetingScript a = missileClone.GetComponent<TargetingScript>();
        a.setTarget(target);
        canShoot = false;
		rocketCount--;
		rocketText.text = "Rockets: " + rocketCount + "/" + maxRocketCount;
    }

    public void Reset()
    {
        selectTime = 0f;
        radialProgress.GetComponent<Image>().fillAmount = selectTime / timeTillShoot;
        canShoot = true;
    }

}
