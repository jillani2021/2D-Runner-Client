using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMoveArrows : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "SpeedyArrows")
        {
            CameraShake.isShake = true;
          //    blastsfx.Play();
        }
    }
}
