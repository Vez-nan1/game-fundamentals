using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementPlayer : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private float currentMovespeed;
    private float currentJumpSpeed;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;


    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        currentMovespeed = speed;
        currentJumpSpeed = jumpHeight;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jumpHeight = currentJumpSpeed;
            speed = currentMovespeed;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
        //if (Input.GetKeyDown(KeyCode.Space))

        //TakeDamage(20);

    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "SpeedBoost":
                speed = 25f;
                break;
            case "Jumpad":
                jumpHeight = 25f;
                break;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    if(currentHealth < 1)
        {
            Destroy(gameObject);
        }
    }

}
