using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ERC721BalanceOfExample : MonoBehaviour
{
    public Text balanceTxt;

    private async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = "0x60f80121c31a0d46b5279700f9df786054aa5ee5";
        string account = "0x6D88387A34Bd627c0d9cda94aAd793B78175B0D6";

        int balance = await ERC721.BalanceOf(chain, network, contract, account);
        print(balance);
        balanceTxt.text = balance.ToString();
    }
}