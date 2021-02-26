using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public bool hasLaunched;

    public float blocksRemaining;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
            Destroy(this);
        instance = this;
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
        Time.timeScale = 0;
    }
}
