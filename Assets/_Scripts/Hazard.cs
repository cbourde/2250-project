using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An object containing this script will damage a player or enemy who comes into contact with it
public class Hazard : MonoBehaviour
{
    public int damage = 20;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.P.TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.TakeDamage(damage);
        }
    }
}
