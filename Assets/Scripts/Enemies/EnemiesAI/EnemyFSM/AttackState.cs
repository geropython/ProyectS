using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    private readonly EnemyAnimationController _enemyAnimationController;
    private readonly LineOfSight _lineOfSight;
    private readonly float _attackDistance;
    private readonly float _attackCooldown;
    private float _timeSinceLastAttack ;

    public AttackState(EnemyFSM fsm) : base(fsm)
    {
        _enemyAnimationController = fsm.GetComponent<EnemyAnimationController>();
        _lineOfSight = fsm.GetComponent<LineOfSight>();
        _attackDistance = fsm.GetComponent<EnemyController>().attackDistance;
        _attackCooldown = fsm.GetComponent<EnemyController>().attackCooldown;
    }

    public override void Enter()
    {
        // Update the attack direction to face the player
        Vector2 direction = (Vector2)_lineOfSight.player.position - (Vector2)_fsm.transform.position;
        _enemyAnimationController.SetAttackDirection(direction);
        
        // Set isAttacking to true
        _fsm.GetComponent<EnemyController>().isAttacking = true;
        _timeSinceLastAttack = 0f;
    }

    public override void Exit()
    {
        // Set isAttacking to false
        _fsm.GetComponent<EnemyController>().isAttacking = false;

        // Stop the attack animation
        _enemyAnimationController.StopAttackAnimation();
    }

    public override void Update()
    {
        _timeSinceLastAttack += Time.deltaTime;

        if (_lineOfSight.CanSeePlayer())
        {
            if ((Vector2.Distance(_fsm.transform.position, _lineOfSight.player.position) <= _attackDistance))
            {
                // Update the attack direction to face the player
                Vector2 direction = (Vector2)_lineOfSight.player.position - (Vector2)_fsm.transform.position;
                _enemyAnimationController.SetAttackDirection(direction);

                if (_timeSinceLastAttack >= _attackCooldown)
                {
                    // Attack the player
                    // ...

                    _timeSinceLastAttack = 0f;
                }
            }
            else
            {
                // Transition to Chase state
                _fsm.ChangeState(new ChaseState(_fsm));
                return;
            }
        }
        else
        {
            // Transition to Patrol state
            _fsm.ChangeState(new PatrolState(_fsm));
            return;
        }
    }
}