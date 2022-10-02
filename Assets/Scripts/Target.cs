using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float target_health = 10f; // Total health of the target.
    
    public void GetHit(float damage)
    {
        Debug.Log("Target Damanged");
        target_health -= damage;
        if (target_health <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Target Destroyed");
        }
    }
}
