using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float jumpForce;

    public Rigidbody2D playerRig;

    public GameObject GameOver;

    void Start()
    {
        playerRig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            playerRig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // If in mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                playerRig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
