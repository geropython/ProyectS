using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] public int maxHealth;
    
    public void TakeDamage(int damage)
    {
       health -= damage;
        Debug.Log("Damage"+health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Dead");
        }
    }
    private void Start()
    {
        health = maxHealth;
    }
  
}
