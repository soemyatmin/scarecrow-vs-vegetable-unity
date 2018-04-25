using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject[] SpawnPositions;
	public GameObject enemy;
	public float spawnInterval = 1; 
	public int Money;
	GameObject tempPlant;
	public Text moneyTxt;
	bool isDead=false;
	IEnumerator Start () {
		Money = 100;moneyTxt.text = Money + "";
		deadStatus.SetActive (false);
		while (!isDead) {
			Instantiate (enemy, SpawnPositions [Random.Range(0,SpawnPositions.Length)].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (spawnInterval);
		}
	}

	void Update () {
		if (!isDead) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D[] hit2D = Physics2D.RaycastAll (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				foreach (RaycastHit2D ele in hit2D) {
					if (ele.collider.tag == "gold") {
						Money += 10;
						moneyTxt.text = Money + "";
						Destroy (ele.collider.gameObject);
					}
					if (tempPlant) {
						if (ele.collider.tag == "platform" && ele.collider.transform.childCount == 0) {
							GameObject plantedPlant = Instantiate (tempPlant, ele.collider.transform.position, Quaternion.identity) as GameObject;
							plantedPlant.transform.SetParent (ele.collider.transform);
							Money -= plantedPlant.GetComponent<Health> ().price;
							moneyTxt.text = Money + "";
							tempPlant = null;
						}
					}
				}
			}

			if (Input.GetMouseButtonDown (1)) {
				if (tempPlant) {
					Money += tempPlant.GetComponent<Health> ().price;
					moneyTxt.text = Money + "";
					tempPlant = null;
				}
			}
		}
	}

	public void AssignTempGO(GameObject plant){
		if(Money >= plant.GetComponent<Health>().price ){
			tempPlant = plant;
		}
	}

	public GameObject deadStatus;
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "scareCrow"){
			isDead = true;
			deadStatus.SetActive (true);
		}
	}
}
