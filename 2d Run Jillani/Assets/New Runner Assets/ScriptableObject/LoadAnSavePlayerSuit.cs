using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnSavePlayerSuit : MonoBehaviour
{
    //add Script table object here
    [Header("Add Scriptable Object In this Var")]
    public Character_Save characterSave;

    private int i;

    [Space]
    [Header("Add PlayerChar BodyPart Obj")]
    public List<SpriteRenderer> InGameCharBodyParts = new List<SpriteRenderer>();

    private void Awake()
    {
        //this can load saved suit and Call When Scene loaded
        //if (characterSave.characterBodyPartsForSave.Count == 8)// 7 is the last index of this list
        //{
        //    i = 0;

        //    foreach (SpriteRenderer bodyPart in InGameCharBodyParts)
        //    {
        //        bodyPart.sprite = characterSave.characterBodyPartsForSave[i];
        //        i++;
        //    }
        //}
    }

    // This function can save character suits and call on Btn click
    public void SaveCharacter()
    {
        //if (characterSave.characterBodyPartsForSave == null)
        //{
        //    foreach (SpriteRenderer bodyPart in InGameCharBodyParts)
        //    {
        //        characterSave.characterBodyPartsForSave.Add(bodyPart.sprite);
        //    }
        //}
        //else
        //{
        //    characterSave.characterBodyPartsForSave.Clear();
        //    foreach (SpriteRenderer bodyPart in InGameCharBodyParts)
        //    {
        //        characterSave.characterBodyPartsForSave.Add(bodyPart.sprite);
        //    }
        //}
    }
}