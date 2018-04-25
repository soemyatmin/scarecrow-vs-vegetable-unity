using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float hitPointMax = 10 ;
	public float currentHitPoint;
	public int price;

	void Start () {
		currentHitPoint = hitPointMax;
	}

	public void hit(float damage){
		if (damage > currentHitPoint) {
			dead ();
		} else {
			// hit effect
			currentHitPoint -= damage;
		}
	}

	public float healthPercentage(){
		return currentHitPoint/hitPointMax;
	}

	void dead(){
		// perticle 
		// sound
		// other megic
		Destroy (gameObject);
	}
}
