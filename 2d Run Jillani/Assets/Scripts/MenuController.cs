using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
    public Text txtBestScore;
    public Text CoinText;

    // Use this for initialization
    private void Start()
    {
        Time.timeScale = 1;
        //Advertisements.Instance.HideBanner ();
        SetSoundState();
        txtBestScore.text = PlayerPrefs.GetFloat("BestScore", 0).ToString("F0");
        CoinText.text = PlayerPrefs.GetInt("coin", 0).ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelection");
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        SetSoundState();
    }

    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            audioOnIcon.SetActive(true);
            audioOffIcon.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            audioOnIcon.SetActive(false);
            audioOffIcon.SetActive(true);
        }
    }
}