using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public bool takeDamage = false;

    public Stats damage;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage ");

        if( currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die() //can be overwritten for either enemy
    {
        Destroy(gameObject);
    }

    void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (takeDamage)
            {
                TakeDamage(10);
            }            
        }
    }
}
