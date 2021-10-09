using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroryBySheild : MonoBehaviour
{
    private AudioSource blastsfx;

    // Use this for initialization
    private void Start()
    {
        blastsfx = GameObject.Find("BlastSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)

    {
        //		Destroy (gameObject);

        if (col.gameObject.tag == "hurdle" && gameObject.tag == "bullet"/* || gameObject.tag == "SpeedyArrows"*/)

        {
            CameraShake.isShake = true;
            blastsfx.Play();
            col.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            //col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Canvas").GetComponent<KilledEnemyCounter>().UpdateKilledEnemyCount();

            col.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            col.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }
}