using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowScoreAndCoins : MonoBehaviour {

	public Text txtBestScore;
	public Text score;
	public Text coins;
	public Text TextForLastDistance;

	// Use this for initialization
	void Start () {

		txtBestScore.text  = PlayerPrefs.GetFloat("BestScore", 0).ToString("F0");
		score.text         = TextForLastDistance.text;
		coins.text         = PlayerPrefs.GetInt ("coin", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
