using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle game over
        Debug.Log("Level Lost");
        SceneManager.LoadScene("GameOver");
    }
}
