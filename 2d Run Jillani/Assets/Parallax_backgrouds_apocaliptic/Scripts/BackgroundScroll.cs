using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = 0;
    public BackgroundScroll current;
    public float tileSize = 0;
    private float pos = 0;
    private Renderer my_renderer;

    // Use this for initialization
    private void Start()
    {
        current = this;
    }

    // Update is called once per frame

    private void Update()
    {
        if (GAME_PAUSE.isPaused == false)
        {
            if (BunnyController.isSpeedyArrows)
            {
                speed = -0.25f;
            }
            else
            {
                speed = -0.06f;
            }
            if (BunnyController.isGameOver == false && Time.timeScale > 0)
            {
                pos += speed;
                if (pos < -tileSize)
                    pos += tileSize;

                current.transform.position = new Vector3(pos, current.transform.position.y, current.transform.position.z);
                //my_renderer.material.mainTextureOffset = new Vector2 (pos, 0);
            }
        }
    }
}