using System;
using DefaultNamespace;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;

    private void Awake()
    {
        health = maxHealth;
        Game.Instance.AddTarget(this);
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Game.Instance.RemoveTarget(this);
            Destroy(gameObject);
        }
    }
}