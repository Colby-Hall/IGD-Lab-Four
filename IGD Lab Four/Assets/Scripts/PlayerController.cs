using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpStrength;

    public bool grounded;
    public LayerMask checkGround;

    public Text scoreText;
    public Text highScoreText;

    private Rigidbody2D playerBody;
    private Collider2D playerCollider;

    private Animator playerAnimator;

    private float timer;
    private bool doubleJump;

    void Start()
    {
        doubleJump = false;
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        timer += Time.deltaTime;
        scoreText.text = "Score: " + Math.Floor(timer).ToString();
        grounded = Physics2D.IsTouchingLayers(playerCollider, checkGround);
        playerBody.velocity = new Vector2(moveSpeed + timer, playerBody.velocity.y);

        

        if (Input.GetKeyDown(KeyCode.Space) && grounded) 
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpStrength);
            doubleJump = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && doubleJump) {
                doubleJump = false;
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpStrength);
            }
        }
        

        playerAnimator.SetBool("Grounded", grounded);
        

       
    }
}
