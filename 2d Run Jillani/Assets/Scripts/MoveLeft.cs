using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

    public float speed = 10;
	public float IncInSpeed = 0.000002f;
	// Use this for initialization
	void Start () {
	 
		IncInSpeed = 0.000002f;

	}
	
	// Update is called once per frame
	void Update () {

		if (BunnyController.isGameOver == false) {
			speed = speed + IncInSpeed;
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}
}
