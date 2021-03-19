using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player P;
    public float speed;
    public Rigidbody rb;
 
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
}
