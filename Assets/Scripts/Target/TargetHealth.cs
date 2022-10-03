using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour {
    public GameObject ExplosionFx;

    private float health = 100;

    private void Break() {
        Instantiate(ExplosionFx, transform.position, Quaternion.identity);
        GameManager.TargetDestroyed(gameObject);
        Destroy(gameObject);
    }

    public void GetNormalAttacked(float physicalDamage) {
        health -= 1 * physicalDamage;
        if (health <= 0)
            Break();
    }

    public void GetCriticalAttacked(float physicalDamage) {
        health -= 3 * physicalDamage;
        if (health <= 0)
            Break();
    }

    public void GetFireBallAttacked(float magicalDamage) {
        health -= 2 * magicalDamage;
        if (health <= 0)
            Break();
    }
}