using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private const float jumpForce = 10f;

    private Rigidbody2D playerRig;

    public GameObject GameOver;

    void Awake()
    {
        playerRig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
