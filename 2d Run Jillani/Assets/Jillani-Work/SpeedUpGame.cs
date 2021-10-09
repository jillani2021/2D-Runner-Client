
using UnityEngine;

public class SpeedUpGame : MonoBehaviour {
    //int value;
    float afterThistime;
    // Use this for initialization
    void Start () {
        //value = 10;
       
	}
	
	// Update is called once per frame
	void Update () {
        afterThistime += Time.deltaTime;
        if (afterThistime >= 40&& Time.timeScale<= 2.5f)
        {
            Debug.Log("After  Know Time Scale is..........: " + Time.timeScale);
            Time.timeScale += 0.08f;
            Debug.Log("After  Know Time Scale is..........: " + Time.timeScale);

            afterThistime = 0;
        }
	}
}
