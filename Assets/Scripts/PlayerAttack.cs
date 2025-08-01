using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
       
    }

    void Attack()
    {
        Debug.Log("Player attacked!");

        animator.SetTrigger("attack");

    }

  
}
