using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    [SerializeField] private ParticleSystem explosion;


    public void TakeDamage(float amout){
        health -= amout;
        Debug.Log(health);
        if (health < 0f){
            Die();
        }
    }

    void Die(){
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
