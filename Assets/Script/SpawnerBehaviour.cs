using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {

	public GameObject sunFlower;
	public float spawnInterval = 1; 

	IEnumerator Start () {
		yield return new WaitForSeconds (spawnInterval);
		while (true) {
			Instantiate (sunFlower, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (spawnInterval);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
