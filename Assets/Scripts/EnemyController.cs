using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem smokeEffect;

    private Animator animator;
    //private Rigidbody2D rigidbody2D;
    private float dirx;
    private float diry;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxis("Horizontal");
        diry = Input.GetAxis("Vertical");

        animator.SetFloat("PosX", dirx);
        animator.SetFloat("PosY", diry);
    }/*
    public void Fix()
    {
        //broken = false;
        //rigidbody2D.simulated = false;

        //optional if you added the fixed animation
        //animator.SetTrigger("Fixed");

        smokeEffect.Stop();
    }*/
}
