using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !BunnyController.isSheild && (!BunnyController.isSpeedyArrows))
        {
            CameraShake.isShake = true;

            // collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }
}