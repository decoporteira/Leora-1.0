using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float enemySpeed = 1;

    void Update()
    {
        rb.linearVelocity = -Vector2.left * enemySpeed;
    }
}
