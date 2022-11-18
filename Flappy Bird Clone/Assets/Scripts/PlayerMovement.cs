using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private const float jumpForce = 9f;
    private Rigidbody2D playerRig;
    private State state;

    #region Serielized
    [SerializeField] GameObject spawnManager;
    [SerializeField] GameObject touchText;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject pauseButton;
    #endregion

    private enum State {
        WaitingToStart,
        Playing,
        Dead
    }

    void Awake()
    {
        playerRig = GetComponent<Rigidbody2D>();
        playerRig.bodyType = RigidbodyType2D.Static;
        state = State.WaitingToStart;
    }

    void Update()
    {
        switch (state)
        {
            default:
            case State.WaitingToStart:
                touchText.SetActive(true);
                scoreText.SetActive(false);
                pauseButton.SetActive(false);
                spawnManager.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                {
                    if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject) return; // Prevents the player from jumping when pressing the pause button
                    state = State.Playing;
                    playerRig.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                }
                break;
            case State.Playing:
                touchText.SetActive(false);
                scoreText.SetActive(true);
                pauseButton.SetActive(true);
                spawnManager.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject) return; // Prevents the player from jumping when pressing the pause button
                    Jump();
                }

                transform.eulerAngles = new Vector3(0, 0, playerRig.velocity.y * 0.5f);
                break;
            case State.Dead:
                break;
        }
    }

    public void Jump()
    {
        playerRig.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.ShowGameOver();
        Time.timeScale = 0;
    }
}
