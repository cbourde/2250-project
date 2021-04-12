using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration = 2f;
    public int damage = 10;
    private float lifeTimer;
    // Start is called before the first frame update
    void Start()
    {
      lifeTimer = lifeDuration;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=transform.forward*speed*Time.deltaTime;
        // the arrow will be fired in the forward direction at a certain speed
        lifeTimer-= Time.deltaTime;
        if(lifeTimer<=0f){
          Destroy (gameObject);
        }
        //after 2 seconds the game object will be destroyed to not overload the game

    }
    private void OnTriggerEnter(Collider other)
      {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
      }
      //if the arrow interacts with the enemy is will destroy it

}
