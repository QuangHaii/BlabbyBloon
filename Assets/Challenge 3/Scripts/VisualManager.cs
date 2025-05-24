using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VisualManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject restartUI;

    private PlayerControllerX playerControllerScript;
    private int score = 0;
    private int lives = 3;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        startButton.onClick.AddListener(() => StartGame());
        restartButton.onClick.AddListener(() => RestartGame());
        playerControllerScript.onGameEnd += PlayerControllerScript_onGameEnd; ;
        playerControllerScript.scoreIncreased += PlayerControllerScript_scoreIncreased;
        MoveLeftX.liveDecreased += MoveLeftX_liveDecreased;
    }

    private void PlayerControllerScript_onGameEnd(object sender, EventArgs e)
    {
        gameOver();
    }

    private void MoveLeftX_liveDecreased(object sender, EventArgs e)
    {
        lives--;
        livesText.text = "Lives: " + lives;
        if(lives == 0)
        {
            playerControllerScript.gameOver = true;
            gameOver();
        }
    }

    private void PlayerControllerScript_scoreIncreased(object sender, EventArgs e)
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    private void gameOver()
    {
        lives = 0;
        livesText.text = "Lives: 0";
        restartUI.SetActive(true);
    }
    private void StartGame()
    {
        Time.timeScale = 1f;
        startUI.SetActive(false);
        livesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }
    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
