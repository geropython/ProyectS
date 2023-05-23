using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
     //Waypoint based- patrol for basic Enemy AI
     //Enemy will move towards different waypoints, with a determined speed.
     [SerializeField] private Transform[] waypoints;
     [SerializeField] private float moveSpeed = 5f;

     private int _currentWaypointIndex = 0;
     private Transform _currentWaypoint;

     private void Start()
     {
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
          Vector2 direction = _currentWaypoint.position - transform.position;
          transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));

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
