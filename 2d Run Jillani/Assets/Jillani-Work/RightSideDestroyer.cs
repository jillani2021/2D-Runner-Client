using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideDestroyer: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Car")
        {
            Destroy(collision.gameObject);
        }
    }


}
