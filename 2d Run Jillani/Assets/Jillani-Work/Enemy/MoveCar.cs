using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed*Time.deltaTime);
	}
}
