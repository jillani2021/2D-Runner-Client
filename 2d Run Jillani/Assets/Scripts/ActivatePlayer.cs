using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayer : MonoBehaviour {

	public GameObject[] Players;
	int mIndex;
	// Use this for initialization
	void Start () {

		mIndex = PlayerPrefs.GetInt ("Player", 0);
		Players[mIndex].gameObject.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
