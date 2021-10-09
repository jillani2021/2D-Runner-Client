using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !BunnyController.isSpeedyArrows /*|| collision.gameObject.tag == "Bullet"*/)
        {
            Debug.Log("Blasssssst");
            //  Blast.Play();
            //  col.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            //col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            collision.gameObject.GetComponent<Animator>().SetBool("bunnyHurt", true);
            collision.gameObject.GetComponent<BunnyController>().GameOver(collision);

            //  BunnyController.instance.GameOver(collision);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}