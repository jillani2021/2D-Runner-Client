using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLoudMoveLeft : MonoBehaviour
{
    public float speed;
    public Vector3 tempPos;

    // Start is called before the first frame update
    private void Start()
    {
        tempPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (BunnyController.isGameOver == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x < -7)
            {
                transform.position = tempPos;
            }
        }
    }
}