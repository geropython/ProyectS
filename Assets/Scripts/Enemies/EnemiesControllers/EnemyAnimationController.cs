using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    //Animator variables:
    private Animator animator;
    public Vector2 direction;
    private static readonly int DirectionX = Animator.StringToHash("DirectionX");
    private static readonly int DirectionY = Animator.StringToHash("DirectionY");
    private static readonly int AttackDirectionX = Animator.StringToHash("AttackDirectionX");
    private static readonly int AttackDirectionY = Animator.StringToHash("AttackDirectionY");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // Actualiza la dirección en el Animator Controller
        animator.SetBool(IsMoving, Mathf.Abs( direction.x) + Mathf.Abs( direction.y) > 0);
        animator.SetFloat(DirectionX, direction.x);
        animator.SetFloat(DirectionY, direction.y);
    }
    //Attack Animations (MUTANT):
    public void SetAttackDirection(Vector2 direction)
    {
        animator.SetBool(IsAttacking, Mathf.Abs( direction.x) + Mathf.Abs( direction.y) > 0);
        animator.SetFloat(AttackDirectionX, direction.x);
        animator.SetFloat(AttackDirectionY, direction.y);
    }

}