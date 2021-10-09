using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour {

	public GameObject[] powerUps;

	// Use this for initialization
	void Start () {

		Invoke ("PowerUps", Random.Range (3, 4));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void PowerUps(){
	
		int rand = Random.Range (0, 2);

		GameObject  newPower =   Instantiate (powerUps[rand],transform.position, Quaternion.identity);  
		newPower.transform.position = new Vector3 (newPower.transform.position.x, Random.Range (-3f, 3f), newPower.transform.position.z);
		Invoke ("PowerUps", Random.Range (10,15));

	
	}
}
