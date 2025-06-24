using UnityEngine;
public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Vector2 movement;
    [SerializeField] Animator animator;
    void Update()
    {
        HandleMovement();  
    }
    private void HandleMovement()
    {   
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

}
