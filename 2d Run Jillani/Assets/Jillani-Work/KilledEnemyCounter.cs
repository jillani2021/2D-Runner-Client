using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledEnemyCounter : MonoBehaviour
{
    public int NoOfKilledEnemy;

    public Text killedEnemyTxt;

    public void UpdateKilledEnemyCount()
    {
        NoOfKilledEnemy++;
        killedEnemyTxt.text = NoOfKilledEnemy.ToString();
    }
}