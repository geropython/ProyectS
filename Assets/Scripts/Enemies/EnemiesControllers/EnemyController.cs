using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Movement Variables
    public float moveSpeed = 5f;

    //Attacks
    [SerializeField] public float attackDistance = 1f;
    public float attackCooldown = 2f;
    public bool isAttacking;

    //Attack Range Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}