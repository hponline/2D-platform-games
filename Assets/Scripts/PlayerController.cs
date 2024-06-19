using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject playerPos;
    Rigidbody2D playerRb;
    Animator playerAnimator;
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f, jumpFrequency = 1.0f ,nextJumpTime;

    public float yBorder = -50.0f;

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

        // Zýplama aralýgý
        if (Input.GetAxis("Vertical") > 0 && isGround && (nextJumpTime <Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }

        // Karakter zemine düþerse sahne resetler
        if (playerPos.transform.position.y < yBorder)
        {
            // Sahneyi yeniden yükle
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
       

    // Yana hareket
    void HorizontalMove()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRb.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRb.velocity.x));
    }

    // Yüz çevirme
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    // Zýplama
    void jump()
    {
        playerRb.AddForce(new Vector2(0, jumpSpeed));
    }

    // Karakterin ayaðýndaki collider
    void OngroundCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            Invoke("ColorClassic", 0.5f);

        }
    }

    void ColorClassic()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
