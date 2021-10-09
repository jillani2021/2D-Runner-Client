using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D _enemyBullet;
    private Rigidbody2D bulletInstance;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (EnemyRay.enemyStartShooting)
        {
            StartCoroutine(enemyShootDelay());
            if (bulletInstance)
            {
            }
        }
    }

    private IEnumerator enemyShootDelay()
    {
        yield return new WaitForSeconds(2f);
        bulletInstance = Instantiate(_enemyBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
        bulletInstance.velocity = new Vector2(-10, 0f);
    }
}