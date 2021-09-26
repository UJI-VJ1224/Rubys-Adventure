using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    
    public float speed = 2f;
    public int maxHealth = 100;
    public float timeInvicible = 2f;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float horizontal, vertical;
    
    public int Health { get {return currentHealth;}}
    private int currentHealth;
    
    private bool isInvincible;
    private float invincibleTimer;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void FixedUpdate() {
        
        moveVelocity.x = horizontal * speed;
        moveVelocity.y = vertical * speed;
        rb.velocity = moveVelocity;
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(!Mathf.Approximately(moveVelocity.x, 0.0f) || !Mathf.Approximately(moveVelocity.y, 0.0f))
        {
            lookDirection.Set(moveVelocity.x, moveVelocity.y);
            lookDirection.Normalize();
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", moveVelocity.magnitude);

        if (isInvincible){

            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer < 0) isInvincible = false;
        }
    }

    public void ChangeHealth(int amount){

        if (amount < 0){

            if (isInvincible) return;

            isInvincible = true;
            invincibleTimer = timeInvicible;
            animator.SetTrigger("Hit");
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
