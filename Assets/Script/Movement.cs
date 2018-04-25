using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	Rigidbody2D rigi2;
	public float x, y;

	// Use this for initialization
	void Start () {
		rigi2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigi2.velocity = new Vector2 (x, y);
	}
}
