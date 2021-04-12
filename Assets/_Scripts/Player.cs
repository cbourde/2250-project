using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public static Player P; // Singleton player object
    public float jumpForce; // Jump force
    public int attackDamage = 5;
    private int _xp = 0;
    private int _xpToNextLevel = 50;
    private int _level = 1;
    
    //public float damageTimer = 2;   // Timer for repeated damage
    //public GameObject enemy;    // Enemy to damage or take damage from (to be replaced with a list)
    public Text healthDisplay;  // Health display UI text
    public Text deathMessage;   // Death message UI text
    public Text xpDisplay;
    public Rigidbody rb;
    public Vector3 movement;
    //public GameObject warrior;
    //public GameObject mage;

    // Stats (must be static for character creation to work properly)
    public static int strength = 1;
    public static int dexterity = 1;
    public static int constitution = 1;
    public static int intelligence = 1;
    public static int wisdom = 1;
    public static int charisma = 1;
    public static string charClass = "Warrior";
    public bool _hasJumped = false;
 
    void Awake()
    {
        // Initialize the singleton
        if (P == null)
        {
            P = this;
        }
        else
        {
            Debug.LogError("Error: Player already exists");
        }

        rb = GetComponent<Rigidbody>();

        // Set maximum health based on CON score
        maxHealth = 50 + 10 * (constitution - 1);
        health = maxHealth;

        // Initialize health display
        UpdateHealthDisplay();
        UpdateXPDisplay();

        // Set speed and jump based on DEX score
        movementSpeed += 0.025f * (dexterity - 1);
        jumpForce += 0.5f * (dexterity - 1);

        // Set attack damage based on STR score
        attackDamage += 5 * (strength - 1);

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

    void Update()
    {
        // Jump if space bar is pressed
        if (!_hasJumped && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        
    }

    void Move()
    {
        // Move player based on keyboard input
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        movement = new Vector3(xAxis, 0, zAxis);
        rb.MovePosition(pos + movementSpeed * movement.normalized);
        
        // Turn player in direction of movement if moving
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            

            float direction = Vector3.Angle(Vector3.back, movement);
            if (movement.x > 0)
            {
                direction = -direction;
            }
            rb.MoveRotation(Quaternion.Euler(0, direction, 0));
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
        _hasJumped = true;
    }

    public override void TakeDamage(int dmg) //gameObject takes damage
    {
        base.TakeDamage(dmg);
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (healthDisplay != null)
        {
            healthDisplay.text = "Health: " + health + " / " + maxHealth;
        }
        else
        {
            Debug.LogError("Error: Health display object is null");
        }
    }

    private void UpdateXPDisplay()
    {
        if (xpDisplay != null)
        {
            xpDisplay.text = "XP: " + _xp + " / " + _xpToNextLevel + "\n" + "Level: " + _level;
        }
        else
        {
            Debug.LogError("Error: XP display object is null");
        }
    }

    public override void Die() 
    {

        deathMessage.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            _hasJumped = false;
        }
    }

    public void AwardXP(int xp)
    {
        _xp += xp;
        if (_xp >= _xpToNextLevel)
        {
            _xpToNextLevel *= 2;
            LevelUp();
        }
        UpdateXPDisplay();
    }

    public void LevelUp()
    {
        _level++;
    }
    
}
