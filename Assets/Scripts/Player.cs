using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool doubleJump;
    private float destroyDelay = 0.65f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    // runs once per frame
    void Update()
    {
        // Debug.Log("Update time :" + Time.deltaTime);
        horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            animator.SetBool("IsJumping", false);
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;

                animator.SetBool("IsJumping", true);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Crouch();

        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && IsGrounded())
        {
            animator.SetBool("IsHurt", true);
            Destroy(gameObject, destroyDelay);
        }
    }

    public bool IsGrounded()
    {
        // Debug.Log("IsGrounded :" + Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void Crouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("IsCrouch", true);
        }

        if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("IsCrouch", false);
        }
    }
}
