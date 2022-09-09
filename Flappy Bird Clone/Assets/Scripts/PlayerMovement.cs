using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private const float jumpForce = 9f;

    private Rigidbody2D playerRig;

    public GameObject GameOver;

    private State state;

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
                if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    playerRig.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                }
                // If in mobile
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        Jump();
                    }
                }
                break;
            case State.Playing:
                if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
                {
                    Jump();
                }

                // If in mobile
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        Jump();
                    }
                }
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
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
