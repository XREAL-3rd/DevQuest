using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour {
    public GameObject ExplosionEffect;

    private int health = 10;

    private void Break() {
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void GetNormalAttacked() {
        health--;
        if (health <= 0)
            Break();
    }

    public void GetCriticalAttacked() {
        health -= 3;
        if (health <= 0)
            Break();
    }

    public void GetFireBallAttacked() {
        health -= 2;
        if (health <= 0)
            Break();
    }
}