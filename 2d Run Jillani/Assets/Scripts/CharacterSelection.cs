using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    //public GameObject[] Players;

    public GameObject buyButton, playButton;//FreeImg;
    public GameObject buyPopUp, UnsufficentCoinsForPlayerselection;

    public Text CoinText;
    public Text PlayerNameText, PlayerPriceDisplayText;
    public int TotalCoins, buyCoins = 3000;
    private int Index;

    // Use this for initialization
    private void Start()
    {
        //Advertisements.Instance.Initialize ();
        //PlayerPrefs.DeleteAll();
        Index = 0;
        //  Players[Index].gameObject.SetActive(true);
        CoinText.text = PlayerPrefs.GetInt("coin", 0).ToString();
        TotalCoins = PlayerPrefs.GetInt("coin", 0);
        //		PlayerPrefs.DeleteAll ();
        showcarINFO();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void LeftPress()
    {
        if (Index > 0)
        {
            //  Players[Index].gameObject.SetActive(false);
            Index--;
            // Players[Index].gameObject.SetActive(true);
            PlayerPrefs.SetInt("Player", Index);
            PlayerPrefs.Save();
            showcarINFO();
        }
    }

    public void RightPress()
    {
        if (Index < 4)
        {
            // Players[Index].gameObject.SetActive(false);
            Index++;
            // Players[Index].gameObject.SetActive(true);
            PlayerPrefs.SetInt("Player", Index);
            PlayerPrefs.Save();
            showcarINFO();
        }
    }

    public void BackBtn()
    {
        Application.LoadLevel(0);
        PlayerPrefs.SetInt("Player", 0);
    }

    public void PlayBtn()
    {
        Application.LoadLevel(2);
    }

    public static int PlayerCost = 0;

    public void purchasePlayer()
    {
        switch (Index)
        {
            case 1:

                if (TotalCoins >= 1500)
                {
                    PlayerCost = 1500;//to set the cost in buyPopUpScript
                    buyPopUp.SetActive(true);
                }
                else
                {
                    UnsufficentCoinsForPlayerselection.SetActive(true);
                }

                break;

            case 2:

                if (TotalCoins >= 3000)
                {
                    PlayerCost = 3000;
                    buyPopUp.SetActive(true);
                }
                else
                {
                    UnsufficentCoinsForPlayerselection.SetActive(true);
                }

                break;

            case 3:
                if (TotalCoins >= 4500)
                {
                    PlayerCost = 4500;
                    buyPopUp.SetActive(true);
                }
                else
                {
                    UnsufficentCoinsForPlayerselection.SetActive(true);
                }

                break;

            case 4:
                if (TotalCoins >= 6000)
                {
                    PlayerCost = 6000;
                    buyPopUp.SetActive(true);
                }
                else
                {
                    UnsufficentCoinsForPlayerselection.SetActive(true);
                }

                break;

            case 5:
                if (TotalCoins >= 7500)
                {
                    PlayerCost = 7500;
                    buyPopUp.SetActive(true);
                }
                else
                {
                    UnsufficentCoinsForPlayerselection.SetActive(true);
                }

                break;
        }
    }

    public void YesBuyBtn()
    {
        PlayerPrefs.SetInt("isPlayer" + Index + "Purchased", 1); // to save the Player lock status
        buyButton.SetActive(false);
        playButton.SetActive(true);
        TotalCoins = TotalCoins - PlayerCost;
        PlayerPrefs.SetInt("coin", TotalCoins);
        CoinText.text = PlayerPrefs.GetInt("coin", 0).ToString();
    }

    public void purchaseCoins()
    {
        TotalCoins += buyCoins;
        PlayerPrefs.SetInt("coin", TotalCoins);
        CoinText.text = TotalCoins.ToString();
    }

    private void showcarINFO()
    {
        switch (Index)
        {
            case 0:

                PlayerNameText.text = "Super Hero";
                PlayerPriceDisplayText.text = "FREE ";
                //						playOrBuy.text = "Run";
                playButton.SetActive(true);
                buyButton.SetActive(false);
                ////FreeImg.SetActive(true);
                break;

            case 1:

                PlayerNameText.text = "Simon";
                PlayerPriceDisplayText.text = "1500 ";
                if (PlayerPrefs.GetInt("isPlayer1Purchased", 0) == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                    //  //FreeImg.SetActive(false);
                }
                else
                {
                    //								playOrBuy.text = "BUY";
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    //  //FreeImg.SetActive(false);
                }
                break;

            case 2:

                PlayerNameText.text = "Freeza";
                PlayerPriceDisplayText.text = "3000 ";

                if (PlayerPrefs.GetInt("isPlayer2Purchased", 0) == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                    //  //FreeImg.SetActive(false);
                }
                else
                {
                    //								playOrBuy.text = "buy";
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    //  //FreeImg.SetActive(false);
                }
                break;

            case 3:

                PlayerNameText.text = "Jack";
                PlayerPriceDisplayText.text = "4500 ";

                if (PlayerPrefs.GetInt("isPlayer3Purchased", 0) == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                    //FreeImg.SetActive(false);
                }
                else
                {
                    //								playOrBuy.text = "buy";
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    //FreeImg.SetActive(false);
                }
                break;

            case 4:

                PlayerNameText.text = "Jackson";
                PlayerPriceDisplayText.text = "6000 ";

                if (PlayerPrefs.GetInt("isPlayer4Purchased", 0) == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                    // FreeImg.SetActive(false);
                }
                else
                {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    // FreeImg.SetActive(false);
                }
                break;

            case 5:

                PlayerNameText.text = "Flare";
                PlayerPriceDisplayText.text = "7500 ";

                if (PlayerPrefs.GetInt("isPlayer5Purchased", 0) == 1)
                {
                    playButton.SetActive(true);
                    buyButton.SetActive(false);
                    // FreeImg.SetActive(false);
                }
                else
                {
                    buyButton.SetActive(true);
                    playButton.SetActive(false);
                    // FreeImg.SetActive(false);
                }
                break;
        }
    }
}