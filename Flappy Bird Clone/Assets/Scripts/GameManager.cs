using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int totalScore;

    public Text scoreText;

    public GameObject playButton;
    public GameObject gameOver;

    public PlayerMovement player;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void IncreaseScore()
    {
        totalScore++;
    }

    public void ShowGameOver()
    {
        Debug.Log("Game Over");
    }
}
