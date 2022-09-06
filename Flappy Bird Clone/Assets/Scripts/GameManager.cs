using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalScore;

    public Text textScore;

    public static GameManager instance;

    void Start()
    {
        instance = this;
    }
    
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        Debug.Log("Game Over");
    }
}
