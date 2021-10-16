using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OutFits
{
    None,
    weapons,
    heads,
    Shirts,
    legs,
    Eyes,
    Arms,
    Accessories
}

public class OutfitChanger : MonoBehaviour
{
    public static event System.Action<OutFits, int> _OutfitChangerEvent;

    public OutFits myOutfits;
    private Button playBtn;
    private Button saveBtn;
    private Button buyBtn;
    private Text priceTxt;
    private CharacterCreationMenu characterCreationScript;

    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;

    public SpriteRenderer SecondArm;

    [Space]
    [Header("No. of Options")]
    public List<Sprite> options;

    public int currentIndex;
    private int priceOfParts = 100;

    public int tempPriceSave;

    private void Start()
    {
        playBtn = GameObject.Find("PlayBtn").GetComponent<Button>();
        saveBtn = GameObject.Find("SaveBtn").GetComponent<Button>();

        buyBtn = GameObject.Find("BuyBtn").GetComponent<Button>();

        priceTxt = GameObject.Find("PriceTxt").GetComponent<Text>();
        characterCreationScript = GameObject.Find("ChracterCreationMenu").GetComponent<CharacterCreationMenu>();
    }

    public void OnNextBtnClick()
    {
        currentIndex++;

        if (currentIndex >= options.Count)
        {
            currentIndex = 0;
        }
        if (_OutfitChangerEvent != null)
        {
            _OutfitChangerEvent.Invoke(myOutfits, currentIndex);
        }
        //this can check Sprite Buy orr not
        if (currentIndex == characterCreationScript.SelectedIndex)
        {
            bodyPart.sprite = options[currentIndex];
            if (SecondArm != null)
            {
                SecondArm.sprite = options[currentIndex];
            }
            playBtn.gameObject.SetActive(true);
            saveBtn.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(false);
            priceTxt.gameObject.SetActive(false);
        }
        else
        {
            tempPriceSave = priceOfParts * currentIndex;
            playBtn.gameObject.SetActive(false);
            saveBtn.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(true);
            priceTxt.gameObject.SetActive(true);

            priceTxt.text = tempPriceSave.ToString();
            characterCreationScript.TotalCostCalculate();
        }
    }

    public void OnPreviousBtnClick()
    {
        currentIndex--;
        if (currentIndex <= 0)
        {
            currentIndex = options.Count - 1;
        }
        if (_OutfitChangerEvent != null)
        {
            _OutfitChangerEvent.Invoke(myOutfits, currentIndex);
        }
        //this can check Sprite Buy orr not
        if (currentIndex == 0)
        {
            bodyPart.sprite = options[currentIndex];
            if (SecondArm != null)
            {
                SecondArm.sprite = options[currentIndex];
            }
            playBtn.gameObject.SetActive(true);
            saveBtn.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(false);
            priceTxt.gameObject.SetActive(false);
        }
        else
        {
            tempPriceSave = priceOfParts * currentIndex;
            playBtn.gameObject.SetActive(false);
            saveBtn.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(true);
            priceTxt.gameObject.SetActive(true);

            priceTxt.text = tempPriceSave.ToString();
            characterCreationScript.TotalCostCalculate();
        }
    }

    public void Randomize()
    {
        currentIndex = Random.Range(0, options.Count - 1);
        bodyPart.sprite = options[currentIndex];
        if (SecondArm != null)
        {
            SecondArm.sprite = options[currentIndex];
        }
    }

    //public void DefaultBtn()
    //{
    //    buyBtn.gameObject.SetActive(false);
    //    priceTxt.gameObject.SetActive(false);
    //    bodyPart.sprite = options[0];
    //    if (SecondArm != null)
    //    {
    //        SecondArm.sprite = options[0];
    //    }
    //}
}