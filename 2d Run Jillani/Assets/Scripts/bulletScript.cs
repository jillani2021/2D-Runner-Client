using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;

public class bulletScript : MonoBehaviour
{
    public float maxSpeed = 1500f;
    public Rigidbody2D[] bullet;
    public AudioSource fireSfx;
    private bool isFire = true;
    public BunnyController instance;
    private Animator charAnimator;

    //void Update()
    //{
    //if (isFire && ! BunnyController.isGameOver)
    //{
    //	fireSfx.Play ();
    //	Rigidbody2D bulletInstance = Instantiate(bullet[Random.Range(0,4)], transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
    //	bulletInstance.velocity = new Vector2 (10, 0f);

    //	isFire = false;
    //}
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            instance = GameObject.Find("Ninja").GetComponent<BunnyController>();
            if (instance.bulletcount >= 1)
            {
                if (isFire && !BunnyController.isGameOver)
                {
                    fireSfx.Play();
                    // charAnimator = GameObject.Find("Ninja").GetComponent<Animator>();
                    //   charAnimator.SetBool("IsFire", isFire);
                    StartCoroutine(BulletSpawnDelay());
                    //  isFire = false;
                    //charAnimator.SetBool("IsFire", isFire);
                    instance.bulletcount = instance.bulletcount - 1;
                    instance.bullettext.text = instance.bulletcount.ToString();
                    //  Invoke("CharAnimation", 1f);
                }
            }

            isFire = true;
            Invoke("CharAnimation", 0.05f);
        }
    }

    public void Fire()
    {
    }

    private void CharAnimation()
    {
        // charAnimator.SetBool("IsFire", false);
    }

    private IEnumerator BulletSpawnDelay()
    {
        yield return new WaitForSeconds(0.3f);
        Rigidbody2D bulletInstance = Instantiate(bullet[Random.Range(0, bullet.Length)], transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
        bulletInstance.velocity = new Vector2(10, 0f);
    }
}