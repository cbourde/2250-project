using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public bool takeDamage = false;

    public Stats damage;

    public float timer = 2;

    public GameObject enemy;

    public Text healthDisplay;

    void Awake()
    {
        maxHealth = 50 + 10 * (Player.constitution - 1);
        currentHealth = maxHealth;
    }

    /*
    public void TakeDamage() //gameObject takes damage
    {
        if (enemy.GetComponent<Enemy>().giveDamage) //checks if in range and then combat can occur

        {
            int damage = 10;
            currentHealth -= damage;
            Debug.Log(transform.name + " takes " + damage + " damage ");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    */

    public virtual void Die() //can be overwritten for either enemy
    {
        Destroy(gameObject);
    }



    void Start()
    {
        InvokeRepeating("TakeDamage", 1, 2);
    }
}