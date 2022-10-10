using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour, IDamageable
{
    float health = 100f;
    bool dead = false;
    public virtual bool ApplyDamage(DamageMessage damageMessage)
    {
        if (dead) return false; //죽은 상태면 데미지 안 입음

        health -= damageMessage.amount;

        if (health <= 0) Die_effect(gameObject);

        return true;
    }

    void Die()
    {
        gameObject.SetActive(false);
        dead = true;
    }

     void Die_effect(GameObject capsule)
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        Invoke("Die", 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
