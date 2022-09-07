using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    
    GameManager manager; //puxando la do game manager

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        manager.score++;
        manager.scoreText.text = manager.score.ToString();
    }
}
