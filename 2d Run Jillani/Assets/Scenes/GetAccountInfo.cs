using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAccountInfo : MonoBehaviour
{
    public Text accountNo;

    // Start is called before the first frame update
    private void Start()
    {
        accountNo.text = PlayerPrefs.GetString("Account");
    }
}