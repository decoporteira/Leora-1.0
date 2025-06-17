using UnityEngine;
public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Vector2 movement;
    private Vector2 screenBounds;
    [SerializeField] Animator animator;
    public float wallJumpCooldown { get; set; }
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
       
    }
    void Update()
    {

        HandleMovement();
        ClampMovement();

        if (wallJumpCooldown >0f)
        {
            wallJumpCooldown -= Time.deltaTime;
        }
      
       
    }
    private void HandleMovement()
    {
        if (wallJumpCooldown > 0f) return;
        float input = Input.GetAxis("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
        if (input != 0)
        {
            animator.SetBool("isRunning", true);
            if (input < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


    }

    private void ClampMovement()
    {
        float clampX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        Vector2 pos = transform.position;
        pos.x = clampX;
        transform.position = pos;
    }
}
