using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    public Vector2 direction;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Reproduce la animación de caminar correspondiente a la dirección
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                animator.Play("MutantWalkRight");
            }
            else
            {
                animator.Play("MutantWalkLeft");
            }
        }
        else
        {
            if (direction.y > 0)
            {
                animator.Play("MutantWalkBack");
            }
            else
            {
                animator.Play("MutantIdleWalk");
            }
        }
    }
}