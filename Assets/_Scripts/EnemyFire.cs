using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject Arrow;

    public float attackInterval = 2f;
    public float currentInterval;

    private Vector3 position; 

    void Start()
    {
        currentInterval = attackInterval;
    }
    void Update()
    {
        
            currentInterval -= Time.deltaTime;

            if (currentInterval <= 0)
            {
                shootArrow();
                currentInterval = attackInterval;
            }
        
        //the bow and arrow is always firing
    }
    void shootArrow()
    {
        GameObject clone = Instantiate<GameObject>(Arrow, transform.position, transform.rotation);
        clone.transform.position = transform.position;
        EnemyProjectile p = clone.GetComponent<EnemyProjectile>();
        p.damage = 8;
    }
}
