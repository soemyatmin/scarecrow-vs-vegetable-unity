using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletSpawnPoint;

	public float interval = 2;
	float tempTime = 0;

	void Update () {
		RaycastHit2D[] hit2d = Physics2D.RaycastAll (transform.position, -Vector2.left,15f);
		foreach (RaycastHit2D ele in hit2d) {
			if (ele.collider.tag == "scareCrow") {
				shotingAnimation ();
			} 
		}
	}

	public virtual void shoting(){
		if(tempTime < Time.time){
			Instantiate (bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
			tempTime = +Time.time + interval;
		}
	}

	public  virtual void shotingAnimation(){
		shoting();
	}
}
