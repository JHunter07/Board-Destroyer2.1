
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEditor;

public class Boss : MonoBehaviour
{
    //again
    public static Boss Enemy;
    public float Speed = 3f;
    //private float playerClock;
    private Rigidbody2D rb;
   // private InputAction moveInput;
    Vector2 move;
    public bool canAttack; // Allows player to attack nearby enemies
    public GameObject nearbyPlayer; // Empty gameobject that will store nearby enemy upon collision (with trigger collider)


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Enemy = this;

    }
    void Start()
    {
       // moveInput = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * Speed;
    }

    // Update is called once per frame
    void Update()
    {
       // Vector2 rawMove = moveInput.ReadValue<Vector2>();
      //  move = rawMove;
        if (Input.GetKeyDown(KeyCode.E) && canAttack)
        {
            // Upon attacking, destroy nearbyEnemy if there is currently a reference to it 
            if (nearbyPlayer != null)
            {
                // Destroy(nearbyPlayer);
                TakeDamage(-5); // start with 10 health 
                
            }
            else
            {
                Debug.Log("I will destroy you!!!");
            }
        }
//}

    }
    //void Update()
    //{

    //    rb.linearVelocity = moveInput * Speed;
    //    if (Time.deltaTime > 0)
    //    {
    //        playerClock += 1;
    //    }

    //    if (playerClock > 30f)
    //    {
    //        playerClock = 0;
    //        Speed += 1;
    //    }
    //    else if (Speed >= 30)
    //    {
    //        Speed = 30f;
    //    }

    //}

    public void Move(InputAction.CallbackContext context)

    {
        //moveInput = context.ReadValue<Vector2>();
        // Debug.Log("YERR");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<Rigidbody2D>().simulated=false;
        Destroy(gameObject);
        Speed = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if an enemy enters collider
        if (collider.CompareTag("Player"))
        {
            canAttack = true; // Allow attack
            nearbyPlayer = collider.gameObject; // Sets collision object to the nearbyEnemy object reference
        }
    }
public void TakeDamage(int amt) {
     
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            canAttack = false; // Prevent attack
            nearbyPlayer = null; // Removes enemy from nearbyEnemy reference when enemy exits collider
        }
    }

}
