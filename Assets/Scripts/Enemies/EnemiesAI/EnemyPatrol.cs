using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
     //Waypoint based- patrol for basic Enemy AI
     [SerializeField] public Transform[] waypoints;
     private EnemyController _enemyController;
     private int _currentWaypointIndex = 0;
     private Transform _currentWaypoint;
     private EnemyAnimationController _enemyAnimationController;

     private void Start()
     {
          _enemyController = GetComponent<EnemyController>();
          _enemyAnimationController = GetComponent<EnemyAnimationController>();

          if (waypoints.Length > 0)
          {
               _currentWaypoint = waypoints[_currentWaypointIndex];
          }
     }
     private void Update()
     {
          if (_currentWaypoint != null)
          {
               MoveToWaypoint();  
          }
     }
            
     private void MoveToWaypoint()
     {
          //Check attack bool before moving the enemy:
          if (!_enemyController.isAttacking)
          {
               Vector2 direction = _currentWaypoint.position - transform.position;
               transform.Translate(direction.normalized * (_enemyController.moveSpeed * Time.deltaTime));

               // Updates attack direction from animationController
               _enemyAnimationController.direction = direction;

               if (Vector2.Distance(transform.position, _currentWaypoint.position) < 0.1f)
               {
                    _currentWaypointIndex++;
                    if (_currentWaypointIndex >= waypoints.Length)
                    {
                         _currentWaypointIndex = 0;
                    }

                    _currentWaypoint = waypoints[_currentWaypointIndex];
               }
          }
     }
}