using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;
using Character;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int damage = 15;
    public PlayerController _controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _controller.TakeDamage(damage);
        }
    }
}