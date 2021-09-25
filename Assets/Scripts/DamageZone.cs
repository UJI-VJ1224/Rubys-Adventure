using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        
        RubyController rc = other.GetComponent<RubyController>();

        if (rc != null){
            rc.ChangeHealth(-20);
        }
    }
}
