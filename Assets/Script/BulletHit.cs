using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {
	
	public float damage = 3.0f;
	public bool isIced = false;
	public bool isStun = false;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "scareCrow" ) {
			other.GetComponent<Health> ().hit (damage);
			if (isIced) {
				other.GetComponent<ScareCrowBehaviour> ().icey();
			}
			if (isStun) {
				other.GetComponent<ScareCrowBehaviour> ().stun();
			}
			Destroy (gameObject);
		} 

	}
}
