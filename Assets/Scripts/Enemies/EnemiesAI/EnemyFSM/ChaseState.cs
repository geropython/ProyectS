using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    private EnemyAnimationController _enemyAnimationController;
    private LineOfSight _lineOfSight;
    private float _attackDistance;
    public ChaseState(EnemyFSM fsm) : base(fsm)
    {
        _enemyAnimationController = fsm.GetComponent<EnemyAnimationController>();
        _lineOfSight = fsm.GetComponent<LineOfSight>();
        _attackDistance = fsm.GetComponent<EnemyController>().attackDistance;
    }
    public override void Enter()
    {
        // Play the chase animation
        //_enemyAnimationController.PlayChaseAnimation();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Update()
    {
        if (_lineOfSight.CanSeePlayer())
        {
            if ((Vector2.Distance(_fsm.transform.position, _lineOfSight.player.position) <= _attackDistance))
            {
                // Transition to Attack state
                _fsm.ChangeState(new AttackState(_fsm));
                return;
            }

            if (!_fsm.GetComponent<EnemyController>().isAttacking)
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            // Transition to Patrol state
            _fsm.ChangeState(new PatrolState(_fsm));
        }
    }
    private void MoveTowardsPlayer()
    {
        Vector2 direction = (Vector2)_lineOfSight.player.position - (Vector2)_fsm.transform.position;
        float moveSpeed = _fsm.GetComponent<EnemyController>().moveSpeed;
        _fsm.transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));

        // Update the enemy direction in the EnemyAnimationController
        _enemyAnimationController.direction = direction;
    }

}