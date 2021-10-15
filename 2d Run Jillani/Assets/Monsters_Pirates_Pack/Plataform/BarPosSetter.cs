using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPosSetter : MonoBehaviour
{
    public Vector3 startPos;
    public float randomYpos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (transform.position.x < (-startPos.x))
        {
            this.gameObject.transform.position = startPos;
            randomYpos = Random.Range(-0.32f, 0.32f);
            transform.position = new Vector2(transform.position.x, randomYpos);
        }
    }
}