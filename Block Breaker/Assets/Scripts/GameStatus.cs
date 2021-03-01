using UnityEngine;

[System.Serializable]
public class GameStatus
{
    public int totalScore;
    [Range(0.1f, 10f)] public float timeScale = 1f;
}
