using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarController : MonoBehaviour {

    public GameObject carPrefab;
    float timer;
    public GameObject SpeedUpArrows;
    
	// Use this for initialization
	void Start () {
        Invoke("SpawnArrows",5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (BunnyController.isGameOver == false)
        {
            timer += Time.deltaTime;

            if (timer >= 15)
            {
                Instantiate(carPrefab, new Vector3(-12, -3.14f, 0), Quaternion.identity);
                // Instantiate(SpeedUpArrows, new Vector3(12, -2f, 0), Quaternion.identity);
                timer = 0;
            }
        }
	}
    
   void SpawnArrows()
    {
        Instantiate(SpeedUpArrows, new Vector3(12, -2f, 0), Quaternion.identity);
        Invoke("SpawnArrows", Random.Range(15f, 25f));
    }
}
