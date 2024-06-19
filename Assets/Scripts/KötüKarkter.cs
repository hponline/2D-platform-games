using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KötüKarkter : MonoBehaviour
{
    Animator animator;
    Rigidbody2D playerRb;
    public float moveSpeed = 1.0f;

    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HorizontalMove()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, animator.velocity.y);
        animator.SetFloat("playerSpeed", Mathf.Abs(playerRb.velocity.x));
    }

    // Yüz çevirme
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
}
