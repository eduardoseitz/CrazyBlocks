using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float paddleSizeOffset = 0.75f;
    private float mouseHorizontalPosition;
    private float cameraHorizontalSize;

    private Transform ball;

    private void Start()
    {
        // Get camera screen size in units taking in consideration the 4:3 aspect ratio less the paddle size
        cameraHorizontalSize = Camera.main.orthographicSize / 3 * 4 - (paddleSizeOffset);

        ball = FindObjectOfType<BallController>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Ai movement
        if (GameManager.instance.isAutoTestEnabled)
        {
            if (GameManager.instance.hasBallLaunched)
            {
                float randomOffset = Random.Range(-GameManager.instance.autoTestOffset, GameManager.instance.autoTestOffset);
                transform.position = new Vector2(ball.position.x + randomOffset, transform.position.y);
            }
        }
        // Player movement
        else
        {
            // Get mouse position in world units
            mouseHorizontalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            // Move the paddle horizontally on screen
            transform.transform.position = new Vector2(Mathf.Clamp(mouseHorizontalPosition, -cameraHorizontalSize, cameraHorizontalSize), transform.transform.position.y);
        }
    }
}
