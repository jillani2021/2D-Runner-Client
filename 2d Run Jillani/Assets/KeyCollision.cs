using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollision : MonoBehaviour
{
    public static int keyCount;
    public Text keyText;

    //public ParticleSystem effect;
    public GameObject peffect;

    private Vector2 previousPos;
    public GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        peffect = GameObject.Find("ParticleEffect").transform.GetChild(0).gameObject;
        player = GameObject.Find("Ninja").transform.GetChild(5).gameObject;
        //keyText = GameObject.Find("KeyCount").GetComponent<Text>();
        // effect = GameObject.Find("Sparks").GetComponent<ParticleSystem>();
        previousPos = peffect.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //keyText.text = keyCount.ToString();
        if (keyCount == 1)
        {
            keyCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.SetActive(true);
        peffect.SetActive(true);
        Invoke("Disable", 2f);
        keyCount++;
        //Destroy(gameObject);
    }

    private void Disable()
    {
        peffect.transform.position = previousPos;
        peffect.SetActive(false);
        Invoke("effectdisable", 1f);
    }

    private void effectdisable()
    {
        player.SetActive(false);
    }
}