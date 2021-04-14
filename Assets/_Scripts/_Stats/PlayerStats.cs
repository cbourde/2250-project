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

    public virtual void Die() //can be overwritten for either enemy
    {
        Destroy(gameObject);
    }



    void Start()
    {
        InvokeRepeating("TakeDamage", 1, 2);
    }
}