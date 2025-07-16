using System;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float jump;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    [SerializeField] Animator animator;

    void Start()
    {
        animator.SetBool("isJumping", false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetBool("isJumping", !isGrounded());
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        animator.SetBool("isJumping", true);
        rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
       

    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);


    }
    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawWireCube(transform.position -transform.up * castDistance, boxSize);
    }
}
