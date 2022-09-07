using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalScore;

    public Text scoreText;

    public GameObject playButton;
    public GameObject gameOver;

    public PlayerMovement player;

    public static GameManager instance;

    public void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Start()
    {
        instance = this;
    }

    public void Play()
    {
        
        totalScore = 0;
        scoreText.text = scoreText.ToString();

        playButton.SetActive(false);
        gameObject.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        
    }

    public void IncreaseScore()
    {
        totalScore++;
        scoreText.text = scoreText.ToString();
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
}
