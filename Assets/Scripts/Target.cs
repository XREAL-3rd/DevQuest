using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }
}