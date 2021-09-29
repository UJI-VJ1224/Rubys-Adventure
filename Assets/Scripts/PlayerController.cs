using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 3.0f;
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;
    public float timeInvincible = 2.0f;
    bool isInvencible;
    float invencibleTimer;
    public AudioClip shot;
    public AudioClip hit;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    Rigidbody2D rigidbody2d;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        position = position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        if (isInvencible)
        {
            invencibleTimer -= Time.deltaTime;
            if(invencibleTimer < 0)
            {
                isInvencible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if (isInvencible)
            {
                return;
            }
            isInvencible = true;
            invencibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
        //PlayOneShot(shot);
    }
}
