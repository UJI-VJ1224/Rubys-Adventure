using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;
        position.x = position.x + 0.5f * horizontal * Time.deltaTime;
        position.y = position.y + 0.5f * vertical * Time.deltaTime;
        transform.position = position;
    }
}
