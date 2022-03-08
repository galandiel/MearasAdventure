using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggyController : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public AudioSource jumpSound;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpSound.Play();
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }

        if (betterJump)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
