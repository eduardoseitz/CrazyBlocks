using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isAutoTestEnabled;
    public float autoTestOffset;
    public bool hasBallLaunched;

    public float blocksRemaining;
    public int pointsPerBlock = 50;
    public GameStatus gameStatus;
    public TextMeshProUGUI scoreText;

    private SceneLoader sceneLoader;

    private void Awake()
    {
        if (instance)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasBallLaunched)
        {
            if (blocksRemaining == 0)
            {
                WinGame();
            }
        }

        Time.timeScale = gameStatus.timeScale;
    }

    public void ScoreBlock()
    {
        blocksRemaining--;
        gameStatus.totalScore += pointsPerBlock;

        scoreText.text = gameStatus.totalScore.ToString();
    }

    public void ResetGame()
    {
        blocksRemaining = 0;
        hasBallLaunched = false;
        
    }

    public void ResetScore()
    {
        gameStatus.totalScore = 0;
        scoreText.text = gameStatus.totalScore.ToString();

        ResetGame();
    }

    private void WinGame()
    {
        Debug.Log("Level Won");
        
        ResetGame();
        
        sceneLoader.LoadNextScene();
    }
}
