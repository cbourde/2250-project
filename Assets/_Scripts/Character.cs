using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generic base class for players and enemies
public abstract class Character : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public int maxHealth;
    private int _health;
    
    void Awake()
    {
        health = maxHealth;
    }

    public int health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    public abstract void Die();

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
