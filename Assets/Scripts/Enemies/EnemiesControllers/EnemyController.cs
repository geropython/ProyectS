using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enemy Basic Controller, movement, and related stuff.

    //Enemy AI
    [SerializeField] private LineOfSight lineOfSight;

    //Movement  Variables.
    public float moveSpeed = 5f;

    //Animations
    private EnemyAnimationController _enemyAnimationController;

    //Attacks:
    [SerializeField] private float attackDistance = 1f;
    public float attackCooldown = 2f;
    private float timeSinceLastAttack = 0f;
    
    //Stop  moving when attack is active:
    public bool isAttacking = false;
    
    private void Start()
    {
        _enemyAnimationController = GetComponent<EnemyAnimationController>();
    }
    //Attack Delay- Cooldown on Update
    private void Update()   //MODIFICAR PERFORMANCE?¿
    {
        if (lineOfSight.CanSeePlayer())
        {
            if (Vector2.Distance(transform.position, lineOfSight.player.position) <= attackDistance)
            {
                Attack();
            }
            else
            {
                _enemyAnimationController.StopAttackAnimation();
                MoveTowardsPlayer(lineOfSight.player.position);

                
                isAttacking = false;
            }
        }
        else
        {
            _enemyAnimationController.StopAttackAnimation();

            
            isAttacking = false;
        }
    }
    private void Attack()
    {
        print("Attacking Player");
        Vector2 direction = lineOfSight.player.position - transform.position;

        // Attack direction from EnemyAnimationController
        _enemyAnimationController.SetAttackDirection(direction);

      
        isAttacking = true;
    }
    private void MoveTowardsPlayer(Vector2 targetPosition)
    {
        print("Chasing Player");

        //Is attacking bool condition checked:
        if (!isAttacking)
        {
            Vector2 direction = targetPosition - (Vector2)transform.position;
            transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));

            // Updates the attack Direction from AnimationController
            _enemyAnimationController.direction = direction;
        }
    }

    //Attack Range Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}