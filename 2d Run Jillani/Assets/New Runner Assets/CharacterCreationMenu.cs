using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationMenu : MonoBehaviour
{
    public int SelectedIndex;
    public OutFits SelectedOutFit;
    public GameObject character;
    public Text totalCostTxt;
    private int TotalCost;
    private int previousTotal;
    public Text cointxt;
    public Character_Save CS;

    [Space]
    [Header("Ref Sprite of Every Body Part")]
    public List<OutfitChanger> outfitChangers = new List<OutfitChanger>();

    private void Start()
    {
        OutfitChanger._OutfitChangerEvent += OutfitChanger__OutfitChangerEvent;
    }

    private void OutfitChanger__OutfitChangerEvent(OutFits _fitstype, int index)
    {
        SelectedOutFit = _fitstype;
        SelectedIndex = index;
    }

    public void DefaultCharacter()
    {
        foreach (OutfitChanger changer in outfitChangers)
        {
            changer.bodyPart.sprite = changer.options[0];
        }
    }

    public void TotalCostCalculate()
    {
        foreach (OutfitChanger changer in outfitChangers)
        {
            TotalCost = 100 * changer.currentIndex;
            totalCostTxt.text = TotalCost.ToString();
        }
    }

    public void Buy()
    {
        int coins = PlayerPrefs.GetInt("coin");
        foreach (OutfitChanger changer in outfitChangers)
        {
            if (SelectedOutFit == OutFits.None)
            {
                Debug.Log("Nothing is Selected");
                return;
            }
            if (coins >= changer.tempPriceSave && changer.myOutfits == SelectedOutFit)
            {
                coins -= changer.tempPriceSave;
                PlayerPrefs.SetInt("coin", coins);
                Debug.Log("Detuct Money: " + changer.tempPriceSave);
                cointxt.text = PlayerPrefs.GetInt("coin").ToString();
                switch (SelectedOutFit)
                {
                    case OutFits.None:
                        break;

                    case OutFits.weapons:
                        CS.WeponsPartsave[SelectedIndex] = true;
                        break;

                    case OutFits.heads:
                        CS.HeadPartSave[SelectedIndex] = true;
                        break;

                    case OutFits.Shirts:
                        CS.ShirtPartsave[SelectedIndex] = true;
                        break;

                    case OutFits.legs:
                        CS.LegsPartSave[SelectedIndex] = true;
                        break;

                    case OutFits.Eyes:
                        CS.EyesPartsave[SelectedIndex] = true;
                        break;

                    case OutFits.Arms:
                        CS.ArmsPartsave[SelectedIndex] = true;
                        break;

                    case OutFits.Accessories:
                        CS.AccessoriesPartsave[SelectedIndex] = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    public void AddCoins()

    {
        PlayerPrefs.SetInt("coin", 5000);
        cointxt.text = PlayerPrefs.GetInt("coin").ToString();
    }
}