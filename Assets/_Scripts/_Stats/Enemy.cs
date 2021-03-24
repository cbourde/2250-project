using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float viewRadius = 10f;
    public bool giveDamage = false;
    Transform target;

    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerTracker.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= viewRadius) //move towards target if in range
        {
            agent.SetDestination(target.position);

            if (distance <= viewRadius)
            {
                gameObject.GetComponent<EnemyStats>().takeDamage = true; //can give and receive damage at the viewRange
                giveDamage = true;

            } else
            {
                gameObject.GetComponent<EnemyStats>().takeDamage = false;
                giveDamage = false;
            }
        }

    }

    void OnDrawGizmosSelected() //visual boundary of enemy field
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
