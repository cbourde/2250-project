﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public float viewRadius = 10f;
    public float attackReach = 2f;
    public bool canAttack = false;
    public int attackDamage = 10;
    public float attackInterval = 1.5f;
    public int _attackTimer;

    Transform target;

    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerTracker.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        _attackTimer = (int)(attackInterval * 60);
    }

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= viewRadius) //move towards target if in range
        {
            agent.SetDestination(target.position);

            if (distance <= attackReach)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }

            _attackTimer -= 1;
            if (_attackTimer <= 0 && canAttack)
            {
                Attack();
                _attackTimer = (int)(attackInterval * 60);
            }

            /*
            if (distance <= viewRadius)
            {
                gameObject.GetComponent<EnemyStats>().takeDamage = true; //can give and receive damage at the viewRange
                giveDamage = true;

            } else
            {
                gameObject.GetComponent<EnemyStats>().takeDamage = false;
                giveDamage = false;
            }
            */
        }

    }

    void OnDrawGizmosSelected() //visual boundary of enemy field
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }

    private void Attack()
    {
        Player.P.TakeDamage(attackDamage);
    }

    public override void Die()
    {
        canAttack = false;
        Destroy(gameObject);
    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        Debug.Log("Enemy takes " + dmg + " damage [Health: " + health + "/" + maxHealth + "]");
    }


}
