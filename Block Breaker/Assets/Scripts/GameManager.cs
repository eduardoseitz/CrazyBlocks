using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public bool hasLaunched;

    public float blocksRemaining;

    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
            Destroy(this);
        instance = this;

        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLaunched)
        {
            if (blocksRemaining == 0)
            {
                WinGame();
            }
        }
    }

    private void WinGame()
    {
        Debug.Log("Game won");
        sceneLoader.LoadNextScene();
    }
}
