using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Enemy")
        {
            obj.transform.Rotate(0f, 180f, 0f);
        }
    }
}