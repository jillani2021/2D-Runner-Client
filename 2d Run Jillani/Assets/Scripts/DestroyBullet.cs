using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public AudioSource Blast;
    public Animator enemyAnimator;

    // Use this for initialization
    private void Start()
    {
        Blast = GameObject.Find("BlastSound").GetComponent<AudioSource>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)

    {
        //		Destroy (gameObject);

        if (col.gameObject.tag == "hurdle" && !BunnyController.isSpeedyArrows)
        {
            Destroy(gameObject);
            Debug.Log("Blasssssst");

            col.gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            if (col.gameObject.name != "Bomb(Clone)")
            {
                GameObject.Find("Canvas").GetComponent<KilledEnemyCounter>().UpdateKilledEnemyCount();
                col.gameObject.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = false;
                col.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                enemyAnimator = col.gameObject.GetComponent<Animator>();
                Blast.Play();
                enemyAnimator.SetTrigger("Die");
                Destroy(col.gameObject);
            }
            else
            {
                // col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(col.gameObject);
            }
        }
    }
}