using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public ParallaxLayer[] layers;

    private Camera mainCamera;

    private float cameraHorizontalSize;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // Calculate screen ratio
        cameraHorizontalSize = Camera.main.orthographicSize / 3 * 4;
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal mouse position
        float mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        float horizontalPosition = Mathf.Clamp(mousePosition, -cameraHorizontalSize, cameraHorizontalSize);

        for (int i = 0; i < layers.Length; i++)
        {
            float newSpritePosition = horizontalPosition * -layers[i].maxDistance;
            layers[i].sprite.position = new Vector3(newSpritePosition, layers[i].sprite.position.y, layers[i].sprite.position.z);
        }
    }
}

[System.Serializable]
public class ParallaxLayer
{
    public string layerName;
    public Transform sprite;
    public float maxDistance = 1.2f;
}
