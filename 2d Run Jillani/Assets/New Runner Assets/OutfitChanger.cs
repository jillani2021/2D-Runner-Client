using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;

    public SpriteRenderer SecondArm;

    [Space]
    [Header("No. of Options")]
    public List<Sprite> options;

    private int currentIndex;

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnNextBtnClick()
    {
        currentIndex++;
        if (currentIndex >= options.Count)
        {
            currentIndex = 0;
        }
        bodyPart.sprite = options[currentIndex];
        if (SecondArm != null)
        {
            SecondArm.sprite = options[currentIndex];
        }
    }

    public void OnPreviousBtnClick()
    {
        currentIndex--;
        if (currentIndex <= 0)
        {
            currentIndex = options.Count - 1;
        }
        bodyPart.sprite = options[currentIndex];
        if (SecondArm != null)
        {
            SecondArm.sprite = options[currentIndex];
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
}