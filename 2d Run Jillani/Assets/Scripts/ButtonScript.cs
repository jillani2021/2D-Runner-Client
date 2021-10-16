using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private Button yourButton;
    private GameObject Player;
    public static bool IsStart = false;
    private int i = 0;

    private void Start()
    {
        yourButton = transform.GetComponent<Button>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        AudioListener.pause = false;
        Player = GameObject.Find("player") as GameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        //		Debug.Log (EnvironmentController.Distance);
        //		Debug.Log (GameController.Distance);
    }

    private IEnumerator sharedata()
    {
        yield return new WaitForEndOfFrame();
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Superboy Run");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Please download this amazing game\n" + "http://play.google.com/store/apps/details?id=" + Application.identifier);
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
        }
    }

    private void Dialogue()
    {
        //		Player.GetComponent<PlayerController> ().enabled = true;
    }

    private void TaskOnClick()
    {
        if (gameObject.name == "Play")
        {
            SceneManager.LoadScene("PlayerSelection");
            Time.timeScale = 1;
            BunnyController.isGameOver = false;
        }
        else if (gameObject.name == "Home")
        {
            AudioListener.pause = false;
            SceneManager.LoadScene("Home");
            //			AdManager.showAdMob ();
            // Time.timeScale = 1;
            BunnyController.isGameOver = false;
            //	Advertisements.Instance.ShowInterstitial();
        }
        else if (gameObject.name == "Pause")
        {
            Time.timeScale = 0;
            //			AdManager.showUnityAd ();
            AudioListener.pause = true;
            //	Advertisements.Instance.ShowInterstitial();
        }
        else if (gameObject.name == "Resume")
        {
            AudioListener.pause = false;
            Time.timeScale = 1;
            //			AdManager.showAdMob ();
        }
        else if (gameObject.name == "Retry")
        {
            BunnyController.isGameOver = false;
            SceneManager.LoadScene("Game");
            Time.timeScale = 1;
        }
        else if (gameObject.name == "Yes")
        {
            Application.Quit();
        }
        else if (gameObject.name == "Exit")
        {
            //			AdManager.showAdMob ();
        }
        else if (gameObject.name == "RateUs")
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
            //			AdManager.showAdMob ();
        }
        else if (gameObject.name == "More")
        {
            Application.OpenURL("https://play.google.com/store/apps/dev?id=Legend + 3d");
            //			AdManager.showAdMob ();
        }
        else if (gameObject.name == "Share")
        {
            StartCoroutine(sharedata());
            //			    AdManager.showAdMob ();
        }
        else if (gameObject.name == "Tap")
        {
            Invoke("Dialogue", 1f);
            //			PlayerController.scores = 0;
            //			PlayerController.IsGameOver = false;
            //			Player.GetComponent<SliderScript> ().enabled = true;
            Time.timeScale = 1;
            IsStart = true;
        }
        else if (gameObject.name == "SoundOn")
        {
            //			AdManager.showAdMob ();
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.volume = 1;
        }
        else if (gameObject.name == "SoundOff")
        {
            //			AdManager.showAdMob ();
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.volume = 0;
        }
    }

    public void showA2()
    {
        //		AdManager.showUnityAd ();
    }

    public void Show1()
    {
        //		AdManager.showAdMob ();
    }
}