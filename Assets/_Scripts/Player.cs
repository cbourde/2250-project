using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player P;
    public float speed;
    public int maxHealth = 10;
    public Rigidbody rb;

    [Header("Stats")]
    public int strength = 1;
    public int dexterity = 1;
    public int constitution = 1;
    public int intelligence = 1;
    public int wisdom = 1;
    public int charisma = 1;
    private int _health;
 
    // Start is called before the first frame update
    void Awake()
    {
        if (P == null)
        {
            P = this;
        }
        else
        {
            Debug.LogError("Error: Player already exists");
        }
        rb = GetComponent<Rigidbody>();
        _health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xAxis, 0, zAxis);
        rb.MovePosition(pos + speed * movement.normalized);
        float direction = Vector3.Angle(Vector3.back, movement);
        if (movement.x > 0)
        {
            direction = -direction;
        }
        
        rb.MoveRotation(Quaternion.Euler(0, direction, 0));
        
        
    }

    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
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
}
