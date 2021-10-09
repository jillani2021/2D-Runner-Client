using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprinter : MonoBehaviour
{
    public Transform footprints;
    public float totaltime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totaltime += Time.deltaTime;
        if (totaltime > 1)
        {
            Transform go=Instantiate(footprints, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        
            totaltime = 0;
        }
        
    }
}
