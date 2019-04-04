using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpStrength;

    public bool grounded;
    public LayerMask checkGround;

    private Rigidbody2D playerBody;
    private Collider2D playerCollider;

    private Animator playerAnimator;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(playerCollider, checkGround);
        playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) 
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpStrength);
        }
    }
}
