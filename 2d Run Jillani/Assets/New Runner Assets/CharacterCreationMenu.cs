using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCreationMenu : MonoBehaviour
{
    public GameObject character;
    public List<OutfitChanger> outfitChangers = new List<OutfitChanger>();

    public void RandomizeCharacter()
    {
        foreach (OutfitChanger changer in outfitChangers)
        {
            changer.Randomize();
        }
    }

    public void SaveCharacter()
    {
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/NewPlayer1.prefab");
    }
}