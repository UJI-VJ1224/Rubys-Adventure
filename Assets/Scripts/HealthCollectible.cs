using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthAmount = 20;

    private void OnTriggerEnter2D(Collider2D other) {
        
        RubyController rc = other.GetComponent<RubyController>();

        if (rc != null && rc.Health < rc.maxHealth){
            rc.ChangeHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
