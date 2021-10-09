using UnityEngine;
using System.Collections;

public class FloorSpawner : MonoBehaviour {

    
    public Transform[] prefabToSpawn;

	// Use this for initialization
	void Start () {
		BunnyController.isGameOver = false;
		UpperGround ();
	
	}

	void UpperGround () {
		if (BunnyController.isGameOver == false) {
			Instantiate (prefabToSpawn [0], transform.position, Quaternion.identity);  
			Invoke ("UpperGround", Random.Range (3.0f, 7.0f));

		}
	}


}