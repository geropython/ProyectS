using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   //Enemy Basic Controller, movement, and related stuff.
   [SerializeField] private LineOfSight lineOfSight;
   [SerializeField] private float moveSpeed = 5f;

   private void Update()
   {
      if (lineOfSight.CanSeePlayer())
      {
         
         MoveTowardsPlayer(lineOfSight.player.position);
      }
   }

   private void MoveTowardsPlayer(Vector2 targetPosition)
   {
       print("Chasing Player");
      Vector2 direction = targetPosition - (Vector2)transform.position;
      transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime));
   }
    
}
