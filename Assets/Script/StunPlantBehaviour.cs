using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlantBehaviour : PlantBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public override void shotingAnimation(){
		anim.SetTrigger ("shot");
	}
}
