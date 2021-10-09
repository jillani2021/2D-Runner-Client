using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_PAUSE : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public static bool isPaused;

    public void PauseBtnClick()
    {
        //isPaused = true;
      Time.timeScale = 0;
        Debug.Log("CHALLLLLLLLLLLLLLLLLLLLLLLLLLLLL");
    }

    public void ResumeBtnClick1()
    {
        //isPaused = false;
        Time.timeScale = 1;
        Debug.Log("CHALLLLLLLLLLLLLLLLLLLLLLLLLLLLL");

    }
}