using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    private readonly EnemyAnimationController _enemyAnimationController;
    private readonly LineOfSight _lineOfSight;
    private readonly float _attackDistance;

    public AttackState(EnemyFSM fsm) : base(fsm)
    {
        _enemyAnimationController = fsm.GetComponent<EnemyAnimationController>();
        _lineOfSight = fsm.GetComponent<LineOfSight>();
        _attackDistance = fsm.GetComponent<EnemyController>().attackDistance;
    }

    public override void Enter()
    {
        // Play the attack animation
       // _enemyAnimationController.PlayAttackAnimation();

        // Update the attack direction to face the player
        Vector2 direction = (Vector2)_lineOfSight.player.position - (Vector2)_fsm.transform.position;
        _enemyAnimationController.SetAttackDirection(direction);
    }

    public override void Update()
    {
        if (_lineOfSight.CanSeePlayer())
        {
            if ((Vector2.Distance(_fsm.transform.position, _lineOfSight.player.position) <= _attackDistance))
            {
                // Update the attack direction to face the player
                Vector2 direction = (Vector2)_lineOfSight.player.position - (Vector2)_fsm.transform.position;
                _enemyAnimationController.SetAttackDirection(direction);
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