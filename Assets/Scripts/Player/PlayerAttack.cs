using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private Collider2D attackCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private float damage;
    
    public void Attack()
    {
        transform.position = playerModel.Forward;
        attackCollider.enabled = true;
        Invoke(nameof(TurnOffCollider), playerModel.AttackTime);
    }

    private void TurnOffCollider()
    {
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        damageable?.Damage(damage);
    }
}
