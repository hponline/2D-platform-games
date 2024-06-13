using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnimator;
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f, jumpFrequency = 1.0f ,nextJumpTime;

    bool facingRight = true;
    public bool isGround = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        HorizontalMove();
        OngroundCheck();

        if (playerRb.velocity.x <0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRb.velocity.x >0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGround && (nextJumpTime <Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }
    }
       

    // Yana hareket
    void HorizontalMove()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRb.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRb.velocity.x));
    }

    // Y�z �evirme
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void jump()
    {
        playerRb.AddForce(new Vector2(0, jumpSpeed));
    }

    void OngroundCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGround);
    }
}