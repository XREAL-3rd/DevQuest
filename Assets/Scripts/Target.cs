using System;
using UnityEngine;

//Target 용 script
public class Target : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;

    //생성되면 자신을 Game에 등록
    private void OnEnable()
    {
        health = maxHealth;
        Game.Instance.AddTarget(this);
    }

    //죽으면 자신을 Game에서 등록해제
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