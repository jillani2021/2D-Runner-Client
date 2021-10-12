using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BunnyController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public float bunnyJumpForce = 500f;
    private float bunnyHurtTime = -1, HealthCount, SheildCount, GunCount;
    private Collider2D myCollider;
    public Text scoreText, coinText, bullettext;
    private float startTime;
    private int jumpsLeft = 2;
    public int bulletcount;
    public AudioSource jumpSfx;
    public AudioSource deathSfx, coin, powerUp;
    public GameObject GameOverPanel, PausePanel, HealthBar, SheildBar, PlayerSheild, sheildback, sheildBar, gunback, gunPower, Gunbar, bulletPos, exitPanel, Gunbtn, bullet;
    public static bool isSheild = false, isGun = false;
    private static int i;
    public static bool isSpeedyArrows;
    public bool isGameContinue;
    public GameObject continuePanel;
    public Collision2D _overCollision;
    // public static string distance;

    public RuntimeAnimatorController[] Controller;
    private int mIndex;

    //public Animator cameraAnimator;
    public static BunnyController instance;

    public Animator player8bitAnimator;
    public AudioSource gameOverSound;

    // Use this for initialization
    private void Start()
    {
        isGun = false;
        isSheild = false;
        player8bitAnimator.SetTrigger("Run");
        myRigidBody = GetComponent<Rigidbody2D>();
        // myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        startTime = Time.time;
        coinCounter = PlayerPrefs.GetInt("coin", 1);
        coinText.text = coinCounter.ToString();
        bulletcount = PlayerPrefs.GetInt("Bullet", 40);
        bullettext.text = bulletcount.ToString();

        GunCount = gunPower.GetComponent<Image>().fillAmount;
        mIndex = PlayerPrefs.GetInt("Player", 0);
        transform.GetComponent<Animator>().runtimeAnimatorController = Controller[mIndex] as RuntimeAnimatorController;
        scoreText.text = 0 + "  m";
        // Debug.Log(Time.timeScale);
        i = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bunnyHurtTime == -1)
            {
                //  myRigidBody.velocity = new Vector2(0f, 0.02f);

                if (/*(Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1")) &&*/ jumpsLeft > 0)
                {
                    if (myRigidBody.velocity.y < 0)
                    {
                        myRigidBody.velocity = Vector2.zero;
                    }

                    if (jumpsLeft == 1)
                    {
                        myRigidBody.AddForce(transform.up * bunnyJumpForce * 0.75f);
                    }
                    else
                    {
                        myRigidBody.AddForce(transform.up * bunnyJumpForce);
                    }
                    jumpsLeft--;

                    jumpSfx.Play();
                    //  }
                    //   Debug.Log("Velocity " + myRigidBody.transform.position.y);

                    //  myAnim.SetFloat("vVelocity", 0.02f);

                    scoreText.text = ((Time.time - startTime)).ToString("F0") + "  m";
                    //  distance = scoreText.text;
                    Invoke("ResetJump", 0.75f);
                }
            }
            else
            {
                if (Time.time > bunnyHurtTime + 2)
                {
                    GameOverPanel.gameObject.SetActive(true);

                    if (i == 1)
                    {
                        //  Advertisements.Instance.ShowInterstitial();
                        i++;
                    }
                    //you can change the add id's from windows>gley>mobileAds
                }
            }
        }
        if (GAME_PAUSE.isPaused == false)
        {
            Debug.Log(Time.timeScale);
            HealthBar.GetComponent<Image>().fillAmount = HealthBar.GetComponent<Image>().fillAmount - 0.0002f;
            HealthCount = HealthBar.GetComponent<Image>().fillAmount;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitPanel.SetActive(true);
            }

            if (isSheild || isSpeedyArrows)
            {
                //  Debug.Log("isShield........;" + isSheild);
                //			Debug.Log ("IsSheild"+isSheild);

                SheildBar.GetComponent<Image>().fillAmount = SheildBar.GetComponent<Image>().fillAmount - 0.008f;
                SheildCount = SheildBar.GetComponent<Image>().fillAmount;

                if (SheildCount <= 0)
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(false);

                    PlayerSheild.SetActive(false);
                    sheildBar.SetActive(false);
                    sheildback.SetActive(false);
                    SheildBar.GetComponent<Image>().fillAmount = 1;
                    isSheild = false;
                    isSpeedyArrows = false;
                    Time.timeScale = 1;
                }
            }

            if (HealthCount <= 0 && !isGameOver)
            {
                // Debug.Log("GameOver Things trigger: " + isSheild + " And speedy Arrow var: " + isSpeedyArrows);
                //  CameraShake.isShake = true;
                //  cameraAnimator.SetTrigger("IsShake");
                foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
                {
                    spawner.enabled = false;
                }

                foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>())
                {
                    moveLefter.enabled = false;
                }
                foreach (ScrollingBackground Scroll in FindObjectsOfType<ScrollingBackground>())
                {
                    Scroll.enabled = false;
                }
                foreach (FloorSpawner Floor in FindObjectsOfType<FloorSpawner>())
                {
                    Floor.enabled = false;
                }
                CancelInvoke();
                bunnyHurtTime = Time.time;

                // myAnim.SetBool("bunnyHurt", true);
                myRigidBody.velocity = Vector2.zero;
                myRigidBody.AddForce(transform.up * bunnyJumpForce);
                myRigidBody.gameObject.transform.localPosition = new Vector2(transform.position.x - 1f, transform.position.y);
                //            myCollider.enabled = false;
                //   collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                deathSfx.Play();
                // collision.gameObject.SetActive(false);
                isGameOver = true;
                float currentBestScore = PlayerPrefs.GetFloat("BestScore", 0);
                float currentScore = Time.time - startTime;
                StartCoroutine(GameOverPanelWithDelay());

                if (i == 1)
                {
                    // Advertisements.Instance.ShowInterstitial();
                    i++;
                }

                if (currentScore > currentBestScore)
                {
                    PlayerPrefs.SetFloat("BestScore", currentScore);
                }
            }
        }
    }

    public void OnClickJumpBtn() // Jump button call here

    {
    }

    private void ResetJump()
    {
        //  myAnim.SetFloat("vVelocity", 0.00f);
    }

    private int slideNumber = 1;

    public void OnCLickslideBtn()
    {
        if (slideNumber >= 1)
        {
            //  myAnim.SetInteger("slide", slideNumber);
            slideNumber--;
        }

        StartCoroutine(sliding());
    }

    private IEnumerator sliding()
    {
        yield return new WaitForSeconds(0.08f);

        if (slideNumber == 0)
        {
            // myAnim.SetInteger("slide", slideNumber);
            slideNumber = 1;
        }
    }

    public static int coinCounter;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.GetComponent<moveUp>().enabled = true;
            coinCounter = coinCounter + 1;
            coinText.text = coinCounter.ToString();
            coin.Play();
            PlayerPrefs.SetInt("coin", coinCounter);
            PlayerPrefs.Save();
        }
        else if (col.gameObject.tag == "fruit")
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            HealthBar.GetComponent<Image>().fillAmount = 1f;
            powerUp.Play();
        }
        else if (col.gameObject.tag == "sheild")
        {
            isSheild = true;

            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            PlayerSheild.SetActive(true);
            powerUp.Play();
            sheildBar.SetActive(true);
            Time.timeScale = 2.3f;
            sheildback.SetActive(true);
        }
        else if (col.gameObject.tag == "SpeedyArrows")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

            isSpeedyArrows = true;
            //   isSheild = false;
            Time.timeScale = 2.3f;
            sheildBar.SetActive(true);
        }
        else if (col.gameObject.tag == "gun")
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            bulletcount = bulletcount + 5;
            bullettext.text = bulletcount.ToString();
        }
        else if (col.gameObject.tag == "UpperFloor")
        {
            ResetJump();
            jumpsLeft = 2;
            //  myAnim.SetFloat("vVelocity", 0);
        }
    }

    public static bool isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GameOver(collision);
            // }
        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsLeft = 2;
        }
    }

    public void GameOver(Collision2D collision)
    {
        if (!isSheild && (!isSpeedyArrows) /*&& isGameContinue == false*/)
        {
            isGameOver = true;
            Debug.Log("game over bool: " + isGameOver);
            Debug.Log("GameOver Things trigger: " + isSheild + " And speedy Arrow var: " + isSpeedyArrows);
            CameraShake.isShake = true;
            player8bitAnimator.SetTrigger("Die");
            //player8bitAnimator.gameObject.transform.position = new Vector3(transform.position.x, -2.6f, transform.position.z);

            //GameObject TemporaryEnemyObj = GameObject.Find("Enemy_1(Clone)");
            //if (TemporaryEnemyObj != null)
            //{
            //    TemporaryEnemyObj.GetComponent<Animator>().SetTrigger("Idel");
            //}

            foreach (GameObject enemObj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (enemObj.name == "Enemy_1(Clone)")
                {
                    enemObj.GetComponent<Animator>().SetTrigger("Idel");
                }
            }
            //  cameraAnimator.SetTrigger("IsShake");
            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
            {
                spawner.enabled = false;
            }

            foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>())
            {
                moveLefter.enabled = false;
            }
            foreach (ScrollingBackground Scroll in FindObjectsOfType<ScrollingBackground>())
            {
                Scroll.enabled = false;
            }
            foreach (FloorSpawner Floor in FindObjectsOfType<FloorSpawner>())
            {
                Floor.enabled = false;
            }
            //foreach (GameObject enmyObj in <GameObject>())
            //{
            //    if (enmyObj != null)
            //    {
            //        enmyObj.GetComponent<Animator>().SetTrigger("Idel");
            //    }
            //}
            CancelInvoke();
            bunnyHurtTime = Time.time;

            // myAnim.SetBool("bunnyHurt", true);
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(transform.up * bunnyJumpForce);
            myRigidBody.gameObject.transform.localPosition = new Vector2(transform.position.x - 1f, transform.position.y);
            //            myCollider.enabled = false;
            //   collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            //  deathSfx.Play();
            // collision.gameObject.SetActive(false);
            float currentBestScore = PlayerPrefs.GetFloat("BestScore", 0);
            float currentScore = Time.time - startTime;
            StartCoroutine(GameOverPanelWithDelay());

            if (i == 1)
            {
                // Advertisements.Instance.ShowInterstitial();
                i++;
            }

            if (currentScore > currentBestScore)
            {
                PlayerPrefs.SetFloat("BestScore", currentScore);
            }
        }
    }

    public void OnContinueBtnClick()
    {
        //  Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
        Time.timeScale = 1;
        // isGameContinue = true;
    }

    private IEnumerator GameOverPanelWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        GameOverPanel.gameObject.SetActive(true);
        gameOverSound.Play();

        //foreach (GameObject enemObj in GameObject.FindObjectsOfType<GameObject>())
        //{
        //    if (enemObj.name == "Enemy_1(Clone)")
        //    {
        //        enemObj.GetComponent<SpriteRenderer>().enabled = false;
        //    }
        //}
    }

    private IEnumerator ContinuePanelDelay()
    {
        yield return new WaitForSeconds(0.5f);
        continuePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void CompleteMethod(bool completed)
    {
        Debug.Log("Completed " + completed);
        //	GleyMobileAds.ScreenWriter.Write("Completed " + completed);
        if (completed == true)
        {
            //Debug.Log("check video ad");
            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
            {
                spawner.enabled = true;
            }

            foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>())
            {
                moveLefter.enabled = true;
            }
            foreach (ScrollingBackground Scroll in FindObjectsOfType<ScrollingBackground>())
            {
                Scroll.enabled = true;
            }
            foreach (FloorSpawner Floor in FindObjectsOfType<FloorSpawner>())
            {
                Floor.enabled = true;
            }
            //  myAnim.SetBool("bunnyHurt", false);
            // myAnim.SetInteger("gunstate", 1);
            isGameOver = false;
        }
        else
        {
            //no reward
            if (_overCollision != null)
            {
                GameOver(_overCollision);
            }
        }
    }

    private void OnBulletPurchase()
    {
        int TempSave = PlayerPrefs.GetInt("Bullet");
        TempSave += 20;
        PlayerPrefs.SetInt("Bullet", TempSave);
        bulletcount = PlayerPrefs.GetInt("Bullet");
        bullettext.text = bulletcount.ToString();
    }
}