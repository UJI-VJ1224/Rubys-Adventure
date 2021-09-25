using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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
    }
}
