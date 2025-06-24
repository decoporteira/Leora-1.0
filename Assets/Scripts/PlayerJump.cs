using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float jump;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        Debug.Log("Player jumped!");
        rb.AddForce(new Vector2(rb.linearVelocity.x, jump));

    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
       Gizmos.DrawWireCube(transform.position -transform.up * castDistance, boxSize);
    }
}
