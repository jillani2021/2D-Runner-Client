using UnityEngine;
using System.Collections;

public class PrefabSpawner : MonoBehaviour
{
    private float nextSpawn = 0;
    public Transform[] prefabToSpawn;

    public AnimationCurve spawnCurve;
    public float curveLengthInSeconds = 30f;
    private float startTime;
    public float jitter = 0.75f;
    public GameObject BirdPrefab;

    // Use this for initialization
    private void Start()
    {
        //startTime = Time.time;
        Invoke("InsBird", 1f);
    }

    private void InsBird()
    {
        Instantiate(BirdPrefab, BirdPrefab.transform.position, Quaternion.identity);
        Invoke("InsBird", Random.Range(20f, 30f));
    }

    // Update is called once per frame
    private void Update()
    {
        if (GAME_PAUSE.isPaused == false)
        {
            if (Time.time > nextSpawn)
            {
                // Debug.Log("Enemy Number is:" + Random.Range(0, prefabToSpawn.Length ));
                // Debug.Log("Total Enemy is: " + (prefabToSpawn.Length ));
                Instantiate(prefabToSpawn[Random.Range(0, prefabToSpawn.Length)], transform.localPosition, Quaternion.identity);

                // Debug.Log("Length is" + prefabToSpawn.Length);
                //nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);

                float curvePos = (Time.time - startTime) / curveLengthInSeconds;
                if (curvePos > 1f)
                {
                    curvePos = 1f;
                    startTime = Time.time;
                }

                nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + 1f;
            }
        }
    }
}