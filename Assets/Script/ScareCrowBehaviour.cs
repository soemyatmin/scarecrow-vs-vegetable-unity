using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrowBehaviour : MonoBehaviour {

	Animator anim;
	Movement mov;

	public float eatInterval = 1f;
	float eatTemp;
	SpriteRenderer render;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		mov = GetComponent<Movement> ();
		render = GetComponent<SpriteRenderer> ();
		eatTemp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//render.color = new Color (200, 30, 0);
		if (tempStunTime > Time.time) {
			anim.SetFloat ("WalkSpeed", 0);
			anim.SetFloat ("EatSpeed", 0);
			mov.x = 0;
			render.color = new Color (200.0f/255.0f, 30.0f/255.0f, 0);
		} else{
			if (tempIceyTime < Time.time) {
				anim.SetFloat ("WalkSpeed", 1f);
				anim.SetFloat ("EatSpeed", 1f);
				mov.x = -1;
				eatInterval = 1;
				render.color = Color.white;

			} else {
				anim.SetFloat ("WalkSpeed", 0.5f);
				anim.SetFloat ("EatSpeed", 0.5f);
				mov.x = -0.5f;
				eatInterval = 2;
				//render.color = Color.blue;
				render.color = new Color (50.0f/255.0f, 50.0f/255.0f, 180.0f/255.0f);

			}

			RaycastHit2D[] hit2d = Physics2D.RaycastAll (transform.position, Vector2.left,
				GetComponent<BoxCollider2D> ().size.x/2 + 0.1f);
			foreach (RaycastHit2D ele in hit2d) {
				if (ele.collider.tag == "vegetable") {
					anim.SetBool("isEating",true);
					mov.x = 0;
					Eating (ele.collider.gameObject);
				} else {
					anim.SetBool("isEating",false);
				}
			}
		}
	}

	public float iceyInterval = 3;
	float tempIceyTime;
	public void icey(){
		tempIceyTime = Time.time + iceyInterval;
	}

	public float stunInterval = 3;
	public float stunPercentage = 25;
	float tempStunTime;
	public void stun(){
		if (Random.Range (0, 100) < stunPercentage ) {
			tempStunTime = Time.time + stunInterval;	
		}

	}

	void Eating(GameObject eatenObj){
		if(eatTemp < Time.time){
			eatenObj.GetComponent<Health> ().hit (1);
			eatTemp = Time.time + eatInterval;
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Ray ray = new Ray (transform.position, Vector2.left);
		Gizmos.DrawRay(ray);
	}
}
