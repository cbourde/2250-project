using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player P;
    public float speed;
    public float jumpForce;
    public int maxHealth = 10;
    public Rigidbody rb;
    public GameObject warrior;
    public GameObject mage;

    [Header("Stats")]
    public static int strength = 1;
    public static int dexterity = 1;
    public static int constitution = 1;
    public static int intelligence = 1;
    public static int wisdom = 1;
    public static int charisma = 1;
    public static string charClass = "Warrior";

    private int _health;
    public bool _hasJumped = false;
 
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
        maxHealth += 5 * (constitution - 1);
        _health = maxHealth;
        speed += 0.025f * (dexterity - 1);
        jumpForce += 0.5f * (dexterity - 1);
    }

    void Update()
    {
        if (!_hasJumped && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    /*private void Start()
    {
        if (charClass.Equals("Warrior"))
        {
            gameObject = warrior;
        }
    }*/

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

    void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
        _hasJumped = true;
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            _hasJumped = false;
        }
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
