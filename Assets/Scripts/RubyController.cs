using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // void Start()
    // {
        
    // }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector2 position = transform.position;
        
        position.x = position.x + 5f * horizontal * Time.deltaTime;
        position.y = position.y + 5f * vertical * Time.deltaTime;

        transform.position = position;
    }
}
