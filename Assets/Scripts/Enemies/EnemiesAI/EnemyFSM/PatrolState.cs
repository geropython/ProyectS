using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    private readonly EnemyAnimationController _enemyAnimationController;
    private readonly Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private Transform _currentWaypoint;
    private readonly LineOfSight _lineOfSight;

    public PatrolState(EnemyFSM fsm) : base(fsm)
    {
        _enemyAnimationController = fsm.GetComponent<EnemyAnimationController>();
        _waypoints = fsm.GetComponent<EnemyPatrol>().waypoints;
        _lineOfSight = fsm.GetComponent<LineOfSight>();
    }

    public override void Enter()
    {
        // Play the patrol animation
        //_enemyAnimationController.PlayPatrolAnimation();  ---> WAL ANIMATION

        if (_waypoints.Length > 0)
        {
            _currentWaypointIndex = 0;
            _currentWaypoint = _waypoints[_currentWaypointIndex];
        }
    }
    public override void Update()
    {
        if (_lineOfSight.CanSeePlayer())
        {
            // Transition to Chase state
            _fsm.ChangeState(new ChaseState(_fsm));
            return;
        }

        if (_currentWaypoint != null && !_fsm.GetComponent<EnemyController>().isAttacking)
        {
            MoveTowardsWaypoint();
        }
    }

    private void MoveTowardsWaypoint()
    {
        Vector2 direction = (Vector2)_currentWaypoint.position - (Vector2)_fsm.transform.position;
        float moveSpeed = _fsm.GetComponent<EnemyController>().moveSpeed;
        _fsm.transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));

        // Update the enemy direction in the EnemyAnimationController
        _enemyAnimationController.direction = direction;

        if ((direction).sqrMagnitude < 0.1f * 0.1f)
        {
            // Change to the next waypoint
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= _waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
            _currentWaypoint = _waypoints[_currentWaypointIndex];
        }
    }

}