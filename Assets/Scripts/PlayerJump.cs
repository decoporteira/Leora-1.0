using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private float doubleJumpForce = 6f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector2 wallJumpForce = new Vector2(5f, 8f);
    [SerializeField] private float wallJumpMovementCooldown = 0.2f;

    private PlayerMoviment playerMovement;
    private bool canDoubleJump;
    private float playerHalfHeight;
    private float playerHalfWidth;

    private void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
        playerHalfWidth = spriteRenderer.bounds.extents.x;
        playerMovement = GetComponent<PlayerMoviment>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CheckJumpType();
        }
        Debug.DrawRay(transform.position, Vector2.left * (playerHalfWidth + 0.1f), Color.yellow);
        Debug.DrawRay(transform.position, Vector2.right * (playerHalfWidth + 0.1f), Color.yellow);
        Debug.DrawRay(transform.position, Vector2.down * (playerHalfHeight + 0.1f), Color.yellow);
    }

    private void CheckJumpType()
    {
        bool isGrounded = GetIsGrounded();

        if (isGrounded)
        {
            Jump(jumpForce);
        }
        else
        {
            int direction = GetWallJumpDirection();
            if (direction == 0 && canDoubleJump && rigidBody.linearVelocity.y <= 0.1f)
            {
                DoubleJump();
            }
            else if (direction!= 0)
            {
                WallJump(direction);
            }

           
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GetIsGrounded();
    }

    
    private void DoubleJump()
    {
        rigidBody.linearVelocity = Vector2.zero;
        rigidBody.angularVelocity = 0;
        Jump(doubleJumpForce);
        canDoubleJump = false;
    }

    private void WallJump(int direction)
    {
        Vector2 force = wallJumpForce;
        force.x *= direction;
        rigidBody.linearVelocity = Vector2.zero;
        rigidBody.angularVelocity = 0;
        playerMovement.wallJumpCooldown = wallJumpMovementCooldown;
        rigidBody.AddForce(force, ForceMode2D.Impulse);
    }
    private int GetWallJumpDirection()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right, playerHalfWidth + 0.1f, LayerMask.GetMask("Ground")))
        {
            return -1;
        }
        if (Physics2D.Raycast(transform.position, Vector2.left, playerHalfWidth + 0.1f, LayerMask.GetMask("Ground")))
        {
            return 1;
        }
        return 0;
    }

    private bool GetIsGrounded()
    {
        bool hit = Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground"));
        if (hit)
        {
            canDoubleJump = true;
        }
        return hit;
    }
    private void Jump(float force) {
        rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
