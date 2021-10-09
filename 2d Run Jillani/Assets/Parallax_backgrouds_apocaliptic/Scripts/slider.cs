using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour {

    public Slider mySlider;
    public BackgroundScroll myBackgroundScroll1;
    public BackgroundScroll myBackgroundScroll2;
    public BackgroundScroll myBackgroundScroll3;
    public BackgroundScroll myBackgroundScroll4;
    public BackgroundScroll myBackgroundScroll5;
   


    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        Debug.Log(mySlider.value);
        myBackgroundScroll1.speed = mySlider.value * (float)(-0.001);
        myBackgroundScroll2.speed = mySlider.value * (float)(-0.002);
        myBackgroundScroll3.speed = mySlider.value * (float)(-0.003);
        myBackgroundScroll4.speed = mySlider.value * (float)(-0.004);
        myBackgroundScroll5.speed = mySlider.value * (float)(-0.005);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
