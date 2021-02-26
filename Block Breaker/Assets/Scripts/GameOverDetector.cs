using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle game over
        SceneManager.LoadScene("GameOver");
    }
}
