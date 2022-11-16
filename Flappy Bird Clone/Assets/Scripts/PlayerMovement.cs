using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float jumpForce = 9f;
    private Rigidbody2D playerRig;
    private State state;

    [SerializeField] GameObject spawnManager;

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
                spawnManager.SetActive(false);
                if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    playerRig.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                }
                break;
            case State.Playing:
                spawnManager.SetActive(true);
                if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
                {
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
