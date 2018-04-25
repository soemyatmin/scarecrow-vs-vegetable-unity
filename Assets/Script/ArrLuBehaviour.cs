using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrLuBehaviour : MonoBehaviour {

	Animator anim;
	Health h;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		h = GetComponent<Health> ();
	}

	void Update () {
		anim.SetFloat ("health", h.healthPercentage ());
	}
}
