using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : Character
{
    public float viewRadius = 10f;
    public float attackReach = 2f;
    public bool canAttack = false;
    public int attackDamage = 10;
    public float attackInterval = 1.5f;
    public int _attackTimer;
    public int xpValue = 30;
    public int enemyHealth = 50;

    protected Transform target;

    protected NavMeshAgent agent;

    public GameObject Arrow;

    public int arrowDamage = 7;
    public float arrowLife = 2f;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerTracker.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        _attackTimer = (int)(attackInterval * 60);
    }

    void Awake()
    {
        maxHealth = enemyHealth;
        health = maxHealth;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Follow(distance);
    }

    void OnDrawGizmosSelected() //visual boundary of enemy field
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackReach);
    }

    public override void Die()
    {
        canAttack = false;
        Player.P.AwardXP(xpValue);
        Destroy(gameObject);
    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        Debug.Log("Enemy takes " + dmg + " damage [Health: " + health + "/" + maxHealth + "]");
    }

    protected void Follow(float distance)
    {

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
                _attackTimer = (int)(attackInterval * 60);
            }
        }
    }

}
