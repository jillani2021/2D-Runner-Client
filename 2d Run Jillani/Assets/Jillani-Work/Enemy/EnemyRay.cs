using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    private RaycastHit2D hit2d;
    public Animator enemyAnimator;
    private bool isRayHitWithPlayer;
    public static bool enemyStartShooting;
    public Rigidbody2D _enemyBullet;
    private Rigidbody2D bulletInstance;
    public GameObject bulletPos;

    // Use this for initialization
    private void Start()
    {
        enemyAnimator.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        enemyAnimator.SetTrigger("Walk");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && BunnyController.isSpeedyArrows == false)
        {
            enemyAnimator.SetTrigger("Attack");
            Invoke("EnemyFire", 0.06f);
            Invoke("RunAnimActive", 0.04f);
            // BunnyController.isGameOver = true;
        }
    }

    public void EnemyFire()
    {
        bulletInstance = Instantiate(_enemyBullet, bulletPos.transform.position, Quaternion.Euler(0, 180, 0)) as Rigidbody2D;
        bulletInstance.velocity = new Vector2(-8f, 0f);
        // enemyStartShooting = true;
    }

    public void RunAnimActive()
    {
        enemyAnimator.SetTrigger("Walk");
    }
}