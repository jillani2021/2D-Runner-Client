using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardsChicken : MonoBehaviour {

	// Use this for initialization
	public Vector2 aPosition1 = new Vector2(3,3);
	Animator anim;

	void Start ()
	{
		anim = transform.GetComponent<Animator> () as Animator;
		anim.SetInteger ("enstate", 0);
	}


	void Update () 
	{
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, 5 * Time.deltaTime);
		if (transform.position.x >= aPosition1.x) {
			anim.SetInteger ("enstate", 1);
		}
	   
	}
	

}
