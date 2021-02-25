using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float mouseHorizontalPosition;
    private float cameraHorizontalSize;

    private void Start()
    {
        // Get camera screen size in units taking in consideration the 4:3 aspect ratio less the paddle size
        cameraHorizontalSize = Camera.main.orthographicSize / 3 * 4 - (transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position in world units
        mouseHorizontalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        // Move the paddle horizontally on screen
        transform.transform.position = new Vector2(Mathf.Clamp(mouseHorizontalPosition, - cameraHorizontalSize, cameraHorizontalSize), transform.transform.position.y);
    }
}
