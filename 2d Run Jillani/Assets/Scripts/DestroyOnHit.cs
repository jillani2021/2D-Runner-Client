using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
//		Debug.Log ("Dest");
        Destroy(other.gameObject);

    }
}
