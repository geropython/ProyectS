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

    private void Start()
    {
        _enemyAnimationController = GetComponent<EnemyAnimationController>();
    }

    //Attack Delay- Cooldown on Update
    private void Update()
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
            }
        }
        else
        {
            _enemyAnimationController.StopAttackAnimation();
        }
    }

    private void Attack()
    {
        print("Attacking Player");
        Vector2 direction = lineOfSight.player.position - transform.position;

        // Actualiza la dirección de ataque en el script EnemyAnimationController
        _enemyAnimationController.SetAttackDirection(direction);
    }

    private void MoveTowardsPlayer(Vector2 targetPosition)
    {
        print("Chasing Player");
        Vector2 direction = targetPosition - (Vector2)transform.position;
        transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));

        // Actualiza la dirección en el script EnemyAnimationController
        _enemyAnimationController.direction = direction;
    }

    //Attack Range Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}