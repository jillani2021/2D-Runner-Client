using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveRight : MonoBehaviour {

	public float speed;
	public Image fade;
	float fadecount;
	// Use this for initialization
	void Start () {
		fadecount = fade.GetComponent<Image> ().color.a;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
		fadecount += 0.005f;


		Color TempColor = fade.GetComponent<Image> ().color;

		TempColor.a = fadecount;
		fade.GetComponent<Image> ().color = TempColor;


		if (fade.GetComponent<Image> ().color.a >= 0.9f) {
		
			Application.LoadLevel (3);
		}
	}
}
