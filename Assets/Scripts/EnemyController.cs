using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem smokeEffect;
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    private Animator animator;
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    private float dirx;
    private float diry;
    bool broken;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
        broken = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);

        dirx = Input.GetAxis("Horizontal");
        diry = Input.GetAxis("Vertical");

        animator.SetFloat("PosX", dirx);
        animator.SetFloat("PosY", diry);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if(player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;

        //optional if you added the fixed animation
        //animator.SetTrigger("Fixed");

        smokeEffect.Stop();
    }
}
