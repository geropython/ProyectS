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
   private void Start()
   {
      _enemyAnimationController = GetComponent<EnemyAnimationController>();
   }
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

      // Actualiza la dirección en el script EnemyAnimationController
      _enemyAnimationController.direction = direction;
   }

}