using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage(Player.P.attackDamage);
        }
    }
}
