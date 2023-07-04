using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    //Animator variables:
    private Animator _animator;
    public Vector2 direction;
    
    private static readonly int DirectionX = Animator.StringToHash("DirectionX");
    private static readonly int DirectionY = Animator.StringToHash("DirectionY");
    private static readonly int AttackDirectionX = Animator.StringToHash("AttackDirectionX");
    private static readonly int AttackDirectionY = Animator.StringToHash("AttackDirectionY");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // Actualiza la dirección en el Animator Controller
        _animator.SetBool(IsMoving, Mathf.Abs( direction.x) + Mathf.Abs( direction.y) > 0);
        _animator.SetFloat(DirectionX, direction.x);
        _animator.SetFloat(DirectionY, direction.y);
    }
    //Attack Animations (MUTANT):
    public void SetAttackDirection(Vector2 direction)
    {
        _animator.SetBool(IsAttacking, Mathf.Abs( direction.x) + Mathf.Abs( direction.y) > 0);
        _animator.SetFloat(AttackDirectionX, direction.x);
        _animator.SetFloat(AttackDirectionY, direction.y);
    }
    //For Stopping enemyAttack Looping Animation
    public void StopAttackAnimation()
    {
        _animator.SetBool(IsAttacking, false);
    }

}