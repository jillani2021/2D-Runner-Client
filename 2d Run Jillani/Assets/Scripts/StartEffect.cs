using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
    public static StartEffect instance;
    public GameObject peffect;
    Vector2 previousPos;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        peffect = GameObject.Find("ParticleEffect").transform.GetChild(0).gameObject;
        previousPos = peffect.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableEffect()
    {
        peffect.transform.position = previousPos;
        peffect.SetActive(false);

    }
}
