using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUp : MonoBehaviour
{
    private GameObject uiCoinPos;

    // Use this for initialization
    private void Start()
    {
        uiCoinPos = GameObject.Find("CoinUIPos");
        transform.GetComponent<MoveLeft>().enabled = false;
        Destroy(gameObject, 0.7f);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, uiCoinPos.transform.position, 1f);/*new Vector3 (transform.position.x + 0.13f, transform.position.y + 0.2f, transform.position.z)*/;
    }
}