using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Speed & movement
    public float speed;
    public Rigidbody2D rb;
    public float movementSmoothness;

    // Jumps + IsOnGround
    public float jumpForce;
    public bool isJumping;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    
    // Flip & Animations
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // Misc
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("verticalVelocity", rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            Jump();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        MovePlayer(horizontalMovement);
        Flip();
    }

    void MovePlayer(float movement)
    {
        Vector3 targetVelocity = new Vector2(movement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothness);
    }

    void Flip()
    {
        if (rb.velocity.x > 0.3)
        {
            spriteRenderer.flipX = false;
        }

        if (rb.velocity.x < -0.3)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Jump()
    {
        if (isGrounded && isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
